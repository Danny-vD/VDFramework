using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for <see cref="System.String"/>
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Returns a new string where a space is inserted before each capital, skipping the first char
		/// </summary>
		public static string InsertSpaceBeforeCapitals(this string text)
		{
			string copyText = text;

			if (text.CountIsZeroOrOne())
			{
				return copyText;
			}

			for (int i = text.Length - 1; i >= 1; --i)
			{
				if (char.IsUpper(text[i]))
				{
					copyText = copyText.Insert(i, " ");
				}
			}

			return copyText;
		}
		
		/// <summary>
		/// Replaces all underscores in this string with a space
		/// </summary>
		public static string ReplaceUnderscoreWithSpace(this string text)
		{
			return text.Replace('_', ' ');
		}
		
		/// <summary>
		/// Returns a string with specified length where certain substrings will only count as 1 char
		/// </summary>
		/// <param name="desiredLength">The length that you want the returned string to be</param>
		/// <param name="addCharToEnd">In case the string is too short, add this character to get the desired length</param>
		/// <param name="countAs1Char">A collection of substrings that will only count as 1 char for the purposes of returning the desired length</param>
		/// <param name="string">The string whose length to enforce</param>
		public static string EnforceLength(this string @string, int desiredLength, char addCharToEnd = '_', IReadOnlyCollection<string> countAs1Char = null)
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
		/// Get all characters between two characters including the two characters (will not return correctly if another pair is nested within a pair)
		/// </summary>
		public static string[] GetCharsBetweenAandB(this string input, char a, char b, int startIndex = 0)
		{
			int count = input.CharCount(a);
			List<string> betweenCollection = new List<string>(2);

			int indexB = startIndex; // Make sure we start at startindex [[]]_

			for (int i = 0; i < count; i++)
			{
				int indexA = input.IndexOf(a, indexB);

				if (indexA < startIndex || indexB == input.Length - 1)
				{
					continue;
				}

				indexB = input.IndexOf(b, indexB + 1);

				if (indexB == -1) // not found
				{
					// No more B, so we can stop searching
					break;
				}

				string inBetween = input.Substring(indexA, indexB - indexA + 1);
				betweenCollection.Add(inBetween);
			}

			return betweenCollection.ToArray();
		}
		
		/// <summary>
		/// Get a count of how many times a specific character appears within the string
		/// </summary>
		public static int CharCount(this string input, char character)
		{
			return input.Count(c => c == character);
		}
		
		/// <summary>
		/// Get a count of how many times a specific string appears within the string
		/// </summary>
		public static int StringCount(this string input, string tofind, StringComparison stringComparison = StringComparison.Ordinal)
		{
			if (input.Length == 0 || tofind == null || tofind.Length == 0)
			{
				return 0;
			}
			
			int index = input.IndexOf(tofind, stringComparison);
			int count = 0;

			while (index != -1)
			{
				++count;
				index += tofind.Length;

				if (index == input.Length)
				{
					break;
				}
				
				index = input.IndexOf(tofind, index, stringComparison);
			}

			return count;
		}
	}
}