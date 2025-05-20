using System;
using System.Collections.Generic;
using VDFramework.Timer.TimerHandles;
using VDFramework.Timer.TimerHandles.Parameters;

namespace VDFramework.Timer
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
		public static DelegateTimerHandle StartNewTimerDelegate(double startTime, Delegate timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			DelegateTimerHandle handle = new DelegateTimerHandle(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a timer on the given TimerHandle and resets the timer (only resets it is already ticking)
		/// </summary>
		/// <param name="handle">The TimerHandle to set the timer on</param>
		/// <returns>The same timerhandle</returns>
		/// <seealso cref="AbstractTimerHandle.IsTicking"/>
		public static AbstractTimerHandle StartNewTimer(AbstractTimerHandle handle)
		{
			handle.ResetTimer();
			
			if (!handle.IsTicking) // same as !timers.Contains(handle), but a boolean check instead of a list enumeration
			{
				AddHandleToUpdateList(handle);
			}

			return handle;
		}

		/// <summary>
		/// <para>Starts a new timer using the data from the given TimerHandle</para>
		/// <para>use <see cref="StartNewTimerFromTemplate{TDelegate}(VDFramework.Timer.TimerHandles.AbstractTimerHandle{TDelegate})"/> if you want to reuse the callback from the given handle</para>
		/// </summary>
		/// <param name="handle">A TimerHandle whose data will be used to set a new timer</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static DelegateTimerHandle StartNewTimerFromTemplate<TDelegate>(AbstractTimerHandle handle, TDelegate timerExpiredCallback) where TDelegate : Delegate
		{
			if (handle is AbstractParametersTimerHandle<TDelegate> parametersTimerHandle)
			{
				return StartNewTimerDelegate(handle.StartTime, timerExpiredCallback, handle.IsLooping, parametersTimerHandle.GetParameters());
			}

			return StartNewTimerDelegate(handle.StartTime, timerExpiredCallback, handle.IsLooping);
		}

		/// <summary>
		/// <para>Starts a new timer using the data from the given TimerHandle</para>
		/// </summary>
		/// <param name="handle">A TimerHandle whose data will be used to set a new timer</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static AbstractTimerHandle StartNewTimerFromTemplate<TDelegate>(AbstractTimerHandle<TDelegate> handle) where TDelegate : Delegate
		{
			return StartNewTimerFromTemplate(handle, handle.OnTimerExpire);
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