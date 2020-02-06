using UnityEngine;

namespace VDUnityFramework.UnityExtensions
{
	public static class GameObjectExtensions
	{
		/// <summary>
		/// ensures that the specified <see cref="TComponent"/> is on this <see cref="GameObject"/>.
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this GameObject gameObject) where TComponent : Component
		{
			return gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();
		}
	}
}