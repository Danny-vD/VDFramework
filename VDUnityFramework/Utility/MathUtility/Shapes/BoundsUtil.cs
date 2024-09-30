using UnityEngine;

namespace VDFramework.Utility.MathUtility.Shapes
{
	/// <summary>
	/// Provides helper functions for the <see cref="Bounds"/> struct
	/// </summary>
	public static class BoundsUtils
	{
		/// <summary>
		/// Tests whether the given point is inside the bounds
		/// </summary>
		/// <param name="bounds">The bounds to test against</param>
		/// <param name="point">The point to test against the bounds</param>
		/// <param name="acceptPointOnEdge">If true, the function will return true if the point is on the edge of the bounds</param>
		/// <returns>TRUE or FALSE depending on if the given point falls within the bounds</returns>
		public static bool IsPointWithinBounds(Bounds bounds, Vector3 point, bool acceptPointOnEdge)
		{
			float x = point.x;
			float y = point.y;
			float z = point.z;

			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			
			if (acceptPointOnEdge)
			{
				if (x < min.x || x > max.x || y < min.y || y > max.y || z < min.z || z > max.z)
				{
					return false;
				}
			}
			else
			{
				if (x <= min.x || x >= max.x || y <= min.y || y >= max.y || z <= min.z || z >= max.z)
				{
					return false;
				}
			}

			return true;
		}
		
		public static Bounds GetBoundingBoxOfPolygon(Vector3[] polygon)
		{
			float minX = float.PositiveInfinity;
			float minY = float.PositiveInfinity;
			float minZ = float.NegativeInfinity;

			float maxX = float.NegativeInfinity;
			float maxY = float.NegativeInfinity;
			float maxZ = float.NegativeInfinity;

			foreach (Vector3 vertex in polygon)
			{
				float x = vertex.x;
				float y = vertex.y;
				float z = vertex.z;
				
				if (x < minX)
				{
					minX = x;
				}
				
				if (y < minY)
				{
					minY = y;
				}

				if (z < minZ)
				{
					minZ = z;
				}

				if (x > maxX)
				{
					maxX = x;
				}

				if (y > maxY)
				{
					maxY = y;
				}

				if (z > maxZ)
				{
					maxZ = z;
				}
			}

			Vector3 min = new Vector3(minX, minY, minZ);
			Vector3 max = new Vector3(maxX, maxY, maxZ);
			
			Bounds bounds = new Bounds();
			bounds.SetMinMax(min, max);

			return bounds;
		}
	}
}