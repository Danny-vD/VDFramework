using System;
using VDFramework.Logger.Enums;
using VDFramework.Logger.Interfaces;

namespace VDFramework.Logger.Implementations
{
	/// <summary>
	/// A simple implementation of <see cref="ILogger"/> that uses <see cref="System.Console.WriteLine(string)">System.Console.WriteLine</see> to log data<br/>
	/// The extra object field will appended as obj.ToString() to the end of the message
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
				default:
					Console.WriteLine(data + "\n" + obj);
					break;
			}
		}

		/// <inheritdoc />
		public void LogDebug(string data, object obj)
		{
			Console.WriteLine("[DEBUG] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogInfo(string data, object obj)
		{
			Console.WriteLine("[INFO] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogMessage(string data, object obj)
		{
			Console.WriteLine("[MESSAGE] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogWarning(string data, object obj)
		{
			Console.WriteLine("[WARNING] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogError(string data, object obj)
		{
			Console.WriteLine("[ERROR] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogException(Exception exception, string data, object obj)
		{
			if (ReferenceEquals(exception, null))
			{
				Console.WriteLine(data + "\n" + obj);
				return;
			}
			
			if (string.IsNullOrEmpty(data))
			{
				Console.WriteLine("[EXCEPTION] " + $"{exception.Data}\n{exception.StackTrace}\n{obj}");
			}
			else
			{
				Console.WriteLine("[EXCEPTION] " + $"{data}\n{exception.Data}\n{exception.StackTrace}\n{obj}");
			}
		}

		/// <inheritdoc />
		public void LogFatal(string data, object obj)
		{
			Console.WriteLine("[FATAL] " + data + "\n" + obj);
		}
	}
}