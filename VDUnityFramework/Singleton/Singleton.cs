using UnityEngine;
using VDFramework.Exceptions;
using VDFramework.UnityExtensions;

namespace VDFramework.Singleton
{
	/// <summary>
	/// A abstract generic implementation of the singleton pattern
	/// </summary>
	/// <typeparam name="TSingleton">The type to create a singleton of</typeparam>
	public abstract class Singleton<TSingleton> : BetterMonoBehaviour
		where TSingleton : Singleton<TSingleton>
	{
		// ReSharper disable once StaticMemberInGenericType
		private static readonly object singletonLock = new object();

		private static volatile TSingleton instance;

		/// <summary>
		/// Returns an instance of this Singleton or initializes it if it does not exist yet (lazy-initialization)
		/// </summary>
		public static TSingleton Instance
		{
			get
			{
				// ReSharper disable once ConvertIfStatementToNullCoalescingExpression
				if (instance == null)
				{
					lock (singletonLock)
					{
						if (instance == null)
						{
							instance = SingletonInstanceCreator<TSingleton>.CreateInstance();
						}
					}
				}

				return instance;
			}
			private set => instance = value;
		}

		public static TSingleton InstanceIfInitialized => IsInitialized ? instance : null;

		public static bool IsInitialized => instance != null;
        
		protected virtual void Awake()
		{
			if (!IsInitialized)
			{
				Instance = this as TSingleton;
			}
			else
			{
				DestroyThis(false);
				throw new SingletonViolationException($"Violator: {typeof(TSingleton).Name}");
			}
		}

		protected virtual void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}

		public static TSingleton ForceInitialize()
		{
			return Instance;
		}

		public void DontDestroyOnLoad(bool dontDestroy)
		{
			if (dontDestroy)
			{
				Object.DontDestroyOnLoad(instance.gameObject);
				return;
			}

			instance.gameObject.DestroyOnLoad();
		}
		
		/// <summary>
		/// Sets the instance of the singleton to null.
		/// </summary>
		public static void DestroyInstance()
		{
			if (IsInitialized)
			{
				Instance.DestroyThis(true);
			}
		}

		private void DestroyThis(bool destroyStaticInstance)
		{
			if (destroyStaticInstance)
			{
				instance = null;
			}

			if (gameObject.name.ToLower().Contains("singleton"))
			{
				Destroy(gameObject);
				return;
			}

			Destroy(this);
		}
	}
}