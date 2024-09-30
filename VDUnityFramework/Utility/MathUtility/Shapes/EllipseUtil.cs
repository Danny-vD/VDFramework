using UnityEngine;
using VDFramework.UnityExtensions;

namespace VDFramework.Utility.MathUtility.Shapes
{
	public static class EllipseUtil
	{
		private const float sqrtPointFive = 0.70710678118654752440084436210485f; // Mathf.Sqrt(0.5f);

		/// <summary>
		/// Tests whether the given point is within the axis-alligned ellipse
		/// </summary>
		/// <param name="origin">The centre of the ellipse</param>
		/// <param name="xRadius">The radius of the x side of the ellipse</param>
		/// <param name="yRadius">The radius of the y side of the ellipse</param>
		/// <param name="point">The point to check against the ellipse</param>
		/// <param name="acceptPointOnEdge">If the point is on the edge, should the function still return true?</param>
		/// <param name="pointIsOnEdge">Whether or not the point is located on the edge of the ellipse</param>
		/// <returns>Whether or not the point is inside the ellipse</returns>
		/// <credit>https://math.stackexchange.com/a/243525</credit>
		public static bool IsPointWithinEllipse(Vector2 origin, float xRadius, float yRadius, Vector2 point, bool acceptPointOnEdge, out bool pointIsOnEdge)
		{
			float factor = xRadius / yRadius;

			Vector2 delta = point - origin; // Translate everything back by origin so that the ellipse is centered around the world origin

			if (delta.magnitude > Mathf.Max(xRadius, yRadius)) // If the point is further away than the biggest radius, it can never be within the ellipse
			{
				pointIsOnEdge = false;
				return false;
			}

			delta.y *= factor;

			float length = delta.magnitude;

			pointIsOnEdge = Mathf.Approximately(length, xRadius);

			if (acceptPointOnEdge)
			{
				return length <= xRadius;
			}

			return length < xRadius;
		}

		/// <summary>
		/// Returns the axis-alligned bounding-box of the given ellipse
		/// </summary>
		/// <param name="origin">The centre of the ellipse</param>
		/// <param name="xRadius">The radius of the x side of the ellipse</param>
		/// <param name="yRadius">The radius of the y side of the ellipse</param>
		/// <returns>The bounding box of the ellipse</returns>
		public static Rect GetBoundingBoxOfEllipse(Vector2 origin, float xRadius, float yRadius)
		{
			return Rect.MinMaxRect(origin.x - xRadius, origin.y - yRadius, origin.x + xRadius, origin.y + yRadius);
		}

		/// <summary>
		/// Projects a point onto the ellipse and returns the point on the epplipse, optionally returns the point itself if it is within the ellipse
		/// </summary>
		/// <param name="origin">The centre of the ellipse</param>
		/// <param name="xRadius">The radius of the x side of the ellipse</param>
		/// <param name="yRadius">The radius of the y side of the ellipse</param>
		/// <param name="point">The point to project on the ellipse</param>
		/// <param name="returnPointIfWithinEllipse">If the point falls within the ellipse, should the point itself be returned?</param>
		/// <returns>A point on the edge of the ellipse, closest to the given point. Or, optionally, the given point if it falls within the ellipse</returns>
		/// <credit>https://gist.github.com/JohannesMP/777bdc8e84df6ddfeaa4f0ddb1c7adb3</credit>
		public static Vector2 ProjectPointOntoEllipse(Vector2 origin, float xRadius, float yRadius, Vector2 point, bool returnPointIfWithinEllipse)
		{
			if (returnPointIfWithinEllipse && IsPointWithinEllipse(origin, xRadius, yRadius, point, true, out _))
			{
				return point;
			}

			point -= origin; // Translate everything back by origin so that the ellipse is centered around the world origin

			Vector2 absPoint = point.Abs();

			float xRadiusSquared = xRadius * xRadius;
			float yRadiusSquared = yRadius * yRadius;

			float tx = sqrtPointFive;
			float ty = sqrtPointFive;

			for (int i = 0; i < 3; i++)
			{
				float x = xRadius * tx;
				float y = yRadius * ty;

				float ex = (xRadiusSquared - yRadiusSquared) * (tx * tx * tx) / xRadius;
				float ey = (yRadiusSquared - xRadiusSquared) * (ty * ty * ty) / xRadius;

				float rx = x - ex;
				float ry = y - ey;

				float qx = absPoint.x - ex;
				float qy = absPoint.y - ey;

				float r = Mathf.Sqrt(rx * rx + ry * ry);
				float q = Mathf.Sqrt(qy * qy + qx * qx);

				tx = Mathf.Min(1, Mathf.Max(0, (qx * r / q + ex) / xRadius));
				ty = Mathf.Min(1, Mathf.Max(0, (qy * r / q + ey) / yRadius));

				float t = Mathf.Sqrt(tx * tx + ty * ty);

				tx /= t;
				ty /= t;
			}
			
			Vector2 returnValue = new Vector2
			{
				x = xRadius * (point.x < 0 ? -tx : tx),
				y = yRadius * (point.y < 0 ? -ty : ty),
			};

			returnValue += origin;

			return returnValue;
		}
		
		/// <summary>
		/// Calculates the distance from the given point to the ellipse, or optionally the distance from the point to the edge of the ellipse if the point falls within the ellipse
		/// </summary>
		/// <param name="origin">The centre of the ellipse</param>
		/// <param name="semiMajor">The radius of the longest side of the ellipse</param>
		/// <param name="semiMinor">The radius of the shortest side of the ellipse</param>
		/// <param name="point">The point to project on the ellipse</param>
		/// <param name="measureDistanceToEdgeIfWithinEllipse">If the point falls within the ellipse, should the distance to the edge be calculated?</param>
		/// <returns>The distance from the given point to the ellipse</returns>
		public static float GetDistanceToEllipse(Vector2 origin, float semiMajor, float semiMinor, Vector2 point, bool measureDistanceToEdgeIfWithinEllipse)
		{
			Vector2 projectedPoint = ProjectPointOntoEllipse(origin, semiMajor, semiMinor, point, !measureDistanceToEdgeIfWithinEllipse);

			return Vector2.Distance(projectedPoint, point);
		}
	}
}