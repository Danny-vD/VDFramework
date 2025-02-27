using System;
using System.Collections.Generic;

namespace VDFramework.Utility.DataTypes
{
	public static partial class StringUtil
	{
		/// <summary>
		/// The backslash character '\'
		/// </summary>
		private const char escapeCharacter = '\\';

		/// <summary>
		/// Tests how 'deep' the given index is determined by nested pairs of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The string that represents the opening of a pair</param>
		/// <param name="b">The string that represents the closing of a pair</param>
		/// <param name="lookupIndex">The index to check the depth (nested-ness) for</param>
		/// <returns>The depth of the given index<br/>0 means it is not within any pair (or no pair could be found)</returns>
		public static int GetDepthAtIndex(string input, string a, string b, int lookupIndex)
		{
			int pairOpenIndex = input.IndexOf(a, StringComparison.InvariantCulture);

			if (pairOpenIndex == -1 || lookupIndex < pairOpenIndex) // No beginning found so no pairs can be made or the requested index is before the first pair would be opened
			{
				return 0;
			}

			int pairCloseIndex = input.LastIndexOf(b, StringComparison.InvariantCulture);

			if (pairCloseIndex == -1 || pairCloseIndex <= pairOpenIndex || lookupIndex > pairCloseIndex) // No ending found so no pairs can be made or the requested index is after the last pair would be closed
			{
				return 0;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();
			openingPairIndices.Push(pairOpenIndex);

			int depthAtIndex = 0;

			int searchIndex = pairOpenIndex + a.Length; // Search index represents the index after which to look for the next opening/closing of the pair

			while (searchIndex < input.Length)
			{
				pairCloseIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

				if (pairCloseIndex == -1) // No valid B remaining, so it is impossible to finish any other pairs, therfore, we can return early
				{
					break;
				}

				int count = pairCloseIndex - searchIndex;
				pairOpenIndex = input.IndexOf(a, searchIndex, count, StringComparison.InvariantCulture);

				if (pairOpenIndex != -1 && pairOpenIndex < pairCloseIndex) // Another A before the B | Because of count it should always be before, but the check is there just to be sure
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							if (openingIndex <= lookupIndex && lookupIndex <= pairOpenIndex) // If the requested index is within the range of the pair
							{
								return 1; // always depth 1 because nesting is impossible if a and b are equal
							}
						}
					}

					openingPairIndices.Push(pairOpenIndex);

					searchIndex = pairOpenIndex + a.Length;
				}
				else // No As before B
				{
					int depth = openingPairIndices.Count;
					int openIndex = openingPairIndices.Pop();

					if (openIndex <= lookupIndex && lookupIndex <= pairCloseIndex) // If the requested index is within the range of the pair
					{
						++depthAtIndex; // Simply increase it, any parent pairs would increase it more and therefore calculate the depth correctly
					}

					searchIndex = pairCloseIndex + b.Length;

					if (depth == 1) // Closing brace would put depth to 0, so we can jump ahead to the next start of a pair
					{
						pairOpenIndex = input.IndexOf(a, searchIndex, StringComparison.InvariantCulture);

						if (pairOpenIndex == -1) // No valid A remaining, return the pairs we found so far
						{
							break;
						}

						openingPairIndices.Push(pairOpenIndex);

						searchIndex = pairOpenIndex + a.Length;
					}
				}
			}

