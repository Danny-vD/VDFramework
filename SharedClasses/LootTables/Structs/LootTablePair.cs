using System;
using System.Collections.Generic;
using VDFramework.LootTables.Interfaces;

namespace VDFramework.LootTables.Structs
{
	public struct LootTablePair<TLootType> : IEquatable<LootTablePair<TLootType>>, IComparable<LootTablePair<TLootType>>
	{
		public readonly ILoot<TLootType> Loot;
		public long Weight;

		public LootTablePair(ILoot<TLootType> loot, long weight)
		{
			Loot   = loot;
			Weight = weight;
		}

		public static implicit operator KeyValuePair<ILoot<TLootType>, long>(LootTablePair<TLootType> lootTablePair)
		{
			return new KeyValuePair<ILoot<TLootType>, long>(lootTablePair.Loot, lootTablePair.Weight);
		}

		public bool Equals(LootTablePair<TLootType> other)
		{
			return Loot != null && Loot.Equals(other.Loot);
		}

		public override bool Equals(object obj)
		{
			return obj is LootTablePair<TLootType> other && Equals(other);
		}

		public override int GetHashCode()
		{
			return Loot.GetHashCode();
		}

		public int CompareTo(LootTablePair<TLootType> other)
		{
			return Weight.CompareTo(other.Weight);
		}
	}
}