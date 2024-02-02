using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.LootTableItems;
using VDFramework.LootTables.Structs;

namespace VDFramework.LootTables
{
	public class WeightedLootTable<TLootType> : ILoot<TLootType>
	{
		protected bool ShouldRecalculateIndices
		{
			get => indexArray == null;
			set
			{
				if (value)
				{
					indexArray = null;
				}
			}
		}

		private long totalWeight;

		public long TotalWeight
		{
			get
			{
				if (ShouldRecalculateIndices)
				{
					CalculateIndexArray();
				}

				return totalWeight;
			}
		}

		// Similar to Dictionary<ILoot<TLootType>, int>
		protected readonly List<LootTablePair<TLootType>> lootTable;

		private int[] indexArray;

		public WeightedLootTable()
		{
			lootTable = new List<LootTablePair<TLootType>>();
		}

		public WeightedLootTable(IEnumerable<KeyValuePair<TLootType, long>> collection) : this()
		{
			Add(collection);
		}
		
		public WeightedLootTable(IEnumerable<KeyValuePair<ILoot<TLootType>, long>> collection) : this()
		{
			Add(collection);
		}

		public decimal GetLootDropChance(ILoot<TLootType> loot)
		{
			return GetLootWeight(loot) / (decimal)TotalWeight;
		}

		public long GetLootWeight(ILoot<TLootType> loot)
		{
			if (TryGetLootTablePair(loot, out LootTablePair<TLootType> pair))
			{
				return pair.Weight;
			}

			return 0;
		}

		public bool Contains(ILoot<TLootType> loot)
		{
			return TryGetLootTablePair(loot, out _);
		}

		public bool TryAdd(ILoot<TLootType> loot, long weight)
		{
			if (Contains(loot))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // Reset the indexArray because the totalWeight might have changed

			lootTable.Add(new LootTablePair<TLootType>(loot, weight));
			return true;
		}
		
		public void Add(IEnumerable<KeyValuePair<ILoot<TLootType>, long>> collection)
		{
			foreach (KeyValuePair<ILoot<TLootType>, long> pair in collection)
			{
				TryAdd(pair.Key, pair.Value);
			}
		}

		public void Add(IEnumerable<KeyValuePair<TLootType, long>> collection)
		{
			foreach (KeyValuePair<TLootType, long> pair in collection)
			{
				TryAdd(new LootTableItem<TLootType>(pair.Key), pair.Value);
			}
		}

		public bool TryRemove(LootTablePair<TLootType> pair)
		{
			if (!lootTable.Contains(pair))
			{
				return false;
			}

			lootTable.Remove(pair);
			return true;
		}

		public bool TryRemove(ILoot<TLootType> loot)
		{
			if (!TryGetLootTablePair(loot, out LootTablePair<TLootType> pair))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights

			lootTable.Remove(pair);
			return true;
		}
		
		public bool TryRemove(TLootType loot)
		{
			return TryRemove(new LootTableItem<TLootType>(loot));
		}

		public virtual void ClearTable()
		{
			lootTable.Clear();
			ShouldRecalculateIndices = true;
		}

		public virtual TLootType GetLoot()
		{
			int index = GetIndexArray().GetRandomElement();
			return lootTable[index].Loot.GetLoot();
		}

		protected int[] GetIndexArray()
		{
			if (!ShouldRecalculateIndices)
			{
				return indexArray;
			}

			return CalculateIndexArray();
		}

		/// <summary>
		/// <para>Calculate an array of indices from the Loot Table</para>
		/// <para>The amount of duplicate values is dependent on the weight</para>
		/// </summary>
		protected virtual int[] CalculateIndexArray()
		{
			totalWeight = lootTable.Sum(pair => pair.Weight > 0 ? pair.Weight : 0);

			indexArray = new int[totalWeight];
			int totalIndex = 0;

			for (int lootTableIndex = 0; lootTableIndex < lootTable.Count; lootTableIndex++)
			{
				long weight = lootTable[lootTableIndex].Weight;

				if (weight <= 0) // Ignore weights below 0
				{
					continue;
				}

				// No new interator variable, length equals where we were + weight
				for (long length = totalIndex + weight; totalIndex < length; totalIndex++)
				{
					indexArray[totalIndex] = lootTableIndex;
				}
			}

			return indexArray;
		}

		protected bool TryGetLootTablePair(ILoot<TLootType> loot, out LootTablePair<TLootType> lootTablePair)
		{
			foreach (LootTablePair<TLootType> pair in lootTable)
			{
				if (pair.Loot.Equals(loot))
				{
					lootTablePair = pair;
					return true;
				}
			}

			lootTablePair = default;
			return false;
		}
	}
}