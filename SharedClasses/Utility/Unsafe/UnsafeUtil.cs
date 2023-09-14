using System;

namespace VDFramework.Utility.Unsafe
{
	/// <summary>
	/// Contains utility methods for working with unsafe code
	/// </summary>
	public static class UnsafeUtil
	{
		/// <summary>
		/// Reinterpret the bits from one type as if it were another
		/// </summary>
		public static unsafe TTo reinterpret_cast<TFrom, TTo>(TFrom from) where TFrom : unmanaged where TTo : unmanaged
		{
			if (sizeof(TFrom) != sizeof(TTo))
			{
				throw new ArgumentException("TFrom and TTo must be the same size (same amount of bits)!");
			}
			
			return *(TTo*)&from;
		}
	}
}