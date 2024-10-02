namespace VDFramework.Utility.MathUtility
{
	/// <summary>
	/// Provides helper functions for linear interpolation between values
	/// </summary>
	public class LinearInterpolationUtil
	{
		/// <summary>
		/// Provides the value at t% between a and b
		/// </summary>
		public static double Lerp(double a, double b, double t)
		{
			return a + (b - a) * t;
		}
		
		/// <summary>
		/// Provides the value at t% between a and b
		/// </summary>
		public static float Lerp(float a, float b, float t)
		{
			return a + (b - a) * t;
		}
		
		/// <summary>
		/// Provides the % between a and b at value
		/// </summary>
		public static double InverseLerp(double a, double b, double value)
		{
			return (value - a) / (b - a);
		}
		
		/// <summary>
		/// Provides the % between a and b at value
		/// </summary>
		public static float InverseLerp(float a, float b, float value)
		{
			return (value - a) / (b - a);
		}
	}
}