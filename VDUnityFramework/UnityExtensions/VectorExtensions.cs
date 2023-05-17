using System;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains Extension methods for Vectors
	/// </summary>
	public static class VectorExtensions
	{
		/// <summary>
		/// Return the absolute value of this vector
		/// </summary>
		public static Vector2 Abs(this Vector2 vector)
		{
			return new Vector2(Math.Abs(vector.x), Math.Abs(vector.y));
		}
		
		/// <summary>
		/// Return the absolute value of this vector
		/// </summary>
		public static Vector2Int Abs(this Vector2Int vector)
		{
			return new Vector2Int(Math.Abs(vector.x), Math.Abs(vector.y));
		}
		
		/// <summary>
		/// Return the absolute value of this vector
		/// </summary>
		public static Vector3 Abs(this Vector3 vector)
		{
			return new Vector3(Math.Abs(vector.x), Math.Abs(vector.y), Math.Abs(vector.z));
		}
		
		/// <summary>
		/// Return the absolute value of this vector
		/// </summary>
		public static Vector3Int Abs(this Vector3Int vector)
		{
			return new Vector3Int(Math.Abs(vector.x), Math.Abs(vector.y), Math.Abs(vector.z));
		}
		
		/// <summary>
		/// Return the absolute value of this vector
		/// </summary>
		public static Vector4 Abs(this Vector4 vector)
		{
			return new Vector4(Math.Abs(vector.x), Math.Abs(vector.y), Math.Abs(vector.z), Math.Abs(vector.w));
		}
	}
}