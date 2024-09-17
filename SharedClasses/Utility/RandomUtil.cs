using VDFramework.Extensions;
using VDFramework.RandomWrapper;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.Utility
{
	/// <summary>
	/// Utility methods to randomly get an item from a given set of objects
	/// </summary>
	public static class RandomUtil
	{
		private static readonly bool[] boolValues = { true, false };

		/// <summary>
		/// Returns a random bool value
		/// </summary>
		/// <param name="rng">The random number generator to use</param>
		/// <returns>TRUE or FALSE</returns>
		public static bool RandomBool(IRandomNumberGenerator rng)
		{
			return boolValues.GetRandomElement(rng);
		}
		
		/// <summary>
		/// Returns a random bool value (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <returns>TRUE or FALSE</returns>
		public static bool RandomBool()
		{
			return RandomBool(SystemRandom.StaticInstance);
		}

		/// <summary>
		/// Returns randomly from the parameters given
		/// </summary>
		/// <param name="rng">The random number generator to use</param>
		/// <param name="array">The collection to randomly select an object from</param>
		/// <returns>Any of the given objects, randomly selected</returns>
		public static object GetRandom(IRandomNumberGenerator rng, params object[] array)
		{
			return array.GetRandomElement(rng);
		}

		/// <inheritdoc cref="GetRandom(IRandomNumberGenerator, object[])"/>
		public static TItem GetRandom<TItem>(IRandomNumberGenerator rng, params TItem[] array)
		{
			return array.GetRandomElement(rng);
		}
		
		/// <summary>
		/// Returns randomly from the parameters given (using <see cref="System.Random">System.Random</see>)
		/// </summary>
		/// <param name="array">The collection to randomly select an object from</param>
		/// <returns>Any of the given objects, randomly selected</returns>
		public static object GetRandom(params object[] array)
		{
			return array.GetRandomElement(SystemRandom.StaticInstance);
		}

		/// <inheritdoc cref="GetRandom(object[])"/>
		public static TItem GetRandom<TItem>(params TItem[] array)
		{
			return array.GetRandomElement(SystemRandom.StaticInstance);
		}
	}
}