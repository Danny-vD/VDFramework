using System;

namespace VDFramework.Utility.SpanUtility
{
	/// <summary>
	/// Provides utility functions for working with spans
	/// </summary>
	public class SpanUtil
	{
		/// <summary>
		/// Insert the given object into the span at the given index 
		/// </summary>
		/// <remarks>Gracefully prevents out of bounds errors by only copying elements until the end of either span is reached</remarks>
		public static void Insert<T>(in ReadOnlySpan<T> copyFrom, in Span<T> insertInto, int insertionIndex, T toInsert)
		{
			int highestAllowedIndex = Math.Min(copyFrom.Length, insertInto.Length);
			
			if (insertionIndex < 0 || insertionIndex > highestAllowedIndex)
			{
				throw new ArgumentOutOfRangeException($"{nameof(insertionIndex)} cannot be lower than 0 or larger than the size of the Span!\nValue: {insertionIndex}\tValid Range: [0-{highestAllowedIndex}]");
			}

			for (int i = 0, indexOriginal = 0; indexOriginal < copyFrom.Length && i < insertInto.Length; i++)
			{
				if (i == insertionIndex)
				{
					insertInto[i] = toInsert;
					continue;
				}

				insertInto[i] = copyFrom[indexOriginal++];
			}
		}
	}
}