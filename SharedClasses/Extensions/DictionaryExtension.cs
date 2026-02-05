using System;
using System.Collections.Generic;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains Extension methods for Dictionaries
	/// </summary>
	public static class DictionaryExtension
	{
		/// <summary>
		/// <para>Get the value of the KeyValuePair with key <paramref name="key"/></para>
		/// <para>Or add a new <typeparamref name="TValue"/> to the dictionary with that key and return it</para>
		/// </summary>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the KeyValuePair to get the value from</param>
		/// <typeparam name="TKey">The type of the Key in the dictionary</typeparam>
		/// <typeparam name="TValue">The type of the Value in the dictionary</typeparam>
		/// <returns>The value of the KeyValuePair at <paramref name="key"/> or a new <typeparamref name="TValue"/></returns>
		public static TValue GetOrAddNewValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
		{
			if (!dictionary.TryGetValue(key, out TValue value))
			{
				value = new TValue();
				dictionary.Add(key, value);
			}
			
			return value;
		}

		/// <summary>
		/// <para>Get the value of the KeyValuePair with key <paramref name="key"/></para>
		/// <para>Or add a new <typeparamref name="TValue"/> to the dictionary with that key and return it</para>
		/// </summary>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the KeyValuePair to get the value from</param>
		/// <param name="factoryFunction">A function to create a new <typeparamref name="TValue"/> (only invoked if <paramref name="key"/> is not present in the dictionary)</param>
		/// <typeparam name="TKey">The type of the Key in the dictionary</typeparam>
		/// <typeparam name="TValue">The type of the Value in the dictionary</typeparam>
		/// <returns>The value of the KeyValuePair at <paramref name="key"/> or a new <typeparamref name="TValue"/></returns>
		public static TValue GetOrAddNewValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factoryFunction)
		{
			if (!dictionary.TryGetValue(key, out TValue value))
			{
				value = factoryFunction.Invoke();
				dictionary.Add(key, value);
			}
			
			return value;
		}
		
		/// <summary>
		/// <para>Get the value of the KeyValuePair with key <paramref name="key"/></para>
		/// <para>Or add a new <typeparamref name="TValue"/> to the dictionary with that key and return it</para>
		/// </summary>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the KeyValuePair to get the value from</param>
		/// <param name="defaultValue">The value of the new KeyValuePair that is created when <paramref name="key"/> is not present</param>
		/// <typeparam name="TKey">The type of the Key in the dictionary</typeparam>
		/// <typeparam name="TValue">The type of the Value in the dictionary</typeparam>
		/// <returns>The value of the KeyValuePair at <paramref name="key"/> or a new <typeparamref name="TValue"/></returns>
		public static TValue GetOrAddNewValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			if (!dictionary.TryGetValue(key, out TValue value))
			{
				value = defaultValue;
				dictionary.Add(key, value);
			}
			
			return value;
		}
	}
}