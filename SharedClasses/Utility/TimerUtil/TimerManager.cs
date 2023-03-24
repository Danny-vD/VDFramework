using System;
using System.Collections.Generic;

namespace VDFramework.Utility.TimerUtil
{
	/// <summary>
	/// Manager class for all timers
	/// <para>use <see cref="Update"/> to update all timers</para>
	/// </summary>
	public static class TimerManager
	{
		private static readonly List<TimerHandle> timers = new List<TimerHandle>();

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <returns>Returns a handle to the timer, this can be used to Pause the timer or change some properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static TimerHandle StartNewTimer(double startTime, Action timerExpiredCallback, bool loop)
		{
			TimerHandle handle = new TimerHandle(startTime, timerExpiredCallback, loop);

			handle.OnHandleFinished += RemoveTimerFromList;
			
			timers.Add(handle);

			return handle;
		}
		
		/// <summary>
		/// Updates the internal timer of each <see cref="TimerHandle"/> with deltaTime
		/// </summary>
		/// <param name="deltaTime">The amount to update the timers with</param>
		public static void Update(double deltaTime)
		{
			foreach (TimerHandle handle in timers)
			{
				handle.Step(deltaTime);
			}
		}

		private static void RemoveTimerFromList(TimerHandle handle)
		{
			timers.Remove(handle);
		}
	}
}