using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using VDFramework.Utility.DataTypes;
using VDFramework.Utility.PhysicsUtility;
using VDFramework.Utility.PhysicsUtility.Structs;

namespace VDFramework.Utility.MathUtility.Shapes
{
	/// <summary>
	/// Provides helper functions for working with cones
	/// </summary>
	public static class ConeUtils
	{
		/// <summary>
		/// Calculate the endpoints of the cone based on pre-calculated properties
		/// </summary>
		/// <seealso cref="CalculateConeEndPointProperties"/>
		public static void GetConeEndPoints(in Vector2 coneOrigin, in Vector2 aimDirection, float distanceConeOriginToEndPointMiddle, float distanceConeMiddleToEndPoint, out Vector2 endPoint1, out Vector2 endPoint2)
		{
			Vector2 aimNormal = Vector2.Perpendicular(in aimDirection).normalized;

			Vector2 endPointCentre = coneOrigin + (aimDirection * distanceConeOriginToEndPointMiddle);

			endPoint1 = endPointCentre + aimNormal * distanceConeMiddleToEndPoint;
			endPoint2 = endPointCentre - aimNormal * distanceConeMiddleToEndPoint;
		}

		/// <summary>
		/// Apply trigonometry to determine where the end points of the cone are and several properties on how to perform a spherecast that covers the entire cone
		/// </summary>
		public static void CalculateConeEndPointProperties(float angleDegrees, float range, out float distanceConeOriginToEndPointMiddle, out float distanceConeMiddleToEndPoint, out float distanceToSphereCastStart, out float sphereCastDistance, out float sphereCastRadius)
		{
			if (angleDegrees == 0) // AngleDegrees == 0
			{
				distanceConeOriginToEndPointMiddle = range;
				distanceConeMiddleToEndPoint       = 0;

				sphereCastRadius          = 0; // should do a raycast instead.
				distanceToSphereCastStart = 0;
				sphereCastDistance        = range;
			}
			else if (FloatUtil.AreClose(angleDegrees, 180)) // AngleDegrees == 180
			{
				distanceConeMiddleToEndPoint       = range;
				distanceConeOriginToEndPointMiddle = 0;

				sphereCastRadius          = range;
				distanceToSphereCastStart = 0;
				sphereCastDistance        = 0;
			}
			else if (angleDegrees > 180) // AngleDegrees > 180
			{
				float halfAngleDeg = angleDegrees / 2;
				float halfAngleRad = (180 - halfAngleDeg) * Mathf.Deg2Rad;

				float cosineAngle = Mathf.Cos(halfAngleRad);

				distanceConeOriginToEndPointMiddle = cosineAngle * -range; // -range because after 180° the end points are behind the aimDirection

				float sineAngle = Mathf.Sin(halfAngleRad);

				distanceConeMiddleToEndPoint = sineAngle * range;

				sphereCastRadius          = range;
				distanceToSphereCastStart = 0;
				sphereCastDistance        = 0; // Cannot cast in any direction when the cone is this wide
			}
			else // AngleDegrees < 180
			{
				float halfAngleDeg = angleDegrees / 2;
				float halfAngleRad = halfAngleDeg * Mathf.Deg2Rad;

				float cosineAngle = Mathf.Cos(halfAngleRad);

				distanceConeOriginToEndPointMiddle = cosineAngle * range;

				float sineAngle = Mathf.Sin(halfAngleRad);

				distanceConeMiddleToEndPoint = sineAngle * range;

				sphereCastRadius          = distanceConeMiddleToEndPoint;
				distanceToSphereCastStart = sphereCastRadius;
				sphereCastDistance        = distanceConeOriginToEndPointMiddle - distanceToSphereCastStart;
			}
		}

		/// <summary>
		/// Tests if the given point falls within the cone
		/// </summary>
		public static bool IsPointWithinCone(in Vector2 coneOrigin, in Vector2 coneDirection, float sqrRange, float halfConeAngleDeg, in Vector2 point, float angleTolerance = 0.05f)
		{
			Vector2 coneToPoint = point - coneOrigin;

			if (coneToPoint.sqrMagnitude > sqrRange) // the square of the magnitude is a faster operation
			{
				// Outside of the range of the cone
				return false;
			}

			float angle = Vector2.Angle(in coneDirection, in coneToPoint);

			if (angle > halfConeAngleDeg)
			{
				float angleDelta = angle - halfConeAngleDeg;

				if (angleDelta > angleTolerance)
				{
					return false;
				}
			}

			return true;
		}

		[Pure]
		public static Tuple<GameObject, Vector2>[] GetClosestPointsOfObjectsWithinCone(in Vector2 coneOrigin, in Vector2 coneDirection, float sqrRange, float halfAngleDeg, ReadOnlySpan<Line> endPointLines, IEnumerable<Collider2D> colliders, PhysicsShapeGroup2D physicsShapeGroup2D)
		{
			List<Tuple<GameObject, Vector2>> hitsInsideCone = new List<Tuple<GameObject, Vector2>>();

			foreach (Collider2D collider in colliders) // Iterate over all possible objects in the cone
			{
				Vector2 closestPoint = collider.ClosestPoint(coneOrigin);

				if (!IsPointWithinCone(coneOrigin, coneDirection, sqrRange, halfAngleDeg, closestPoint)) // Try the closest point first
				{
					Vector2[] coneEdgePoints = IntersectionUtils.GetAllIntersectPointsWithCollider(endPointLines, collider, physicsShapeGroup2D, coneOrigin, out Vector2[] closestPoints);

					bool hasClosestPointInCone = false;

					foreach (Vector2 point in closestPoints)
					{
						if (IsPointWithinCone(coneOrigin, coneDirection, sqrRange, halfAngleDeg, point))
						{
							closestPoint = point;

							hasClosestPointInCone = true;
							break;
						}
					}

					if (coneEdgePoints.Length > 0)
					{
						Vector2 closestIntersection = coneEdgePoints[0];

						if (hasClosestPointInCone)
						{
							if (Vector2.SqrMagnitude(closestIntersection - coneOrigin) < Vector2.SqrMagnitude(closestPoint - coneOrigin))
							{
								closestPoint = closestIntersection;
							}
						}
						else
						{
							closestPoint = closestIntersection;
						}

						hasClosestPointInCone = true;
					}

					if (!hasClosestPointInCone)
					{
						continue;
					}
				}

				hitsInsideCone.Add(new Tuple<GameObject, Vector2>(collider.gameObject, closestPoint));
			}

			return hitsInsideCone.ToArray();
		}
	}
}