using System;
using System.Collections.Generic;
using VDFramework.LootTables.Interfaces;

namespace VDFramework.LootTables.Structs
{
	public struct PercentageLootTablePair<TLootType> : IEquatable<PercentageLootTablePair<TLootType>>
	{
		public readonly ILoot<TLootType> Loot;
		public decimal Percentage;

		public PercentageLootTablePair(ILoot<TLootType> loot, decimal percentage)
		{
			Loot       = loot;
			Percentage = percentage;
		}

		public static implicit operator KeyValuePair<ILoot<TLootType>, decimal>(PercentageLootTablePair<TLootType> lootTablePair)
		{
			return new KeyValuePair<ILoot<TLootType>, decimal>(lootTablePair.Loot, lootTablePair.Percentage);
		}

		public bool Equals(PercentageLootTablePair<TLootType> other)
		{
			return Loot != null && Loot.Equals(other.Loot);
		}

		public override bool Equals(object obj)
		{
			return obj is PercentageLootTablePair<TLootType> other && Equals(other);
		}

		public override int GetHashCode()
		{
			return Loot.GetHashCode();
		}
	}
}