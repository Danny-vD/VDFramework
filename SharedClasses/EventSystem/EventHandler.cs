using System;
using VDFramework.ObserverPattern;

namespace VDFramework.EventSystem
{
	/// <summary>
	/// Wrapper class for a <see cref="CallbackHandler"/> that uses a callback that takes an eventInstance as parameter
	/// </summary>
	/// <typeparam name="TEvent">The type of the event</typeparam>
	internal class EventHandler<TEvent> : CallbackHandler
		where TEvent : VDEvent
	{
		public EventHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(TEvent eventToRaise)
		{
			(Callback as Action<TEvent>)?.Invoke(eventToRaise);
		}
	}
}