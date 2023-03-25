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
		
		public static float DistanceSquaredHSV(this Color referenceColour, Color colour)
		{
			Color.RGBToHSV(referenceColour, out float hue1, out float saturation1, out float value1);
			Color.RGBToHSV(colour, out float hue2, out float saturation2, out float value2);
			
			float hueDelta = hue2 - hue1;
			float saturationDelta = saturation2 - saturation1;
			float valueDelta = value2 - value1;

			return (hueDelta * hueDelta) + (saturationDelta * saturationDelta) + (valueDelta * valueDelta);
		}
	}
}