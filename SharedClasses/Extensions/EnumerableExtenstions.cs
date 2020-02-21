using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	public static class EnumerableExtentions
	{
		public static bool CountIsZeroOrOne<TItem>(this IEnumerable<TItem> collection)
		{
			int count = collection.Count();
			return (count == 0 || count == 1);
		}
	}
}