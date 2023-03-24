using System;

namespace VDFramework.Utility.TimerUtil
{
	/// <summary>
	/// A representation of a timer which invokes an event after a certain amount of seconds pass (possibly loops)
	/// </summary>
	public class TimerHandle
	{
		/// <summary>
		/// The callback to invoke when the timer expires
		/// </summary>
		public event Action OnTimerExpire;
		
		internal event Action<TimerHandle> OnHandleFinished = delegate { };

		/// <summary>
		/// The amount of seconds remaining until the callback invokes
		/// </summary>
		public double CurrentTime { get; private set; }
		
		/// <summary>
		/// A value of [0,1] that represents the % between 0 and the startTime of the timer
		/// </summary>
		public double CurrentTimeNormalized => Math.Max(0, Math.Min(CurrentTime / StartTime, 1));

		/// <summary>
		/// The amount of seconds that the timer started with (will be reset to this value when the timer loops)
		/// </summary>
		public double StartTime { get; private set; }

		/// <summary>
		/// Whether or not the timer should reset itself upon expiring
		/// </summary>
		public bool IsLooping { get; private set; }
		
		/// <summary>
		/// If a timer is paused the internal timer will not be updated
		/// </summary>
		public bool IsPaused { get; private set; }

		/// <summary>
		/// Whether or not this handle still represents an active timer (will be false if a non-looped timer expires)
		/// </summary>
		public bool IsValid { get; private set; } = true;

		internal TimerHandle(double startTime, Action callback, bool loop)
		{
			StartTime = startTime;
			OnTimerExpire  = callback;

			SetLoop(loop);

			ResetTimer();
		}

		/// <summary>
		/// Reset the internal timer immediately to <see cref="StartTime"/>
		/// </summary>
		public void ResetTimer()
		{
			CurrentTime = StartTime;
		}

		/// <summary>
		/// Set whether or not the timer should loop after expiring
		/// </summary>
		/// <param name="loop">Should the timer loop after expiring?</param>
		public void SetLoop(bool loop)
		{
			IsLooping = loop;
		}

		/// <summary>
		/// Set the <see cref="StartTime"/> of the timer
		/// <para>This will only have an effect if the timer is reset or loops</para>
		/// </summary>
		/// <param name="newStartTime">The new start time for the timer</param>
		/// <param name="resetTimer">Whether the timer should reset after setting the new start time</param>
		public void SetStartTime(double newStartTime, bool resetTimer = true)
		{
			StartTime = newStartTime;

			if (resetTimer)
			{
				ResetTimer();
			}
		}

		/// <summary>
		/// Pause the timer to temporarily prevent updating the internal timer
		/// </summary>
		public void SetPause(bool paused)
		{
			IsPaused = paused;
		}

		/// <summary>
		/// Stop this timer immediately and prevent further updates
		/// <para>If you mean to temporarily pause a timer, use <see cref="SetPause"/> instead</para>
		/// </summary>
		public void Stop()
		{
			Cleanup();
		}

		internal void Step(double deltaTime)
		{
			if (IsPaused)
			{
				return;
			}
			
			CurrentTime -= deltaTime;

			if (CurrentTime <= 0)
			{
				InvokeCallback();

				if (IsLooping)
				{
					ResetTimer();
				}
				else
				{
					Cleanup();
				}
			}
		}

		private void InvokeCallback()
		{
			OnTimerExpire!.Invoke();
		}

		private void Cleanup()
		{
			OnHandleFinished.Invoke(this);

			OnTimerExpire    = null;
			OnHandleFinished = null;

			IsValid = false;
		}
	}
}