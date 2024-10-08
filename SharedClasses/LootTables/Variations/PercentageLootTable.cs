﻿using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.LootTables.AliasMethod;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.LootTableItems;
using VDFramework.LootTables.Structs;
using VDFramework.Utility.MathUtility;

namespace VDFramework.LootTables.Variations
{
	public class PercentageLootTable<TLootType> : WeightedLootTable<TLootType>, IEnumerable<PercentageLootTablePair<TLootType>>
	{
		private const int maximumNumberOfDecimalsForPercentage = 6;

		private readonly List<PercentageLootTablePair<TLootType>> internalPercentageLootTable = new List<PercentageLootTablePair<TLootType>>();

		public PercentageLootTable()
		{
		}

		public PercentageLootTable(IEnumerable<KeyValuePair<ILoot<TLootType>, float>> collection)
		{
			TryAddCollection(collection);
		}

		public PercentageLootTable(IEnumerable<KeyValuePair<TLootType, float>> collection)
		{
			TryAddCollection(collection);
		}

		public List<PercentageLootTablePair<TLootType>> GetPercentageLootList()
		{
			return EnsureValidPercentages();
		}

		/// <inheritdoc />
		public override List<LootTablePair<TLootType>> GetLootList()
		{
			if (ShouldReconstructAliasTable)
			{
				// Add the correct values to the base.lootTable
				ConstructAliasTable();
			}

			return base.GetLootList();
		}
		
		public decimal GetLootPercentage(ILoot<TLootType> loot)
		{
			if (TryGetLootTablePair(loot, out PercentageLootTablePair<TLootType> pair, out _))
			{
				return pair.Percentage;
			}

			return 0;
		}
		
		public decimal GetLootPercentage(TLootType loot)
		{
			return GetLootPercentage(new LootTableItem<TLootType>(loot));
		}

		public new bool Contains(ILoot<TLootType> loot)
		{
			return internalPercentageLootTable.Any(pair => pair.Loot.Equals(loot));
		}
		
		public bool TryGetPair(TLootType loot, out PercentageLootTablePair<TLootType> pair)
		{
			return TryGetLootTablePair(new LootTableItem<TLootType>(loot), out pair, out _);
		}

		public bool TryGetPair(ILoot<TLootType> loot, out PercentageLootTablePair<TLootType> pair)
		{
			return TryGetLootTablePair(loot, out pair, out _);
		}
		
		public void SetPair(PercentageLootTablePair<TLootType> pair)
		{
			if (TryGetLootTablePair(pair.Loot, out PercentageLootTablePair<TLootType> _, out int index))
			{
				internalPercentageLootTable[index] = pair;
			}
			else
			{
				internalPercentageLootTable.Add(pair);
			}

			ShouldReconstructAliasTable = true;
		}
		
		public bool TryAdd(PercentageLootTablePair<TLootType> pair, bool overrideWeightIfAlreadyPresent = false)
		{
			if (TryGetLootTablePair(pair.Loot, out _, out int index))
			{
				if (overrideWeightIfAlreadyPresent)
				{
					internalPercentageLootTable[index] = pair;
					
					ShouldReconstructAliasTable = true;
				}

				return false;
			}

			InternalAdd(pair);

			return true;
		}

		public bool TryAdd(ILoot<TLootType> loot, float percentage, bool overridePercentageIfAlreadyPresent = false)
		{
			if (TryGetLootTablePair(loot, out PercentageLootTablePair<TLootType> pair, out int index))
			{
				if (overridePercentageIfAlreadyPresent)
				{
					pair.Percentage = PercentageFloatToDecimal(percentage);

					internalPercentageLootTable[index] = pair;
					
					ShouldReconstructAliasTable = true;
				}
				
				return false;
			}

			InternalAdd(loot, percentage);
			return true;
		}
		
		public bool TryAdd(TLootType loot, float percentage, bool overridePercentageIfAlreadyPresent = false)
		{
			return TryAdd(new LootTableItem<TLootType>(loot), percentage, overridePercentageIfAlreadyPresent);
		}

		public void TryAddCollection(IEnumerable<KeyValuePair<ILoot<TLootType>, float>> collection)
		{
			foreach (KeyValuePair<ILoot<TLootType>, float> pair in collection)
			{
				TryAdd(pair.Key, pair.Value);
			}
		}

