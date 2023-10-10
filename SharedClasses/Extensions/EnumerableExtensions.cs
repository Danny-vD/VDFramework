using System;
using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains Extension methods for IEnumerables
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// True if this collection is empty or contains only one element
		/// </summary>
		public static bool CountIsZeroOrOne<TItem>(this IEnumerable<TItem> collection)
		{
			int count = collection.Count();
			return count == 0 || count == 1;
		}

		/// <summary>
		/// Calculate the Min and the Max values in the collection using <see cref="IComparable{TElement}"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="minElement">The element in the collection that precedes all other elements in the sort order</param>
		/// <param name="maxElement">The element in the collection that follows all other elements in the sort order</param>
		/// <returns>A value indicating whether calculating the Min and Max was successful</returns>
		public static bool GetMinMax<TElement>(this IEnumerable<TElement> collection, out TElement minElement, out TElement maxElement) where TElement : IComparable<TElement>
		{
			minElement = default;
			maxElement = default;

			bool firstElementSet = false;
			
			foreach (TElement element in collection)
			{
				if (!firstElementSet)
				{
					minElement = element;
					maxElement = element;

					firstElementSet = true;
					continue;
				}

				int comparison = element.CompareTo(minElement);

				if (comparison < 0)
				{
					minElement = element;
				}

				comparison = element.CompareTo(maxElement);

				if (comparison > 0)
				{
					maxElement = element;
				}
			}

			return firstElementSet;
		}
	}
}