using System;
using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Extension methods for collections that allow getting a random element or randomly sorting the collection 
	/// </summary>
	public static class RandomElement
	{
		private static readonly System.Random random = new System.Random();

		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="randomIndex">the index of the element returned</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, out int randomIndex)
		{
			// Convert to a List<T> to prevent multiple enumeration
			List<TElement> list = collection.ToList();

			int index = random.Next(list.Count); // Get a random index

			TElement value = list[index]; // Get the element at that index

			randomIndex = index;
			return value;
		}
		
		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection)
		{
			return collection.GetRandomElement(out _);
		}
		
		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="randomIndex">the index of the element returned</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, out int randomIndex, params int[] ignoreIndices)
		{
			// Transform the collection to a collection of Tuples<TElement, OriginalIndex> and then filter
			List<(TElement item, int i)> filteredList = collection.Select((element, index) => (element, index)).Where(tuple => !ignoreIndices.Contains(tuple.index)).ToList();

			if (filteredList.Count == 0)
			{
				randomIndex = -1;
				return default;
			}

			int index = random.Next(filteredList.Count); // Get a random index
			
			(TElement element, int originalIndex) valueTuple = filteredList[index]; // Get the tuple at that index

			randomIndex = valueTuple.originalIndex; // Get the original index from that tuple
			return valueTuple.element;              // Get the element from the tuple
		}

		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="collection">The collection to return a random element from</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TItem GetRandomElement<TItem>(this IEnumerable<TItem> collection, params int[] ignoreIndices)
		{
			return collection.GetRandomElement(out _, ignoreIndices);
		}

		/// <summary>
		/// Randomly sorts the IEnumberable
		/// </summary>
		public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> collection)
		{
			List<TItem> list = collection.ToList();
			return list.Randomize();
		}

		/// <summary>
		/// Randomly sorts the list
		/// </summary>
		public static List<TItem> Randomize<TItem>(this List<TItem> list)
		{
			if (list.CountIsZeroOrOne())
			{
				return list;
			}

			List<TItem> tempList = new List<TItem>(list);
			list.Clear();

			while (tempList.Count > 0)
			{
				TItem randomItem = tempList.GetRandomElement();

				tempList.Remove(randomItem);
				list.Add(randomItem);
			}

			return list;
		}
	}
}