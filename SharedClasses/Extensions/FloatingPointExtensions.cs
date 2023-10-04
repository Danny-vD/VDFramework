using System.Globalization;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for 32-bit and 64-bit floating-point numbers
	/// </summary>
	/// <seealso cref="System.Single"/>
	/// <seealso cref="System.Double"/>
	public static class FloatingPointExtensions
	{
		/// <summary>
		/// Get the amount of decimals after the decimal seperator
		/// </summary>
		public static int GetDecimalCount(this float number)
		{
			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int index = numberString.IndexOf('.');

			if (index < 0)
			{
				return 0;
			}

			return numberString[index..].Length;
		}
		
		/// <summary>
		/// Get the amount of decimals after the decimal seperator
		/// </summary>
		public static int GetDecimalCount(this double number)
		{
			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int index = numberString.IndexOf('.');

			if (index < 0)
			{
				return 0;
			}

			return numberString[index..].Length;
		}
	}
}