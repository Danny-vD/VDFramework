using System;
using UnityEngine;

namespace VDFramework.Utility.MathUtility.VectorMath
{
	/// <summary>
	/// Provides helper functions to do vector math
	/// </summary>
	public static class VectorProjectionUtil
	{
		/// <summary>
		/// Projects a point onto a line and returns the projected point, optionally clamps the returned point to the line
		/// </summary>
		/// <param name="lineStart">The start point of the line</param>
		/// <param name="line">The line to project to</param>
		/// <param name="point">The point to project onto the line</param>
		/// <param name="ensureReturnedPointIsOnLine">Should the projected point be clamped between the end points of the line?</param>
		/// <param name="normalizedValueFromStart">A value that signifies how far away from the start the returned point is, normalized to the length of the line</param>
		/// <returns>A point on the line closest to the given point</returns>
		public static Vector2 ProjectPointOntoLine(Vector2 lineStart, Vector2 line, Vector2 point, bool ensureReturnedPointIsOnLine, out float normalizedValueFromStart)
		{
			Vector2 normalizedLine = VectorUtils.Normalize(line, out float lineLength);
			Vector2 lineToPoint = point - lineStart;

			float dot = Vector2.Dot(lineToPoint, normalizedLine); // Project the target onto the line

			normalizedValueFromStart = dot / lineLength; // normalize the value for the out parameter

			if (ensureReturnedPointIsOnLine)
			{
				dot = Mathf.Clamp(dot, 0, lineLength);
			}

			return lineStart + normalizedLine * dot;
		}
		
		/// <summary>
		/// Projects a point onto a line and returns the projected point, optionally clamps the returned point to the line
		/// </summary>
		/// <param name="lineStart">The start point of the line</param>
		/// <param name="lineEnd">The end point of the line</param>
		/// <param name="point">The point to project onto the line</param>
		/// <param name="ensureReturnedPointIsOnLine">Should the projected point be clamped between the end points of the line?</param>
		/// <param name="normalizedValueFromStart">A value that signifies how far away from the start the returned point is, normalized to the length of the line</param>
		/// <returns>A point on the line closest to the given point</returns>
		/// <returns></returns>
		public static Vector2 ProjectPointOntoLineBetweenPoints(Vector2 lineStart, Vector2 lineEnd, Vector2 point, bool ensureReturnedPointIsOnLine, out float normalizedValueFromStart)
		{
			Vector2 line = lineEnd - lineStart;
			
			return ProjectPointOntoLine(lineStart, line, point, ensureReturnedPointIsOnLine, out normalizedValueFromStart);
		}

		public static Vector2 ProjectPointOntoPolygonEdge(ReadOnlySpan<Vector2> vertices, Vector2 point, bool connectLastVertexToFirst)
		{
			if (vertices.Length == 0)
			{
				return Vector2.positiveInfinity;
			}
			
			Vector2 closestPointOnEdge = vertices[0];
			float closestDistanceToEdgePoint = float.PositiveInfinity; // Used to determine the closest point on the edge

			if (connectLastVertexToFirst)
			{
				Vector2 vertex = vertices[^1];
				Vector2 vertex2 = vertices[0];

				Vector2 projectedPoint = ProjectPointOntoLine(vertex, vertex2, point, true, out _);
				float distanceToProjectedPoint = Vector2.SqrMagnitude(projectedPoint - point);

				if (distanceToProjectedPoint < closestDistanceToEdgePoint)
				{
					closestDistanceToEdgePoint = distanceToProjectedPoint;
					closestPointOnEdge         = projectedPoint;
				}
			}

			for (int i = 1; i < vertices.Length; i++)
			{
				Vector2 vertex = vertices[i - 1];
				Vector2 vertex2 = vertices[i];

				Vector2 projectedPoint = ProjectPointOntoLine(vertex, vertex2, point, true, out _);
				float distanceToProjectedPoint = Vector2.SqrMagnitude(projectedPoint - point);

				if (distanceToProjectedPoint < closestDistanceToEdgePoint)
				{
					closestDistanceToEdgePoint = distanceToProjectedPoint;
					closestPointOnEdge         = projectedPoint;
				}
			}

			return closestPointOnEdge;
		}
		
		/// <summary>
		/// Projects a point onto a line and returns the projected point, optionally clamps the returned point to the line
		/// </summary>
		/// <param name="lineStart">The start point of the line</param>
		/// <param name="line">The line to project to</param>
		/// <param name="point">The point to project onto the line</param>
		/// <param name="ensureReturnedPointIsOnLine">Should the projected point be clamped between the end points of the line?</param>
		/// <param name="normalizedValueFromStart">A value that signifies how far away from the start the returned point is, normalized to the length of the line</param>
		/// <returns>A point on the line closest to the given point</returns>
		public static Vector3 ProjectPointOntoLine(Vector3 lineStart, Vector3 line, Vector3 point, bool ensureReturnedPointIsOnLine, out float normalizedValueFromStart)
		{
			Vector3 normalizedLine = VectorUtils.Normalize(line, out float lineLength);
			Vector3 lineToPoint = point - lineStart;

			float dot = Vector3.Dot(lineToPoint, normalizedLine); // Project the target onto the line

			normalizedValueFromStart = dot / lineLength; // normalize the value for the out parameter

			if (ensureReturnedPointIsOnLine)
			{
				dot = Mathf.Clamp(dot, 0, lineLength);
			}

			return lineStart + normalizedLine * dot;
		}

		/// <summary>
		/// Projects a point onto a line and returns the projected point, optionally clamps the returned point to the line
		/// </summary>
		/// <param name="lineStart">The start point of the line</param>
		/// <param name="lineEnd">The end point of the line</param>
		/// <param name="point">The point to project onto the line</param>
		/// <param name="ensureReturnedPointIsOnLine">Should the projected point be clamped between the end points of the line?</param>
		/// <param name="normalizedValueFromStart">A value that signifies how far away from the start the returned point is, normalized to the length of the line</param>
		/// <returns>A point on the line closest to the given point</returns>
		/// <returns></returns>
		public static Vector3 ProjectPointOntoLineBetweenPoints(Vector3 lineStart, Vector3 lineEnd, Vector3 point, bool ensureReturnedPointIsOnLine, out float normalizedValueFromStart)
		{
			Vector3 line = lineEnd - lineStart;
			
			return ProjectPointOntoLine(lineStart, line, point, ensureReturnedPointIsOnLine, out normalizedValueFromStart);
		}
	}
}