using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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
		/// 
		/// </summary>
		/// <param name="lines"></param>
		/// <param name="collider"></param>
		/// <param name="physicsShapeGroup2D"></param>
		/// <param name="referencePoint"></param>
		/// <param name="closestPoints">The closest point on every physics shape, sorted so that the closest points (to <paramref name="referencePoint"/>) are first in the array</param>
		/// <returns>All intersection points with the collider, sorted so that the closest points (to <paramref name="referencePoint"/>) are first in the array</returns>
		[Pure]
		public static Vector2[] GetAllIntersectPointsWithCollider(in ReadOnlySpan<Line> lines, Collider2D collider, PhysicsShapeGroup2D physicsShapeGroup2D, Vector2 referencePoint, out Vector2[] closestPoints)
		{
			closestPoints = Array.Empty<Vector2>();

			if (lines.Length == 0)
			{
				return Array.Empty<Vector2>();
			}

			int shapeCount = collider.GetShapes(physicsShapeGroup2D);

			if (shapeCount == 0)
			{
				return Array.Empty<Vector2>();
			}

			bool isLocalSpace = collider.attachedRigidbody != null; // Has a rigidbody, so the vertices are in local space 

			Span<Line> transformedLines = stackalloc Line[lines.Length]; // Array assigned on the stack

			if (isLocalSpace)
			{
				for (int i = 0; i < transformedLines.Length; i++)
				{
					Line line = lines[i];

					Vector2 linePoint1Transformed = collider.transform.TransformPoint(line.Point1); // Because the vertices are in local space, we turn our line into local space as well
					Vector2 linePoint2Transformed = collider.transform.TransformPoint(line.Point2); // This is cheaper than turning every other point into world space (2 operations per line vs however many points)
					transformedLines[i] = new Line(linePoint1Transformed, linePoint2Transformed);
				}
			}
			else
			{
				for (int i = 0; i < transformedLines.Length; i++)
				{
					Line line = lines[i];

					// No need to actually transform anything, but by assigning the original we can use the same variable later
					transformedLines[i] = new Line(line.Point1, line.Point2);
				}
			}

			NativeArray<PhysicsShape2D> shapes = new NativeArray<PhysicsShape2D>(shapeCount, Allocator.Temp);
			NativeArray<Vector2> vertices = new NativeArray<Vector2>(physicsShapeGroup2D.vertexCount, Allocator.Temp);

			physicsShapeGroup2D.GetShapeData(shapes, vertices);

			List<Vector2> intersectionPoints = new List<Vector2>(2);
			closestPoints = new Vector2[shapeCount];

			for (int i = 0; i < shapes.Length; i++)
			{
				PhysicsShape2D currentShape = shapes[i];

				switch (currentShape.shapeType)
				{
					case PhysicsShapeType2D.Circle:
						Vector2 circleCentre = vertices[currentShape.vertexStartIndex];

						AddInteresectionPointsCircle(intersectionPoints, transformedLines, circleCentre, currentShape.radius); // Circle always has 1 vertex (the centre)

						closestPoints[i] = GetClosestPointInCircle(referencePoint, circleCentre, currentShape.radius);
						break;
					case PhysicsShapeType2D.Capsule:
						AddInteresectionPointsCapsule(intersectionPoints, transformedLines, currentShape, vertices, referencePoint, out Vector2 closestPoint);

						closestPoints[i] = closestPoint;
						break;
					case PhysicsShapeType2D.Polygon:
						ReadOnlySpan<Vector2> polygonVertices = vertices.AsReadOnlySpan().Slice(currentShape.vertexStartIndex, currentShape.vertexCount);

						AddInteresectionPointsPolygon(intersectionPoints, transformedLines, true, polygonVertices);
						closestPoints[i] = PolygonUtils.GetClosestPointInPolygon(polygonVertices, referencePoint);
						break;
					case PhysicsShapeType2D.Edges:
						ReadOnlySpan<Vector2> edgeVertices = vertices.AsReadOnlySpan().Slice(currentShape.vertexStartIndex, currentShape.vertexCount);

						AddInteresectionPointsPolygon(intersectionPoints, transformedLines, false, edgeVertices);
						closestPoints[i] = VectorProjectionUtil.ProjectPointOntoPolygonEdge(edgeVertices, referencePoint, false);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			shapes.Dispose();
			vertices.Dispose();

			if (intersectionPoints.Count == 0)
			{
				return Array.Empty<Vector2>();
			}

			if (isLocalSpace)
			{
				// Transform the intersection and closest points to world space
				intersectionPoints = intersectionPoints.Select(point => (Vector2)collider.transform.TransformPoint(point)).ToList();
				closestPoints      = closestPoints.Select(point => (Vector2)collider.transform.TransformPoint(point)).ToArray();
			}

			Comparison<Vector2> closestToPointComparison = (lhs, rhs) => Vector2.SqrMagnitude(referencePoint - lhs).CompareTo(Vector2.SqrMagnitude(referencePoint - rhs));

			intersectionPoints.Sort(closestToPointComparison);
			Array.Sort(closestPoints, closestToPointComparison);

			return intersectionPoints.ToArray();
		}

		private static void AddInteresectionPointsPolygon(List<Vector2> intersectionPoints, in Span<Line> lines, bool isPolygon, in ReadOnlySpan<Vector2> vertices)
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

		private static void AddInteresectionPointsCapsule(List<Vector2> intersectionPoints, in Span<Line> lines, in PhysicsShape2D physicsShape, in NativeArray<Vector2> vertices, Vector2 point, out Vector2 closestPoint)
		{
			int startIndex = physicsShape.vertexStartIndex; // Capsule always has 2 vertices (1 for each circle)

			Vector2 circle1Centre = vertices[startIndex];
			Vector2 circle2Centre = vertices[startIndex + 1];

			Vector2 capsuleVector = circle2Centre - circle1Centre;
			Vector2 normal = Vector2.Perpendicular(in capsuleVector).normalized;

			Vector2 circle1LeftBound = circle1Centre + normal * physicsShape.radius;
			Vector2 circle1RightBound = circle1Centre - normal * physicsShape.radius;

			Vector2 circle2LeftBound = circle2Centre + normal * physicsShape.radius;
			Vector2 circle2RightBound = circle2Centre - normal * physicsShape.radius;

			AddIntersectionsToList(lines, circle1LeftBound, circle1RightBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle1RightBound, circle2RightBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle2RightBound, circle2LeftBound, true, intersectionPoints);
			AddIntersectionsToList(lines, circle2LeftBound, circle1LeftBound, true, intersectionPoints);

			AddInteresectionPointsCircle(intersectionPoints, lines, circle1Centre, physicsShape.radius);
			AddInteresectionPointsCircle(intersectionPoints, lines, circle2Centre, physicsShape.radius);

			Span<Vector2> closestPoints = stackalloc Vector2[2];

			closestPoint = GetClosestPointInCircle(point, circle1Centre, physicsShape.radius);
			float sqrDistanceToClosestPoint = Vector2.SqrMagnitude(closestPoint - point);

			closestPoints[0] = GetClosestPointInCircle(point, circle2Centre, physicsShape.radius);

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
		private static void AddInteresectionPointsCircle(List<Vector2> intersectionPoints, in Span<Line> lines, in Vector2 circleCentre, float radius)
		{
			foreach (Line line in lines)
			{
				Vector2 E = line.Point1;
				Vector2 L = line.Point2;
				Vector2 C = circleCentre;

				Vector2 d = L - E;
				Vector2 f = E - C;

				float a = d.sqrMagnitude;
				float b = 2 * Vector2.Dot(f, d);
				float c = f.sqrMagnitude - radius * radius;

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

				// here t1 didn't intersect so we are either started
				// inside the sphere or completely past it
				if (t2 is >= 0 and <= 1)
				{
					// ExitWound
					intersectionPoints.Add(E + d * t2);
				}

				// no intn: FallShort, Past, CompletelyInside
			}
		}

		private static Vector2 GetClosestPointInCircle(in Vector2 point, in Vector2 circleCentre, float circleRadius)
		{
			Vector2 circleToPoint = VectorUtils.Normalize(point - circleCentre, out float distanceToPoint);

			if (distanceToPoint < circleRadius)
			{
				return point;
			}

			return circleCentre + circleToPoint * circleRadius;
		}

		private static void AddIntersectionsToList(in Span<Line> lines, in Vector2 line2Point1, in Vector2 line2Point2, bool useLineSegment, List<Vector2> intersections)
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