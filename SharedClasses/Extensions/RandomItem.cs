using System.Collections.Generic;

namespace VDFramework.Extensions
{
	public static class RandomItem
	{
		private static readonly System.Random random = new System.Random();

		public static TItem GetRandomItem<TItem>(this TItem[] array)
		{
			return array.GetRandomItem(out _);
		}

		public static TItem GetRandomItem<TItem>(this TItem[] array, out int randomIndex)
		{
			if (array.Length == 0)
			{
				randomIndex = -1;
				return default;
			}

			randomIndex = random.Next(array.Length);

			return array[randomIndex];
		}

		public static TItem GetRandomItem<TItem>(this List<TItem> list)
		{
			return list.GetRandomItem(out _);
		}

		public static TItem GetRandomItem<TItem>(this List<TItem> list, out int randomIndex)
		{
			if (list.Count == 0)
			{
				randomIndex = -1;
				return default;
			}

			randomIndex = random.Next(list.Count);

			return list[randomIndex];
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