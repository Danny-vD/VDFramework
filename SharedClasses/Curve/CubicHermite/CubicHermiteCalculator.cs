using System;
using System.Numerics;
using VDFramework.Curve.Structs;
using VDFramework.Utility.MathUtility;

namespace VDFramework.Curve.CubicHermite
{
	/// <summary>
	/// Provides the under-the-hood calculations needed for a Cubic Hermite curve.<br/>
	/// This is a Cubic curve that where the 2 control points are defined by a weight and a tangent from the start and end points
	/// </summary>
	/// <wikipedia>https://en.wikipedia.org/wiki/Cubic_Hermite_spline</wikipedia>
	/// <plottedExample>https://www.desmos.com/calculator/hrswjq9qbe</plottedExample>
	public static class CubicHermiteCalculator
	{
		/// <summary>
		/// A mathematical constant used for getting the roots of a cubic equation.<br/>
		/// (-1 + √-3) / 2<br/>
		/// Symbol: ξ
		/// </summary>
		/// <wikipedia>https://en.wikipedia.org/wiki/Cubic_equation#General_cubic_formula</wikipedia>
		public static readonly Complex Xi = (-1 + Complex.Sqrt(-3)) / 2;

		/// <summary>
		/// Calculates the right control point for the start keyframe and the left control point for the end keyframe and returns them as out parameters
		/// </summary>
		public static void CalculateControlPoints(KeyFrame start, KeyFrame end, out Point controlPoint1, out Point controlPoint2)
		{
			double deltaX = end.x - start.x;

			double x, y;

			if (start.UseWeightForRightControlPoint)
			{
				x = start.x + deltaX * start.OutWeight; // lerp(start, end, start.weight)
				y = start.y + start.OutTangent * start.OutWeight * deltaX;
			}
			else
			{
				// For unweighted the weights are simply 1/3
				
				x = start.x + deltaX * MathConstants.THIRD;
				y = start.y + start.OutTangent * MathConstants.THIRD * deltaX;
			}

			double x2, y2;

			if (end.UseWeightForLeftControlPoint)
			{
				x2 = end.x - deltaX * end.InWeight; // lerp(end, start, end.weight)
				y2 = end.y - end.InTangent * end.InWeight * deltaX;
			}
			else
			{
				// For unweighted the weights are simply 1/3
				
				x2 = end.x - deltaX * MathConstants.THIRD;
				y2 = end.y - end.InTangent * MathConstants.THIRD * deltaX;
			}

			controlPoint1 = new Point(x, y);
			controlPoint2 = new Point(x2, y2);
		}

		/// <summary>
		/// Calculates the control point to the right of the start keyframe
		/// </summary>
		public static Point CalculateControlPoint1(KeyFrame start, KeyFrame end)
		{
			double deltaX = end.x - start.x;

			double x = 0;
			double y = 0;

			if (start.UseWeightForRightControlPoint)
			{
				x = start.x + deltaX * start.OutWeight; // lerp(start, end, start.weight)
				y = start.y + start.OutTangent * start.OutWeight * deltaX;
			}
			else
			{
				// For unweighted the weight is simply 1/3
				
				x = start.x + deltaX * MathConstants.THIRD;
				y = start.y + start.OutTangent * MathConstants.THIRD * deltaX;
			}

			return new Point(x, y);
		}

		/// <summary>
		/// Calculates the control point to the left of the end keyframe
		/// </summary>
		public static Point CalculateControlPoint2(KeyFrame start, KeyFrame end)
		{
			double deltaX = end.x - start.x;

			double x = 0;
			double y = 0;

			if (end.UseWeightForLeftControlPoint)
			{
				x = end.x - deltaX * end.InWeight; // lerp(end, start, end.weight)
				y = end.y - end.InTangent * end.InWeight * deltaX;
			}
			else
			{
				// For unweighted the weight is simply 1/3
				
				x = end.x - deltaX * MathConstants.THIRD;
				y = end.y - end.InTangent * MathConstants.THIRD * deltaX;
			}

			return new Point(x, y);
		}

		/// <summary>
		/// Evaluate the Cubic Hermite curve that is defined by the start and end points and 2 control points 
		/// </summary>
		/// <returns>the y value of the evaluated x coordinate on the curve</returns>
		public static double EvaluateCurve(double x, Point start, Point controlPoint1, Point controlPoint2, Point end)
		{
			GetCoefficients(start, controlPoint1, controlPoint2, end, out double a, out double b, out double c, out double m);

			double rp = 0;

			for (int i = 0; i < 3; i++)
			{
				Complex rpComplex = RootPlus(x, start, a, b, c, m, i);

				if (rpComplex.Real >= 0 && rpComplex.Real <= 1 && rpComplex.Imaginary < 0.0000000001)
				{
					rp = rpComplex.Real;
					break;
				}
			}

			return GetY(rp, start.y, controlPoint1.y, controlPoint2.y, end.y);
		}

		/// <summary>
		/// Gives a point on the curve depending on the value of t. With t = 0 being the start and t = 1 being the end.<br/>
		/// </summary>
		/// <warning>While this does allow one to trace the curve easily, t does not equate to a % along the curve and should not be used for constant steps</warning>
		public static Point GetPointOnCurve(double t, Point start, Point controlPoint1, Point controlPoint2, Point end)
		{
			t = Math.Clamp(t, 0, 1);

			double oneMinusT = 1 - t;
			double oneMinusTPower2 = oneMinusT * oneMinusT;
			double oneMinusTPower3 = oneMinusTPower2 * oneMinusT;

			double tPower2 = t * t;
			double tPower3 = tPower2 * t;

			double controlPoint1Coefficient = 3 * t * oneMinusTPower2;
			double controlPoint2Coefficient = 3 * tPower2 * oneMinusT;

			double x = GetX(start.x, controlPoint1.x, controlPoint2.x, end.x, oneMinusTPower3, controlPoint1Coefficient, controlPoint2Coefficient, tPower3);
			double y = GetY(start.y, controlPoint1.y, controlPoint2.y, end.y, oneMinusTPower3, controlPoint1Coefficient, controlPoint2Coefficient, tPower3);

			return new Point(x, y);
		}

