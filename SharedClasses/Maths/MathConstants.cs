using System;

namespace VDFramework.Maths
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
		
		/// <summary>
		/// The square root of 0.5
		/// </summary>
		public const float SQRT_HALF = 0.70710678118654752440084436210485f; // Mathf.Sqrt(0.5f);
	}
}