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
		public static void DestroyOnLoad(this GameObject gameObject)
		{
			SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
		}

		/// <summary>
		/// Ensures that the specified <see cref="Component"/> is on this <see cref="GameObject"/> by creating it if it does not exists
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this GameObject gameObject)
			where TComponent : Component
		{
			return gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();
		}

		/// <summary>
		/// Ensures that the specified <see cref="Component"/> is on this <see cref="GameObject"/> by creating it if it does not exists
		/// </summary>
		public static TComponent EnsureComponent<TComponent>(this Component myComponent)
			where TComponent : Component
		{
			return myComponent.gameObject.EnsureComponent<TComponent>();
		}
		
		/// <summary>
		/// Attempts to get the specified <see cref="Component"/> in one of the children and returns whether one was found
		/// </summary>
		public static bool TryGetComponentInChildren<TComponent>(this GameObject gameObject, out TComponent component, bool includeInactive = false)
			where TComponent : Component
		{
			component = gameObject.GetComponentInChildren<TComponent>(includeInactive);

			return !ReferenceEquals(component, null);
		}
		
		/// <summary>
		/// Attempts to get the specified <see cref="Component"/> in one of the children and returns whether one was found
		/// </summary>
		public static bool TryGetComponentInChildren<TComponent>(this Component myComponent, out TComponent component, bool includeInactive = false)
			where TComponent : Component
		{
			return myComponent.gameObject.TryGetComponentInChildren(out component, includeInactive);
		}
		
		/// <summary>
		/// Attempts to get the specified <see cref="Component"/> in one of the parents and returns whether one was found
		/// </summary>
		public static bool TryGetComponentInParent<TComponent>(this GameObject gameObject, out TComponent component, bool includeInactive = false)
			where TComponent : Component
		{
			component = gameObject.GetComponentInParent<TComponent>(includeInactive);

			return !ReferenceEquals(component, null);
		}
		
		/// <summary>
		/// Attempts to get the specified <see cref="Component"/> in one of the parents and returns whether one was found
		/// </summary>
		public static bool TryGetComponentInParent<TComponent>(this Component myComponent, out TComponent component, bool includeInactive = false)
			where TComponent : Component
		{
			return myComponent.gameObject.TryGetComponentInParent(out component, includeInactive);
		}
	}
}