using System.Collections.Generic;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class ComponentExtensions
	{
		public static GameObject[] ConvertToGameObjectArray<TItem>(this TItem[] array) where TItem : Component
		{
			GameObject[] gameObjects = new GameObject[array.Length];

			for (int i = 0; i < array.Length; ++i)
			{
				gameObjects[i] = array[i].gameObject;
			}

			return gameObjects;
		}

		public static List<GameObject> ConvertToGameObjectList<TItem>(this List<TItem> list) where TItem : Component
		{
			List<GameObject> gameObjects = new List<GameObject>(list.Count) {Capacity = list.Count};

			for (int i = 0; i < list.Count; ++i)
			{
				gameObjects.Add(list[i].gameObject);
			}

			return gameObjects;
		}
	}
}