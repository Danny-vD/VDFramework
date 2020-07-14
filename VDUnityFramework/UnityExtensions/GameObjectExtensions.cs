using UnityEngine;
using UnityEngine.SceneManagement;

namespace VDFramework.UnityExtensions
{
	public static class GameObjectExtensions
	{
		public static void DestroyOnLoad(this GameObject gameObject)
		{
			SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
		}
		
		/// <summary>
		/// Ensures that the specified <see cref="TComponent"/> is on this <see cref="GameObject"/>.
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this GameObject gameObject)
			where TComponent : Component
		{
			return gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();
		}

		public static TComponent EnsureComponent<TComponent>(this Component monoBehaviour)
			where TComponent : Component
		{
			return monoBehaviour.gameObject.EnsureComponent<TComponent>();
		}
	}
}