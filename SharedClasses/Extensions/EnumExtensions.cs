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

			names                  = Enum.GetNames(enumType);
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

		/// <summary>Determines whether any of the given flags are set in the current instance</summary>
		/// <param name="enum">The enumeration value to check for flags</param>
		/// <param name="flag">An enumeration value</param>
		/// <returns>
		/// <see langword="true"/> if any bit fields that are set in <paramref name="flag" /> are also set in the current instance; otherwise, <see langword="false" />.
		/// </returns>
		/// <info>Differs from <see cref="Enum.HasFlag"/> in that <see cref="Enum.HasFlag"/> requires that every flag is set to return <see langword="true"/></info>
		public static bool HasAnyFlag<TEnum>(this TEnum @enum, TEnum flag) where TEnum : struct, Enum
		{
			switch (@enum.GetTypeCode())
			{
				case TypeCode.SByte:
					sbyte enumNumberSByte = Convert.ToSByte(@enum);
					sbyte flagNumberSByte = Convert.ToSByte(flag);
					
					return (enumNumberSByte & flagNumberSByte) != 0;
				case TypeCode.Int16:
					short enumNumberShort = Convert.ToInt16(@enum);
					short flagNumberShort = Convert.ToInt16(flag);
					
					return (enumNumberShort & flagNumberShort) != 0;
				case TypeCode.Int32:
					int enumNumberInt = Convert.ToInt32(@enum);
					int flagNumberInt = Convert.ToInt32(flag);
					
					return (enumNumberInt & flagNumberInt) != 0;
				case TypeCode.Int64:
					long enumNumberLong = Convert.ToInt64(@enum);
					long flagNumberLong = Convert.ToInt64(flag);
					
					return (enumNumberLong & flagNumberLong) != 0;
				case TypeCode.Byte:
					byte enumNumberByte = Convert.ToByte(@enum);
					byte flagNumberByte = Convert.ToByte(flag);

					return (enumNumberByte & flagNumberByte) != 0;
				case TypeCode.UInt16:
					ushort enumNumberUShort = Convert.ToUInt16(@enum);
					ushort flagNumberUShort = Convert.ToUInt16(flag);

					return (enumNumberUShort & flagNumberUShort) != 0;
				case TypeCode.UInt32:
					uint enumNumberUInt = Convert.ToUInt32(@enum);
					uint flagNumberUInt = Convert.ToUInt32(flag);

					return (enumNumberUInt & flagNumberUInt) != 0;
				case TypeCode.UInt64:
					ulong enumNumberULong = Convert.ToUInt64(@enum);
					ulong flagNumberULong = Convert.ToUInt64(flag);
					
					return (enumNumberULong & flagNumberULong) != 0;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}