using System.Collections;
using System.Collections.Generic;
using VDFramework.LootTables.AliasMethod;
using VDFramework.Extensions;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.LootTableItems;
using VDFramework.LootTables.Structs;
using VDFramework.RandomWrapper;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.LootTables
{
	/// <summary>
	/// A weighted loot table that allows you to grab an random element of type <typeparamref name="TLootType"/> with a probability based on the weight assigned to it.<br/>
	/// Internally the Alias-method is used for the sampling.
	/// </summary>
	/// <seealso cref="AliasTable{TType}"/>
	public class WeightedLootTable<TLootType> : ILoot<TLootType>, IEnumerable<LootTablePair<TLootType>>
	{
		/// <summary>
		/// The combined weight of every loot in the table
		/// </summary>
		public long TotalWeight
		{
			get
			{
				if (ShouldReconstructAliasTable)
				{
					ConstructAliasTable();
				}

				return aliasTable.TotalWeight;
			}
		}

		/// <summary>
		/// Whether or not the internal alias table should be reconstructed first when <see cref="GetLoot"/> is called
		/// </summary>
		protected bool ShouldReconstructAliasTable
		{
			get => !aliasTable.IsValid;
			set
			{
				if (value)
				{
					aliasTable.Clear();
				}
			}
		}

		/// <summary>
		/// The <see cref="IRandomNumberGenerator"/> implementation that should be used when getting a random value from the loot table.<br/>
		/// Will default to <see cref="SystemRandom"/> if not set.
		/// </summary>
		public IRandomNumberGenerator RandomNumberGenerator { get; private set; }

		/// <summary>
		/// The list of pairs that represents this loot table.<br/>
		/// Similar to Dictionary{ILoot{TLootType}, int}
		/// </summary>
		protected readonly List<LootTablePair<TLootType>> lootTable;

		private readonly AliasTable<TLootType> aliasTable;

		/// <summary>
		/// Creates a new instance of a weighted loot table with no loot
		/// </summary>
		public WeightedLootTable()
		{
			lootTable = new List<LootTablePair<TLootType>>();

			aliasTable = new AliasTable<TLootType>();
		}

		/// <summary>
		/// Creates a new instance of a weighted loot table with the given loot
		/// </summary>
		public WeightedLootTable(IEnumerable<KeyValuePair<TLootType, long>> collection) : this()
		{
			TryAddCollection(collection);
		}

		/// <summary>
		/// Creates a new instance of a weighted loot table with the given loot
		/// </summary>
		public WeightedLootTable(IEnumerable<KeyValuePair<ILoot<TLootType>, long>> collection) : this()
		{
			TryAddCollection(collection);
		}

		/// <summary>
		/// Returns a copy of the loot table as a list.
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

				ShouldReconstructAliasTable = true;
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

					ShouldReconstructAliasTable = true;
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

					ShouldReconstructAliasTable = true;
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

				ShouldReconstructAliasTable = true;
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

		public virtual bool TryRemove(ILoot<TLootType> loot)
		{
			if (!TryGetLootTablePair(loot, out _, out int index))
			{
				return false;
			}

			ShouldReconstructAliasTable = true; // The internal collection changed, so next time GetLoot() is called we should recalculate the weights

			lootTable.RemoveAt(index);
			return true;
		}

		public virtual bool TryRemove(TLootType loot)
		{
			return TryRemove(new LootTableItem<TLootType>(loot));
		}

		public virtual void ClearTable()
		{
			lootTable.Clear();
			ShouldReconstructAliasTable = true;
		}

		/// <summary>
		/// Grabs a random ILoot from the table based on the weights and returns it.<br/>
		/// Uses the <see cref="RandomNumberGenerator"/> or <see cref="SystemRandom"/> if that is null.
		/// </summary>
		public virtual TLootType GetLoot()
		{
			return GetAliasTable().Sample(RandomNumberGenerator).GetLoot();
		}

		/// <summary>
		/// Returns the internal alias table of this loot table<br/>
		/// The table will be constructed if <see cref="ShouldReconstructAliasTable"/> is true
		/// </summary>
		protected AliasTable<TLootType> GetAliasTable()
		{
			return ShouldReconstructAliasTable ? ConstructAliasTable() : aliasTable;
		}

		/// <summary>
		/// Calculate an array of indices from the Loot Table <br/>
		/// </summary>
		protected virtual AliasTable<TLootType> ConstructAliasTable()
		{
			aliasTable.Construct(lootTable); // The loot table is sorted because InternalAdd uses AddSorted

			return aliasTable;
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
			ShouldReconstructAliasTable = true; // Reset the indexArray because the totalWeight might have changed

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