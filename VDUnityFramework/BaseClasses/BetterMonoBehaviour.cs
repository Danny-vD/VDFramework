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
	}
}