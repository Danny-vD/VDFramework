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
	/// The implementation of a Cubic Hermite curve
	/// </summary>
	/// <graphicExample>https://www.desmos.com/calculator/jczgacl2jk</graphicExample>
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

		public KeyFrame StartPoint => keyFrames[0];

		public KeyFrame EndPoint => keyFrames[^1];

		private bool isDirty = true; // Used to know to recalculate the control points

		public CubicHermiteCurve()
		{
		}

		public CubicHermiteCurve(KeyFrame[] keyframes)
		{
			KeyFrames = keyframes;
		}

		public CubicHermiteCurve(IEnumerable<KeyFrame> keyframes) : this(keyframes.ToArray())
		{
		}

		public double Evaluate(double x)
		{
			return Evaluate(x, PreWrapMode, PostWrapMode);
		}
		
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
					continue;
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