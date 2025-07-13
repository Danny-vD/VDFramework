using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDFramework.Utility.DataTypes
{
	/// <summary>
	/// Contains utility functions for the built-in <see cref="string"/> type
	/// </summary>
	public static partial class StringUtil
	{
		/// <summary>
		/// Returns a string with specified length where certain substrings will only count as 1 char
		/// </summary>
		/// <param name="desiredLength">The length that you want the returned string to be</param>
		/// <param name="addCharToEnd">In case the string is too short, add character to get the desired length</param>
		/// <param name="countAs1Char">A collection of substrings that will only count as 1 char for the purposes of returning the desired length</param>
		/// <param name="string">The string whose length to enforce</param>
		public static string EnforceLength(string @string, int desiredLength, char addCharToEnd = '_', IReadOnlyCollection<string> countAs1Char = null)
		{
			int actualLength = @string.Length;

			if (countAs1Char != null && countAs1Char.Count > 0)
			{
				// actual length = string without special strings + 1 char for each special string
				int subtractLength = countAs1Char.Sum(s => s.Length) - countAs1Char.Count;
				actualLength -= subtractLength;
			}

			if (actualLength <= desiredLength)
			{
				while (actualLength < desiredLength)
				{
					@string += addCharToEnd;
					++actualLength;
				}

				return @string;
			}

			if (countAs1Char == null || countAs1Char.Count == 0 || !countAs1Char.Any(@string.Contains))
			{
				return @string.Substring(0, desiredLength);
			}

			List<string> specialStrings = countAs1Char.ToList();
			specialStrings.RemoveAll(substring => !@string.Contains(substring));

			StringBuilder stringBuilder = new StringBuilder(desiredLength);
			int currentLength = 0;

			int stringLength = @string.Length;

			for (int i = 0; i < stringLength; i++)
			{
				char letter = @string[i];

				bool addedSpecialString = false;

				foreach (string specialString in specialStrings.Where(specialString => specialString[0] == letter))
				{
					int specialStringLength = specialString.Length;

					if (i + specialStringLength >= stringLength)
					{
						continue;
					}

					string substring = @string.Substring(i, specialStringLength);

					if (substring == specialString)
					{
						stringBuilder.Append(substring);
						addedSpecialString = true;

						i += specialStringLength - 1;
						break;
					}
				}

				if (!addedSpecialString)
				{
					stringBuilder.Append(letter);
				}

				if (++currentLength == desiredLength)
				{
					break;
				}
			}

			return stringBuilder.ToString();
		}
	}
}