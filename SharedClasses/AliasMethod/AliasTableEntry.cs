using VDFramework.LootTables.Interfaces;

namespace VDFramework.AliasMethod
{
	/// <summary>
	/// An entry of an Alias table
	/// </summary>
	internal class AliasTableEntry<TType>
	{
		public readonly ILoot<TType> LowerSample;
		public readonly ILoot<TType> HigherSample;

		/// <summary>
		/// Value in the range of [0, 1) that is used to determine whether to use <see cref="LowerSample"/> or <see cref="HigherSample"/>
		/// </summary>
		public readonly double Threshold;

		public AliasTableEntry(ILoot<TType> lowerSample, ILoot<TType> higherSample, double threshold)
		{
			LowerSample    = lowerSample;
			HigherSample   = higherSample;
			Threshold = threshold;
		}
	}
}