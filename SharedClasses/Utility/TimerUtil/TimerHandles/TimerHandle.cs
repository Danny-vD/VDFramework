using System;

namespace VDFramework.Utility.TimerUtil.TimerHandles
{
	/// <summary>
	/// A Handle for a timer that has a callback that has no parameters
	/// </summary>
	public class TimerHandle : AbstractTimerHandle<Action>
	{
		/// <summary>
		/// A Handle for a timer that has a callback that has no parameters
		/// </summary>
		/// <inheritdoc />
		protected internal TimerHandle(double startTime, Action callback, bool loop) : base(startTime, callback, loop)
		{
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire!.Invoke();
		}
	}
}