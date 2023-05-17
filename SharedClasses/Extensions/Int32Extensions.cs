namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for 32-bit integers (<see cref="System.Int32"/>)
	/// </summary>
	public static class Int32Extensions
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

		/// <summary>
		/// Add the given bitflag to this value
		/// </summary>
		public static void AddFlag(this ref int number, int flagToAdd)
		{
			number |= flagToAdd;
		}

		/// <summary>
		/// Remove the given bitflag from this value
		/// </summary>
		public static void RemoveFlag(this ref int number, int flagToRemove)
		{
			number &= ~flagToRemove;
		}

		/// <summary>
		/// <para>Returns the ordinal version of this number</para>
		/// <para>Only supports 0-16 at the moment, higher than that will return number.ToString</para>
		/// </summary>
		/// <param name="number">The number to ordinalise</param>
		/// <returns>A string that respresents the ordinal version of the given number (e.g. 3 -> "third")</returns>
		public static string Ordinalize(this int number)
		{
			return number switch
			{
				0 => "zeroth",
				1 => "first",
				2 => "second",
				3 => "third",
				4 => "fourth",
				5 => "fifth",
				6 => "sixth",
				7 => "seventh",
				8 => "eighth",
				9 => "ninth",
				10 => "tenth",
				11 => "eleventh",
				12 => "twelfth",
				13 => "thirteenth",
				14 => "fourteenth",
				15 => "fifteenth",
				16 => "sixteenth",
				_ => number.ToString(),
			};
		}
	}
}