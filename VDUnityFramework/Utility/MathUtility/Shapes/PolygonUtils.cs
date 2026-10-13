using System;
using System.Collections.Generic;
using UnityEngine;
using VDFramework.Extensions;
using VDFramework.Utility.DataTypes;
using VDFramework.Utility.MathUtility.VectorMath;
using VDFramework.Utility.PhysicsUtility;
using VDFramework.Utility.SpanUtility;

namespace VDFramework.Utility.MathUtility.Shapes
{
	/// <summary>
	/// Provides utility functions for working with polygons
	/// </summary>
	public static class PolygonUtils
	{
		/// <summary>
		/// Calculates the Area * 2 of the polygon, this is an in-between step when calculating the area of a polygon
		/// </summary>
		public static float CalculateAreaDouble(in ReadOnlySpan<Vector2> vertices)
		{
			float area2 = CalculateAreaPart(vertices[^1], vertices[0]); // The part from last vertex to the first

			int length = vertices.Length - 1;

			for (int i = 0; i < length; i++)
			{
				area2 += CalculateAreaPart(vertices[i], vertices[i + 1]);
			}

			return Math.Abs(area2);
		}

		/// <summary>
		/// Calculates the Area * 2 of the polygon, this is an in-between step when calculating the area of a polygon
		/// </summary>
		public static float CalculateAreaDouble(List<Vector2> vertices)
		{
			float area2 = CalculateAreaPart(vertices[^1], vertices[0]); // The part from last vertex to the first

			int length = vertices.Count - 1;

			for (int i = 0; i < length; i++)
			{
				area2 += CalculateAreaPart(vertices[i], vertices[i + 1]);
			}

			return Math.Abs(area2);
		}

		/// <summary>
		/// Returns the point inside the polygon that is closest to the given point or <paramref name="point"/> if the given point is inside the polygon
		/// </summary>
		public static Vector2 GetClosestPointInPolygon(in ReadOnlySpan<Vector2> vertices, in Vector2 point)
		{
			if (IsPointInPolygon(vertices, point, out bool _, out Vector2 closestPointOnEdge))
			{
				return point;
			}

			return closestPointOnEdge;
		}
		
