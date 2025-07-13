using System.Collections.Generic;
using VDFramework.Extensions;
using VDFramework.RandomWrapper.Interface;
using VDFramework.Utility.DataTypes;

namespace VDFramework.Utility.RandomUtility
{
	/// <summary>
	/// A helper class to return a random integer in a given range while ignoring the last value that was returned
	/// </summary>
	public class RandomRangeHelper
	{
		private List<int> range;

		private int previousIndex = -1;
		
		/// <summary>
		/// Use values in the range of &lt;<paramref name="fromZeroExclusive"/>, 0] or [0, <paramref name="fromZeroExclusive"/>&gt;
		/// </summary>
		/// <param name="fromZeroExclusive">A non-zero number that defines the range, this can be either negative or positive</param>
		public RandomRangeHelper(int fromZeroExclusive)
		{
			SetRange(fromZeroExclusive);
		}

		/// <summary>
		/// Use values in the range of [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>&gt;
		/// </summary>
		/// <param name="minInclusive">The lower bound of the range, the value itself will be inside the range</param>
		/// <param name="maxExclusive">The upper bound of the range, the value itself will fall outside of the range</param>
		public RandomRangeHelper(int minInclusive, int maxExclusive)
		{
			SetRange(minInclusive, maxExclusive);
		}
		
		/// <summary>
		/// Use values in the range of &lt;<paramref name="fromZeroExclusive"/>, 0] or [0, <paramref name="fromZeroExclusive"/>&gt;
		/// </summary>
		/// <param name="fromZeroExclusive">A non-zero number that defines the range, this can be either negative or positive</param>
		public void SetRange(int fromZeroExclusive)
		{
			range         = ValueRangeCreator.CreateList(fromZeroExclusive);
			previousIndex = -1;
		}
		
		/// <summary>
		/// Use values in the range of [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>&gt;
		/// </summary>
		/// <param name="minInclusive">The lower bound of the range, the value itself will be inside the range</param>
		/// <param name="maxExclusive">The upper bound of the range, the value itself will fall outside of the range</param>
		public void SetRange(int minInclusive, int maxExclusive)
		{
			range         = ValueRangeCreator.CreateList(minInclusive, maxExclusive);
			previousIndex = -1;
		}

		/// <summary>
		/// Returns a random value in the given range, but not the value that was returned the last time this class returned a value
		/// </summary>
		public void GetRandomValueIgnorePrevious()
		{
			range.GetRandomElement(out previousIndex, previousIndex);
		}
		
		/// <summary>
		/// Returns a random value in the given range
		/// </summary>
		public void GetRandomValue()
		{
			range.GetRandomElement(out previousIndex);
		}

		/// <summary>
		/// Returns a random value in the given range, but not the value that was returned the last time this class returned a value
		/// </summary>
		/// <param name="rng">The random number generator to use</param>
		public void GetRandomValueIgnorePrevious(IRandomNumberGenerator rng)
		{
			range.GetRandomElement(rng, out previousIndex, previousIndex);
		}
		
		/// <summary>
		/// Returns a random value in the given range
		/// </summary>
		/// <param name="rng">The random number generator to use</param>
		public void GetRandomValue(IRandomNumberGenerator rng)
		{
			range.GetRandomElement(rng, out previousIndex);
		}
	}
}