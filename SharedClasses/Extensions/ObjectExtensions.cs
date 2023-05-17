using System;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for System.<see cref="System.Object"/>
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// <para>Converts this type to the specified type</para>
		/// <para>WARNING: this method does not support user-defined conversions</para>
		/// </summary>
		/// <typeparam name="TNewType">The Type to convert to</typeparam>
		/// <exception cref="InvalidCastException">Will be thrown if the conversion is not valid</exception>
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