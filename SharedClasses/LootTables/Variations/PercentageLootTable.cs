using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.LootTableItems;
using VDFramework.LootTables.Structs;
using VDFramework.Utility.MathUtility;

namespace VDFramework.LootTables.Variations
{
	public class PercentageLootTable<TLootType> : WeightedLootTable<TLootType>
	{
		private const int maximumNumberOfDecimalsForPercentage = 6;

		private readonly List<PercentageLootTablePair<TLootType>> internalPercentageLootTable = new List<PercentageLootTablePair<TLootType>>();

		public PercentageLootTable()
		{
		}
		
		public PercentageLootTable(IEnumerable<KeyValuePair<ILoot<TLootType>, float>> collection)
		{
			Add(collection);
		}
		
		public PercentageLootTable(IEnumerable<KeyValuePair<TLootType, float>> collection)
		{
			Add(collection);
		}

		public List<PercentageLootTablePair<TLootType>> GetPercentageLootList()
		{
			return new List<PercentageLootTablePair<TLootType>>(internalPercentageLootTable);
		}
		
		public new bool Contains(ILoot<TLootType> loot)
		{
			return internalPercentageLootTable.Any(pair => pair.Loot.Equals(loot));
		}
		
		public bool TryAdd(ILoot<TLootType> loot, float percentage)
		{
			if (Contains(loot))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // The internal collection changed, so next time we try to GetLoot() we should recalculate the weights
			
			internalPercentageLootTable.Add(new PercentageLootTablePair<TLootType>(loot, PercentageFloatToDecimal(percentage)));
			return true;
		}

		
		public void Add(IEnumerable<KeyValuePair<ILoot<TLootType>, float>> collection)
		{
			foreach (KeyValuePair<ILoot<TLootType>, float> pair in collection)
			{
				TryAdd(pair.Key, pair.Value);
			}
		}
		
		public void Add(IEnumerable<KeyValuePair<TLootType, float>> collection)
		{
			foreach (KeyValuePair<TLootType, float> pair in collection)
			{
				TryAdd(new LootTableItem<TLootType>(pair.Key), pair.Value);
			}
		}
		
		public bool TryRemove(PercentageLootTablePair<TLootType> pair)
		{
			if (!internalPercentageLootTable.Contains(pair))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights
			
			internalPercentageLootTable.Remove(pair);
			return true;
		}
		
		public bool TryRemove(ILoot<TLootType> loot)
		{
			if (!TryGetPair(loot, out PercentageLootTablePair<TLootType> pair))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights
			
			internalPercentageLootTable.Remove(pair);
			return true;
		}
		
		public bool TryRemove(TLootType loot)
		{
			return TryRemove(new LootTableItem<TLootType>(loot));
		}

		public override void ClearTable()
		{
			internalPercentageLootTable.Clear();
			base.ClearTable();
		}

		protected override int[] CalculateIndexArray()
		{
			lootTable.Clear();

			List<PercentageLootTablePair<TLootType>> percentageLootTable = EnsureValidPercentages();
			ConvertPercentagesToWeightAndAddToTable(percentageLootTable);

			return base.CalculateIndexArray();
		}
		
		/// <summary>
		/// Attempt to get the LootTablePair whose loot matches the given loot
		/// </summary>
		private bool TryGetPair(ILoot<TLootType> loot, out PercentageLootTablePair<TLootType> lootTablePair)
		{
			lootTablePair = default;
			
			foreach (PercentageLootTablePair<TLootType> pair in internalPercentageLootTable)
			{
				if (pair.Loot.Equals(loot))
				{
					lootTablePair = pair;
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Grab the first N percentages until we reached 100%, or increase the last percentage if the total is below 100%
		/// </summary>
		private List<PercentageLootTablePair<TLootType>> EnsureValidPercentages()
		{
			decimal totalPercentage = 0;

			List<PercentageLootTablePair<TLootType>> modifedList = new List<PercentageLootTablePair<TLootType>>();

			for (int i = 0; i < internalPercentageLootTable.Count; i++)
			{
				PercentageLootTablePair<TLootType> pair = internalPercentageLootTable[i];

				if (pair.Percentage < decimal.Zero) // Do not allow negative percentages
				{
					pair.Percentage = decimal.Zero;
				}
				else if (totalPercentage + pair.Percentage > decimal.One) // make sure we never exceed 100% by setting the percentage to the remainder towards 1
				{
					pair.Percentage = 1 - totalPercentage;
				}

				modifedList.Add(pair);
				totalPercentage += pair.Percentage;

				if (totalPercentage >= decimal.One) // If we reached 100% we can stop
				{
					break;
				}
			}

			if (totalPercentage < decimal.One)
			{
				decimal distanceTo1 = decimal.One - totalPercentage;

				int lastIndex = modifedList.Count - 1;

				PercentageLootTablePair<TLootType> lastPair = modifedList[lastIndex];
				lastPair.Percentage    += distanceTo1; // Increase the last % to make everything add up to 100%
				modifedList[lastIndex] =  lastPair;
			}

			return modifedList;
		}

		/// <summary>
		/// Convert percentages to weight and add them to the lootTable
		/// </summary>
		private void ConvertPercentagesToWeightAndAddToTable(List<PercentageLootTablePair<TLootType>> percentageLootTable)
		{
			long totalWeight = CalculateTotalWeight(percentageLootTable);

			if (totalWeight > int.MaxValue)
			{
				throw new OutOfMemoryException($"{totalWeight} is too big to contain in an array! Adjust the numbers of the percentages.");
			}

			for (int i = 0; i < percentageLootTable.Count; i++)
			{
				decimal percentage = percentageLootTable[i].Percentage;

				long weight = (long)(totalWeight * percentage);
				
				base.TryAdd(percentageLootTable[i].Loot, weight);
			}
		}

		private long CalculateTotalWeight(IEnumerable<PercentageLootTablePair<TLootType>> percentageLootTable)
		{
			IEnumerable<decimal> percentages = percentageLootTable.Select(pair => pair.Percentage);

			return NumberUtil.GetLeastCommonMultiple(percentages);
		}
		
		private static decimal PercentageFloatToDecimal(float percentage)
		{
			decimal decimalPercentage = new decimal(percentage) / 100;
			return decimal.Round(decimalPercentage, maximumNumberOfDecimalsForPercentage, MidpointRounding.AwayFromZero);
		}
	}
}