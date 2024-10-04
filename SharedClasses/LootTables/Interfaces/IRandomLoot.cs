using VDFramework.RandomWrapper.Interface;

namespace VDFramework.LootTables.Interfaces
{
	/// <summary>
	/// Represents an object that returns random loot in some way using a <see cref="IRandomNumberGenerator"/>
	/// </summary>
	public interface IRandomLoot<out TLootType> : ILoot<TLootType>
	{
		/// <summary>
		/// Retrieves or calculates the loot and returns it
		/// </summary>
		TLootType GetLoot(IRandomNumberGenerator rng);
	}
}