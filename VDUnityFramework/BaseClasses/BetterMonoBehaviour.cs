using UnityEngine;

namespace VDFramework
{
	/// <summary>
	/// An 'improved' <see cref="MonoBehaviour"/> which caches often used properties
	/// </summary>
	public class BetterMonoBehaviour : MonoBehaviour
	{
		/*
		 * A standard call to 'transform' makes a call to the C++ side of Unity (where it is cached)
		 * this call has some overhead which can be removed by caching the transform on the C# side
		 */
		
		private Transform cachedTransform;
		private GameObject cachedGameObject;

		/// <summary>
		/// The transform of this object
		/// </summary>
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
		
		/// <summary>
		/// The gameobject where this component is attached to
		/// </summary>
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