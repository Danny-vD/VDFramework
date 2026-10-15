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
		public static void GetConeEndPoints(in Vector2 coneOrigin, in Vector2 coneDirection, float distanceConeOriginToEndPointMiddle, float distanceConeMiddleToEndPoint, out Vector2 endPoint1, out Vector2 endPoint2)
		{
			Vector2 coneDirectionNormalised = coneDirection.normalized;
            
			Vector2 aimNormal = Vector2.Perpendicular(in coneDirectionNormalised);

			Vector2 endPointCentre = coneOrigin + (coneDirectionNormalised * distanceConeOriginToEndPointMiddle);

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
		/// <param name="coneOrigin">The origin of the cone</param>
		/// <param name="coneDirection">The direction the cone is aiming in (does not need to be normalized)</param>
		/// <param name="sqrRange">The square of the range of the cone</param>
		/// <param name="halfConeAngleDeg">The angle of the cone in degrees, halved (so the angle from the cone centre to the endpoint)</param>
		/// <param name="point">The point to check against the cone</param>
		/// <param name="angleTolerance">How many degrees the point is allowed to fall outside of the cone</param>
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

		/// <summary>
		/// Go over all <paramref name="colliders"/> and return their closest points in the cone (if they are not in the cone, nothing will be returned for that object)<br/>
		/// Works for both convex and concave colliders
		/// </summary>
		/// <param name="coneOrigin">The origin of the cone</param>
		/// <param name="coneDirection">The direction the cone is aiming in (does not need to be normalized)</param>
		/// <param name="sqrRange">The square of the range of the cone</param>
		/// <param name="halfConeAngleDeg">The angle of the cone in degrees, halved (so the angle from the cone centre to the endpoint)</param>
		/// <param name="endPointLines">The 2 directions from the cone origin to the end points</param>
		/// <param name="colliders">The colliders to check against the cone</param>
		/// <param name="physicsShapeGroup2D">A <see cref="PhysicsShapeGroup2D"/> that will be used to hold the physics shapes of the collider</param>
		/// <returns>A collection of GameObjects within the cone and their closest point to the <paramref name="coneOrigin"/> within the cone</returns>
		[Pure]
		public static ValueTuple<GameObject, Vector2>[] GetClosestPointsOfObjectsWithinCone(in Vector2 coneOrigin, in Vector2 coneDirection, float sqrRange, float halfConeAngleDeg, ReadOnlySpan<Line> endPointLines, IEnumerable<Collider2D> colliders, PhysicsShapeGroup2D physicsShapeGroup2D)
		{
			List<ValueTuple<GameObject, Vector2>> hitsInsideCone = new List<ValueTuple<GameObject, Vector2>>();

			List<Vector2> coneIntersectionPoints = new List<Vector2>(); // Allocate once so we can reuse the list
			List<Vector2> closestPoints = new List<Vector2>();

			foreach (Collider2D collider in colliders) // Iterate over all possible objects in the cone
			{
				coneIntersectionPoints.Clear(); // Clear every time
				closestPoints.Clear();

				Vector2 closestPoint = collider.ClosestPoint(coneOrigin);

				if (!IsPointWithinCone(coneOrigin, coneDirection, sqrRange, halfConeAngleDeg, closestPoint)) // Try the closest point first
				{
					IntersectionUtils.AddAllIntersectPointsWithCollider(endPointLines, collider, physicsShapeGroup2D, coneOrigin, coneIntersectionPoints, closestPoints);

					bool hasClosestPointInCone = false;

					foreach (Vector2 point in closestPoints)
					{
						if (IsPointWithinCone(coneOrigin, coneDirection, sqrRange, halfConeAngleDeg, point))
						{
							closestPoint = point;

							hasClosestPointInCone = true;
							break;
						}
					}

					if (coneIntersectionPoints.Count > 0) // All intersection points are by definition inside the cone, so no need to check
					{
						Vector2 closestIntersection = coneIntersectionPoints[0];

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

				hitsInsideCone.Add(new ValueTuple<GameObject, Vector2>(collider.gameObject, closestPoint));
			}

			return hitsInsideCone.ToArray();
		}

		/// <summary>
		/// Draws the cone using <see cref="Debug.DrawLine(Vector3, Vector3, Color, float, bool)"/> and 
		/// </summary>
		/// <seealso cref="GetConeEndPoints"/>
		public static void DebugDrawCone(Vector2 coneOrigin,     float angleDegrees,   float range,      Vector2 endPoint1, Vector2 endPoint2,
			Color                                endPoint1Color, Color endPoint2Color, Color coneColour, float   duration,  bool    depthTest, float rayCount = 9)
		{
			Debug.DrawLine(coneOrigin, endPoint1, endPoint1Color, duration, depthTest);
			Debug.DrawLine(coneOrigin, endPoint2, endPoint2Color, duration, depthTest);

			if (rayCount <= 0)
			{
				return;
			}

			Vector3 endPoint2Direction = endPoint2 - coneOrigin;

			float delta = angleDegrees / (rayCount + 1);
			float rotation = 0;

			for (float i = 0; i < rayCount; i++)
			{
				rotation += delta;

				Quaternion rotationQuaternion = Quaternion.Euler(0, 0, rotation);

				Vector3 point = rotationQuaternion * endPoint2Direction; // Positive rotation is counter-clockwise so rotate from point 2
				Debug.DrawRay(coneOrigin, point.normalized * range, coneColour, duration, depthTest);
			}
		}
	}
}