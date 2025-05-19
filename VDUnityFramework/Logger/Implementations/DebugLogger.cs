using System;
using UnityEngine;
using VDFramework.Logger.Enums;
using Object = UnityEngine.Object;

namespace VDFramework.Logger.Implementations
{
	/// <summary>
	/// A simple implementation of <see cref="VDFramework.Logger.Interfaces.ILogger"/> that uses <see cref="UnityEngine.Debug.Log(object)">Debug.Log</see> to log data<br/>
	/// The extra object parameter will be interpreted as <see cref="UnityEngine.Object"/> to provide context to the Debug.Log
	/// </summary>
	public class DebugLogger : Interfaces.ILogger
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
		public void LogDebug(object data, object obj)
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
		public void LogInfo(object data, object obj)
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
		public void LogMessage(object data, object obj)
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
		public void LogWarning(object data, object obj)
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
		public void LogError(object data, object obj)
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
		public void LogException(Exception exception, object data, object obj)
		{
			if (ReferenceEquals(exception, null))
			{
				if (obj is Object unityObj)
				{
					Debug.LogError(data, unityObj);
				}
				else
				{
					Debug.LogError(data);
				}

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
		public void LogFatal(object data, object obj)
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