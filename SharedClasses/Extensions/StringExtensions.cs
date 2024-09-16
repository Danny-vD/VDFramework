using System;
using System.Linq;

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