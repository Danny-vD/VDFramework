using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;

namespace VDFramework.Utility.MathUtility
{
	/// <summary>
	/// Static class that contains functions for getting data about numbers
	/// </summary>
	public static class NumberUtil
	{
		/// <summary>
		/// Breaks down the given number into a numerator and a denominator and converts it to its simplest form
		/// </summary>
		public static void ToFraction(decimal number, out long numerator, out long denominator)
		{
			int decimalCount = number.GetDecimalCount();
			
			double factor = Math.Pow(10, decimalCount);

			numerator   = (long)(number * (decimal)factor);
			denominator = (long)factor;

			// convert to the simplest form
			long gcd = GetGreatestCommonDenominator(numerator, denominator);

			numerator   /= gcd;
			denominator /= gcd;
		}
		
		/// <summary>
		/// Breaks down the given number into a numerator and a denominator and converts it to its simplest form
		/// </summary>
		public static void ToFraction(double number, out long numerator, out long denominator, int maxDecimalCount = 6)
		{
			decimal decimalNumber = new decimal(number);

			if (maxDecimalCount > 0)
			{
				decimalNumber = decimal.Round(decimalNumber, maxDecimalCount);
			}
			
			ToFraction(decimalNumber, out numerator, out denominator);
		}
		
		/// <summary>
		/// Breaks down the given number into a numerator and a denominator and converts it to its simplest form
		/// </summary>
		public static void ToFraction(float number, out long numerator, out long denominator, int maxDecimalCount = 6)
		{
			decimal decimalNumber = new decimal(number);

			if (maxDecimalCount > 0)
			{
				decimalNumber = decimal.Round(decimalNumber, maxDecimalCount);
			}
			
			ToFraction(decimalNumber, out numerator, out denominator);
		}

		/// <summary>
		/// Returns the Least Common Multiple of the given floating point numbers
		/// </summary>
		/// <theory>
		/// <para>https://en.wikipedia.org/wiki/Euclidean_algorithm</para>
		/// <para>https://en.wikipedia.org/wiki/Least_common_multiple</para>
		/// </theory>
		public static long GetLeastCommonMultiple(IEnumerable<decimal> numbers)
		{
			long[] denominators = numbers.Select(number =>
			{
				ToFraction(number, out long numerator, out long denominator);
				return denominator;
			}).ToArray();

			return GetLeastCommonMultiple(denominators);
		}
		
		/// <summary>
		/// Returns the Least Common Multiple of the given floating point numbers
		/// </summary>
		/// <theory>
		/// <para>https://en.wikipedia.org/wiki/Euclidean_algorithm</para>
		/// <para>https://en.wikipedia.org/wiki/Least_common_multiple</para>
		/// </theory>
		public static long GetLeastCommonMultiple(IEnumerable<float> numbers, int maximumDecimalsInFloat = 4)
		{
			long[] denominators = numbers.Select(number =>
			{
				ToFraction(number, out long numerator, out long denominator, maximumDecimalsInFloat);
				return denominator;
			}).ToArray();

			return GetLeastCommonMultiple(denominators);
		}

		/// <summary>
		/// Returns the Least Common Multiple of the given numbers
		/// </summary>
		/// <credit>https://stackoverflow.com/questions/147515/least-common-multiple-for-3-or-more-numbers/29717490#29717490</credit>
		/// <theory>
		/// <para>https://en.wikipedia.org/wiki/Euclidean_algorithm</para>
		/// <para>https://en.wikipedia.org/wiki/Least_common_multiple</para>
		/// </theory>
		public static long GetLeastCommonMultiple(IEnumerable<long> numbers)
		{
			return numbers.Aggregate(GetLeastCommonMultiple);
		}

		/// <summary>
		/// Returns the Least Common Multiple of the given numbers
		/// </summary>
		/// <theory>
		/// <para>https://en.wikipedia.org/wiki/Euclidean_algorithm</para>
		/// <para>https://en.wikipedia.org/wiki/Least_common_multiple</para>
		/// </theory>
		public static long GetLeastCommonMultiple(long lhs, long rhs)
		{
			return Math.Abs(lhs * rhs) / GetGreatestCommonDenominator(lhs, rhs);
		}

		//TODO: Document (actually understand it!)
		public static long GetGreatestCommonDenominator(long lhs, long rhs)
		{
			return rhs == 0 ? lhs : GetGreatestCommonDenominator(rhs, lhs % rhs);
		}
	}
}