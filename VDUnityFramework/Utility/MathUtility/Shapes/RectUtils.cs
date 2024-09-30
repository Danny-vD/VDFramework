using UnityEngine;

namespace VDFramework.Utility.MathUtility.Shapes
{
	/// <summary>
	/// Provides helper functions for the <see cref="Rect"/> struct
	/// </summary>
	public static class RectUtils
	{
		/// <summary>
		/// Tests whether the given point is inside the rect
		/// </summary>
		/// <param name="rect">The rectangle to test against</param>
		/// <param name="point">The point to test against the rectangle</param>
		/// <param name="acceptPointOnRect">If true, the function will return true if the point is on the edge of the rectangle</param>
		/// <returns>TRUE or FALSE depending on if the given point falls within the rectangle</returns>
		public static bool IsPointWithinRect(Rect rect, Vector2 point, bool acceptPointOnRect)
		{
			float x = point.x;
			float y = point.y;
			
			if (acceptPointOnRect)
			{
				if (x < rect.xMin || x > rect.xMax || y < rect.yMin || y > rect.yMax)
				{
					return false;
				}
			}
			else
			{
				if (x <= rect.xMin || x >= rect.xMax || y <= rect.yMin || y >= rect.yMax)
				{
					return false;
				}
			}

			return true;
		}
		
		public static Rect GetBoundingBoxOfPolygon2D(Vector2[] polygon)
		{
			float minX = float.PositiveInfinity;
			float minY = float.PositiveInfinity;

			float maxX = float.NegativeInfinity;
			float maxY = float.NegativeInfinity;
			
			foreach (Vector2 vertex in polygon)
			{
				float x = vertex.x;
				float y = vertex.y;
				
				if (x < minX)
				{
					minX = x;
				}
				
				if (y < minY)
				{
					minY = y;
				}

				if (x > maxX)
				{
					maxX = x;
				}

				if (y > maxY)
				{
					maxY = y;
				}
			}

			return Rect.MinMaxRect(minX, minY, maxX, maxY);
		}
	}
}