using UnityEngine;

namespace VDFramework.Singleton
{
	public static class SingletonInstanceCreator<T> where T : Component
	{
		public static T CreateInstance()
		{
			GameObject singletonContainer = new GameObject($"{typeof(T)}");
			return singletonContainer.AddComponent<T>();
		}
	}
}