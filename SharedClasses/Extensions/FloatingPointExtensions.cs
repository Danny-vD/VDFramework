using System.Globalization;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains extension methods for floating-point numbers
	/// </summary>
	/// <seealso cref="System.Single"/>
	/// <seealso cref="System.Double"/>
	/// <seealso cref="System.Decimal"/>
	public static class FloatingPointExtensions
	{
		/// <summary>
		/// Get the amount of decimals after the decimal seperator
		/// </summary>
		public static int GetDecimalCount(this float number)
		{
			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int index = numberString.IndexOf('.');

			if (index < 0) // index == -1 if no '.' present
			{
				return 0;
			}

			return numberString[(index + 1)..].Length; // +1 because we do not want to include the '.'
		}
		
		/// <summary>
		/// Get the amount of decimals after the decimal seperator
		/// </summary>
		public static int GetDecimalCount(this double number)
		{
			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int index = numberString.IndexOf('.');

			if (index < 0) // index == -1 if no '.' present
			{
				return 0;
			}

			return numberString[(index + 1)..].Length; // +1 because we do not want to include the '.'
		}
		
		/// <summary>
		/// Get the amount of decimals after the decimal seperator
		/// </summary>
		public static int GetDecimalCount(this decimal number)
		{
			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int index = numberString.IndexOf('.');

			if (index < 0) // index == -1 if no '.' present
			{
				return 0;
			}

			return numberString[(index + 1)..].Length; // +1 because we do not want to include the '.'
		}
	}
}