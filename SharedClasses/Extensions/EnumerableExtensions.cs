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
	}
}