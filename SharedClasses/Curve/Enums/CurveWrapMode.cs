namespace VDFramework.Curve.Enums
{
	/// <summary>
	/// How to handle evaluating a point outside of the defined curve
	/// </summary>
	public enum CurveWrapMode
	{
		/// <summary>
		/// Repeat the curve ad ininitum
		/// </summary>
		Loop,
		
		/// <summary>
		/// Repeat the curve ad infinitum, but reverse the curve every other cycle
		/// </summary>
		PingPong,
		
		/// <summary>
		/// Return the value at the start/end point
		/// </summary>
		Clamp,
	}
}