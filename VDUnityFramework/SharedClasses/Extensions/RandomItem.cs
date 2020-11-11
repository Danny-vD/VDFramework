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
			int count = collection.Count();

			if (count == 0)
			{
				randomIndex = -1;
				return default;
			}

			randomIndex = random.Next(count);

			return collection.ElementAt(randomIndex);
		}

		/// <summary>
		/// Randomly sorts the IEnumberable
		/// </summary>
		public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> collection)
		{
			List<TItem> list = collection.ToList();
			return list.Randomize();
		}

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
				TItem randomItem = tempList.GetRandomItem();

				tempList.Remove(randomItem);
				list.Add(randomItem);
			}

			return list;
		}
	}
}