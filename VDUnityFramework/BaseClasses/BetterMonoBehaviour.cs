using UnityEngine;

namespace VDUnityFramework.BaseClasses
{
	public class BetterMonoBehaviour : MonoBehaviour
	{
		private Transform cachedTransform;

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

		private Rigidbody cachedRigidBody;

		public Rigidbody CachedRigidBody
		{
			get
			{
				if (cachedRigidBody == null)
				{
					cachedRigidBody = GetComponent<Rigidbody>();
				}

				return cachedRigidBody;
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
		/// Overridden to return the CachedRigidbody
		/// </summary>
		public new Rigidbody rigidbody => CachedRigidBody;
	}
}