namespace VDFramework.Utility.DataTypes
{
	/// <summary>
	/// Provides utility functions specifically aimed at single precision floating-point numbers
	/// </summary>
	/// <seealso cref="DoubleUtil"/>
	public static class FloatUtil
	{
		/// <inheritdoc cref="DoubleUtil.AreClose(double, double)"/>
		public static bool AreClose(float lhs, float rhs)
		{
			return DoubleUtil.AreClose(lhs, rhs);
		}

		/// <inheritdoc cref="DoubleUtil.LessThan"/>
		public static bool LessThan(float lhs, float rhs)
		{
			return DoubleUtil.LessThan(lhs, rhs);
		}

		/// <inheritdoc cref="DoubleUtil.GreaterThan"/>
		public static bool GreaterThan(float lhs, float rhs)
		{
			return DoubleUtil.GreaterThan(lhs, rhs);
		}

		/// <inheritdoc cref="DoubleUtil.LesserThanOrClose(double, double)"/>
		/// <seealso cref="AreClose(float, float)"/>
		public static bool LesserThanOrClose(float lhs, float rhs)
		{
			return DoubleUtil.LesserThanOrClose(lhs, rhs);
		}
		
		/// <inheritdoc cref="DoubleUtil.LesserThanOrClose(double, double, out bool)"/>
		/// <seealso cref="AreClose(float, float)"/>
		public static bool LesserThanOrClose(float lhs, float rhs, out bool areClose)
		{
			return DoubleUtil.LesserThanOrClose(lhs, rhs, out areClose);
		}

		/// <inheritdoc cref="DoubleUtil.GreaterThanOrClose(double, double)"/>
		/// <seealso cref="AreClose(float,float)"/>
		public static bool GreaterThanOrClose(float lhs, float rhs)
		{
			return DoubleUtil.GreaterThanOrClose(lhs, rhs);
		}
		
		/// <inheritdoc cref="DoubleUtil.GreaterThanOrClose(double, double, out bool)"/>
		/// <seealso cref="AreClose(float,float)"/>
		public static bool GreaterThanOrClose(float lhs, float rhs, out bool areClose)
		{
			return DoubleUtil.GreaterThanOrClose(lhs, rhs, out areClose);
		}

		/// <inheritdoc cref="DoubleUtil.IsOne"/>
		public static bool IsOne(double value)
		{
			return DoubleUtil.IsOne(value);
		}

		/// <inheritdoc cref="DoubleUtil.IsZero"/>
		public static bool IsZero(double value)
		{
			return DoubleUtil.IsZero(value);
		}

		/// <inheritdoc cref="DoubleUtil.IsBetweenZeroAndOne"/>
		public static bool IsBetweenZeroAndOne(double value, bool zeroInclusive = true, bool oneInclusive = true)
		{
			return DoubleUtil.IsBetweenZeroAndOne(value, zeroInclusive, oneInclusive);
		}

		/// <summary>
		/// Rounds the given value to the nearest int
		/// </summary>
		public static int RoundToInt(float value)
		{
			if (value <= 0.0)
				return (int)(value - 0.5);

			return (int)(value + 0.5);
		}
	}
}