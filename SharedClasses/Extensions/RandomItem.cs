using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	public static class RandomItem
	{
		private static readonly System.Random random = new System.Random();

		public static TItem GetRandomItem<TItem>(this IEnumerable<TItem> collection)
		{
			return collection.GetRandomItem(out _);
		}

		public static TItem GetRandomItem<TItem>(this IEnumerable<TItem> collection, out int randomIndex)
		{
			if (collection.Any())
			{
				randomIndex = -1;
				return default;
			}

			randomIndex = random.Next(collection.Count());

			return collection.ElementAt(randomIndex);
		}

		public static IEnumerable<TItem> RandomSort<TItem>(this IEnumerable<TItem> collection)
		{
			List<TItem> list = collection.ToList();
			list.RandomSort();

			return list.ToArray();
		}
		
		public static List<TItem> RandomSort<TItem>(this List<TItem> list)
		{
			if (list.Count == 0)
			{
				return list;
			}

			List<TItem> tempList = new List<TItem>(list);
			list.Clear();

			while (tempList.Count > 0)
			{
				TItem randomItem = tempList.GetRandomItem();

				tempList.Remove(randomItem);
				list.Add(randomItem);
			}

			return list;
		}
	}
}