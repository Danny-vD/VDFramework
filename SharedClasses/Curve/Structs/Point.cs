using System.Diagnostics;

namespace SeedFinder.Curve.Structs
{
	/// <summary>
	/// Represents an ordered pair of integer x- and y-coordinates that defines a point in a two-dimensional plane.
	/// </summary>
	[DebuggerDisplay("{x}, {y}")]
	public struct Point
	{
		/// <summary>
		/// The x coordinate of this point
		/// </summary>
		public double x;
		
		/// <summary>
		/// The y coordinate of this point
		/// </summary>
		public double y;

		/// <summary>
		/// Create a new point with the given x and y coordinates
		/// </summary>
		public Point(double xCoordinate, double yCoordinate)
		{
			x = xCoordinate;
			y = yCoordinate;
		}

		/// <summary>
		/// Create a new point with the same coordinates as the given point
		/// </summary>
		public Point(Point point) : this(point.x, point.y)
		{
		}
	}
}