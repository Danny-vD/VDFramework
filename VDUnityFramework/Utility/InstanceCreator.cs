using UnityEngine;

namespace VDUnityFramework.Utility
{
	public static class InstanceCreator<T> where T: Component
	{
		public static T CreateInstance()
		{
			GameObject singletonContainer = new GameObject($"{typeof(T)} Singleton");
			return singletonContainer.AddComponent<T>();
		}
	}
}