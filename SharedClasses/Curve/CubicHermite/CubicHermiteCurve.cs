using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SeedFinder.Curve.Enums;
using SeedFinder.Curve.Structs;
using SeedFinder.Curve.Utility;
using VDFramework.Utility.DataTypes;

namespace SeedFinder.Curve
{
	/// <summary>
	/// The implementation of a Cubic Hermite curve.<br/>
	/// This is a Cubic curve that where the 2 control points are defined by a weight and a tangent from the start and end points.<br/>
	/// The behaviour of this curve is identical to Unitys AnimationCurve
	/// </summary>
	/// <wikipedia>https://en.wikipedia.org/wiki/Cubic_Hermite_spline</wikipedia>
	/// <plottedExample>https://www.desmos.com/calculator/hrswjq9qbe</plottedExample>
	public class CubicHermiteCurve : IEnumerable
	{
		/// <summary>
		/// How evaluating a point that falls to the left of the curve should be handled
		/// </summary>
		public CurveWrapMode PreWrapMode { get; set; } = CurveWrapMode.Clamp;
		
		/// <summary>
		/// How evaluating a point that falls to the right of the curve should be handled
		/// </summary>
		public CurveWrapMode PostWrapMode { get; set; } = CurveWrapMode.Clamp;

		private KeyFrame[] keyFrames;

		/// <summary>
		/// All the keyframes that belong to this curve, sorted by their x coordinates.
		/// </summary>
		public KeyFrame[] KeyFrames
		{
			get => keyFrames;
			set
			{
				keyFrames = value;
				SortKeyFrames();
				isDirty = true;
			}
		}

		/// <summary>
		/// The first keyframe of this curve
		/// </summary>
		public KeyFrame StartPoint => keyFrames[0];

		/// <summary>
		/// The last keyframe of this curve
		/// </summary>
		public KeyFrame EndPoint => keyFrames[^1];

		private bool isDirty = true; // Used to know whether to recalculate the control points

		/// <summary>
		/// Creates a new Cubic Hermite curve with no keyframes
		/// </summary>
		public CubicHermiteCurve()
		{
		}

		/// <summary>
		/// Creates a new Cubic Hermite curve with the given keyframes
		/// </summary>
		public CubicHermiteCurve(KeyFrame[] keyframes)
		{
			KeyFrames = keyframes;
		}

		/// <summary>
		/// Creates a new Cubic Hermite curve with the given keyframes
		/// </summary>
		public CubicHermiteCurve(IEnumerable<KeyFrame> keyframes) : this(keyframes.ToArray())
		{
		}

		/// <summary>
		/// Evaluate the curve at the given x coordinate
		/// </summary>
		/// <param name="x">The X coordnate to evaluate</param>
		/// <returns>The Y coordinate of the point on the curve that has the given X coordinate</returns>
		public double Evaluate(double x)
		{
			return Evaluate(x, PreWrapMode, PostWrapMode);
		}
		
