using System;
using UnityEngine;
using VDFramework.Logger.Enums;
using Object = UnityEngine.Object;

namespace VDFramework.Logger.Implementations
{
	/// <summary>
	/// A simple implementation of <see cref="VDFramework.Logger.Interfaces.ILogger"/> that uses <see cref="UnityEngine.Debug.Log(object)">Debug.Log</see> to log data
	/// </summary>
	public class DebugLogger : Interfaces.ILogger
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
					if (obj is Object unityObject)
					{
						Debug.Log(data, unityObject);
					}
					else
					{
						Debug.Log(data);
					}

					break;
			}
		}

		/// <inheritdoc />
		public void LogDebug(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.Log("[DEBUG] " + data, unityObject);
			}
			else
			{
				Debug.Log("[DEBUG] " + data);
			}
		}

		/// <inheritdoc />
		public void LogInfo(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.Log("[INFO] " + data, unityObject);
			}
			else
			{
				Debug.Log("[INFO] " + data);
			}
		}

		/// <inheritdoc />
		public void LogMessage(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.Log("[MESSAGE] " + data, unityObject);
			}
			else
			{
				Debug.Log("[MESSAGE] " + data);
			}
		}

		/// <inheritdoc />
		public void LogWarning(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.LogWarning(data, unityObject);
			}
			else
			{
				Debug.LogWarning(data);
			}
		}

		/// <inheritdoc />
		public void LogError(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.LogError(data, unityObject);
			}
			else
			{
				Debug.LogError(data);
			}
		}

		/// <inheritdoc />
		public void LogException(Exception exception, string data, object obj)
		{
			if (ReferenceEquals(exception, null))
			{
				Debug.LogError(data);
				return;
			}

			if (obj is Object unityObject)
			{
				Debug.LogException(exception, unityObject);
			}
			else
			{
				Debug.LogException(exception);
			}
		}

		/// <inheritdoc />
		public void LogFatal(string data, object obj)
		{
			if (obj is Object unityObject)
			{
				Debug.LogError("[FATAL] " + data, unityObject);
			}
			else
			{
				Debug.LogError("[FATAL] " + data);
			}
		}
	}
}