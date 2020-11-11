using UnityEngine;

namespace VDFramework
{
	/// <summary>
	/// An 'improved' <see cref="MonoBehaviour"/> which caches often used properties
	/// </summary>
	public class BetterMonoBehaviour : MonoBehaviour
	{
		private Transform cachedTransform;
		private GameObject cachedGameObject;

		public Transform CachedTransform
		{
			get
			{
				if (cachedTransform == null)
				{
					cachedTransform = base.transform;
				}

				return cachedTransform;
			}
		}
		
		public GameObject CachedGameObject
		{
			get
			{
				if (cachedGameObject == null)
				{
					cachedGameObject = base.gameObject;
				}

				return cachedGameObject;
			}
		}

		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//				Hiding inherited members
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		
		// ReSharper disable InconsistentNaming
		
		/// <summary>
		/// Overridden to return the CachedTransform
		/// </summary>
		public new Transform transform => CachedTransform;

		/// <summary>
		/// Overridden to return the CachedGameObject
		/// </summary>
		public new GameObject gameObject => CachedGameObject;
		
		// ReSharper restore InconsistentNaming
	}
}