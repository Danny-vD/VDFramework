using System;

namespace VDFramework.Utility.TimerUtil.TimerHandles
{
	/// <summary>
	/// <para>An abstract representation of a timer which invokes an event after a certain amount of seconds pass (possibly loops)</para>
	/// <para>This can be used to Pause the timer or change properties</para>
	/// </summary>
	public abstract class AbstractTimerHandle : IComparable<AbstractTimerHandle>
	{
		/// <summary>
		/// Used internally by the <see cref="TimerManager"/> to remove this Handle from the update list when <see cref="Stop"/> is invoked
		/// </summary>
		/// <seealso cref="TimerManager.timers"/>
		internal Action<AbstractTimerHandle> OnHandleFinished = delegate { };

		/// <summary>
		/// The amount of seconds remaining until the callback invokes
		/// </summary>
		public double CurrentTime { get; private set; }

		/// <summary>
		/// A value of [0,1] that represents the % between 0 and the startTime of the timer
		/// </summary>
		public double CurrentTimeNormalized => Math.Max(0, Math.Min(CurrentTime / StartTime, 1)); // Math.Clamp does not exist in .NET Standard

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
		/// <para>Whether or not this handle represents an active timer (i.e. started by the <see cref="TimerManager"/>)</para>
		/// <para>This will also return true if a timer is started by the <see cref="TimerManager"/> but has been paused</para>
		/// </summary>
		/// <seealso cref="IsPaused"/>
		public bool IsTicking { get; internal set; } = false;

		/// <summary>
		/// A handle to the timer, this can be used to Pause the timer or change some properties
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callback will be invoked</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		protected AbstractTimerHandle(double startTime, bool loop)
		{
			StartTime = startTime;

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
					Stop();
				}
			}
		}

		/// <summary>
		/// Called when the timer is stopped
		/// </summary>
		/// <seealso cref="Stop"/>
		protected virtual void Cleanup()
		{
			OnHandleFinished.Invoke(this);
			OnHandleFinished = null;
		}

		/// <summary>
		/// <para>Invoke the callback</para>
		/// <para>Called when the timer expires</para>
		/// </summary>
		protected abstract void InvokeCallback();

		/// <summary>
		/// <para>Set the callback to null to remove all references it may hold</para>
		/// <para>Called when the timer expires for a non-looping handle</para>
		/// </summary>
		protected abstract void SetCallbackToNull();

		/// <summary>
		/// Compare using the StartTime
		/// <para>(uses CurrentTime if equal)</para>
		/// </summary>
		public int CompareTo(AbstractTimerHandle other)
		{
			if (this == other)
			{
				return 0;
			}

			if (other == null)
			{
				return 1;
			}

			int result = StartTime.CompareTo(other.StartTime);

			if (result == 0)
			{
				result = CurrentTime.CompareTo(other.CurrentTime);
			}

			return result;
		}
	}

	/// <summary>
	/// A version of <see cref="AbstractTimerHandle"/> that implements a property for the Callback
	/// </summary>
	/// <typeparam name="TDelegate">Any delegate type (e.g. Action)</typeparam>
	public abstract class AbstractTimerHandle<TDelegate> : AbstractTimerHandle where TDelegate : Delegate
	{
		private TDelegate onTimerExpire;

		/// <summary>
		/// The callback to invoke when the timer expires, setting this to null will stop the timer
		/// </summary>
		public virtual TDelegate OnTimerExpire
		{
			get => onTimerExpire;
			set
			{
				if (value == null)
				{
					Stop();
					return;
				}

				onTimerExpire = value;
			}
		}

		/// <inheritdoc />
		protected override void SetCallbackToNull()
		{
			onTimerExpire = null;
		}
		
		/// <inheritdoc />
		/// <param name="startTime">The time in seconds after which the callback will be invoked</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callback">The callback that is will be invoked after the timer expires</param>
		protected AbstractTimerHandle(double startTime, TDelegate callback, bool loop) : base(startTime, loop)
		{
			onTimerExpire = callback;
		}
	}
}