using System.Collections.Generic;
using UnityEngine;
using VDFramework.Extensions;
using VDFramework.Singleton;
using StringConverter = VDFramework.Input.JoystickButtonToStringConverter;

namespace VDFramework.Input
{
	public static class JoystickInput
	{
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//					JoystickAxis
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//

		/// <summary>
		/// Returns a vector3 containing the joystick axis values
		/// </summary>
		/// <param name="joystickNumber">The number of the joystick to get input from</param>
		/// <returns>A vector3(HorizontalAxis, 0, VerticalAxis)</returns>
		public static Vector3 GetAxes(uint joystickNumber)
		{
			float horizontalAxis =
				UnityEngine.Input.GetAxisRaw(
					StringConverter.GetString(JoystickButton.HorizontalAxis, joystickNumber));
			float verticalAxis =
				UnityEngine.Input.GetAxisRaw(
					StringConverter.GetString(JoystickButton.VerticalAxis, joystickNumber));

			return new Vector3(horizontalAxis, 0.0f, verticalAxis);
		}

		public static Vector3 GetClampedAxes(uint joystickNumber, float maxLength)
		{
			return Vector3.ClampMagnitude(GetAxes(joystickNumber), maxLength);
		}

		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//					JoystickButtons
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//

		public static bool GetButtonDown(uint joystickNumber, JoystickButton button)
		{
			return !ButtonDataHandler.Instance.IsButtonPressedLastFrame(joystickNumber, button)
				   && GetButton(joystickNumber, button);
		}

		public static bool GetButtonUp(uint joystickNumber, JoystickButton button)
		{
			return ButtonDataHandler.Instance.IsButtonPressedLastFrame(joystickNumber, button)
				   && !GetButton(joystickNumber, button);
		}

		public static bool GetButton(uint joystickNumber, JoystickButton button)
		{
			return UnityEngine.Input.GetAxis(
				StringConverter.GetString(button, joystickNumber)) > 0;
		}

		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//					ButtonDataHandler
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		private class ButtonDataHandler : Singleton<ButtonDataHandler>
		{
			// Stores the buttonData per Joystick for the previous frame
			private static readonly List<Dictionary<JoystickButton, bool>> buttonDataPerJoystick =
				new List<Dictionary<JoystickButton, bool>>();

			public static int JoystickCount => buttonDataPerJoystick.Count;

			protected override void Awake()
			{
				base.Awake();
				hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
			}

			public bool IsButtonPressedLastFrame(uint joystickNumber, JoystickButton button)
			{
				return EnsureKeyIsPresent(joystickNumber, button);
			}

			/// <returns>The value of the key</returns>
			private static bool EnsureKeyIsPresent(uint joystickNumber, JoystickButton button)
			{
				// Joysticks start counting at 1, while index starts at 0
				int joystickIndex = (int) joystickNumber - 1;

				// Check if exists in list
				if (buttonDataPerJoystick.Count < joystickNumber)
				{
					buttonDataPerJoystick.ResizeList(joystickIndex + 1);
					buttonDataPerJoystick[joystickIndex] = new Dictionary<JoystickButton, bool>
					{
						{button, false}
					};

					return false;
				}

				// Dictionary might be null
				if (buttonDataPerJoystick[joystickIndex] != null)
				{
					return buttonDataPerJoystick[joystickIndex][button];
				}

				// Add it with default value if it is null
				buttonDataPerJoystick[joystickIndex] = new Dictionary<JoystickButton, bool>
				{
					{button, false}
				};

				return false;
			}

			public static void UpdateData()
			{
				for (int joystickIndex = 0; joystickIndex < JoystickCount; joystickIndex++)
				{
					Dictionary<JoystickButton, bool> dictionaryPerJoystick = buttonDataPerJoystick[joystickIndex];

					for (int i = 0; i < dictionaryPerJoystick.Count; i++)
					{
						JoystickButton button = (JoystickButton) i;

						buttonDataPerJoystick[joystickIndex][button] = IsButtonPressed(joystickIndex, button);
					}
				}

				// Local function
				bool IsButtonPressed(int joystickIndex, JoystickButton button)
				{
					uint joystickNumber = (uint) joystickIndex + 1;

					return GetButton(joystickNumber, button);
				}
			}

			private void LateUpdate()
			{
				UpdateData();
			}
		}
	}
}