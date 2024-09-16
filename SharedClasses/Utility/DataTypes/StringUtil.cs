using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDFramework.Utility.DataTypes
{
	/// <summary>
	/// Contains utility functions for the built-in <see cref="string"/> type
	/// </summary>
	public static class StringUtil
	{
		private const char escapeCharacter = '\\';
		
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
		
		/// <summary>
		/// Get the string between two given strings, optionally including the two strings
		/// </summary>
		public static string GetStringBetweenAandB(string input, string a, string b, int startIndex = 0, bool includeAandB = true)
		{
			int beginIndex = input.IndexOf(a, startIndex, StringComparison.InvariantCulture);

			if (beginIndex == -1) // No beginning found
			{
				return string.Empty;
			}

			int depth = 0; // Used to keep track of nested pairs

			int endIndex = -1;
			int searchIndex = beginIndex + a.Length;

			while (searchIndex < input.Length)
			{
				int pairEndIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

				if (pairEndIndex == -1) // No valid B remaining, return empty string
				{
					return string.Empty;
				}

				int count = pairEndIndex - searchIndex;
				int pairStartIndex = input.IndexOf(a, searchIndex, count, StringComparison.InvariantCulture);

				if (pairStartIndex != -1 && pairStartIndex < pairEndIndex) // Another A before the B
				{
					++depth;

					searchIndex = pairStartIndex + a.Length;
				}
				else // No As before B
				{
					if (depth == 0)
					{
						endIndex = pairEndIndex;
						break;
					}
					
					--depth;

					searchIndex = pairEndIndex + b.Length;
				}
			}

			if (includeAandB)
			{
				endIndex += b.Length; // Make sure the length calculation is 1 longer so it includes the last character
			}
			else
			{
				beginIndex += a.Length; // Make sure the length calculation is 1 shorter so it excludes the first character
			}

			int length = endIndex - beginIndex;

			if (length == 0) // If we cannot find the beginning, the end or if there's nothing in between, return an empty string
			{
				return string.Empty;
			}

			return input.Substring(beginIndex, length);
		}

		/// <summary>
		/// Get all characters between two characters, optionally including the two characters
		/// </summary>
		public static string GetStringBetweenAandB(string input, char a, char b, int startIndex = 0, bool ignoreEscaped = true, bool includeAandB = true)
		{
			int depth = -1; // Used to keep track of nested pairs

			bool isEscaped = false;

			int beginIndex = -1;
			int endIndex = -1;

			for (int i = startIndex; i < input.Length; i++)
			{
				char character = input[i];

				if (ignoreEscaped && isEscaped)
				{
					isEscaped = false;
					continue;
				}

				if (character == a)
				{
					++depth;

					if (depth == 0)
					{
						beginIndex = i;
					}
				}
				else if (character == b && beginIndex != -1) // Only care about the end of a pair if we found the beginning
				{
					if (depth == 0)
					{
						endIndex = i;
						break;
					}

					--depth;
				}
				else if (character == escapeCharacter)
				{
					isEscaped = true;
					continue;
				}
			}

			if (includeAandB)
			{
				endIndex += 1; // Make sure the length calculation is 1 longer so it includes the last character
			}
			else
			{
				beginIndex += 1; // Make sure the length calculation is 1 shorter so it excludes the first character
			}

			int length = endIndex - beginIndex;

			if (length == 0 || beginIndex == -1 || endIndex == -1) // If we cannot find the beginning, the end or if there's nothing in between, return an empty string
			{
				return string.Empty;
			}

			return input.Substring(beginIndex, length);
		}

		/// <summary>
		/// Get the strings between all pairs of two characters, optionally including the two characters
		/// </summary>
		public static List<string> GetStringsBetweenAandB(string input, char a, char b, int startIndex = 0, bool ignoreEscaped = true, bool includeAandB = true)
		{
			List<string> pairs = new List<string>();

			int searchIndex = input.IndexOf(a, startIndex);

			while (searchIndex != -1)
			{
				string pair = GetStringBetweenAandB(input, a, b, searchIndex, ignoreEscaped, includeAandB);

				if (!pair.Equals(string.Empty))
				{
					pairs.Add(pair);
				}

				searchIndex = input.IndexOf(a, searchIndex + 1);
			}

			return pairs;
		}

		/// <summary>
		/// Get the strings between all pairs of two strings, optionally including the two strings
		/// </summary>
		public static List<string> GetStringsBetweenAandB(string input, string a, string b, int startIndex = 0, bool includeAandB = true)
		{
			List<string> pairs = new List<string>();

			int searchIndex = input.IndexOf(a, startIndex, StringComparison.InvariantCulture);

			while (searchIndex != -1)
			{
				string pair = GetStringBetweenAandB(input, a, b, searchIndex, includeAandB);

				if (!pair.Equals(string.Empty))
				{
					pairs.Add(pair);
				}

				searchIndex = input.IndexOf(a, searchIndex + 1, StringComparison.InvariantCulture);
			}

			return pairs;
		}
	}
}