namespace VDFramework.Singleton
{
	// The facade class, will have to be modified to work with whatever engine you use
	internal static class SingletonInstanceCreator<T> where T : new()
	{
		public static T CreateInstance()
		{
			return new T();
		}
	}
}