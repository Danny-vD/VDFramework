using VDFramework.Extensions;

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
		/// <returns>TRUE or FALSE</returns>
		public static bool RandomBool()
		{
			return boolValues.GetRandomElement();
		}

		/// <summary>
		/// Returns randomly from the parameters given
		/// </summary>
		/// <returns>Any of the parameters, randomly selected</returns>
		public static object GetRandom(params object[] array)
		{
			return array.GetRandomElement();
		}

		/// <inheritdoc cref="GetRandom"/>
		public static TItem GetRandom<TItem>(params TItem[] array)
		{
			return array.GetRandomElement();
		}
	}
}