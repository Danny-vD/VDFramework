using System;
using System.Collections.Generic;
using VDFramework.Utility.TimerUtil.TimerHandles;
using VDFramework.Utility.TimerUtil.TimerHandles.Parameters;

namespace VDFramework.Utility.TimerUtil
{
	/// <summary>
	/// <para>Manager class for all timers</para>
	/// <para>use <see cref="Update"/> to update all timers</para>
	/// <para>The timers are updated in reversed order so the last one started will be updated first</para>
	/// </summary>
	public static partial class TimerManager
	{
		/// <summary>
		/// A collection of <see cref="AbstractTimerHandle"/> whose time will be updated in <see cref="Update"/>
		/// </summary>
		private static readonly List<AbstractTimerHandle> timers = new List<AbstractTimerHandle>();

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static TimerHandle StartNewTimer(double startTime, Action timerExpiredCallback, bool loop = false)
		{
			TimerHandle handle = new TimerHandle(startTime, timerExpiredCallback, loop);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		/// <seealso cref="Delegate.DynamicInvoke"/>
		public static DelegateTimerHandle StartNewTimer(double startTime, Delegate timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			DelegateTimerHandle handle = new DelegateTimerHandle(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a timer on the given TimerHandle (resets if one is already ticking)
		/// </summary>
		/// <param name="handle">The TimerHandle to set the timer on</param>
		/// <returns>Whether a not a timer was successfully started (will fail if the handle is not valid (i.e. has already been cleaned up after expiring))</returns>
		/// <seealso cref="AbstractTimerHandle.IsTicking"/>
		/// <seealso cref="AbstractTimerHandle.IsValid"/>
		public static bool StartNewTimer(AbstractTimerHandle handle)
		{
			if (handle.IsTicking) // same as timers.Contains(handle), but a boolean check instead of a list enumaration
			{
				handle.ResetTimer();
			}
			else
			{
				if (handle.IsValid)
				{
					AddHandleToUpdateList(handle);
				}
				else
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Adds this timerHandle to the list of TimerHandles
		/// </summary>
		/// <param name="handle">The TimerHandle that will be added</param>
		private static void AddHandleToUpdateList(AbstractTimerHandle handle)
		{
			handle.OnHandleFinished += RemoveTimerFromList;

			// We don't sort because it might lead to a double update if a timer is started in the callback of another timer
			timers.Add(handle);

			handle.IsTicking = true;
		}

		/// <summary>
		/// Updates the internal timer of each <see cref="AbstractTimerHandle"/> with deltaTime
		/// </summary>
		/// <param name="deltaTime">The amount to update the timers with</param>
		public static void Update(double deltaTime)
		{
			// In reverse order because a non-looped timer will be removed from the list if it expires
			for (int i = timers.Count - 1; i >= 0; i--)
			{
				AbstractTimerHandle handle = timers[i];
				handle.Step(deltaTime);
			}
		}

		private static void RemoveTimerFromList(AbstractTimerHandle handle)
		{
			handle.IsTicking = false;
			timers.Remove(handle);
		}
	}
}