		private static double GetX(double t, double startX, double controlPoint1X, double controlPoint2X, double endX)
		{
			double oneMinusT = 1 - t;
			double oneMinusTSquared = oneMinusT * oneMinusT;
			double oneMinusTCubed = oneMinusTSquared * oneMinusT;

			double tSquared = t * t;
			double tCubed = tSquared * t;

			double controlPoint1Coefficient = 3 * t * oneMinusTSquared;
			double controlPoint2Coefficient = 3 * tSquared * oneMinusT;

			return GetX(startX, controlPoint1X, controlPoint2X, endX, oneMinusTCubed, controlPoint1Coefficient, controlPoint2Coefficient, tCubed);
		}

		private static double GetX(double startX, double controlPoint1X, double controlPoint2X, double endX, double oneMinusTCubed, double controlPoint1Coefficient, double controlPoint2Coefficient, double tCubed)
		{
			return oneMinusTCubed * startX + controlPoint1Coefficient * controlPoint1X + controlPoint2Coefficient * controlPoint2X + tCubed * endX;
		}

		private static double GetY(double t, double startY, double controlPoint1Y, double controlPoint2Y, double endY)
		{
			double oneMinusT = 1 - t;
			double oneMinusTSquared = oneMinusT * oneMinusT;
			double oneMinusTCubed = oneMinusTSquared * oneMinusT;

			double tSquared = t * t;
			double tCubed = tSquared * t;

			double controlPoint1Coefficient = 3 * t * oneMinusTSquared;
			double controlPoint2Coefficient = 3 * tSquared * oneMinusT;

			return GetY(startY, controlPoint1Y, controlPoint2Y, endY, oneMinusTCubed, controlPoint1Coefficient, controlPoint2Coefficient, tCubed);
		}

		private static double GetY(double startY, double controlPoint1Y, double controlPoint2Y, double endY, double oneMinusTCubed, double controlPoint1Coefficient, double controlPoint2Coefficient, double tCubed)
		{
			return oneMinusTCubed * startY + controlPoint1Coefficient * controlPoint1Y + controlPoint2Coefficient * controlPoint2Y + tCubed * endY;
		}

		private static void GetCoefficients(Point start, Point controlPoint1, Point controlPoint2, Point end, out double a, out double b, out double c, out double m)
		{
			a = -start.x + 3 * controlPoint1.x - 3 * controlPoint2.x + end.x; // -P_0x + 3P_1x - 3P_2x + P_3x
			b = 3 * start.x - 6 * controlPoint1.x + 3 * controlPoint2.x;      // 3P_0x - 6P_1x + 3P_2x
			c = -3 * start.x + 3 * controlPoint1.x;                           // -3P_0x + 3P_1x

			m = b * b - 3 * a * c; // b² - 3ac
		}

		/// <summary>
		/// Returns the difference towards the start coordinate
		/// </summary>
		private static double Delta(double t, Point start)
		{
			return start.x - t;
		}

		private static double N(double t, Point start, double a, double b, double c)
		{
			return 2 * Math.Pow(b, 3) - 9 * a * b * c + 27 * a * a * Delta(t, start); // 2b³ - 9abc + 27a² * d(t)
		}

		/// <summary>
		/// Calculates a root of the polynomial equation using the complex number from <see cref="ComplexPlus"/> and ensures the result is real.
		/// </summary>
		private static Complex RootPlus(double t, Point start, double a, double b, double c, double m, int xiPower)
		{
			double factor = -1 / (3.0 * a);

			Complex cp = ComplexPlus(t, start, a, b, c, m);

			Complex xiFactor = xiPower == 0 ? 1 : Complex.Pow(Xi, xiPower);

			Complex xiCp = xiFactor * cp;

			Complex fraction = m / xiCp;

			return factor * (b + xiCp + fraction); // -1/3a(b + cp + m / cp) | this addition cancels out the imaginary part
		}
		
		private static Complex ComplexPlus(double t, Point start, double a, double b, double c, double m)
		{
			double n = N(t, start, a, b, c);

			double variable1 = n * n - 4 * m * m * m; // N(t)² - 4m³

			Complex nominator = n + Complex.Sqrt(variable1);

			Complex result = nominator / 2.0;

			return MathFunctions.CubicRoot(result);
		}

		/// <summary>
		/// Calculates a root of the polynomial equation using the complex number from <see cref="ComplexMinus"/> and ensures the result is real.
		/// </summary>
		private static Complex RootMinus(double t, Point start, double a, double b, double c, double m, int xiPower)
		{
			double factor = -1 / (3.0 * a);

			Complex cm = ComplexMinus(t, start, a, b, c, m);

			Complex xiFactor = xiPower == 0 ? 1 : Complex.Pow(Xi, xiPower);

			Complex xiCm = xiFactor * cm;

			Complex fraction = m / xiCm;

			return factor * (b + cm + fraction); // -1/3a(b + cm + m / cm) | this addition cancels out the imaginary part
		}
		
		private static Complex ComplexMinus(double t, Point start, double a, double b, double c, double m)
		{
			double n = N(t, start, a, b, c);

			double variable1 = n * n - 4 * m * m * m; // N(t)² - 4m³

			Complex nominator = n - Complex.Sqrt(variable1);

			Complex result = nominator / 2.0;

			return MathFunctions.CubicRoot(result);
		}
	}
}