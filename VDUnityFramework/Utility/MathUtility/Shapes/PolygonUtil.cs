using System;
using UnityEngine;
using VDFramework.Utility.MathUtility.VectorMath;

namespace VDFramework.Utility.MathUtility.Shapes
{
	public static class PolygonUtil
	{
		public static bool IsPointWithinPolygon2D(Vector2[] polygon, Vector2 point, bool acceptPointOnEdge)
		{
			Rect boundingBox = RectUtils.GetBoundingBoxOfPolygon2D(polygon);

			if (!RectUtils.IsPointWithinRect(boundingBox, point, acceptPointOnEdge)) // If the point is not in the bounding box of the polygon then it can never be within the polygon
			{
				return false;
			}

			return JordanCurveTheorem2D(polygon, point, acceptPointOnEdge);
		}
		
		public static bool IsPointWithinPolygon(Vector3[] polygon, Vector3 point, bool acceptPointOnEdge)
		{
			Bounds boundingBox = BoundsUtils.GetBoundingBoxOfPolygon(polygon);

			if (!BoundsUtils.IsPointWithinBounds(boundingBox, point, acceptPointOnEdge)) // If the point is not in the bounding box of the polygon then it can never be within the polygon
			{
				return false;
			}

			return JordanCurveTheorem(polygon, point, acceptPointOnEdge);
		}
		
		/// <summary>
		/// Projects a point onto the polygon and returns the point on the polygon, optionally returns the point itself if it is within the polygon
		/// </summary>
		/// <param name="polygon">An array of vertices of the polygon</param>
		/// <param name="point">The point to project onto the polygon</param>
		/// <param name="returnPointIfWithinPolygon">If the point falls within the polygon, should the point itself be returned?</param>
		/// <returns>A point on the edge of the polygon, closest to the given point. Or, optionally, the given point if it falls within the polygon</returns>
		public static Vector2 ProjectPointOntoPolygon2D(Vector2[] polygon, Vector2 point, bool returnPointIfWithinPolygon)
		{
			int vertexCount = polygon.Length;

			switch (vertexCount)
			{
				case 0:
					throw new ArgumentException("The given polygon does not contain any vertices", nameof(polygon));
				case 1:
					return polygon[0];
			}

			if (returnPointIfWithinPolygon && IsPointWithinPolygon2D(polygon, point, true))
			{
				return point;
			}

			Vector2[] closestPoints = new Vector2[vertexCount];

			for (int i = 0; i < vertexCount; i++)
			{
				int nextIndex = i + 1;

				if (nextIndex >= vertexCount)
				{
					nextIndex = 0;
				}

				Vector2 vertex = polygon[i];
				Vector2 nextVertex = polygon[nextIndex];

				Vector2 pointOnLine = VectorProjectionUtil.ProjectPointOntoLineBetweenPoints(vertex, nextVertex, point, true);
				closestPoints[i] = pointOnLine;
			}

			Vector2 closestPoint = default;
			float closestDistance = int.MaxValue;

			foreach (Vector2 potentionalClosest in closestPoints)
			{
				Vector2 delta = point - potentionalClosest;
				float distance = delta.sqrMagnitude;

				if (distance < closestDistance)
				{
					closestPoint    = potentionalClosest;
					closestDistance = distance;
				}
			}

			return closestPoint;
		}

