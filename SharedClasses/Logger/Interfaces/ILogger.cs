using System;
using VDFramework.Logger.Enums;

namespace VDFramework.Logger.Interfaces
{
	/// <summary>
	/// Logs data
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Logs data with respect to the LogLevel<br/>
		/// To send the exception with <see cref="LogLevel.Exception">LogLevel.Exception</see> use <see cref="LogException"/> instead
		/// </summary>
		/// <param name="logLevel">The level of this log</param>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public void Log(LogLevel logLevel, object data, object obj = null);

		/// <summary>
		/// Logs a Debug message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogDebug(object data, object obj = null);

		/// <summary>
		/// Logs an Info message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogInfo(object data, object obj = null);
		
		/// <summary>
		/// Logs a Message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogMessage(object data, object obj = null);
		
		/// <summary>
		/// Logs a Warning
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogWarning(object data, object obj = null);
		
		/// <summary>
		/// Logs an Error
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogError(object data, object obj = null);
		
		/// <summary>
		/// Logs an Exception
		/// </summary>
		/// <param name="exception">The exception that needs to be logged</param>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogException(Exception exception, object data = null, object obj = null);
		
		/// <summary>
		/// Logs a fatal error
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogFatal(object data, object obj = null);
	}
}