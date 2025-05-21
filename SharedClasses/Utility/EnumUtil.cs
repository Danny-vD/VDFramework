using System;
using System.Linq;
using VDFramework.Extensions;

namespace VDFramework.Utility
{
	/// <summary>
	/// Provides utility functions for Enums
	/// </summary>
	public static class EnumUtil
	{
		/// <summary>
		/// Tests if the given value exists as any defined value in the enum
		/// </summary>
		/// <param name="enum">The value to check for in the enum</param>
		/// <typeparam name="TEnum">The enum to check against</typeparam>
		/// <returns><see langword="true"/> or <see langword="false"/></returns>
		public static bool IsValidEnumValue<TEnum>(TEnum @enum) where TEnum : struct, Enum
		{
			ulong enumNumber = Convert.ToUInt64(@enum);

			return default(TEnum).GetValues().Any(enumValue => enumNumber == Convert.ToUInt64(enumValue));
		}
	}
}