using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class TransformExtensions
	{
		/// <summary>
		/// Destroys all children
		/// </summary>
		public static void DestroyChildren(this Transform transform)
		{
			// It's possible to loop over all of them like this because they will only be destroyed at the end of the frame
			foreach (Transform child in transform)
			{
				Object.Destroy(child.gameObject);
			}
		}

		/// <summary>
		/// Destroys all children immediately
		/// </summary>
		public static void DestroyChildrenImmediate(this Transform transform)
		{
			int childCount = transform.childCount;

			for (int i = 0; i < childCount; i++)
			{
				Object.DestroyImmediate(transform.GetChild(0));
			}
		}
	}
}