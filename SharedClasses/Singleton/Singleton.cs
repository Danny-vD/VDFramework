using VDFramework.Exceptions;

namespace VDFramework.Singleton
{
	/// <summary>
	/// A abstract generic implementation of the singleton pattern
	/// </summary>
	/// <typeparam name="TSingleton">The type to create a singleton of</typeparam>
	public abstract class Singleton<TSingleton> where TSingleton : Singleton<TSingleton>, new()
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
		public static TSingleton InstanceIfInitialised => IsInitialised ? instance : null;
		
		/// <summary>
		/// Returns an instance of this Singleton or creates one if it does not exist yet (lazy-initialization)
		/// </summary>
		public static TSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					lock (singletonLock)
					{
						if (instance == null)
						{
							instance = new TSingleton();
						}
					}
				}

				return instance;
			}
			private set => instance = value;
		}

		/// <summary>
		/// Creates 
		/// </summary>
		/// <exception cref="SingletonViolationException"></exception>
		protected Singleton()
		{
			if (!IsInitialised)
			{
				Instance = this as TSingleton;
			}
			else
			{
				throw new SingletonViolationException($"Violator: {typeof(TSingleton).Name}");
			}
		}
		
		/// <summary>
		/// Forces the lazy-initaliasation if not performed already and returns the instance
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
			instance = null;
		}
	}
}