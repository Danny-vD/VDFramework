using UnityEngine;

namespace VDFramework.Singleton
{
	internal static class SingletonInstanceCreator<T>
		where T : Component
	{
		public static T CreateInstance()
		{
			GameObject singletonContainer = new GameObject($"{typeof(T).Name} singleton");
			return singletonContainer.AddComponent<T>();
		}
	}
}