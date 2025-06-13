using System.Collections.Generic;
using UnityEngine;

namespace VDFramework.Animators
{
	/// <summary>
	/// A utility class to cache and retrieve the ID from an Animator
	/// </summary>
	/// <remarks>
	/// <para>This class provides a single storage-point for all the cached IDs (so multiple classes can take advantage of caching a similar named parameter/states)</para>
	/// <para>You should still cache all the returned IDs yourself (so that you do not need a dictionary lookup for the cached value all the time)</para>
	/// </remarks>
	public static class AnimatorHashUtil
	{
		private static readonly Dictionary<string, int> cachedIdDictionary = new Dictionary<string, int>();

		/// <summary>
		/// Retrieves the cached ID of the given name or caches a new one if it was not already
		/// </summary>
		/// <param name="name">The name of the parameter/state</param>
		/// <returns>A ID that can be used for animator parameters/states</returns>
		/// <seealso cref="Animator.StringToHash"/>
		public static int GetCachedID(string name)
		{
			if (cachedIdDictionary.TryGetValue(name, out int id))
			{
				return id;
			}

			id = Animator.StringToHash(name);
			cachedIdDictionary.Add(name, id);

			return id;
		}
	}
}