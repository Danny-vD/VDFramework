using System;
using System.Collections.Generic;
using VDFramework.LootTables.Interfaces;

namespace VDFramework.LootTables.Structs
{
	/// <summary>
	/// A simple struct that holds the weight per <see cref="ILoot{TLootType}"/>
	/// </summary>
	public struct LootTablePair<TLootType> : IEquatable<LootTablePair<TLootType>>, IComparable<LootTablePair<TLootType>>
	{
		/// <summary>
		/// The loot that is assigned to this pair
		/// </summary>
		public readonly ILoot<TLootType> Loot;
		
		/// <summary>
		/// The weight that is associated with the loot of this pair
		/// </summary>
		public long Weight;

		/// <summary>
		/// Create a new instance of this struct with the given loot and weight 
		/// </summary>
		public LootTablePair(ILoot<TLootType> loot, long weight)
		{
			Loot   = loot;
			Weight = weight;
		}

		/// <summary>
		/// Convert into a KeyValuePair with Key = Loot and Value = Weight
		/// </summary>
		public static implicit operator KeyValuePair<ILoot<TLootType>, long>(LootTablePair<TLootType> lootTablePair)
		{
			return new KeyValuePair<ILoot<TLootType>, long>(lootTablePair.Loot, lootTablePair.Weight);
		}

		/// <inheritdoc />
		public bool Equals(LootTablePair<TLootType> other)
		{
			return Loot != null && Loot.Equals(other.Loot);
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return obj is LootTablePair<TLootType> other && Equals(other);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return Loot.GetHashCode();
		}

		/// <inheritdoc />
		public int CompareTo(LootTablePair<TLootType> other)
		{
			return Weight.CompareTo(other.Weight);
		}
	}
}