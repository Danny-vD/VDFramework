using UnityEngine;

namespace VDFramework
{
	/// <summary>
	///<para>An 'improved' <see cref="MonoBehaviour"/> which caches often used properties</para>
	///<para>A standard call to 'transform' and 'gameobject' makes a call to the C++ side of Unity (where it is cached)</para>
	///<para>this call has some overhead which can be removed by caching these on the C# side</para>
	/// </summary>
	public class BetterMonoBehaviour : MonoBehaviour
	{
		private Transform cachedTransform;
		private GameObject cachedGameObject;

		/// <summary>
		/// The transform of this object
		/// </summary>
		public Transform CachedTransform
		{
			get
			{
				// Will be true the first time we perform this check and when the transform changes between a normal transform and a RectTransform
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
				// Using ReferenceEquals so we don't have the overhead from Unity's lifetime check
				if (ReferenceEquals(cachedGameObject, null))
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