		/// <summary>
		/// Projects a point onto the polygon and returns the point on the polygon, optionally returns the point itself if it is within the polygon
		/// </summary>
		/// <param name="polygon">An array of vertices of the polygon</param>
		/// <param name="point">The point to project onto the polygon</param>
		/// <param name="returnPointIfWithinPolygon">If the point falls within the polygon, should the point itself be returned?</param>
		/// <returns>A point on the edge of the polygon, closest to the given point. Or, optionally, the given point if it falls within the polygon</returns>
		public static Vector3 ProjectPointOntoPolygon(Vector3[] polygon, Vector3 point, bool returnPointIfWithinPolygon) // note: it should project onto the face of the polygon as well
		{
			int vertexCount = polygon.Length;

			switch (vertexCount)
			{
				case 0:
					throw new ArgumentException("The given polygon does not contain any vertices", nameof(polygon));
				case 1:
					return polygon[0];
			}

			if (returnPointIfWithinPolygon && IsPointWithinPolygon(polygon, point, true))
			{
				return point;
			}

			Vector3[] closestPoints = new Vector3[vertexCount];

			for (int i = 0; i < vertexCount; i++)
			{
				int nextIndex = i + 1;

				if (nextIndex >= vertexCount)
				{
					nextIndex = 0;
				}

				Vector3 vertex = polygon[i];
				Vector3 nextVertex = polygon[nextIndex];

				Vector3 pointOnLine = VectorProjectionUtil.ProjectPointOntoLineBetweenPoints(vertex, nextVertex, point, true);
				closestPoints[i] = pointOnLine;
			}

			Vector3 closestPoint = default;
			float closestDistance = int.MaxValue;

			foreach (Vector3 potentionalClosest in closestPoints)
			{
				Vector3 delta = point - potentionalClosest;
				float distance = delta.sqrMagnitude;

				if (distance < closestDistance)
				{
					closestPoint    = potentionalClosest;
					closestDistance = distance;
				}
			}

			return closestPoint;
		}

		private static bool JordanCurveTheorem2D(Vector2[] polygon, Vector2 point, bool acceptPointOnEdge)
		{
			bool inside = false;

			for (int i = 0, previousIndex = polygon.Length - 1; i < polygon.Length; i++)
			{
				Vector2 vertex = polygon[i];
				Vector2 previousVertex = polygon[previousIndex];

				if (acceptPointOnEdge)
				{
					if ((vertex.y <= point.y && point.y < previousVertex.y || previousVertex.y <= point.y && point.y < vertex.y) &&
						point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x)
					{
						inside = !inside;
					}
				}
				else
				{
					if ((vertex.y < point.y && point.y < previousVertex.y || previousVertex.y < point.y && point.y < vertex.y) &&
						point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x)
					{
						inside = !inside;
					}
				}

				previousIndex = i;
			}

			return inside;
		}

		private static bool AnotherJordanCurveTheorem2D(Vector2[] polygon, Vector2 point)
		{
			bool inside = false;

			for (int i = 0, previousVertexIndex = polygon.Length - 1; i < polygon.Length; i++)
			{
				Vector2 vertex = polygon[i];
				Vector2 previousVertex = polygon[previousVertexIndex];

				if (vertex.y > point.y != previousVertex.y > point.y &&
					point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x)
				{
					inside = !inside;
				}

				previousVertexIndex = i;
			}

			return inside;
		}

		private static bool JordanCurveTheorem(Vector3[] polygon, Vector3 point, bool acceptPointOnEdge) // Note: mistake in here somewhere? it gives false positives
		{
			bool inside = false;

			for (int i = 0, previousIndex = polygon.Length - 1; i < polygon.Length; i++)
			{
				Vector3 vertex = polygon[i];
				Vector3 previousVertex = polygon[previousIndex];

				if (acceptPointOnEdge)
				{
					if ((vertex.y <= point.y && point.y < previousVertex.y || previousVertex.y <= point.y && point.y < vertex.y) &&
						point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x &&
						point.z < (previousVertex.z - vertex.z) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.z)
					{
						inside = !inside;
					}
				}
				else
				{
					if ((vertex.y < point.y && point.y < previousVertex.y || previousVertex.y < point.y && point.y < vertex.y) &&
						point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x &&
						point.z < (previousVertex.z - vertex.z) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.z)
					{
						inside = !inside;
					}
				}

				previousIndex = i;
			}

			return inside;
		}

		private static bool AnotherJordanCurveTheorem(Vector3[] polygon, Vector3 point)
		{
			bool inside = false;

			for (int i = 0, previousVertexIndex = polygon.Length - 1; i < polygon.Length; i++)
			{
				Vector3 vertex = polygon[i];
				Vector3 previousVertex = polygon[previousVertexIndex];

				if (vertex.y > point.y != previousVertex.y > point.y && 
					point.x < (previousVertex.x - vertex.x) * (point.y - vertex.y) / (previousVertex.y - vertex.y) + vertex.x)
				{
					inside = !inside;
				}

				previousVertexIndex = i;
			}

			return inside;
		}
	}
}