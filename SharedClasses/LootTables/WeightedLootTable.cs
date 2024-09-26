using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.LootTableItems;
using VDFramework.LootTables.Structs;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.LootTables
{
	public class WeightedLootTable<TLootType> : ILoot<TLootType>, IEnumerable<LootTablePair<TLootType>>
	{
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

		// Similar to Dictionary<ILoot<TLootType>, int>
		protected readonly List<LootTablePair<TLootType>> lootTable;

		private int[] indexArray;

		public WeightedLootTable()
		{
			lootTable = new List<LootTablePair<TLootType>>();
		}

		public WeightedLootTable(IEnumerable<KeyValuePair<TLootType, long>> collection) : this()
		{
			TryAddCollection(collection);
		}

		public WeightedLootTable(IEnumerable<KeyValuePair<ILoot<TLootType>, long>> collection) : this()
		{
			TryAddCollection(collection);
		}

		/// <summary>
		/// Returns a copy of the loot table as a list
		/// </summary>
		public virtual List<LootTablePair<TLootType>> GetLootList()
		{
			return new List<LootTablePair<TLootType>>(lootTable);
		}

		public decimal GetLootDropChance(ILoot<TLootType> loot)
		{
			return GetLootWeight(loot) / (decimal)TotalWeight;
		}
		
		public decimal GetLootDropChance(TLootType loot)
		{
			return GetLootWeight(loot);
		}
		
		public long GetLootWeight(ILoot<TLootType> loot)
		{
			if (TryGetLootTablePair(loot, out LootTablePair<TLootType> pair, out _))
			{
				return pair.Weight;
			}

			return 0;
		}
		
		public long GetLootWeight(TLootType loot)
		{
			return GetLootWeight(new LootTableItem<TLootType>(loot));
		}

		public bool Contains(ILoot<TLootType> loot)
		{
			return TryGetLootTablePair(loot, out _, out _);
		}
		
		public bool TryGetPair(TLootType loot, out LootTablePair<TLootType> pair)
		{
			return TryGetLootTablePair(new LootTableItem<TLootType>(loot), out pair, out _);
		}
		
		public bool TryGetPair(ILoot<TLootType> loot, out LootTablePair<TLootType> pair)
		{
			return TryGetLootTablePair(loot, out pair, out _);
		}
		
		public void SetPair(LootTablePair<TLootType> pair)
		{
			if (TryGetLootTablePair(pair.Loot, out LootTablePair<TLootType> _, out int index))
			{
				lootTable[index] = pair;
				
				ShouldRecalculateIndices = true;
			}
			else
			{
				InternalAdd(pair);
			}
		}

		public bool TryAdd(LootTablePair<TLootType> pair, bool overrideWeightIfAlreadyPresent = false)
		{
			if (TryGetLootTablePair(pair.Loot, out _, out int index))
			{
				if (overrideWeightIfAlreadyPresent)
				{
					lootTable[index] = pair;
					
					ShouldRecalculateIndices = true;
				}

				return false;
			}
			
			InternalAdd(pair);

			return true;
		}

		public bool TryAdd(ILoot<TLootType> loot, long weight, bool overrideWeightIfAlreadyPresent = false)
		{
			if (TryGetLootTablePair(loot, out LootTablePair<TLootType> pair, out int index))
			{
				if (overrideWeightIfAlreadyPresent)
				{
					pair.Weight = weight;

					lootTable[index] = pair;
					
					ShouldRecalculateIndices = true;
				}

				return false;
			}

			InternalAdd(loot, weight);
			return true;
		}

		public bool TryAdd(TLootType loot, long weight, bool overrideWeightIfAlreadyPresent = false)
		{
			return TryAdd(new LootTableItem<TLootType>(loot), weight, overrideWeightIfAlreadyPresent);
		}

		public void TryAddCollection(IEnumerable<KeyValuePair<ILoot<TLootType>, long>> collection)
		{
			foreach (KeyValuePair<ILoot<TLootType>, long> pair in collection)
			{
				TryAdd(pair.Key, pair.Value);
			}
		}

		public void TryAddCollection(IEnumerable<KeyValuePair<TLootType, long>> collection)
		{
			foreach (KeyValuePair<TLootType, long> pair in collection)
			{
				TryAdd(new LootTableItem<TLootType>(pair.Key), pair.Value);
			}
		}

		public void SetWeight(ILoot<TLootType> loot, long weight)
		{
			if (TryGetLootTablePair(loot, out LootTablePair<TLootType> pair, out int index))
			{
				pair.Weight = weight;

				lootTable[index] = pair;
				
				ShouldRecalculateIndices = true;
			}
			else
			{
				InternalAdd(loot, weight);
			}
		}

		public void SetWeight(TLootType loot, long weight)
		{
			SetWeight(new LootTableItem<TLootType>(loot), weight);
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
			if (!TryGetLootTablePair(loot, out _, out int index))
			{
				return false;
			}

			ShouldRecalculateIndices = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights

			lootTable.RemoveAt(index);
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

		/// <summary>
		/// Grabs a random ILoot from the table based on the weights and returns it.<br/>
		/// Uses <see cref="System.Random">System.Random</see>
		/// </summary>
		public virtual TLootType GetLoot()
		{
			int index = GetIndexArray().GetRandomElement();
			return lootTable[index].Loot.GetLoot();
		}

		/// <summary>
		/// Grabs a random ILoot from the table based on the weights and returns it
		/// </summary>
		public virtual TLootType GetLoot(IRandomNumberGenerator rng)
		{
			int index = GetIndexArray().GetRandomElement(rng);
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
		/// Calculate an array of indices from the Loot Table <br/>
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

		protected bool TryGetLootTablePair(ILoot<TLootType> loot, out LootTablePair<TLootType> lootTablePair, out int index)
		{
			for (index = 0; index < lootTable.Count; index++)
			{
				LootTablePair<TLootType> pair = lootTable[index];

				if (pair.Loot.Equals(loot))
				{
					lootTablePair = pair;
					return true;
				}
			}

			lootTablePair = default;
			return false;
		}
		
		protected void InternalAdd(LootTablePair<TLootType> loot)
		{
			ShouldRecalculateIndices = true; // Reset the indexArray because the totalWeight might have changed
			
			lootTable.AddSorted(loot);
		}
		
		protected void InternalAdd(ILoot<TLootType> loot, long weight)
		{
			InternalAdd(new LootTablePair<TLootType>(loot, weight));
		}

		/// <inheritdoc />
		public IEnumerator<LootTablePair<TLootType>> GetEnumerator()
		{
			return lootTable.GetEnumerator();
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}