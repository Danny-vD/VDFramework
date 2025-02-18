using System;

namespace VDFramework.Utility.MathUtility
{
	/// <summary>
	/// Contains constants used for mathematical operations
	/// </summary>
	public static class MathConstants
	{
		/// <summary>
		/// The constant 1/3
		/// </summary>
		public const double THIRD = 0.3333333333333333D;

		/// <summary>
		/// The 'extreme and mean ratio' or 'divine proportion' calculated as<br/>(1 + √5) / 2<br/>1.618033988749...
		/// </summary>
		/// <symbol>φ (phi)</symbol>
		/// <theory>https://en.wikipedia.org/wiki/Golden_ratio#Calculation</theory>
		public static readonly double GoldenRatio = (1 + Math.Sqrt(5)) / 2;
	}
}