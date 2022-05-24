using System;
using System.Drawing;

namespace VDFramework.Utility
{
	public static class MathUtil
	{
		public static int GetSignFactor(float input)
		{
			if (input < 0)
			{
				return -1;
			}

			if (input > 0)
			{
				return 1;
			}

			return 0;
		}

		/// <summary>
		/// Get the Y coordinate of a 2D curve that crosses y = 0 at [0,0] and [distance,0] with a maxY of height
		/// </summary>
		public static float GetYCoordinateOnCurve(float x, float distance, float height)
		{
			if (height == 0)
			{
				throw new ArgumentException("Height cannot be 0, the result would be a straight horizontal line", nameof(height));
			}

			if (distance == 0)
			{
				throw new ArgumentException("Distance cannot be 0, the result would be a straight vertical line", nameof(distance));
			}

			float b = height / distance * 4; // Magic number 4, but 4 just happens to be the correct factor
			float a = b / distance;

			float sqrX = x * x;

			return -a * sqrX + b * x; // -ax² + bx
		}

		/// <summary>
		/// Get the X coordinates of a 2D curve that crosses y = 0 at [0,0] and [distance,0] with a maxY of height
		/// </summary>
		public static Tuple<float, float> GetXCoordinatesOnCurve(float y, float distance, float height)
		{
			if (height == 0)
			{
				throw new ArgumentException("Height cannot be 0, the result would be a straight horizontal line", nameof(height));
			}

			if (distance == 0)
			{
				throw new ArgumentException("Distance cannot be 0, the result would be a straight vertical line", nameof(distance));
			}
			
			if (y > height)
			{
				throw new ArgumentException("The coordinate y may not be heigher than height", nameof(y));
			}
			
			float b = height / distance * 4; // Magic number 4, but 4 just happens to be the correct factor
			float a = b / distance;
			float c = -y; // We shift the entire curve down by -y, to then solve -ax² + bx = 0
			
			float discriminant = b * b - 4 * -a * c; // b² - 4(-a)c    a negative because we flipped the curve
			float sqrtDiscriminant = (float)Math.Sqrt(discriminant);
			
			float p1 = (-b + sqrtDiscriminant) / 2 * a;
			float p2 = (-b - sqrtDiscriminant) / 2 * a;

			return new Tuple<float, float>(p1, p2);
		}
	}
}