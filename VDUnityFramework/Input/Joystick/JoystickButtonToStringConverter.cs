﻿using System.Collections.Generic;
using System.ComponentModel;
using Enums;

namespace JoystickData
{
	public static class JoystickButtonToStringConverter
	{
		private static readonly Dictionary<JoystickButton, string> stringPerButton = new Dictionary<JoystickButton, string>()
		{
			{JoystickButton.HorizontalAxis, "Horizontal_Joystick_"},
			{JoystickButton.VerticalAxis, "Vertical_Joystick_"},
			{JoystickButton.RightShoulderButton, "RShoulderButton_Joystick_"},
		};

		public static string GetString(JoystickButton buttonName)
		{
			if (!stringPerButton.TryGetValue(buttonName, out string button))
			{
				throw new InvalidEnumArgumentException($"There is no button assigned for {buttonName}");
			}
			
			return button;
		}

		public static string GetString(JoystickButton buttonName, uint joystickNumber)
		{
			return $"{GetString(buttonName)}{joystickNumber}";
		}
	}
}