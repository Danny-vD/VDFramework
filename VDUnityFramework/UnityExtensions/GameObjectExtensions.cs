using UnityEngine;
using UnityEngine.SceneManagement;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains extension methods for <see cref="UnityEngine.GameObject"/>
	/// </summary>
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Mark this object to be destroyed on load (the reverse of DontDestroyOnLoad)
		/// </summary>
		/// <param name="gameObject"></param>
		public static void DestroyOnLoad(this GameObject gameObject)
		{
			SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
		}

		/// <summary>
		/// Ensures that the specified <see cref="TComponent"/> is on this <see cref="GameObject"/> by creating it if it doesn not exists
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this GameObject gameObject)
			where TComponent : Component
		{
			return gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();
		}

		/// <summary>
		/// Ensures that the specified <see cref="TComponent"/> is on this <see cref="GameObject"/> by creating it if it doesn not exists
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this Component monoBehaviour)
			where TComponent : Component
		{
			return monoBehaviour.gameObject.EnsureComponent<TComponent>();
		}
	}
}