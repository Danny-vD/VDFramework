using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	public static class RandomItem
	{
		private static readonly System.Random random = new System.Random();
		private static readonly bool[] boolValues = {true, false};

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
		public static IEnumerable<TItem> RandomSort<TItem>(this IEnumerable<TItem> collection)
		{
			List<TItem> list = collection.ToList();
			return list.RandomSort();
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

		public static bool RandomBool()
		{
			return boolValues.GetRandomItem();
		}
	}
}