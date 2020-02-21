﻿using System.Collections.Generic;

namespace VDFramework.Extensions
{
	public static class StringExtentions
	{
		/// <summary>
		/// Returns a new string where a space is inserted before each capital, skipping the first char
		/// </summary>
		public static string InsertSpaceBeforeCapitals(this string text)
		{
			string capitals = text.ToUpper();
			string copyText = text;

			if (text.CountIsZeroOrOne())
			{
				return copyText;
			}

			for (int i = text.Length - 1; i >= 1; i--)
			{
				if (text[i] == capitals[i])
				{
					copyText = copyText.Insert(i, " ");
				}
			}

			return copyText;
		}
	}
}