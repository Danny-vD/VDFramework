using UnityEngine;

namespace VDFramework.Utility
{
	public static class InstanceCreator<T> where T: Component
	{
		public static T CreateInstance()
		{
			GameObject singletonContainer = new GameObject($"{typeof(T)}");
			return singletonContainer.AddComponent<T>();
		}
	}
}