using System;
using System.Diagnostics;
using VDFramework.LootTables.Interfaces;

namespace VDFramework.LootTables.LootTableItems
{
	/// <summary>
	/// The simplest implementation of the <see cref="ILoot{TLootType}"/> interface
	/// </summary>
	[DebuggerDisplay("{loot.ToString()}")]
	public class LootTableItem<TLootType> : ILoot<TLootType>, IEquatable<LootTableItem<TLootType>>
	{
		private readonly TLootType loot;

		/// <summary>
		/// Creates a new instance of this class with the loot set to <paramref name="loot"/>
		/// </summary>
		public LootTableItem(TLootType loot)
		{
			this.loot = loot;
		}

		/// <inheritdoc/>
		public TLootType GetLoot()
		{
			return loot;
		}

		/// <inheritdoc/>
		public bool Equals(LootTableItem<TLootType> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return loot != null && loot.Equals(other.loot);
		}

		/// <inheritdoc/>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((LootTableItem<TLootType>)obj);
		}

		/// <inheritdoc/>
		public override int GetHashCode() => loot.GetHashCode();
	}
}