using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace VDFramework.Utility.Windows
{
	[DebuggerDisplay("{DisplayName} [{FolderType}] ({Path})")]
	public readonly struct SpecialFolder
	{
		public Guid Guid { get; }

		public string DisplayName { get; }

		public FolderType FolderType { get; }

		/// <summary>
		/// Returns the default path for the folder
		/// </summary>
		public string DefaultPath => Environment.GetEnvironmentVariable(defaultPathRoot) + defaultPath;

		/// <summary>
		/// Get the current path to the folder
		/// </summary>
		/// <exception cref="DirectoryNotFoundException">Throws if there is no valid path to the folder</exception>
		public string Path => GetPath();

		/// <summary>
		/// constant special item ID list
		/// <para>(Only applicable before Windows Vista)</para>
		/// <para>https://docs.microsoft.com/en-us/windows/win32/shell/csidl</para>
		/// </summary>
		public string[] CSIDL { get; }

		private readonly string defaultPathRoot;
		private readonly string defaultPath;

		internal SpecialFolder(Guid guid, string displayName, FolderType folderType, string defaultPathRoot, string defaultPath = null,
			params string[]         csidl)
		{
			Guid        = guid;
			DisplayName = displayName;
			FolderType  = folderType;
			CSIDL       = csidl;

			this.defaultPathRoot = defaultPathRoot;
			this.defaultPath     = defaultPath;
		}

		[DllImport("Shell32.dll", CharSet = CharSet.Auto)]
		private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

		private string GetPath()
		{
			IntPtr pathPtr = IntPtr.Zero;

			try
			{
				if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
					Environment.OSVersion.Version.Major < 6) // Before windows vista
				{
					throw new NotSupportedException("You are on a Windows version before Windows Vista, this is not supported.");
				}

				Guid tempGuid = Guid;

				if (SHGetKnownFolderPath(ref tempGuid, 0, IntPtr.Zero, out pathPtr) != 0)
				{
					throw new DirectoryNotFoundException(
						"The directory cannot be found, you might be not using the Windows OS or trying to access a virtual folder.\nOr The directory might simply not exist");
				}

				return Marshal.PtrToStringUni(pathPtr);
			}
			finally
			{
				Marshal.FreeCoTaskMem(pathPtr);
			}
		}
	}
}