		public void TryAddCollection(IEnumerable<KeyValuePair<TLootType, float>> collection)
		{
			foreach (KeyValuePair<TLootType, float> pair in collection)
			{
				TryAdd(new LootTableItem<TLootType>(pair.Key), pair.Value);
			}
		}

		public void SetPercentage(ILoot<TLootType> loot, float percentage)
		{
			if (TryGetLootTablePair(loot, out PercentageLootTablePair<TLootType> pair, out int index))
			{
				pair.Percentage = PercentageFloatToDecimal(percentage);

				internalPercentageLootTable[index] = pair;
				
				ShouldReconstructAliasTable = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights
			}
			else
			{
				InternalAdd(loot, percentage);
			}
		}

		public void SetPercentage(TLootType loot, float percentage)
		{
			SetPercentage(new LootTableItem<TLootType>(loot), percentage);
		}

		public bool TryRemove(PercentageLootTablePair<TLootType> pair)
		{
			if (!internalPercentageLootTable.Contains(pair))
			{
				return false;
			}

			ShouldReconstructAliasTable = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights

			internalPercentageLootTable.Remove(pair);
			return true;
		}

		public override bool TryRemove(ILoot<TLootType> loot)
		{
			if (!TryGetLootTablePair(loot, out _, out int index))
			{
				return false;
			}

			ShouldReconstructAliasTable = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights

			internalPercentageLootTable.RemoveAt(index);
			return true;
		}

		public override bool TryRemove(TLootType loot)
		{
			return TryRemove(new LootTableItem<TLootType>(loot));
		}

		public override void ClearTable()
		{
			internalPercentageLootTable.Clear();
			base.ClearTable();
		}

		protected override AliasTable<TLootType> ConstructAliasTable()
		{
			lootTable.Clear();

			List<PercentageLootTablePair<TLootType>> percentageLootTable = EnsureValidPercentages();
			ConvertPercentagesToWeightAndAddToTable(percentageLootTable);

			return base.ConstructAliasTable();
		}

		/// <summary>
		/// Attempt to get the LootTablePair whose loot matches the given loot
		/// </summary>
		private bool TryGetLootTablePair(ILoot<TLootType> loot, out PercentageLootTablePair<TLootType> lootTablePair, out int index)
		{
			for (index = 0; index < internalPercentageLootTable.Count; index++)
			{
				PercentageLootTablePair<TLootType> pair = internalPercentageLootTable[index];

				if (pair.Loot.Equals(loot))
				{
					lootTablePair = pair;
					return true;
				}
			}

			lootTablePair = default;
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

			if (totalPercentage < decimal.One) // Increase the last % to make everything adds up to 100%
			{
				decimal distanceTo1 = decimal.One - totalPercentage;

				int lastIndex = modifedList.Count - 1;

				PercentageLootTablePair<TLootType> lastPair = modifedList[lastIndex];
				lastPair.Percentage    += distanceTo1;
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

				base.InternalAdd(percentageLootTable[i].Loot, weight);
			}
		}

		private void InternalAdd(PercentageLootTablePair<TLootType> loot)
		{
			ShouldReconstructAliasTable = true; // The internal collection changed, so next time we try to GetLoot() we should recalculate the weights
			
			internalPercentageLootTable.Add(loot);
		}
		
		private void InternalAdd(ILoot<TLootType> loot, float percentage)
		{
			InternalAdd(new PercentageLootTablePair<TLootType>(loot, PercentageFloatToDecimal(percentage)));
		}

		private long CalculateTotalWeight(IEnumerable<PercentageLootTablePair<TLootType>> percentageLootTable)
		{
			IEnumerable<decimal> percentages = percentageLootTable.Select(pair => pair.Percentage);

			return NumberUtil.GetLeastCommonMultiple(percentages);
		}

		/// <summary>
		/// Converts a float percentage (0% - 100%) to a decimal percentage factor (0 - 1)
		/// </summary>
		private static decimal PercentageFloatToDecimal(float percentage)
		{
			decimal decimalPercentage = new decimal(percentage) / 100;
			return decimal.Round(decimalPercentage, maximumNumberOfDecimalsForPercentage, MidpointRounding.AwayFromZero);
		}

		/// <inheritdoc />
		public new IEnumerator<PercentageLootTablePair<TLootType>> GetEnumerator()
		{
			return internalPercentageLootTable.GetEnumerator();
		}
	}
}