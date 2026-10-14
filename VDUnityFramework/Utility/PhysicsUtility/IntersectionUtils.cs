using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using VDFramework.Utility.DataTypes;
using VDFramework.Utility.MathUtility.Shapes;
using VDFramework.Utility.MathUtility.VectorMath;
using VDFramework.Utility.PhysicsUtility.Structs;

namespace VDFramework.Utility.PhysicsUtility
{
	/// <summary>
	/// Provides helper functions to get the intersection points with given shapes
	/// </summary>
	public static class IntersectionUtils
	{
		/// <summary>
		/// Find the intersection between 2 lines
		/// </summary>
		/// <param name="line1Point1">The first point on line 1, or the start of the line segment</param>
		/// <param name="line1Point2">The second point on line 1, or the end of the line segment</param>
		/// <param name="line2Point1">The first point on line 2, or the start of the line segment</param>
		/// <param name="line2Point2">The second point on line 2, or the end of the line segment</param>
		/// <param name="useLineSegments">If true, the lines will be treated as line-segments. An intersection outside of the lines will return false</param>
		/// <param name="intersectAtEndPoints">If false, the function will return false if the intersection is exactly at the end of a line. Only applicable with <paramref name="useLineSegments"/>=true</param>
		/// <param name="intersection">The point of the intersection between the lines or <see cref="float.NaN"/> if no intersection is found (even when using line segments, this still returns the point of the intersection of infinite lines)</param>
		/// <param name="normalizedDistanceLine1">The normalized distance along line 1 towards the intersection or <see cref="float.NaN"/> if no intersection is found</param>
		/// <returns>Whether the 2 lines intersect</returns>
		public static bool TryGetIntersection(in Vector2 line1Point1, in Vector2 line1Point2, in Vector2 line2Point1, in Vector2 line2Point2, bool useLineSegments, bool intersectAtEndPoints, out Vector2 intersection, out float normalizedDistanceLine1)
		{
			Vector2 line1 = line1Point2 - line1Point1;
			Vector2 line2 = line2Point2 - line2Point1;

			// z-coordinate of the cross product represents the determinant
			float denominator = line1.x * line2.y - line1.y * line2.x;

			// If denominator is 0, lines are parallel or collinear (same straight line)
			if (FloatUtil.AreClose(denominator, 0))
			{
				normalizedDistanceLine1 = float.NaN;
				intersection            = new Vector2(float.NaN, float.NaN);

				return false;
			}

			Vector2 lineBetweenLineStarts = line2Point1 - line1Point1;

			// Calculate parametric values for the intersection point
			normalizedDistanceLine1 = (lineBetweenLineStarts.x * line2.y - lineBetweenLineStarts.y * line2.x) / denominator;
			float normalizedDistanceLine2 = (lineBetweenLineStarts.x * line1.y - lineBetweenLineStarts.y * line1.x) / denominator;

			intersection = line1Point1 + normalizedDistanceLine1 * line1; // Can also be done using line 2, they give the same result

			// If checking finite segments, ensure t1 and t2 fall between 0 and 1
			if (useLineSegments)
			{
				if (!intersectAtEndPoints) // If we don't allow endpoints to intersect, check against 0 and 1 as well
				{
					if (FloatUtil.LesserThanOrClose(normalizedDistanceLine1, 0) || FloatUtil.GreaterThanOrClose(normalizedDistanceLine1, 1))
					{
						return false;
					}

					if (FloatUtil.LesserThanOrClose(normalizedDistanceLine2, 0) || FloatUtil.GreaterThanOrClose(normalizedDistanceLine2, 1))
					{
						return false;
					}
				}
				else
				{
					if (FloatUtil.LessThan(normalizedDistanceLine1, 0) || FloatUtil.GreaterThan(normalizedDistanceLine1, 1))
					{
						return false;
					}

					if (FloatUtil.LessThan(normalizedDistanceLine2, 0) || FloatUtil.GreaterThan(normalizedDistanceLine2, 1))
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Determine all intersection points between <paramref name="lines"/> and <paramref name="collider"/> and add them to the <paramref name="intersectionPoints"/> lists<br/>
		/// Also determine the closest points on every physics shape to <paramref name="referencePoint"/> and return those in <paramref name="closestPoints"/><br/>
		/// Both lists will be sorted by distance to <paramref name="referencePoint"/> (closest first)
		/// </summary>
		/// <param name="lines">The lines to check against the collider</param>
		/// <param name="collider">The collider to check against</param>
		/// <param name="physicsShapeGroup2D">A <see cref="PhysicsShapeGroup2D"/> that will be used to hold the physics shapes of the collider</param>
		/// <param name="referencePoint">A point used to sort the intersections by distance and to determine the closest point</param>
		/// <param name="intersectionPoints">All intersection points with the collider, sorted so that the closest points (to <paramref name="referencePoint"/>) are first in the list</param>
		/// <param name="closestPoints">The closest point on every physics shape, sorted so that the closest points (to <paramref name="referencePoint"/>) are first in the list</param>
		public static void AddAllIntersectPointsWithCollider(in ReadOnlySpan<Line> lines, Collider2D collider, PhysicsShapeGroup2D physicsShapeGroup2D, Vector2 referencePoint, List<Vector2> intersectionPoints, List<Vector2> closestPoints)
		{
			if (lines.Length == 0)
			{
				return;
			}

			int shapeCount = collider.GetShapes(physicsShapeGroup2D);

			if (shapeCount == 0)
			{
				return;
			}

			bool isLocalSpace = collider.attachedRigidbody != null; // Has a rigidbody, so the vertices are in local space 

			Span<Line> transformedLines = stackalloc Line[lines.Length]; // Array assigned on the stack

			if (isLocalSpace)
			{
				for (int i = 0; i < transformedLines.Length; i++)
				{
					Line line = lines[i];

					Vector2 linePoint1Transformed = collider.transform.InverseTransformPoint(line.Point1); // Because the vertices are in local space, we turn our line into local space as well
					Vector2 linePoint2Transformed = collider.transform.InverseTransformPoint(line.Point2); // This is cheaper than turning every vertex into world space (2 operations per line vs however many vertices)
					transformedLines[i] = new Line(linePoint1Transformed, linePoint2Transformed);
				}
			}
			else
			{
				for (int i = 0; i < transformedLines.Length; i++)
				{
					// No need to actually transform anything, but by assigning the original we can use the same variable later
					transformedLines[i] = lines[i];
				}
			}

			NativeArray<PhysicsShape2D> shapes = new NativeArray<PhysicsShape2D>(shapeCount, Allocator.Temp);
			NativeArray<Vector2> vertices = new NativeArray<Vector2>(physicsShapeGroup2D.vertexCount, Allocator.Temp);

			physicsShapeGroup2D.GetShapeData(shapes, vertices);

			int intersectionPointsLengthOriginal = intersectionPoints.Count;
			int closestPointsLengthOriginal = closestPoints.Count;

			ReadOnlySpan<Vector2> allVertices = vertices.AsReadOnlySpan();

			for (int i = 0; i < shapes.Length; i++)
			{
				PhysicsShape2D currentShape = shapes[i];
				ReadOnlySpan<Vector2> shapeVertices = allVertices.Slice(currentShape.vertexStartIndex, currentShape.vertexCount);

				switch (currentShape.shapeType)
				{
					case PhysicsShapeType2D.Circle:
						Vector2 circleCentre = shapeVertices[0]; // Circle always has 1 vertex (the centre)

						float radiusSquared = currentShape.radius * currentShape.radius;

						AddIntersectionPointsCircle(intersectionPoints, transformedLines, circleCentre, radiusSquared);

						closestPoints.Add(GetClosestPointInCircle(referencePoint, circleCentre, radiusSquared, currentShape.radius));
						break;
					case PhysicsShapeType2D.Capsule:
						AddIntersectionPointsCapsule(intersectionPoints, transformedLines, shapeVertices, currentShape.radius, referencePoint, out Vector2 closestPoint);

						closestPoints.Add(closestPoint);
						break;
					case PhysicsShapeType2D.Polygon:

						AddIntersectionPointsPolygon(intersectionPoints, transformedLines, true, shapeVertices);

						closestPoints.Add(PolygonUtils.GetClosestPointInPolygon(shapeVertices, referencePoint));
						break;
					case PhysicsShapeType2D.Edges:

						AddIntersectionPointsPolygon(intersectionPoints, transformedLines, false, shapeVertices);

						closestPoints.Add(VectorProjectionUtil.ProjectPointOntoPolygonEdge(shapeVertices, referencePoint, false));
						break;
					default:
						Debug.LogWarning($"Collider {collider.gameObject.name} contains an unknown shape!\nShape index: {i}");
						break;
				}
			}

			shapes.Dispose();
			vertices.Dispose();

			if (isLocalSpace)
			{
				for (int i = intersectionPointsLengthOriginal; i < intersectionPoints.Count; i++) // Only tranform the points that are newly added
				{
					intersectionPoints[i] = collider.transform.TransformPoint(intersectionPoints[i]);
				}

				for (int i = closestPointsLengthOriginal; i < closestPoints.Count; i++) // Only tranform the points that are newly added
				{
					closestPoints[i] = collider.transform.TransformPoint(closestPoints[i]);
				}
			}

			intersectionPoints.Sort(ClosestToPointComparison);
			closestPoints.Sort(ClosestToPointComparison);
			return;

			int ClosestToPointComparison(Vector2 lhs, Vector2 rhs)
			{
				return Vector2.SqrMagnitude(referencePoint - lhs).CompareTo(Vector2.SqrMagnitude(referencePoint - rhs));
			}
		}

		public static void AddIntersectionPointsPolygon(List<Vector2> intersectionPoints, in Span<Line> lines, bool isPolygon, in ReadOnlySpan<Vector2> vertices)
		{
			int length = vertices.Length;

			for (int i = 1; i < length; i++)
			{
				AddIntersectionsToList(lines, vertices[i - 1], vertices[i], true, intersectionPoints);
			}

			if (isPolygon)
			{
				AddIntersectionsToList(lines, vertices[length - 1], vertices[0], true, intersectionPoints);
			}
		}

		public static void AddIntersectionPointsCapsule(List<Vector2> intersectionPoints, in Span<Line> lines, in ReadOnlySpan<Vector2> vertices, float radius, Vector2 point, out Vector2 closestPoint)
		{
			Vector2 circle1Centre = vertices[0];
			Vector2 circle2Centre = vertices[1];

			Vector2 capsuleVector = circle2Centre - circle1Centre;
			Vector2 normal = Vector2.Perpendicular(in capsuleVector).normalized;

			Vector2 circle1LeftBound = circle1Centre + normal * radius;
			Vector2 circle1RightBound = circle1Centre - normal * radius;

			Vector2 circle2LeftBound = circle2Centre + normal * radius;
			Vector2 circle2RightBound = circle2Centre - normal * radius;

			AddIntersectionsToList(lines, circle1LeftBound, circle1RightBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle1RightBound, circle2RightBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle2RightBound, circle2LeftBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle2LeftBound, circle1LeftBound, true, intersectionPoints);

			float radiusSquared = radius * radius;

			AddIntersectionPointsCircle(intersectionPoints, lines, circle1Centre, radiusSquared);
			AddIntersectionPointsCircle(intersectionPoints, lines, circle2Centre, radiusSquared);

			Span<Vector2> closestPoints = stackalloc Vector2[2];

			closestPoint = GetClosestPointInCircle(point, circle1Centre, radiusSquared, radius);
			float sqrDistanceToClosestPoint = Vector2.SqrMagnitude(closestPoint - point);

			closestPoints[0] = GetClosestPointInCircle(point, circle2Centre, radiusSquared, radius);

			ReadOnlySpan<Vector2> boxVertices = stackalloc Vector2[4] { circle1LeftBound, circle1RightBound, circle2RightBound, circle2LeftBound };

			closestPoints[1] = PolygonUtils.GetClosestPointInPolygon(boxVertices, point);

			for (int i = 0; i < closestPoints.Length; i++)
			{
				Vector2 potentialClosest = closestPoints[i];

				float sqrDistanceToPotentialClosest = Vector2.SqrMagnitude(potentialClosest - point);

				if (sqrDistanceToPotentialClosest < sqrDistanceToClosestPoint)
				{
					sqrDistanceToClosestPoint = sqrDistanceToPotentialClosest;
					closestPoint              = potentialClosest;
				}
			}
		}

		/// <summary>
		/// Gets the intersection point between the given lines and the circle and adds them to the <paramref name="intersectionPoints"/> list
		/// </summary>
		/// <credits>https://stackoverflow.com/a/1084899</credits>
		public static void AddIntersectionPointsCircle(List<Vector2> intersectionPoints, in Span<Line> lines, in Vector2 circleCentre, float radiusSquared)
		{
			foreach (Line line in lines)
			{
				Vector2 E = line.Point1;
				Vector2 C = circleCentre;

				Vector2 d = line.LineVector;
				Vector2 f = E - C;

				float a = d.sqrMagnitude;

				if (FloatUtil.AreClose(a, 0)) // Cannot intersect with a line with length 0
				{
					continue;
				}

				float b = 2 * Vector2.Dot(f, d);
				float c = f.sqrMagnitude - radiusSquared;

				float discriminant = b * b - 4 * a * c;

				if (discriminant < 0)
				{
					// no intersection
					continue;
				}

				// ray didn't totally miss sphere,
				// so there is a solution to
				// the equation.

				discriminant = Mathf.Sqrt(discriminant);

				// either solution may be on or off the ray so need to test both
				// t1 is always the smaller value, because BOTH discriminant and
				// a are nonnegative.
				float t1 = (-b - discriminant) / (2 * a);
				float t2 = (-b + discriminant) / (2 * a);

				// 3x HIT cases:
				//          -o->             --|-->  |            |  --|->
				// Impale(t1 hit,t2 hit), Poke(t1 hit,t2>1), ExitWound(t1<0, t2 hit), 

				// 3x MISS cases:
				//       ->  o                     o ->              | -> |
				// FallShort (t1>1,t2>1), Past (t1<0,t2<0), CompletelyInside(t1<0, t2>1)

				if (t1 is >= 0 and <= 1)
				{
					// t1 is the intersection, and it's closer than t2
					// (since t1 uses -b - discriminant)
					// Impale, Poke
					intersectionPoints.Add(E + d * t1);
				}

				if (!FloatUtil.AreClose(discriminant, 0))  // If discriminant == 0 then we hit the edge of the circle (and t1 == t2) so we can skip adding a point for t2
				{
					// here t1 didn't intersect so we are either started
					// inside the sphere or completely past it
					if (t2 is >= 0 and <= 1)
					{
						// ExitWound
						intersectionPoints.Add(E + d * t2);
					}
				}

				// no intn: FallShort, Past, CompletelyInside
			}
		}

		public static Vector2 GetClosestPointInCircle(in Vector2 point, in Vector2 circleCentre, float circleRadiusSquared, float circleRadius)
		{
			Vector2 circleToPoint = point - circleCentre;
			float distanceSquared = circleToPoint.sqrMagnitude;

			if (distanceSquared < circleRadiusSquared)
			{
				return point;
			}

			Vector2 circleToPointNormalised = circleToPoint / Mathf.Sqrt(distanceSquared);

			return circleCentre + circleToPointNormalised * circleRadius;
		}

		public static void AddIntersectionsToList(in Span<Line> lines, in Vector2 line2Point1, in Vector2 line2Point2, bool useLineSegment, List<Vector2> intersections)
		{
			foreach (Line line in lines)
			{
				if (TryGetIntersection(line.Point1, line.Point2, line2Point1, line2Point2, useLineSegment, false, out Vector2 intersection, out _))
				{
					intersections.Add(intersection);
				}
			}
		}
	}
}