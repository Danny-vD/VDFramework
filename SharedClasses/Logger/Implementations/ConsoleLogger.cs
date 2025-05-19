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
		public void Log(LogLevel logLevel, object data, object obj)
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
		public void LogDebug(object data, object obj)
		{
			Console.WriteLine("[DEBUG] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogInfo(object data, object obj)
		{
			Console.WriteLine("[INFO] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogMessage(object data, object obj)
		{
			Console.WriteLine("[MESSAGE] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogWarning(object data, object obj)
		{
			Console.WriteLine("[WARNING] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogError(object data, object obj)
		{
			Console.WriteLine("[ERROR] " + data + "\n" + obj);
		}

		/// <inheritdoc />
		public void LogException(Exception exception, object data, object obj)
		{
			if (ReferenceEquals(exception, null))
			{
				Console.WriteLine(data + "\n" + obj);
				return;
			}

			string dataString = data.ToString();
			
			if (string.IsNullOrEmpty(dataString))
			{
				Console.WriteLine("[EXCEPTION] " + $"{exception.Data}\n{exception.StackTrace}\n{obj}");
			}
			else
			{
				Console.WriteLine("[EXCEPTION] " + $"{dataString}\n{exception.Data}\n{exception.StackTrace}\n{obj}");
			}
		}

		/// <inheritdoc />
		public void LogFatal(object data, object obj)
		{
			Console.WriteLine("[FATAL] " + data + "\n" + obj);
		}
	}
}