		/// <summary>
		/// Evaluate the curve at the given x coordinate
		/// </summary>
		/// <param name="x">The X coordnate to evaluate</param>
		/// <param name="preWrapMode">How to handle a point that falls outside the curve, before the first keyframe</param>
		/// <param name="postWrapMode">How to handle a point that falls outside the curve, after the last keyframe</param>
		/// <returns>The Y coordinate of the point on the curve that has the given X coordinate</returns>
		public double Evaluate(double x, CurveWrapMode preWrapMode, CurveWrapMode postWrapMode)
		{
			if (keyFrames.Length == 0)
			{
				return 0;
			}

			if (keyFrames.Length == 1)
			{
				return keyFrames[0].y;
			}

			if (isDirty)
			{
				RecalculateControlPoints();
			}

			KeyFrame startPoint = StartPoint;
			KeyFrame endPoint = EndPoint;

			// Check if the x falls outside of the curve
			if (DoubleUtil.LesserThanOrClose(x, startPoint.x, out bool areEqual))
			{
				if (areEqual)
				{
					return startPoint.y;
				}
				
				return CalculateOutOfBoundsValueLeft(x, preWrapMode, postWrapMode);
			}

			if (DoubleUtil.GreaterThanOrClose(x, endPoint.x, out areEqual))
			{
				if (areEqual)
				{
					return endPoint.y;
				}

				return CalculateOutOfBoundsValueRight(x, preWrapMode, postWrapMode);
			}

			// Go over each part of the whole curve to the section that contains the requested coordinate
			for (int i = 1; i < keyFrames.Length; i++)
			{
				KeyFrame start = keyFrames[i - 1];
				KeyFrame end = keyFrames[i];

				if (DoubleUtil.GreaterThanOrClose(x, end.x, out areEqual))
				{
					if (areEqual)
					{
						return end.y;
					}
					
					// x is not within this part of the curve, so check the next part
					continue; // No need to check if the point is before the start, that has already been checked
				}

				// For the constant line, the InTangent takes precedence over the OutTangent
				if (double.IsInfinity(end.InTangent)) // For an infinity tangent the curve should just be a straight line (constant) 
				{
					return double.IsPositiveInfinity(end.InTangent) ? start.y : end.y;
				}
				
				if (double.IsInfinity(start.OutTangent)) // For an infinity tangent the curve should just be a straight line (constant) 
				{
					return double.IsPositiveInfinity(start.OutTangent) ? start.y : end.y;
				}

				if (!start.HasCalculatedRightControlPoint)
				{
					start.CalculateRightControlPoint(end);
				}

				if (!end.HasCalculatedLeftControlPoint)
				{
					end.CalculateLeftControlPoint(start);
				}

				Point controlPoint1 = start.RightControlPoint;
				Point controlPoint2 = end.LeftControlPoint;

				return CubicHermiteCalculator.EvaluateCurve(x, start.Position, controlPoint1, controlPoint2, end.Position);
			}

			throw new ArgumentException("The value can not be evaluated, this should never happen!", nameof(x));
		}

		private void SortKeyFrames()
		{
			Array.Sort(keyFrames);
		}

		private void RecalculateControlPoints()
		{
			if (keyFrames.Length < 2)
			{
				return;
			}

			for (int i = 1; i < keyFrames.Length; i++)
			{
				KeyFrame start = keyFrames[i - 1];
				KeyFrame end = keyFrames[i];

				start.CalculateRightControlPoint(end);
				end.CalculateLeftControlPoint(start);

				keyFrames[i - 1] = start;
				keyFrames[i]     = end;
			}

			isDirty = false;
		}

		private double CalculateOutOfBoundsValueLeft(double x, CurveWrapMode preWrapMode, CurveWrapMode postWrapMode)
		{
			KeyFrame startPoint = StartPoint;
			KeyFrame endPoint = EndPoint;

			double amountOver = startPoint.x - x;
			double totalCurveLength = endPoint.x - startPoint.x;
			
			int curveIndex = (int)Math.Ceiling(amountOver / totalCurveLength);
			double remainder = amountOver % totalCurveLength;

			bool onEvenCurve = (curveIndex & 1) != 1; // Every 2nd wrap

			return preWrapMode switch
			{
				CurveWrapMode.Loop => Evaluate(endPoint.x - remainder, preWrapMode, postWrapMode),
				CurveWrapMode.PingPong => onEvenCurve ? Evaluate(endPoint.x - remainder, preWrapMode, postWrapMode) : Evaluate(startPoint.x + remainder, preWrapMode, postWrapMode),
				CurveWrapMode.Clamp => startPoint.y,
				_ => 0,
			};
		}

		private double CalculateOutOfBoundsValueRight(double x, CurveWrapMode preWrapMode, CurveWrapMode postWrapMode)
		{
			KeyFrame startPoint = StartPoint;
			KeyFrame endPoint = EndPoint;

			double amountOver = x - endPoint.x;
			double totalCurveLength = endPoint.x - startPoint.x;

			int curveIndex = (int)Math.Ceiling(amountOver / totalCurveLength);
			double remainder = amountOver % totalCurveLength;

			bool onEvenCurve = (curveIndex & 1) != 1; // Every 2nd wrap

			return postWrapMode switch
			{
				CurveWrapMode.Loop => Evaluate(startPoint.x + remainder, preWrapMode, postWrapMode),
				CurveWrapMode.PingPong => onEvenCurve ? Evaluate(startPoint.x + remainder, preWrapMode, postWrapMode) : Evaluate(endPoint.x - remainder, preWrapMode, postWrapMode),
				CurveWrapMode.Clamp => endPoint.y,
				_ => 0,
			};
		}

		/// <inheritdoc />
		public IEnumerator GetEnumerator()
		{
			return keyFrames.GetEnumerator();
		}
	}
}