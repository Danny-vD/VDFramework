using System;
using System.Numerics;

namespace VDFramework.Utility.MathUtility
{
	/// <summary>
	/// Provides implementations of mathematical functions
	/// </summary>
	public static class MathFunctions
	{
		/// <summary>
		/// Returns the cubic root of the given value
		/// </summary>
		/// <math>³√x</math>
		public static double CubicRoot(double value)
		{
			return Math.Cbrt(value);
		}
		
		/// <summary>
		/// Returns the cubic root of the given complex number
		/// </summary>
		/// <math>³√x</math>
		public static Complex CubicRoot(Complex value)
		{
			return Complex.Pow(value, MathConstants.THIRD);
		}
	}
}