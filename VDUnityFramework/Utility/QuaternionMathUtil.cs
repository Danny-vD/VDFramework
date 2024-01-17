using UnityEngine;

namespace VDFramework.Utility
{
	/// <summary>
	/// Contains helper functions for <see cref="Quaternion"/> math
	/// </summary>
	public static class QuaternionMathUtil
	{
		/// <summary>
		/// Checks if two quaternions are approximately the same
		/// </summary>
		/// <param name="lhs">The first quaternion to compare</param>
		/// <param name="rhs">The second quaternion to compare</param>
		/// <param name="precision">
		/// <para>An acceptable range for quaternions to still be counted as equal</para>
		/// <para>0.1 degree difference is a difference of 0.0000004f</para>
		/// </param>
		/// <credit>https://discussions.unity.com/t/how-do-i-compare-quaternions/47274/6</credit>
		public static bool IsApproximate(Quaternion lhs, Quaternion rhs, float precision = 0.0000004f)
		{
			// Dot returns 0.9999996 for a difference of 0.1 degree
			return 1 - Mathf.Abs(Quaternion.Dot(lhs, rhs)) < precision;
		}
	}
}