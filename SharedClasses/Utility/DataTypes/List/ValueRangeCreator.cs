using System;
using System.Collections.Generic;

namespace VDFramework.Utility.DataTypes
{
	/// <summary>
	/// A helper class to easily create a list of values in a range
	/// </summary>
	public static class ValueRangeCreator
	{
		/// <summary>
		/// Creates a list of values in the range of &lt;<paramref name="fromZeroExclusive"/>, 0] or [0, <paramref name="fromZeroExclusive"/>&gt;
		/// </summary>
		/// <param name="fromZeroExclusive">A non-zero number that defines the range, this can be either negative or positive</param>
		public static List<int> CreateList(int fromZeroExclusive)
		{
			if (fromZeroExclusive < 0)
			{
				return CreateList(fromZeroExclusive + 1, 1);
			}

			return CreateList(0, fromZeroExclusive);
		}

		/// <summary>
		/// Creates a list of values in the range of [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>&gt;
		/// </summary>
		/// <param name="minInclusive">The lower bound of the range, the value itself will be inside the range</param>
		/// <param name="maxExclusive">The upper bound of the range, the value itself will fall outside of the range</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="minInclusive"/> cannot be higher than <paramref name="maxExclusive"/></exception>
		public static List<int> CreateList(int minInclusive, int maxExclusive)
		{
			if (minInclusive > maxExclusive)
			{
				throw new ArgumentOutOfRangeException(nameof(minInclusive), "Min value cannot be higher than max value!");
			}

			int length = maxExclusive - minInclusive;
			length = Math.Abs(length);

			List<int> values = new List<int>(length);

			for (int i = minInclusive; i < maxExclusive; i++)
			{
				values.Add(i);
			}

			return values;
		}
	}
}