		/// <summary>
		/// Test to see if a given point is within a polygon by modifying the polygon and checking if the area increased or decreased.<br/>
		/// Additionally it also returns the closest point on the edge of the polygon
		/// </summary>
		/// <theory>
		/// https://www.researchgate.net/publication/335796456_Modified-Polygon_Method_for_Point-in-Polygon_Problem<br/>
		/// https://www.researchgate.net/publication/342679727_Enhanced_Modified-Polygon_Method_for_Point-in-_Polygon_Problem
		/// </theory>
		public static bool IsPointInPolygon(in ReadOnlySpan<Vector2> vertices, in Vector2 point, out bool isOnEdge, out Vector2 closestPointOnEdge)
		{
			isOnEdge = false;

			if (vertices.Length < 3)
			{
				closestPointOnEdge = VectorProjectionUtil.ProjectPointOntoPolygonEdge(vertices, point, false);
				return false;
			}

			Rect boundingBox = RectUtils.GetBoundingBoxOfPolygon2D(vertices);

			if (!RectUtils.IsPointWithinRect(boundingBox, point, true))
			{
				closestPointOnEdge = VectorProjectionUtil.ProjectPointOntoPolygonEdge(vertices, point, true);
				return false;
			}

			float originalArea = CalculateAreaDouble(vertices);

			float closestDistance = Vector2.SqrMagnitude(vertices[0] - point);

			int vertexBeforeIndex = vertices.Length - 1;
			int closestVertexIndex = 0;
			int vertexAfterIndex = 1;

			for (int i = 1; i < vertices.Length; i++)
			{
				float distance = Vector2.SqrMagnitude(vertices[i] - point);

				if (distance < closestDistance)
				{
					closestDistance = distance;

					closestVertexIndex = i;

					vertexBeforeIndex = i - 1;
					vertexAfterIndex  = (i + 1) % vertices.Length;
				}
			}

			Vector2 closestVertex = vertices[closestVertexIndex];
			Vector2 vertexBefore = vertices[vertexBeforeIndex];

			bool vertexBeforeToPointIntersects = false; // Used to determine whether we should use vertexBefore or vertexAfter
			int vertexAtIntersection = -1;

			double closestIntersectionDistance = double.PositiveInfinity;

			closestPointOnEdge = vertices[0];
			float closestDistanceToEdgePoint = float.PositiveInfinity; // Used to determine the closest point on the edge

			for (int i = 0; i < vertices.Length; i++)
			{
				int nextIndex = i + 1;

				if (nextIndex >= vertices.Length)
				{
					nextIndex = 0;
				}

				Vector2 vertex = vertices[i];
				Vector2 vertex2 = vertices[nextIndex];

				Vector2 projectedPoint = VectorProjectionUtil.ProjectPointOntoLine(vertex, vertex2, point, true, out _);
				float distanceToProjectedPoint = Vector2.SqrMagnitude(projectedPoint - point);

				if (distanceToProjectedPoint < closestDistanceToEdgePoint)
				{
					closestDistanceToEdgePoint = distanceToProjectedPoint;
					closestPointOnEdge         = projectedPoint;
				}

				// Check if the line from the point to the closest vertex intersects with the polygon
				if (IntersectionUtils.TryGetIntersection(point, closestVertex, vertex, vertex2, true, false, out Vector2 intersection, out _))
				{
					double sqrDistanceToIntersection = (intersection - point).sqrMagnitude;

					// If so, grab the nearest intersection and use those vertices instead
					if (sqrDistanceToIntersection < closestIntersectionDistance)
					{
						vertexAtIntersection = i;

						Vector2 lineToFirstVertex = vertex - point;
						Vector2 lineToSecondVertex = vertex2 - point;

						if (lineToSecondVertex.sqrMagnitude < lineToFirstVertex.sqrMagnitude)
						{
							closestVertexIndex = nextIndex;

							vertexBeforeIndex = i;
							vertexAfterIndex  = (nextIndex + 1) % vertices.Length;

							vertexBefore = vertices[vertexBeforeIndex];
						}
						else
						{
							closestVertexIndex = i;

							vertexBeforeIndex = i == 0 ? vertices.Length - 1 : i - 1;
							vertexAfterIndex  = nextIndex;

							vertexBefore = vertices[vertexBeforeIndex];
						}

						vertexBeforeToPointIntersects = false;

						closestIntersectionDistance = sqrDistanceToIntersection;
					}
				}

				if (!vertexBeforeToPointIntersects)
				{
					if (IntersectionUtils.TryGetIntersection(vertexBefore, point, vertex, vertex2, true, false, out _, out _))
					{
						vertexBeforeToPointIntersects = true;
					}
				}
			}

			if (!vertexBeforeToPointIntersects)
			{
				for (int i = 0; i < vertexAtIntersection; i++)
				{
					if (IntersectionUtils.TryGetIntersection(vertexBefore, point, vertices[i], vertices[i + 1], true, false, out _, out _))
					{
						vertexBeforeToPointIntersects = true;
						break;
					}
				}
			}

			Span<Vector2> modifiedVertices = stackalloc Vector2[vertices.Length + 1];

			int insertionIndex = vertexBeforeToPointIntersects ? vertexAfterIndex : closestVertexIndex;
			SpanUtil.Insert(vertices, modifiedVertices, insertionIndex, point);

			float newArea = CalculateAreaDouble(modifiedVertices);

			if (FloatUtil.LesserThanOrClose(newArea, originalArea, out bool areClose))
			{
				if (areClose) // The area stayed the same so the point must be on the edge
				{
					isOnEdge           = true;
					closestPointOnEdge = point;
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// Draws the polygon using <see cref="Debug.DrawLine(Vector3, Vector3, Color, float, bool)"/>
		/// </summary>
		public static void DebugDrawPolygon(in ReadOnlySpan<Vector2> vertices, Color colour, float duration, bool depthTest, bool connectLastVertexToFirst = true)
		{
			for (int j = 1; j < vertices.Length; j++)
			{
				Debug.DrawLine(vertices[j - 1], vertices[j], colour, duration, depthTest);
			}

			if (connectLastVertexToFirst)
			{
				Debug.DrawLine(vertices[^1], vertices[0], colour, duration, depthTest);
			}
		}
		
		private static float CalculateAreaPart(in Vector2 point1, in Vector2 point2)
		{
			return point1.x * point2.y - point1.y * point2.x;
		}

		//\\//\\//\\//
		//	3D Logic
		//\\//\\//\\//

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

				Vector3 pointOnLine = VectorProjectionUtil.ProjectPointOntoLineBetweenPoints(vertex, nextVertex, point, true, out _);
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
	}
}