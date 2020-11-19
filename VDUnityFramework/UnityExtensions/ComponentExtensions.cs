using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class ComponentExtensions
	{
		public static IEnumerable<GameObject> ToGameObject<TItem>(this IEnumerable<TItem> collection)
			where TItem : Component
		{
			return collection.Select(item => item.gameObject);
		}
	}
}