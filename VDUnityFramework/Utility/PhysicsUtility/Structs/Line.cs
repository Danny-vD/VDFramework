using UnityEngine;

namespace VDFramework.Utility.PhysicsUtility.Structs
{
	/// <summary>
	/// A simple struct that represents a line by holding 2 points
	/// </summary>
	public struct Line
	{
		/// <summary>
		/// The first point on the line, or the start of the line segment
		/// </summary>
		public Vector2 Point1 { get; set; }
		
		/// <summary>
		/// The second point on the line, or the end of the line segment
		/// </summary>
		public Vector2 Point2 { get; set; }

		/// <summary>
		/// Get the vector from <see cref="Point1"/> towards <see cref="Point2"/>
		/// </summary>
		public Vector2 LineVector => Point2 - Point1;
		
		/// <summary>
		/// Create a new line with the given points
		/// </summary>
		/// <param name="linePoint1">The first point on the line, or the start of the line segment</param>
		/// <param name="linePoint2">The second point on the line, or the end of the line segment</param>
		public Line(Vector2 linePoint1, Vector2 linePoint2)
		{
			Point1 = linePoint1;
			Point2 = linePoint2;
		}
	}
}