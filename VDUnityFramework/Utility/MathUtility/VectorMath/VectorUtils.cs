using System.Runtime.CompilerServices;
using UnityEngine;

namespace VDFramework.Utility.MathUtility.VectorMath
{
	/// <summary>
	/// Contains utility functions for Vectors
	/// </summary>
	public static class VectorUtils
	{
		/// <summary>
		/// Normalize the given Vector and return the length as an out-parameter
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Normalize(Vector3 vector, out float length)
		{
			length = Vector3.Magnitude(vector);
			return length > 9.999999747378752E-06 ? vector / length : Vector3.zero; // Identical to Unity's implementation
		}
		
		/// <summary>
		/// Normalize the given Vector and return the length as an out-parameter
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Normalize(Vector2 vector, out float length)
		{
			length = vector.magnitude;
			return length > 9.999999747378752E-06 ? vector / length : Vector2.zero; // Identical to Unity's implementation
		}
		
		public static bool Approximately(in Vector2 lhs, in Vector2 rhs)
		{
			return Mathf.Approximately(lhs.x, rhs.x) && Mathf.Approximately(lhs.y, rhs.y);
		}
	}
}