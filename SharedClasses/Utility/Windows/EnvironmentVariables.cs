using System;

namespace VDFramework.Utility.Windows
{
	/// <summary>
	/// An Utility class to easily access some environment variables
	/// </summary>
	public static class EnvironmentVariables
	{
		// ReSharper disable UnusedMember.Global
		// ReSharper disable InconsistentNaming
		// ReSharper disable MissingBlankLines
		public static string ALLUSERSPROFILE => Environment.GetEnvironmentVariable("ALLUSERSPROFILE");
		public static string APPDATA => Environment.GetEnvironmentVariable("APPDATA");
		public static string LOCALAPPDATA => Environment.GetEnvironmentVariable("LOCALAPPDATA");
		public static string ProgramData => Environment.GetEnvironmentVariable("ProgramData");
		public static string ProgramFiles => Environment.GetEnvironmentVariable("ProgramFiles");
		public static string ProgramFilesx86 => Environment.GetEnvironmentVariable("ProgramFiles(x86)");
		public static string PUBLIC => Environment.GetEnvironmentVariable("PUBLIC");
		public static string SystemDrive => Environment.GetEnvironmentVariable("SystemDrive");
		public static string USERPROFILE => Environment.GetEnvironmentVariable("USERPROFILE");
		public static string windir => Environment.GetEnvironmentVariable("windir");
	}
}