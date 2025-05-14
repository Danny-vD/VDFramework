using System;

namespace VDFramework.Interfaces
{
	/// <summary>
	/// Represents a Key-Value pair with a public getter and setter for the Key and Value
	/// </summary>
	/// <typeparam name="TKey">The type of the key</typeparam>
	/// <typeparam name="TValue">The type of the value</typeparam>
	public interface IKeyValuePair<TKey, TValue> : IEquatable<IKeyValuePair<TKey, TValue>>
	{
		/// <summary>
		/// The key of this Key-Value pair
		/// </summary>
		TKey Key { get; set; }
		
		/// <summary>
		/// The value of this Key-Value pair
		/// </summary>
		TValue Value { get; set; }
	}
}