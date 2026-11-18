using UnityEngine;
using VDFramework.Exceptions;

namespace VDFramework.Singleton
{
	/// <summary>
	/// A abstract generic implementation of the singleton pattern
	/// </summary>
	/// <typeparam name="TSingleton">The type to create a singleton of</typeparam>
	public abstract class UnitySingleton<TSingleton> : BetterMonoBehaviour where TSingleton : UnitySingleton<TSingleton>
	{
		// ReSharper disable once StaticMemberInGenericType
		private static readonly object singletonLock = new object();

		private static volatile TSingleton instance;

		/// <summary>
		/// Tests if this Singleton has a valid instance
		/// </summary>
		public static bool IsInitialised => instance != null;

		/// <summary>
		/// Returns the instance of the singleton, if it was created.<br/>Otherwise, NULL
		/// </summary>
		public static TSingleton InstanceIfInitialized => IsInitialised ? instance : null;

		/// <summary>
		/// Returns an instance of this Singleton or initializes it if it does not exist yet (lazy-initialisation)
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
							instance = CreateInstance();
						}
					}
				}

				return instance;
			}
			private set => instance = value;
		}

		private static TSingleton CreateInstance()
		{
			GameObject singletonContainer = new GameObject($"{typeof(TSingleton).Name} singleton");
			TSingleton singleton = singletonContainer.AddComponent<TSingleton>();

			singleton.createdObject = true;

			return singleton;
		}

		/// <Description></Description>
		protected virtual void Awake()
		{
			lock (singletonLock)
			{
				if (!IsInitialised)
				{
					Instance = this as TSingleton;
				}
				else
				{
					DestroyThis(false);
					throw new SingletonViolationException($"Violator: {typeof(TSingleton).Name}");
				}
			}
		}

		private bool createdObject = false;

		/// <summary>
		/// Forces the lazy-initialisation if not performed already and returns the instance
		/// </summary>
		public static TSingleton ForceInitialise()
		{
			return Instance;
		}

		/// <summary>
		/// Sets the instance of the singleton to null.
		/// </summary>
		public static void DestroyInstance()
		{
			if (IsInitialised)
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

			if (createdObject)
			{
				Destroy(gameObject);
				return;
			}

			Destroy(this);
		}

		/// <Description></Description>
		protected virtual void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}
	}
}