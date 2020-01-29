namespace VDFramework.Utility
{
	// The facade class, will have to be modified to work with whatever engine you use
	internal static class InstanceCreator<T> where T : new()
	{
		public static T CreateInstance()
		{
			return new T();
		}
	}
}