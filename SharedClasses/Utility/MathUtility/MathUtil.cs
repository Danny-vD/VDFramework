using System;

namespace VDFramework.Utility.MathUtility
{
	/// <summary>
	/// Static class that contains useful math functions
	/// </summary>
	public static class MathUtil
	{
		/// <summary>
		/// Returns a number depending on the sign of the input
		/// </summary>
		/// <returns>negative: -1 | zero: 0 | positive: 1</returns>
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

			// ReSharper disable once CompareOfFloatsByEqualityOperator | Reason: Not a problem here, we actually want to check if the same value was passed in as an argument
			if (y == height) // in this case, the peak of the curve will be the requested coordinate
			{
				float halfDistance = distance / 2;
				return new Tuple<float, float>(halfDistance, halfDistance);
			}

			bool curveFlipped = height < 0;

			if (distance == 0)
			{
				throw new ArgumentException("Distance cannot be 0, the result would be a straight vertical line", nameof(distance));
			}

			if (curveFlipped)
			{
				if (y < height)
				{
					throw new ArgumentException("The coordinate y may not be lower than height, for a negative height", nameof(y));
				}
			}
			else
			{
				if (y > height)
				{
					throw new ArgumentException("The coordinate y may not be higher than height, for a positive height", nameof(y));
				}
			}

			float b = height / distance * 4; // Magic number 4, but 4 just happens to be the correct factor
			float a = b / distance;
			float c = -y; // We shift the entire curve down by -y, to then solve -ax² + bx = 0

			float discriminant = b * b - 4 * -a * c; // b² - 4(-a)c    a negative because we flipped the curve
			float sqrtDiscriminant = (float)Math.Sqrt(discriminant);

			float p1 = -((-b + sqrtDiscriminant) / (2 * a)); // - (-b + sqrt(d))/2a | the left X coordinate
			float p2 = -((-b - sqrtDiscriminant) / (2 * a)); // - (-b - sqrt(d))/2a | the right X coordinate

			if (curveFlipped)
			{
				return new Tuple<float, float>(p2, p1); // Reverse P2 and P1
			}

			return new Tuple<float, float>(p1, p2);
		}
	}
}