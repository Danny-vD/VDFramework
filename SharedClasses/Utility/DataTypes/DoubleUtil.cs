using System;
using System.Drawing;

namespace VDFramework.Utility.DataTypes
{
	/// <summary>
	/// Provides utility functions specifically aimed at double precision floating-point numbers
	/// </summary>
	public static class DoubleUtil
	{
		private const double doubleEpsilon = 2.22044604925031E-16;

		/// <summary>
		/// Tests whether the given values are very close to eachother (almost equal)
		/// </summary>
		/// <reference>https://stackoverflow.com/a/35418564</reference>
		public static bool AreClose(double lhs, double rhs)
		{
			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if (lhs == rhs)
			{
				return true;
			}

			double tolerance = (Math.Abs(lhs) + Math.Abs(rhs) + 10.0) * doubleEpsilon;

			double delta = lhs - rhs;

			if (delta > -tolerance)
			{
				return delta < tolerance;
			}

			return false;
		}

		/// <summary>
		/// Tests whether the left value is less than the right value (and not almost equal)
		/// </summary>
		public static bool LessThan(double lhs, double rhs)
		{
			if (lhs < rhs)
				return !AreClose(lhs, rhs);

			return false;
		}

		/// <summary>
		/// Tests whether the left value is greater than the right value (and not almost equal)
		/// </summary>
		public static bool GreaterThan(double lhs, double rhs)
		{
			if (lhs > rhs)
				return !AreClose(lhs, rhs);

			return false;
		}

		/// <summary>
		/// Tests whether the left value is less than or close to the right value
		/// </summary>
		/// <seealso cref="AreClose(double,double)"/>
		public static bool LesserThanOrClose(double lhs, double rhs)
		{
			if (lhs >= rhs) // Test for equality if the value is not lesser
			{
				return AreClose(lhs, rhs);
			}

			return true;
		}

		/// <summary>
		/// Tests whether the left value is less than or close to the right value.<br/>
		/// Returns whether or not the values are close as an out parameter
		/// </summary>
		/// <seealso cref="AreClose(double,double)"/>
		public static bool LesserThanOrClose(double lhs, double rhs, out bool areClose)
		{
			areClose = AreClose(lhs, rhs);

			if (areClose)
			{
				return true;
			}

			return lhs < rhs;
		}

		/// <summary>
		/// Tests whether the left value is greater than or close to the right value
		/// </summary>
		/// <seealso cref="AreClose(double,double)"/>
		public static bool GreaterThanOrClose(double lhs, double rhs)
		{
			if (lhs <= rhs) // Test for equality if the value is not greater
			{
				return AreClose(lhs, rhs);
			}

			return true;
		}

		/// <summary>
		/// Tests whether the left value is greater than or close to the right value.<br/>
		/// Returns whether or not the values are close as an out parameter
		/// </summary>
		/// <seealso cref="AreClose(double,double)"/>
		public static bool GreaterThanOrClose(double lhs, double rhs, out bool areClose)
		{
			areClose = AreClose(lhs, rhs);

			if (areClose)
			{
				return true;
			}

			return lhs > rhs;
		}

		/// <summary>
		/// Tests whether the given value is almost equal to 1
		/// </summary>
		public static bool IsOne(double value)
		{
			return Math.Abs(value - 1.0) < doubleEpsilon;
		}

		/// <summary>
		/// Tests whether the given value is almost equal to 0
		/// </summary>
		public static bool IsZero(double value)
		{
			return Math.Abs(value) < doubleEpsilon;
		}

		/// <summary>
		/// Tests whether the given points are almost equal
		/// </summary>
		public static bool AreClose(Point point1, Point point2)
		{
			if (AreClose(point1.X, point2.X))
				return AreClose(point1.Y, point2.Y);

			return false;
		}

		/// <summary>
		/// Tests whether the given sizes are almost equal
		/// </summary>
		public static bool AreClose(Size size1, Size size2)
		{
			if (AreClose(size1.Width, size2.Width))
				return AreClose(size1.Height, size2.Height);

			return false;
		}

		/// <summary>
		/// Tests whether the given value is between 0.0 and 1.0.<br/>
		/// Which bounds are inclusive and exclusive are set through the parameters
		/// </summary>
		public static bool IsBetweenZeroAndOne(double value, bool zeroInclusive = true, bool oneInclusive = true)
		{
			if (zeroInclusive ? GreaterThanOrClose(value, 0.0) : GreaterThan(value, 0.0))
			{
				return oneInclusive ? LesserThanOrClose(value, 1.0) : LessThan(value, 1.0);
			}

			return false;
		}

		/// <summary>
		/// Rounds the given value to the nearest int
		/// </summary>
		public static int RoundToInt(double value)
		{
			if (value <= 0.0)
				return (int)(value - 0.5);

			return (int)(value + 0.5);
		}
	}
}