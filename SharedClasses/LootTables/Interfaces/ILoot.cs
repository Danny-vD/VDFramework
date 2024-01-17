namespace VDFramework.LootTables.Interfaces
{
	/// <summary>
	/// Represents an object that returns loot in some way
	/// </summary>
	public interface ILoot<out TLootType>
	{
		/// <summary>
		/// Retrieves or calculates the loot and returns it
		/// </summary>
		TLootType GetLoot();
	}
}