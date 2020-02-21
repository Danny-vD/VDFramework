using System.Collections.Generic;
using System.ComponentModel;

namespace VDFramework.Input
{
	public static class JoystickButtonToStringConverter
	{
		public static Dictionary<JoystickButton, string> StringPerButton = new Dictionary<JoystickButton, string>();

		internal static string GetString(JoystickButton buttonName)
		{
			if (!StringPerButton.TryGetValue(buttonName, out string button))
			{
				throw new InvalidEnumArgumentException($"There is no string assigned for {buttonName}!\n Assign one through JoystickButtonToStringConverter");
			}
			
			return button;
		}

		internal static string GetString(JoystickButton buttonName, uint joystickNumber)
		{
			return $"{GetString(buttonName)}{joystickNumber}";
		}
	}
}