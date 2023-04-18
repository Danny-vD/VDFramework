using System;

namespace VDFramework.Extensions
{
	public static class ObjectExtensions
	{
		public static TNewType ConvertTo<TNewType>(this object @object)
		{
			try
			{
				return (TNewType)Convert.ChangeType(@object, typeof(TNewType));
			}
			catch
			{
				return (TNewType)@object;
			}
		}
	}
}