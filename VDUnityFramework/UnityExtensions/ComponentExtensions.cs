using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains extension methods for <see cref="UnityEngine.Component"/>
	/// </summary>
	public static class ComponentExtensions
	{
		/// <summary>
		/// Transforms a collections of components to a collection of their <see cref="GameObject"/>s
		/// </summary>
		public static IEnumerable<GameObject> ToGameObject<TItem>(this IEnumerable<TItem> collection)
			where TItem : Component
		{
			return collection.Select(item => item.gameObject);
		}
	}
}