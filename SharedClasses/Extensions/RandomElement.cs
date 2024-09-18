using System.Collections.Generic;
using System.Linq;
using VDFramework.RandomWrapper;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Extension methods for collections that allow getting a random element or randomly sorting the collection 
	/// </summary>
	public static partial class RandomElement
	{
		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="rng">The random number generator to use</param>
		/// <param name="randomIndex">the index of the element returned</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, IRandomNumberGenerator rng, out int randomIndex)
		{
			// Convert to a T[] to prevent multiple enumeration
			TElement[] array = collection.ToArray();

			int index = rng.Next(array.Length); // Get a random index

			TElement value = array[index]; // Get the element at that index

			randomIndex = index;
			return value;
		}
		
		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="rng">The random number generator to use</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, IRandomNumberGenerator rng)
		{
			return collection.GetRandomElement(rng, out _);
		}
		
		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="rng">The random number generator to use</param>
		/// <param name="randomIndex">the index of the element returned</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, IRandomNumberGenerator rng, out int randomIndex, params int[] ignoreIndices)
		{
			// Transform the collection to a collection of Tuples<TElement, OriginalIndex> and then filter
			(TElement item, int i)[] filteredArray = collection.Select((element, index) => (element, index)).Where(tuple => !ignoreIndices.Contains(tuple.index)).ToArray();

			if (filteredArray.Length == 0)
			{
				randomIndex = -1;
				return default;
			}

			(TElement element, int originalIndex) valueTuple = filteredArray.GetRandomElement(rng, out _);

			randomIndex = valueTuple.originalIndex; // Get the original index from that tuple
			return valueTuple.element;              // Get the element from the tuple
		}

		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="rng">The random number generator to use</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TItem GetRandomElement<TItem>(this IEnumerable<TItem> collection, IRandomNumberGenerator rng, params int[] ignoreIndices)
		{
			return collection.GetRandomElement(rng, out _, ignoreIndices);
		}

		/// <summary>
		/// Randomly sorts the IEnumerable
		/// </summary>
		/// <returns>The same list, for the purposes of chaining</returns>
		public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> collection, IRandomNumberGenerator random)
		{
			List<TItem> list = collection.ToList();
			return list.Randomize(random);
		}

		/// <summary>
		/// Randomly sorts the list
		/// </summary>
		/// <returns>The same list, for the purposes of chaining</returns>
		public static List<TItem> Randomize<TItem>(this List<TItem> list, IRandomNumberGenerator random)
		{
			if (list.CountIsZeroOrOne())
			{
				return list;
			}

			List<TItem> tempList = new List<TItem>(list);
			list.Clear();

			while (tempList.Count > 0)
			{
				TItem randomItem = tempList.GetRandomElement(random, out _);

				tempList.Remove(randomItem);
				list.Add(randomItem);
			}

			return list;
		}
		
		/// <summary>
		/// Randomly sorts the list
		/// </summary>
		/// <returns>The same list, for the purposes of chaining</returns>
		public static List<TItem> Randomize<TItem>(this List<TItem> list)
		{
			return list.Randomize(SystemRandom.StaticInstance);
		}
	}
}