using VDFramework.Extensions;

namespace VDFramework.Utility
{
	public static class RandomUtil
	{
		private static readonly bool[] boolValues = { true, false };

		public static bool RandomBool()
		{
			return boolValues.GetRandomElement();
		}

		public static object GetRandom(params object[] array)
		{
			return array.GetRandomElement();
		}

		public static TItem GetRandom<TItem>(params TItem[] array)
		{
			return array.GetRandomElement();
		}
	}
}