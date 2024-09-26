using System;
using System.Collections.Generic;
using VDFramework.LootTables.Interfaces;

namespace VDFramework.LootTables.Structs
{
	public struct PercentageLootTablePair<TLootType> : IEquatable<PercentageLootTablePair<TLootType>>, IComparable<PercentageLootTablePair<TLootType>>
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

		/// <inheritdoc />
		public bool Equals(PercentageLootTablePair<TLootType> other)
		{
			return Loot != null && Loot.Equals(other.Loot);
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return obj is PercentageLootTablePair<TLootType> other && Equals(other);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return Loot.GetHashCode();
		}

		/// <inheritdoc />
		public int CompareTo(PercentageLootTablePair<TLootType> other)
		{
			return Percentage.CompareTo(other.Percentage);
		}
	}
}