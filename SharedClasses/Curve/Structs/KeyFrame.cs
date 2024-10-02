using System;
using System.Diagnostics;
using SeedFinder.Curve.Utility;

namespace SeedFinder.Curve.Structs
{
	/// <summary>
	/// Represents a x and y coordinate on the curve.<br/>
	/// Also contains a weight and a tangent for a cubic hermite curve
	/// </summary>
	[DebuggerDisplay("{x}, {y}")]
	public struct KeyFrame : IComparable<KeyFrame>
	{
		/// <summary>
		/// Creates a new keyframe with the given coordinates, and optionally the weights and tangents
		/// </summary>
		public KeyFrame(double xCoordinate, double yCoordinate, double inTangent = 0, double inWeight = 0, double outTangent = 0, double outWeight = 0)
		{
			this.xCoordinate = xCoordinate;
			this.yCoordinate = yCoordinate;

			position = new Point(xCoordinate, yCoordinate);

			this.inTangent = inTangent;
			this.inWeight  = inWeight;

			this.outTangent = outTangent;
			this.outWeight  = outWeight;

			useWeightForLeftControlPoint  = true;
			useWeightForRightControlPoint = true;

			LeftControlPoint              = position;
			HasCalculatedLeftControlPoint = false;

			RightControlPoint              = position;
			HasCalculatedRightControlPoint = false;
		}

		/// <summary>
		/// Creates a new keyframe with the coordinates from the given points, and optionally the weights and tangents
		/// </summary>
		public KeyFrame(Point coordinates, double inTangent = 0, double inWeight = 0, double outTangent = 0, double outWeight = 0)
			: this(coordinates.x, coordinates.y, inTangent, inWeight, outTangent, outWeight)
		{
		}

		// ReSharper disable InconsistentNaming | Reason: lowercase just looks better for the x and y coordinate
		private double xCoordinate;

		/// <summary>
		/// The X coordinate (Time) of this keyframe
		/// </summary>
		public double x
		{
			readonly get => xCoordinate;
			set
			{
				xCoordinate = value;
				position.x  = value;

				ResetLeftControlPoint();
				ResetRightControlPoint();
			}
		}

		private double yCoordinate;

		/// <summary>
		/// The Y coordinate (Value) of this keyframe
		/// </summary>
		public double y
		{
			readonly get => yCoordinate;
			set
			{
				yCoordinate = value;
				position.y  = value;

				ResetLeftControlPoint();
				ResetRightControlPoint();
			}
		}
		
		// ReSharper restore InconsistentNaming

		private Point position;

		/// <summary>
		/// The position of this keyframe
		/// </summary>
		public Point Position
		{
			readonly get => position;
			set
			{
				position = value;

				x = position.x;
				y = position.y;
			}
		}

		private bool useWeightForLeftControlPoint;

		/// <summary>
		/// Whether or not the weight should be used when calculating the left control point of this keyframe
		/// </summary>
		public bool UseWeightForLeftControlPoint
		{
			readonly get => useWeightForLeftControlPoint;
			set
			{
				useWeightForLeftControlPoint = value;
				ResetLeftControlPoint();
			}
		}

		private bool useWeightForRightControlPoint;

		/// <summary>
		/// Whether or not the weight should be used when calculating the right control point of this keyframe
		/// </summary>
		public bool UseWeightForRightControlPoint
		{
			readonly get => useWeightForRightControlPoint;
			set
			{
				useWeightForRightControlPoint = value;
				ResetRightControlPoint();
			}
		}

		private double inTangent;

		/// <summary>
		/// The tangent on the left side of this keyframe
		/// </summary>
		public double InTangent
		{
			readonly get => inTangent;
			set
			{
				inTangent = value;
				ResetLeftControlPoint();
			}
		}

		private double inWeight;

		/// <summary>
		/// The weight used to calculate the control point on the left of this keyframe
		/// </summary>
		public double InWeight
		{
			readonly get => inWeight;
			set
			{
				inWeight = value;
				ResetLeftControlPoint();
			}
		}

		private double outTangent;

		/// <summary>
		/// The tangent on the right side of this keyframe
		/// </summary>
		public double OutTangent
		{
			readonly get => outTangent;
			set
			{
				outTangent = value;
				ResetRightControlPoint();
			}
		}

		private double outWeight;

		/// <summary>
		/// The weight used to calculate the control point on the right of this keyframe
		/// </summary>
		public double OutWeight
		{
			readonly get => outWeight;
			set
			{
				outWeight = value;
				ResetRightControlPoint();
			}
		}

		/// <summary>
		/// The control point to the left of this keyframe
		/// </summary>
		public Point LeftControlPoint { readonly get; private set; }

		/// <summary>
		/// The control point to the right of this keyframe
		/// </summary>
		public Point RightControlPoint { readonly get; private set; }

		/// <summary>
		/// Whether or not the left control point has been calculated with the latest data set
		/// </summary>
		public bool HasCalculatedLeftControlPoint { readonly get; private set; }
		
		/// <summary>
		/// Whether or not the right control point has been calculated with the latest data set
		/// </summary>
		public bool HasCalculatedRightControlPoint { readonly get; private set; }

		/// <inheritdoc />
		public int CompareTo(KeyFrame other) => x.CompareTo(other.x);

		/// <summary>
		/// Calculate the left control point of this keyframe
		/// </summary>
		/// <param name="startPoint">A keyframe to the left of this keyframe that will serve as the begin point of the cubic hermite curve</param>
		public void CalculateLeftControlPoint(KeyFrame startPoint)
		{
			LeftControlPoint              = CubicHermiteCalculator.CalculateControlPoint2(startPoint, this);
			HasCalculatedLeftControlPoint = true;
		}

		/// <summary>
		/// Calculate the right control point of this keyframe
		/// </summary>
		/// <param name="endPoint">A keyframe to the right of this keyframe that will serve as the end point of the cubic hermite curve</param>
		public void CalculateRightControlPoint(KeyFrame endPoint)
		{
			RightControlPoint              = CubicHermiteCalculator.CalculateControlPoint1(this, endPoint);
			HasCalculatedRightControlPoint = true;
		}

		private void ResetLeftControlPoint()
		{
			if (!HasCalculatedLeftControlPoint) // Nothing to reset if it has not been calculated yet
			{
				return;
			}

			HasCalculatedLeftControlPoint = false;
			LeftControlPoint              = new Point(x, y);
		}

		private void ResetRightControlPoint()
		{
			if (!HasCalculatedRightControlPoint) // Nothing to reset if it has not been calculated yet
			{
				return;
			}

			HasCalculatedRightControlPoint = false;
			RightControlPoint              = new Point(x, y);
		}
	}
}