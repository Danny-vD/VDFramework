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
		/// <returns>A point on the line closest to the given point</returns>
		public static Vector3 ProjectPointOntoLine(Vector3 lineStart, Vector3 line, Vector3 point, bool ensureReturnedPointIsOnLine)
		{
			Vector3 normalizedLine = line.normalized;

			Vector3 directionToPoint = point - lineStart;

			float dot = Vector3.Dot(directionToPoint, normalizedLine); // Project the target onto the line

			dot /= line.magnitude; // normalize the result so we can then clamp it between 0 and 1

			if (ensureReturnedPointIsOnLine)
			{
				dot = Mathf.Clamp01(dot);
			}

			return lineStart + line * dot;
		}

		/// <summary>
		/// Projects a point onto a line and returns the projected point, optionally clamps the returned point to the line
		/// </summary>
		/// <param name="lineStart">The start point of the line</param>
		/// <param name="lineEnd">The end point of the line</param>
		/// <param name="point">The point to project onto the line</param>
		/// <param name="ensureReturnedPointIsOnLine">Should the projected point be clamped between the end points of the line?</param>
		/// <returns>A point on the line closest to the given point</returns>
		/// <returns></returns>
		public static Vector3 ProjectPointOntoLineBetweenPoints(Vector3 lineStart, Vector3 lineEnd, Vector3 point, bool ensureReturnedPointIsOnLine)
		{
			Vector3 line = lineEnd - lineStart;
			return ProjectPointOntoLine(lineStart, line, point, ensureReturnedPointIsOnLine);
		}
	}
}