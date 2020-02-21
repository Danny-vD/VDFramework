using System.Collections.Generic;

namespace VDFramework.Extensions
{
	public static class ListExtensions
	{
		/// <summary>
		/// Resize the list so that it holds a <see cref="newSize"/> amount of <see cref="TItem"/>
		/// <para></para>(will also resize the underlaying array)
		/// </summary>
		/// <param name="list">The list to resize</param>
		/// <param name="newSize">The elements that are in the list</param>
		/// <typeparam name="TItem">The type of items in the list</typeparam>
		public static void ResizeList<TItem>(this List<TItem> list, int newSize)
		{
			if (list.Count == newSize)
			{
				list.Capacity = newSize;
				return;
			}

			if (newSize <= 0)
			{
				list.Clear();
			}
			else if (list.Count > newSize)
			{
				list.RemoveRange(newSize, list.Count - newSize);
				list.Capacity = newSize;
			}
			else if (list.Count < newSize)
			{
				list.Capacity = newSize;

				while (list.Count != newSize)
				{
					list.Add(default);
				}
			}
		}
	}
}