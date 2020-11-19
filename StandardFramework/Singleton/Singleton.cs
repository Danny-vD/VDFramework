namespace VDFramework.Singleton
{
	using Exceptions;

	/// <summary>
	/// A abstract generic implementation of the singleton pattern
	/// </summary>
	/// <typeparam name="TSingleton">The type to create a singleton of</typeparam>
	public abstract class Singleton<TSingleton>
		where TSingleton : Singleton<TSingleton>, new()
	{
		private static TSingleton instance;

		public static TSingleton Instance
		{
			get => instance ??= SingletonInstanceCreator<TSingleton>.CreateInstance();
			private set => instance = value;
		}

		public static TSingleton InstanceIfInitialized => IsInitialized ? instance : null;

		public static bool IsInitialized => instance != null;

		protected Singleton()
		{
			if (!IsInitialized)
			{
				Instance = this as TSingleton;
			}
			else
			{
				throw new SingletonViolationException($"Violator: {typeof(TSingleton).Name}");
			}
		}

		public static TSingleton ForceInitialize()
		{
			return Instance;
		}

		/// <summary>
		/// Sets the instance of the singleton to null.
		/// </summary>
		public void DestroyInstance()
		{
			instance = null;
		}
	}
}