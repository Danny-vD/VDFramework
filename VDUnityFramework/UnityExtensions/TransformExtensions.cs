﻿using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class TransformExtensions
	{
		/// <summary>
		/// Destroys all children
		/// </summary>
		public static void DestroyChildren(this Transform transform)
		{
			foreach (Transform child in transform)
			{
				Object.Destroy(child.gameObject);
			}
		}
	}
}