using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	public static class RandomElement
	{
		private static readonly System.Random random = new System.Random();

		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
		/// <param name="randomIndex">the index of the element returned</param>
		/// <param name="ignoreIndices">[OPTIONAL] the indices of elements that cannot be returned by this function</param>
		public static TElement GetRandomElement<TElement>(this IEnumerable<TElement> collection, out int randomIndex, params int[] ignoreIndices)
		{
			List<TElement> list = collection.ToList();

			if (list.Count == 0)
			{
				randomIndex = -1;
				return default;
			}

			if (ignoreIndices.Length > 0)
			{
				List<int> ignore = ignoreIndices.Distinct().ToList();
				ignore.Sort();

				int ignoreCount = ignore.Count;

				if (list.Count - ignoreCount <= 0)
				{
					randomIndex = -1;
					return default;
				}
				
				for (int i = ignoreCount - 1; i < ignoreCount; i--)
				{
					list.RemoveAt(ignore[i]);
				}
			}

			randomIndex = random.Next(list.Count);

			return list[randomIndex];
		}

		/// <summary>
		/// Returns a random element from this collection
		/// </summary>
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