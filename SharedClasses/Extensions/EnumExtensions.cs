using System;
using System.Collections.Generic;
using System.Linq;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for <see cref="System.Enum"/>
	/// </summary>
	public static class EnumExtensions
	{
		private static readonly Dictionary<Type, string[]> namesPerEnum = new Dictionary<Type, string[]>();

		/// <summary>
		/// Returns an IEnumerable that contains the names of every value of this enum
		/// </summary>
		public static IEnumerable<string> GetNames<TEnum>(this TEnum @enum)
			where TEnum : Enum
		{
			Type enumType = @enum.GetType();

			if (namesPerEnum.TryGetValue(enumType, out string[] names))
			{
				return names;
			}

			names = Enum.GetNames(enumType);
			namesPerEnum[enumType] = names;

			return names;
		}

		/// <summary>
		/// Returns an IEnumerable of <typeparamref name="TEnum"/> that has all the values of the enum
		/// </summary>
		public static IEnumerable<TEnum> GetValues<TEnum>(this TEnum @enum)
			where TEnum : struct, Enum
		{
			string[] names = @enum.GetNames().ToArray();
			TEnum[] values = new TEnum[names.Length];

			for (int i = 0; i < names.Length; i++)
			{
				Enum.TryParse(names[i], out values[i]);
			}

			return values;
		}

		/// <summary>
		/// Returns a random value of this enum
		/// </summary>
		public static TEnum GetRandomValue<TEnum>(this TEnum @enum)
			where TEnum : struct, Enum
		{
			IEnumerable<string> names = @enum.GetNames();

			Enum.TryParse(names.GetRandomElement(), out TEnum result);

			return result;
		}
	}
}