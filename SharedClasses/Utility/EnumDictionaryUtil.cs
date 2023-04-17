using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;
using VDFramework.Interfaces;

namespace VDFramework.Utility
{
	public class EnumDictionaryUtil
	{
		/// <summary>
		/// Will add a KeyValuePair for every enumValue to the list
		/// </summary>
		public static void PopulateEnumDictionary<TKeyValuePair, TEnum, TValue>(List<TKeyValuePair> list)
			where TKeyValuePair : IKeyValuePair<TEnum, TValue>, new()
			where TEnum : struct, Enum
		{
			list ??= new List<TKeyValuePair>();

			TEnum @enum = default;
			TEnum[] enumValues = @enum.GetValues().ToArray();

			// Remove the keys that are no longer in the enum
			for (int i = list.Count - 1; i >= 0; i--)
			{
				TKeyValuePair pair = list[i];

				if (!enumValues.Contains(pair.Key))
				{
					list.Remove(pair);
				}
			}

			// Add all keys are are not yet in the list
			for (int i = 0; i < enumValues.Length; i++)
			{
				TEnum enumValue = enumValues[i];

				if (ContainsKey<TKeyValuePair, TEnum, TValue>(list, enumValue))
				{
					continue;
				}

				if (i > list.Count) // Happens in case of duplicate values
				{
					list.Add(new TKeyValuePair { Key = enumValue });
				}
				else
				{
					list.Insert(i, new TKeyValuePair { Key = enumValue });
				}
			}

			// Remove any duplicates
			for (int i = 0; i < list.Count; i++)
			{
				TKeyValuePair pair = list[i];

				for (int index = list.Count - 1; index > i; index--)
				{
					TKeyValuePair other = list[index];

					if (pair.Key.Equals(other.Key))
					{
						list.Remove(other);
					}
				}
			}
		}

		private static bool ContainsKey<TKeyValuePair, TKey, TValue>(IEnumerable<TKeyValuePair> collection, TKey key)
			where TKeyValuePair : IKeyValuePair<TKey, TValue>
		{
			return collection.Any(pair => Equals(pair.Key, key));
		}
	}
}