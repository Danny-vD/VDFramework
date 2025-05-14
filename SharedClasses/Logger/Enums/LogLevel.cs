using System;

namespace VDFramework.Logger.Enums
{
	/// <summary>
	/// The Log level or type that should be logged<br/>
	/// How this is represented by the final log output is fully determined by the used <see cref="VDFramework.Logger.Interfaces.ILogger"/>
	/// </summary>
	[Flags]
	public enum LogLevel
	{
		/// <summary>
		/// Nothing should be logged
		/// </summary>
		None = 0,

		/// <summary>
		/// A message used for debugging usually only intended for developers
		/// </summary>
		Debug = 1,
		
		/// <summary>
		/// A message that has no importance but can be used to inform that something happened
		/// </summary>
		Info = 2,
		
		/// <summary>
		/// An important message
		/// </summary>
		Message = 4,
		
		/// <summary>
		/// A warning that informs that something special or undesirable has happened but does not have severe impact on the flow of the program 
		/// </summary>
		Warning = 8,
		
		/// <summary>
		/// An error that interferes with the expected flow of the program
		/// </summary>
		Error = 16,

		/// <summary>
		/// A critical error that caused an exception to be thrown
		/// </summary>
		Exception = 32,
		
		/// <summary>
		/// A fatal error that caused the program to terminate
		/// </summary>
		Fatal = 64,

		/// <summary>
		/// Only <see cref="Warning"/>, <see cref="Error"/>, <see cref="Exception"/> and <see cref="Fatal"/>
		/// </summary>
		Important = Warning | Error | Exception | Fatal,
		
		/// <summary>
		/// All other <see cref="LogLevel"/>s combined
		/// </summary>
		All = Debug | Info | Message | Warning | Error | Exception | Fatal,
	}
}