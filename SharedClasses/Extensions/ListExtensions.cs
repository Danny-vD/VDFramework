using System;
using System.Collections.Generic;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for <see cref="List{T}"/>
	/// </summary>
	public static class ListExtensions
	{
		/// <summary>
		/// Resize the list so that it holds a <paramref name="newSize"/> amount of <typeparamref name="TItem"/>
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

		/// <summary>
		/// Removes all duplicate elements from this list by using the default equality comparer to compare values.
		/// </summary>
		/// <param name="list">The list whose duplicates will be removed</param>
		/// <typeparam name="TItem">The type of elements in the list</typeparam>
		/// <returns>the same list to support chaining methods</returns>
		/// <seealso cref="MakeDistinct{TItem}(System.Collections.Generic.List{TItem}, System.Collections.Generic.IEqualityComparer{TItem})"/>
		public static List<TItem> MakeDistinct<TItem>(this List<TItem> list)
		{
			return list.MakeDistinct(EqualityComparer<TItem>.Default);
		}

		/// <summary>
		/// Removes all duplicate elements from this list by by using a specified <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare values.
		/// </summary>
		/// <param name="list">The list whose duplicates will be removed</param>
		/// <param name="equalityComparer">the <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> that will be used to compare values</param>
		/// <typeparam name="TItem">The type of elements in the list</typeparam>
		/// <returns>the same list to support chaining methods</returns>
		public static List<TItem> MakeDistinct<TItem>(this List<TItem> list, IEqualityComparer<TItem> equalityComparer)
		{
			// Remove any duplicates
			for (int i = 0; i < list.Count; i++)
			{
				TItem pair = list[i];

				for (int index = list.Count - 1; index > i; index--)
				{
					TItem other = list[index];
					
					if (equalityComparer.Equals(pair, other))
					{
						list.Remove(other);
					}
				}
			}

			return list;
		}

		/// <summary>
		/// Insert the item in a location so that the list remains sorted (insertionSort) <br/>
		/// The comparisions are made using the <see cref="IComparable{T}.CompareTo"/> function
		/// </summary>
		/// <param name="list">The list to insert the item in</param>
		/// <param name="itemToAdd">The item to insert into the list</param>
		/// <param name="addToEndOfEquals">If true, the item will be inserted after all other items that are equal. Otherwise at the beginning</param>
		/// <typeparam name="TItem">The type of elements in the list</typeparam>
		public static void AddSorted<TItem>(this List<TItem> list, TItem itemToAdd, bool addToEndOfEquals = true) where TItem : IComparable<TItem>
		{
			for (int i = 0; i < list.Count; i++)
			{
				TItem currentItem = list[i];

				int compareResult = currentItem.CompareTo(itemToAdd);

				// If the current item is bigger than the item we should add, or if we want to add it to the beginning of the group of equals and the current item is an equal: add the item
				if (compareResult > 0 || !addToEndOfEquals && compareResult == 0)
				{
					list.Insert(i, itemToAdd);
					return;
				}
			}
			
			list.Add(itemToAdd);
		}
	}
}