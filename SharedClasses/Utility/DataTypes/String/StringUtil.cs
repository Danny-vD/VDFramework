using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VDFramework.Extensions;

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
		
		/// <summary>
		/// Tests if the string is not null and has any visible characters (non-format and non-whitespace)
		/// </summary>
		/// <returns><see langword="false"/> if the string is null or only contains whitespace and/or format characters</returns>
		public static bool HasVisibleCharacters(string value)
		{
			return value != null && value.Any(IsVisible);
		}
		
		/// <summary>
		/// Tests if the given character is visible (non-whitespace and not a format character)
		/// </summary>
		public static bool IsVisible(char character)
		{
			if (char.IsWhiteSpace(character))
			{
				return false;
			}

			return char.GetUnicodeCategory(character) != UnicodeCategory.Format; // Format characters are not whitespace (includes the zero-width space)
		}
		
		/// <summary>
		/// Converts the given string into a string that follows the Domain Name Notation rules
		/// </summary>
		/// <returns>The same string but only containing alphanumeric characters (A-Z, a-z, 0-9), hyphens (-) and periods (.)<br/>Characters with diacritics will be replaced by their regular version while any other character will be replaced by a hyphen</returns>
		/// <credits>https://stackoverflow.com/a/18577410</credits>
		public static string GetDNSNotation(string input)
		{
			string dnsString = input.RemoveDiacritics();

			return Regex.Replace(dnsString, "[^a-zA-Z0-9-.]+", "-"); // Regex matches: (non-) a-z A-Z 0-9 hyphen dot
		}
		
		/// <summary>
		/// Tests if the character is a alphanumeric character (A-Z, a-z, 0-9), hyphen (-) or period (.)
		/// </summary>
		public static bool IsAllowedInDNS(char character)
		{
			UnicodeCategory unicodeCategory = char.GetUnicodeCategory(character);

			if (unicodeCategory == UnicodeCategory.NonSpacingMark)
			{
				return false;
			}
			
			if (character == 45 || character == 46) // hyphen (-) or dot (.)
			{
				return true;
			}

			if (48 <= character && character <= 57) // digits (0-9)
			{
				return true;
			}
			
			if (65 <= character && character <= 90) // uppercase letters (A-Z)
			{
				return true;
			}
			
			if (97 <= character && character <= 122) // lowercase letters (a-z)
			{
				return true;
			}

			return false;
		}
	}
}