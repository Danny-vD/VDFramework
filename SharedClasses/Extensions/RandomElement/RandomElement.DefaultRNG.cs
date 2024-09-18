using System.Collections.Generic;
using VDFramework.RandomWrapper;

namespace VDFramework.Extensions
{
	public static partial class RandomElement
	{
		/// <summary>
		/// Returns a random element from this collection (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="randomIndex">the index of the element returned</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, out int randomIndex)
		{
			return collection.GetRandomElement(SystemRandom.StaticInstance, out randomIndex);
		}
		
		/// <summary>
		/// Returns a random element from this collection (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection)
		{
			return collection.GetRandomElement(SystemRandom.StaticInstance, out _);
		}
		
		/// <summary>
		/// Returns a random element from this collection (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="randomIndex">the index of the element returned</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, out int randomIndex, params int[] ignoreIndices)
		{
			return collection.GetRandomElement(SystemRandom.StaticInstance, out randomIndex, ignoreIndices);
		}
		
		/// <summary>
		/// Returns a random element from this collection (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TItem GetRandomElement<TItem>(this IEnumerable<TItem> collection, params int[] ignoreIndices)
		{
			return collection.GetRandomElement(SystemRandom.StaticInstance, out _, ignoreIndices);
		}
		
		/// <summary>
		/// Randomly sorts the IEnumerable (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <returns>The same list, for the purposes of chaining</returns>
		public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> collection)
		{
			return collection.Randomize(SystemRandom.StaticInstance);
		}
	}
}