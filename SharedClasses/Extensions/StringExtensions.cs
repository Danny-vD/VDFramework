using System;
using System.Globalization;
using System.Linq;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for <see cref="System.String"/>
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Captalises the first character in the string
		/// </summary>
		/// <param name="input">The string to capitalise</param>
		/// <returns>The given string, with the first character capitalised</returns>
		/// <exception cref="ArgumentException"><paramref name="input"/> is null or empty</exception>
		public static string CapitaliseFirstCharacter(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentException("Invalid string!");
			}

			char[] chars = input.ToCharArray();
			chars[0] = char.ToUpperInvariant(chars[0]);

			return new string(chars);
		}

		/// <summary>
		/// Captalises the first character in the string
		/// </summary>
		/// <param name="input">The string to capitalise</param>
		/// <returns>The given string, with the first character capitalised</returns>
		/// <exception cref="ArgumentException"><paramref name="input"/> is null or empty</exception>
		public static string CapitaliseFirstLetter(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentException("Invalid string!");
			}

			char[] characters = input.ToCharArray();

			for (int i = 0; i < characters.Length; i++)
			{
				char character = characters[i];

				if (!char.IsLetter(character))
				{
					continue;
				}

				characters[i]        = char.ToUpperInvariant(character);
				break;
			}

			return new string(characters);
		}

		/// <summary>
		/// Capitalises the first letter of every word
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string CapitaliseEveryWord(this string input)
		{
			char[] characters = input.ToCharArray();

			bool capitaliseNextLetter = true; // First letter should be capitalised;

			const char space = ' ';

			for (int i = 0; i < characters.Length; i++)
			{
				char character = characters[i];

				if (capitaliseNextLetter)
				{
					if (!char.IsLetter(character))
					{
						continue;
					}

					characters[i]        = char.ToUpperInvariant(character);
					capitaliseNextLetter = false;
				}
				else if (character.Equals(space))
				{
					capitaliseNextLetter = true;
				}
			}

			return new string(characters);
		}

		/// <summary>
		/// Returns a new string where a space is inserted before each capital, skipping the first char
		/// </summary>
		public static string InsertSpaceBeforeCapitals(this string input)
		{
			string copyText = input;
			char[] characters = copyText.ToCharArray();

			if (characters.CountIsZeroOrOne())
			{
				return copyText;
			}

			for (int i = characters.Length - 1; i >= 1; --i)
			{
				if (char.IsUpper(characters[i]))
				{
					copyText = copyText.Insert(i, " ");
				}
			}

			return copyText;
		}

		/// <summary>
		/// Replaces all underscores in this string with a space
		/// </summary>
		public static string ReplaceUnderscoreWithSpace(this string input)
		{
			return input.Replace('_', ' ');
		}

		/// <summary>
		/// Get a count of how many times a specific character appears within the string
		/// </summary>
		public static int CharCount(this string input, char character)
		{
			return input.Count(c => c == character);
		}

		/// <summary>
		/// Get a count of how many times a specific character appears within the string up to a given index
		/// </summary>
		public static int CharCount(this string input, char character, int maxIndex)
		{
			int count = 0;

			int length = Math.Min(input.Length, maxIndex);

			for (int i = 0; i < length; i++)
			{
				char c = input[i];

				if (c.Equals(character))
				{
					++count;
				}
			}

			return count;
		}

		/// <summary>
		/// Get a count of how many times a specific character appears within the string up to a given index
		/// </summary>
		public static int CharCount(this string input, char character, int startIndex, int maxIndex)
		{
			int count = 0;

			int length = Math.Min(input.Length, maxIndex);

			for (int i = startIndex; i < length; i++)
			{
				char c = input[i];

				if (c.Equals(character))
				{
					++count;
				}
			}

			return count;
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