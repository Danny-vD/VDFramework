using System;
using VDFramework.Logger.Enums;
using VDFramework.Logger.Interfaces;

namespace VDFramework.Logger.Implementations
{
	/// <summary>
	/// A simple implementation of <see cref="ILogger"/> that uses <see cref="System.Console.WriteLine(string)">System.Console.WriteLine</see> to log data
	/// </summary>
	public class ConsoleLogger : ILogger
	{
		/// <inheritdoc />
		public void Log(LogLevel logLevel, string data, object obj)
		{
			switch (logLevel)
			{
				case LogLevel.Debug:
					LogDebug(data, obj);
					break;
				case LogLevel.Info:
					LogInfo(data, obj);
					break;
				case LogLevel.Message:
					LogMessage(data, obj);
					break;
				case LogLevel.Warning:
					LogWarning(data, obj);
					break;
				case LogLevel.Error:
					LogError(data, obj);
					break;
				case LogLevel.Exception:
					LogException(null, data, obj);
					break;
				case LogLevel.Fatal:
					LogFatal(data, obj);
					break;
				case LogLevel.None:
				case LogLevel.All:
				default:
					Console.WriteLine(data);
					break;
			}
		}

		/// <inheritdoc />
		public void LogDebug(string data, object obj)
		{
			Console.WriteLine("[DEBUG] " + data);
		}

		/// <inheritdoc />
		public void LogInfo(string data, object obj)
		{
			Console.WriteLine("[INFO] " + data);
		}

		/// <inheritdoc />
		public void LogMessage(string data, object obj)
		{
			Console.WriteLine("[MESSAGE] " + data);
		}

		/// <inheritdoc />
		public void LogWarning(string data, object obj)
		{
			Console.WriteLine("[WARNING] " + data);
		}

		/// <inheritdoc />
		public void LogError(string data, object obj)
		{
			Console.WriteLine("[ERROR] " + data);
		}

		/// <inheritdoc />
		public void LogException(Exception exception, string data, object obj)
		{
			if (ReferenceEquals(exception, null))
			{
				Console.WriteLine(data);
				return;
			}
			
			if (string.IsNullOrEmpty(data))
			{
				Console.WriteLine("[EXCEPTION] " + $"{exception.Data}\n{exception.StackTrace}");
			}
			else
			{
				Console.WriteLine("[EXCEPTION] " + $"{data}\n{exception.Data}\n{exception.StackTrace}");
			}
		}

		/// <inheritdoc />
		public void LogFatal(string data, object obj)
		{
			Console.WriteLine("[FATAL] " + data);
		}
	}
}