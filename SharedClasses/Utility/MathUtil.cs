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
		public static float GetPointOnCurve(float x, float distance, float height)
		{
			float a = height / distance * 4; // Magic number 4, but 4 just happens to be the correct factor
			float b = a / distance;
			
			float sqrX = x * x;

			return a * x - b * sqrX; // ax - b(x^2)
		}
	}
}