			return depthAtIndex;
		}

		/// <summary>
		/// Find all matching pairs of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The string that represents the opening of a pair</param>
		/// <param name="b">The string that represents the closing of a pair</param>
		/// <returns>
		/// A list of tuples that represent: (OpeningIndex, ClosingIndex, Depth)<br/>
		/// with Depth=1 meaning it is not nested within another pair
		/// </returns>
		public static List<Tuple<int, int, int>> GetMatchingPairs(string input, string a, string b)
		{
			// Tuple: index opening, index close, depth
			List<Tuple<int, int, int>> matchingPairs = new List<Tuple<int, int, int>>();

			int pairOpenIndex = input.IndexOf(a, StringComparison.InvariantCulture);

			if (pairOpenIndex == -1) // No beginning found so no pair can be made
			{
				return matchingPairs;
			}

			int searchIndex = pairOpenIndex + a.Length;
			int pairCloseIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

			if (pairCloseIndex == -1) // No ending found so no pair can be made
			{
				return matchingPairs;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();
			openingPairIndices.Push(pairOpenIndex);

			while (searchIndex < input.Length)
			{
				pairCloseIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

				if (pairCloseIndex == -1) // No valid B remaining, return the pairs we found so far
				{
					break;
				}

				int count = pairCloseIndex - searchIndex;
				pairOpenIndex = input.IndexOf(a, searchIndex, count, StringComparison.InvariantCulture);

				if (pairOpenIndex != -1 && pairOpenIndex < pairCloseIndex) // Another A before the B | Because of count it should always be before, but the check is there just to be sure
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							matchingPairs.Add(new Tuple<int, int, int>(openingIndex, pairOpenIndex, 1)); // If opening and closing are equal, everything is depth 1 because nesting is impossible

							pairOpenIndex = input.IndexOf(a, searchIndex, StringComparison.InvariantCulture);

							if (pairOpenIndex == -1) // No valid A remaining, return the pairs we found so far
							{
								break;
							}

							openingPairIndices.Push(pairOpenIndex);

							searchIndex = pairOpenIndex + a.Length;
							continue;
						}
					}

					openingPairIndices.Push(pairOpenIndex);

					searchIndex = pairOpenIndex + a.Length;
				}
				else // No As before B
				{
					int depth = openingPairIndices.Count;
					int openIndex = openingPairIndices.Pop();

					matchingPairs.Add(new Tuple<int, int, int>(openIndex, pairCloseIndex, depth));

					searchIndex = pairCloseIndex + b.Length;

					if (depth == 1) // Closing brace would put depth to 0, so we can jump ahead to the next start of a pair
					{
						pairOpenIndex = input.IndexOf(a, searchIndex, StringComparison.InvariantCulture);

						if (pairOpenIndex == -1) // No valid A remaining, return the pairs we found so far
						{
							break;
						}

						openingPairIndices.Push(pairOpenIndex);

						searchIndex = pairOpenIndex + a.Length;
					}
				}
			}

			ReduceDepthBecauseOfInvalidOpenings(matchingPairs, openingPairIndices);
			return matchingPairs; // Given in order of most-nested to least-nested
		}

		/// <summary>
		/// Find the first matching pair of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The string that represents the opening of a pair</param>
		/// <param name="b">The string that represents the closing of a pair</param>
		/// <param name="startIndex">The index from where to start searching for a matching pair in the string</param>
		/// <returns>
		/// A tuple that represents: (OpeningIndex, ClosingIndex)
		/// </returns>
		public static Tuple<int, int> GetFirstMatchingPair(string input, string a, string b, int startIndex = 0)
		{
			int pairOpenIndex = input.IndexOf(a, startIndex, StringComparison.InvariantCulture);

			if (pairOpenIndex == -1) // No beginning found so no pair can be made
			{
				return null;
			}

			int searchIndex = pairOpenIndex + a.Length;
			int pairCloseIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

			if (pairCloseIndex == -1) // No ending found so no pair can be made
			{
				return null;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();
			openingPairIndices.Push(pairOpenIndex);

			while (searchIndex < input.Length)
			{
				pairCloseIndex = input.IndexOf(b, searchIndex, StringComparison.InvariantCulture);

				if (pairCloseIndex == -1) // No valid B remaining, return the pairs we found so far
				{
					break;
				}

				int count = pairCloseIndex - searchIndex;
				pairOpenIndex = input.IndexOf(a, searchIndex, count, StringComparison.InvariantCulture);

				if (pairOpenIndex != -1 && pairOpenIndex < pairCloseIndex) // Another A before the B | Because of count it should always be before, but the check is there just to be sure
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							return new Tuple<int, int>(openingIndex, pairOpenIndex);
						}
					}

					openingPairIndices.Push(pairOpenIndex);

					searchIndex = pairOpenIndex + a.Length;
				}
				else // No As before B
				{
					int openIndex = openingPairIndices.Pop();

					return new Tuple<int, int>(openIndex, pairCloseIndex);
				}
			}

			return null; // No valid pair found before the end of the string
		}

		/// <summary>
		/// Get the strings between all pairs of two strings, optionally including the two strings
		/// </summary>
		/// <param name="input">The string to get the substrings from</param>
		/// <param name="a">The string that represents the opening of a pair</param>
		/// <param name="b">The string that represents the closing of a pair</param>
		/// <param name="includeAandB">Whether <paramref name="a"/> and <paramref name="b"/> should be included in the result</param>
		/// <returns>
		/// A list of substrings of every occurance of pairs, sorted from most-nested to least-nested<br/>
		/// Returns an empty list if no valid pair can be found
		/// </returns>
		/// <seealso cref="GetMatchingPairs(string, string, string)"/>
		public static List<string> GetStringsBetweenAandB(string input, string a, string b, bool includeAandB = true)
		{
			List<string> substrings = new List<string>();

			List<Tuple<int, int, int>> matchingPairs = GetMatchingPairs(input, a, b); // Given in order of most-nested to least-nested}

			for (int i = 0; i < matchingPairs.Count; i++)
			{
				(int openIndex, int closeIndex, int _) = matchingPairs[i];

				if (includeAandB)
				{
					++closeIndex;
				}
				else
				{
					++openIndex;
				}

				int length = closeIndex - openIndex;
				substrings.Add(input.Substring(openIndex, length));
			}

			return substrings;
		}

		/// <summary>
		/// Get the strings between all pairs of two strings, optionally including the two strings
		/// </summary>
		/// <param name="input">The string to get the substrings from</param>
		/// <param name="a">The string that represents the opening of a pair</param>
		/// <param name="b">The string that represents the closing of a pair</param>
		/// <param name="startIndex">The index from where to start looking for pairs</param>
		/// <param name="endIndex">The index from where to stop looking for pairs</param>
		/// <param name="includeAandB">Whether or not <paramref name="a"/> and <paramref name="b"/> should be included in the result</param>
		/// <returns>
		/// A list of substrings of every occurance of pairs, sorted from most-nested to least-nested<br/>
		/// Returns an empty list if no valid pair is within the given range
		/// </returns>
		/// <seealso cref="GetMatchingPairs(string, string, string)"/>
		public static List<string> GetStringsBetweenAandBRange(string input, string a, string b, int startIndex = 0, int endIndex = int.MaxValue, bool includeAandB = true)
		{
			List<string> substrings = new List<string>();

			List<Tuple<int, int, int>> matchingPairs = GetMatchingPairs(input, a, b); // Given in order of most-nested to least-nested

			for (int i = 0; i < matchingPairs.Count; i++)
			{
				(int openIndex, int closeIndex, int _) = matchingPairs[i];

				if (closeIndex > endIndex)
				{
					break;
				}

				if (openIndex < startIndex)
				{
					continue;
				}

				if (includeAandB)
				{
					++closeIndex;
				}
				else
				{
					++openIndex;
				}

				int length = closeIndex - openIndex;
				substrings.Add(input.Substring(openIndex, length));
			}

			return substrings;
		}

		//\\//\\//\\//\\//\\//\\
		//		Chars
		//\\//\\//\\//\\//\\//\\

		/// <summary>
		/// Tests how 'deep' the given index is determined by nested pairs of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The character that represents the opening of a pair</param>
		/// <param name="b">The character that represents the closing of a pair</param>
		/// <param name="lookupIndex">The index to check the depth (nested-ness) for</param>
		/// <param name="ignoreEscaped">Whether a found closing or opening match should be ignored if it is preceded by the <see cref="escapeCharacter"/></param>
		/// <returns>The depth of the given index<br/>0 means it is not within any pair (or no pair could be found)</returns>
		public static int GetDepthAtIndex(string input, char a, char b, int lookupIndex, bool ignoreEscaped = false)
		{
			int pairOpenIndex = input.IndexOf(a, StringComparison.InvariantCulture);

			if (pairOpenIndex == -1 || lookupIndex < pairOpenIndex) // No beginning found so no pairs can be made or the requested index is before the first pair would be opened
			{
				return 0;
			}

			int pairCloseIndex = input.LastIndexOf(b);

			if (pairCloseIndex == -1 || pairCloseIndex <= pairOpenIndex || lookupIndex > pairCloseIndex) // No ending found so no pairs can be made or the requested index is after the last pair would be closed
			{
				return 0;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();

			bool isEscaped = false;
			int depthAtIndex = 0;

			for (int i = 0; i < input.Length; i++)
			{
				if (ignoreEscaped && isEscaped)
				{
					isEscaped = false;
					continue;
				}

				char character = input[i];

				if (character.Equals(escapeCharacter))
				{
					isEscaped = true;
				}

				if (character.Equals(a))
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							if (openingIndex <= lookupIndex && lookupIndex <= i) // If the requested index is within the range of the pair
							{
								return 1; // always depth 1 because nesting is impossible if a and b are equal
							}
						}
					}

					openingPairIndices.Push(i);
					continue;
				}

				if (character.Equals(b) && openingPairIndices.Count > 0)
				{
					pairOpenIndex = openingPairIndices.Pop();

					if (pairOpenIndex <= lookupIndex && lookupIndex <= i) // If the requested index is within the range of the pair
					{
						++depthAtIndex;
					}
				}
			}

			return depthAtIndex;
		}

		/// <summary>
		/// Find all matching pairs of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The character that represents the opening of a pair</param>
		/// <param name="b">The character that represents the closing of a pair</param>
		/// <param name="ignoreEscaped">Whether a found closing or opening match should be ignored if it is preceded by the <see cref="escapeCharacter"/></param>
		/// <returns>
		/// A list of tuples that represent: (OpeningIndex, ClosingIndex, Depth)<br/>
		/// with Depth=1 meaning it is not nested within another pair
		/// </returns>
		public static List<Tuple<int, int, int>> GetMatchingPairs(string input, char a, char b, bool ignoreEscaped = false)
		{
			// Tuple: index opening, index close, depth
			List<Tuple<int, int, int>> matchingPairs = new List<Tuple<int, int, int>>();

			int pairOpenIndex = input.IndexOf(a, StringComparison.InvariantCulture);

			// 2 simple short-circuit checks to see if there is any chance of a pair (there still might not be because they could be escaped)
			if (pairOpenIndex == -1) // No beginning found so no pair can be made
			{
				return matchingPairs;
			}

			// +1 because otherwise it would find the same character if 'a' and 'b' are equal
			if (input.IndexOf(b, pairOpenIndex + 1) == -1) // No ending found so no pair can be made | No need to store the index of the closing pair, it will be the same as the iterator in the loop
			{
				return matchingPairs;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();

			bool isEscaped = false;

			for (int i = 0; i < input.Length; i++)
			{
				if (ignoreEscaped && isEscaped)
				{
					isEscaped = false;
					continue;
				}

				char character = input[i];

				if (character.Equals(escapeCharacter))
				{
					isEscaped = true;
				}

				if (character.Equals(a))
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							matchingPairs.Add(new Tuple<int, int, int>(openingIndex, i, 1)); // If opening and closing are equal, everything is depth 1 because nesting is impossible
							continue;
						}
					}

					openingPairIndices.Push(i);
					continue;
				}

				if (character.Equals(b) && openingPairIndices.Count > 0)
				{
					int depth = openingPairIndices.Count;

					pairOpenIndex = openingPairIndices.Pop();
					matchingPairs.Add(new Tuple<int, int, int>(pairOpenIndex, i, depth));
				}
			}

			ReduceDepthBecauseOfInvalidOpenings(matchingPairs, openingPairIndices);
			return matchingPairs;
		}

		/// <summary>
		/// Find the first matching pair of <paramref name="a"/> and <paramref name="b"/>
		/// </summary>
		/// <param name="input">The string to search for pairs</param>
		/// <param name="a">The character that represents the opening of a pair</param>
		/// <param name="b">The character that represents the closing of a pair</param>
		/// <param name="startIndex">The index from where to start searching for a matching pair in the string</param>
		/// <param name="ignoreEscaped">Whether a found closing or opening match should be ignored if it is preceded by the <see cref="escapeCharacter"/></param>
		/// <returns>
		/// A tuple that represents: (OpeningIndex, ClosingIndex)
		/// </returns>
		public static Tuple<int, int> GetFirstMatchingPair(string input, char a, char b, int startIndex = 0, bool ignoreEscaped = false)
		{
			int pairOpenIndex = input.IndexOf(a, startIndex);

			// 2 simple short-circuit checks to see if there is any chance of a pair (there still might not be because they could be escaped)
			if (pairOpenIndex == -1) // No beginning found so no pair can be made
			{
				return null;
			}

			// +1 because otherwise it would find the same character if 'a' and 'b' are equal
			if (input.IndexOf(b, pairOpenIndex + 1) == -1) // No ending found so no pair can be made | No need to store the index of the closing pair, it will be the same as the iterator in the loop
			{
				return null;
			}

			bool openingEqualsClosing = a.Equals(b);

			Stack<int> openingPairIndices = new Stack<int>();

			bool isEscaped = false;

			for (int i = 0; i < input.Length; i++)
			{
				if (ignoreEscaped && isEscaped)
				{
					isEscaped = false;
					continue;
				}

				char character = input[i];

				if (character.Equals(escapeCharacter))
				{
					isEscaped = true;
				}

				if (character.Equals(a))
				{
					if (openingEqualsClosing) // If opening and closing are equal, then we should close the pair when we find another 'opening'
					{
						if (openingPairIndices.TryPop(out int openingIndex))
						{
							return new Tuple<int, int>(openingIndex, i);
						}
					}

					openingPairIndices.Push(i);
					continue;
				}

				if (character.Equals(b) && openingPairIndices.Count > 0)
				{
					pairOpenIndex = openingPairIndices.Pop();
					return new Tuple<int, int>(pairOpenIndex, i);
				}
			}

			return null; // No valid pair found before the end of the string
		}

		/// <summary>
		/// Get the strings between all pairs of two strings, optionally including the two strings
		/// </summary>
		/// <param name="input">The string to get the substrings from</param>
		/// <param name="a">The character that represents the opening of a pair</param>
		/// <param name="b">The character that represents the closing of a pair</param>
		/// <param name="includeAandB">Whether <paramref name="a"/> and <paramref name="b"/> should be included in the result</param>
		/// <param name="ignoreEscaped">Whether a found closing or opening match should be ignored if it is preceded by the <see cref="escapeCharacter"/></param>
		/// <returns>
		/// A list of substrings of every occurance of pairs, sorted from most-nested to least-nested<br/>
		/// Returns an empty list if no valid pair can be found
		/// </returns>
		/// <seealso cref="GetMatchingPairs(string, string, string)"/>
		public static List<string> GetStringsBetweenAandB(string input, char a, char b, bool includeAandB = true, bool ignoreEscaped = false)
		{
			List<string> substrings = new List<string>();

			List<Tuple<int, int, int>> matchingPairs = GetMatchingPairs(input, a, b, ignoreEscaped); // Given in order of most-nested to least-nested

			for (int i = 0; i < matchingPairs.Count; i++)
			{
				(int openIndex, int closeIndex, int _) = matchingPairs[i];

				if (includeAandB)
				{
					++closeIndex;
				}
				else
				{
					++openIndex;
				}

				int length = closeIndex - openIndex;
				substrings.Add(input.Substring(openIndex, length));
			}

			return substrings;
		}

		/// <summary>
		/// Get the strings between all pairs of two strings, optionally including the two strings
		/// </summary>
		/// <param name="input">The string to get the substrings from</param>
		/// <param name="a">The character that represents the opening of a pair</param>
		/// <param name="b">The character that represents the closing of a pair</param>
		/// <param name="startIndex">The index from where to start looking for pairs</param>
		/// <param name="endIndex">The index from where to stop looking for pairs</param>
		/// <param name="includeAandB">Whether or not <paramref name="a"/> and <paramref name="b"/> should be included in the result</param>
		/// <param name="ignoreEscaped">Whether a found closing or opening match should be ignored if it is preceded by the <see cref="escapeCharacter"/></param>
		/// <returns>
		/// A list of substrings of every occurance of pairs, sorted from most-nested to least-nested<br/>
		/// Returns an empty list if no valid pair is within the given range
		/// </returns>
		/// <seealso cref="GetMatchingPairs(string, string, string)"/>
		public static List<string> GetStringsBetweenAandBRange(string input, char a, char b, int startIndex = 0, int endIndex = int.MaxValue, bool includeAandB = true, bool ignoreEscaped = false)
		{
			List<string> substrings = new List<string>();

			List<Tuple<int, int, int>> matchingPairs = GetMatchingPairs(input, a, b, ignoreEscaped); // Given in order of most-nested to least-nested

			for (int i = 0; i < matchingPairs.Count; i++)
			{
				(int openIndex, int closeIndex, int _) = matchingPairs[i];

				if (closeIndex > endIndex)
				{
					break;
				}

				if (openIndex < startIndex)
				{
					continue;
				}

				if (includeAandB)
				{
					++closeIndex;
				}
				else
				{
					++openIndex;
				}

				int length = closeIndex - openIndex;
				substrings.Add(input.Substring(openIndex, length));
			}

			return substrings;
		}

		/// <summary>
		/// Fix the invalid depth caused by unclosed openings.<br/>
		/// Unresolved openings (those without a fitting closer to make a pair) falsely increase the depth of the matching pairs<br/>
		/// This function fixes that discrepancy
		/// </summary>
		private static void ReduceDepthBecauseOfInvalidOpenings(List<Tuple<int, int, int>> matchingPairs, Stack<int> openingPairIndices)
		{
			int unresolvedPairOpeningsCount = openingPairIndices.Count;

			if (unresolvedPairOpeningsCount == 0)
			{
				return;
			}

			foreach (int openingPairIndex in openingPairIndices)
			{
				for (int i = matchingPairs.Count - 1; i >= 0; i--)
				{
					(int openingIndex, int closingIndex, int depth) = matchingPairs[i];

					if (openingIndex > openingPairIndex)
					{
						--depth;

						matchingPairs[i] = new Tuple<int, int, int>(openingIndex, closingIndex, depth);
					}
				}
			}
		}
	}
}