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
		public void Log(LogLevel logLevel, string data, object obj);

		/// <summary>
		/// Logs a Debug message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogDebug(string data, object obj);

		/// <summary>
		/// Logs an Info message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogInfo(string data, object obj);
		
		/// <summary>
		/// Logs a Message
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogMessage(string data, object obj);
		
		/// <summary>
		/// Logs a Warning
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogWarning(string data, object obj);
		
		/// <summary>
		/// Logs an Error
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogError(string data, object obj);
		
		/// <summary>
		/// Logs an Exception
		/// </summary>
		/// <param name="exception">The exception that needs to be logged</param>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogException(Exception exception, string data, object obj);
		
		/// <summary>
		/// Logs a fatal error
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// /// <param name="obj">Additional data that can be used by the logger</param>
		public void LogFatal(string data, object obj);
	}
}