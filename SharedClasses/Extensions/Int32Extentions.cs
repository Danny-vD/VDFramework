namespace VDFramework.Extensions
{
	public static class Int32Extentions
	{
		/// <summary>
		/// Check every bit one by one to see if they are equal
		/// </summary>
		/// <returns>TRUE if at least one bit is equal</returns>
		public static bool HasOneMatchingBit(this int number, int toCheck, bool shouldCheckZero = false)
		{
			bool matchingBit = (number & toCheck) != 0;

			if (shouldCheckZero)
			{
				return matchingBit || HasOneMatchingBit(~number, ~toCheck);
			}

			return matchingBit;
		}

		public static void AddFlag(this ref int number, int flagToAdd)
		{
			number |= flagToAdd;
		}

		public static void RemoveFlag(this ref int number, int flagToRemove)
		{
			number &= ~flagToRemove;
		}
	}
}