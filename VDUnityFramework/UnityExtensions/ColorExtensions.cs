using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class ColorExtensions
	{
		public static float DistanceSquared(this Color referenceColour, Color colour)
		{
			float redDelta = colour.r - referenceColour.r;
			float greenDelta = colour.g - referenceColour.g;
			float blueDelta = colour.b - referenceColour.b;

			return (redDelta * redDelta) + (greenDelta * greenDelta) + (blueDelta * blueDelta);
		}
	}
}