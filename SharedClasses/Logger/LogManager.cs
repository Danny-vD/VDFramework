using System;
using VDFramework.Extensions;
using VDFramework.Logger.Enums;
using VDFramework.Logger.Interfaces;

namespace VDFramework.Logger
{
	/// <summary>
	/// A wrapper for logging data<br/>
	/// The actual logging is handled by the <see cref="LoggerImplementation"/> if the <see cref="VDFramework.Logger.Enums.LogLevel"/> is met 
	/// </summary>
	public static class LogManager // 'Logger' would be preferred, but because of Unity's 'Logger' you would have to manually specify which one you mean everywhere
	{
		/// <summary>
		/// If the logger is not enabled then no messages will be logged (except for bypassed logs)
		/// </summary>
		public static bool Enabled = true;

		/// <summary>
		/// The implementation of <see cref="ILogger"/> that will be used for logging data if the <see cref="VDFramework.Logger.Enums.LogLevel"/> is met
		/// </summary>
		public static ILogger LoggerImplementation;

		/// <summary>
		/// The <see cref="VDFramework.Logger.Enums.LogLevel"/>s that should be passed to the <see cref="LoggerImplementation"/>
		/// </summary>
		public static LogLevel LogLevel = LogLevel.All;
		
		/// <summary>
		/// Logs data respective to the LogLevel<br/>
		/// If the <see cref="LogLevel"/> does not meet the <paramref name="logLevel"/> then nothing will be logged<br/>
		/// To send the exception with <see cref="LogLevel.Exception">LogLevel.Exception</see> use <see cref="LogException"/> instead
		/// </summary>
		/// <param name="logLevel">The level of this log</param>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void Log(LogLevel logLevel, object data, object obj = null)
		{
			if (Enabled && LogLevel.HasAnyFlag(logLevel))
			{
				LoggerImplementation.Log(logLevel, data, obj);
			}
		}

		/// <summary>
		/// Logs a Debug message<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Debug"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogDebug(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Debug))
			{
				LoggerImplementation.LogDebug(data, obj);
			}
		}

		/// <summary>
		/// Logs an Info message<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Info"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogInfo(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Info))
			{
				LoggerImplementation.LogInfo(data, obj);
			}
		}

		/// <summary>
		/// Logs a Message<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Message"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogMessage(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Message))
			{
				LoggerImplementation.LogMessage(data, obj);
			}
		}

		/// <summary>
		/// Logs a Warning<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Warning"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogWarning(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Warning))
			{
				LoggerImplementation.LogWarning(data, obj);
			}
		}

		/// <summary>
		/// Logs an Error<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Error"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogError(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Error))
			{
				LoggerImplementation.LogError(data, obj);
			}
		}

		/// <summary>
		/// Logs an Exception<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Exception"/> then nothing will be logged
		/// </summary>
		/// <param name="exception">The exception that needs to be logged</param>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogException(Exception exception, object data = null, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Exception))
			{
				LoggerImplementation.LogException(exception, data, obj);
			}
		}

		/// <summary>
		/// Logs a fatal error<br/>
		/// If the <see cref="LogLevel"/> does not contain <see cref="LogLevel.Fatal"/> then nothing will be logged
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
		public static void LogFatal(object data, object obj = null)
		{
			if (Enabled && LogLevel.HasFlag(LogLevel.Fatal))
			{
				LoggerImplementation.LogFatal(data, obj);
			}
		}

		/// <summary>
		/// Logs data respective to the LogLevel<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings (and therefore technically allows logging with <see cref="LogLevel.None"/>)<br/>
		/// To send the exception with <see cref="LogLevel.Exception">LogLevel.Exception</see> use <see cref="LogExceptionBypassSettings"/> instead
		/// </summary>
		/// <param name="logLevel">The level of this log</param>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogBypassSettings(LogLevel logLevel, object data, object obj = null)
		{
			LoggerImplementation.Log(logLevel, data, obj);
		}

		/// <summary>
		/// Logs a Debug message<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogDebugBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogDebug(data, obj);
		}

		/// <summary>
		/// Logs an Info message<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogInfoBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogInfo(data, obj);
		}

		/// <summary>
		/// Logs a Message<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogMessageBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogMessage(data, obj);
		}

		/// <summary>
		/// Logs a Warning<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogWarningBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogWarning(data, obj);
		}

		/// <summary>
		/// Logs an Error<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogErrorBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogError(data, obj);
		}

		/// <summary>
		/// Logs an Exception<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="exception">The exception that needs to be logged</param>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogExceptionBypassSettings(Exception exception, object data = null, object obj = null)
		{
			LoggerImplementation.LogException(exception, data, obj);
		}

		/// <summary>
		/// Logs a fatal error<br/>
		/// This function will always log and ignores the <see cref="Enabled"/> and <see cref="LogLevel"/> settings
		/// </summary>
		/// <param name="data">The data to be logged</param>
		/// <param name="obj">Additional data that can be used by the logger</param>
        public static void LogFatalBypassSettings(object data, object obj = null)
		{
			LoggerImplementation.LogFatal(data, obj);
		}
	}
}