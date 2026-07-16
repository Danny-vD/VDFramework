using System;
using System.Globalization;
using UnityEngine;

namespace VDFramework.Parsing
{
	/// <summary>
	/// A helper class to go from a <see cref="Vector3"/> and <see cref="Quaternion"/> to a string and vice versa
	/// </summary>
	public static class TransformParsingHelper
	{
		/// <summary>
		/// Parse the string representation of a <see cref="Vector3"/> back into a <see cref="Vector3"/>
		/// </summary>
		/// <remarks>String format: (X, Y, Z)</remarks>
		public static Vector3 VectorFromString(string vectorString, IFormatProvider formatProvider = null)
		{
			formatProvider ??= CultureInfo.InvariantCulture;
			
			string[] coordinates = vectorString.Split(',');

			float x = float.Parse(coordinates[0].TrimStart('('), formatProvider); // Remove the opening parenthesis
			float y = float.Parse(coordinates[1], formatProvider);
			float z = float.Parse(coordinates[2].TrimEnd(')'), formatProvider); // Remove the closing parenthesis

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Parse the string representation of a <see cref="Quaternion"/> back into a <see cref="Quaternion"/>
		/// </summary>
		/// <remarks>String format: (X, Y, Z, W)</remarks>
		public static Quaternion QuaternionFromString(string quaternionString, IFormatProvider formatProvider = null)
		{
			formatProvider ??= CultureInfo.InvariantCulture;
			
			string[] coordinates = quaternionString.Split(',');

			float x = float.Parse(coordinates[0].TrimStart('('), formatProvider); // Remove the opening parenthesis
			float y = float.Parse(coordinates[1], formatProvider);
			float z = float.Parse(coordinates[2], formatProvider);
			float w = float.Parse(coordinates[3].TrimEnd(')'), formatProvider); // Remove the closing parenthesis

			return new Quaternion(x, y, z, w);
		}
	}
}