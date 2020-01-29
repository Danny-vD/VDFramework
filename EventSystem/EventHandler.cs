using System;

namespace VDFramework.EventSystem
{
#pragma warning disable 660,661
	internal abstract class EventHandler
#pragma warning restore 660,661
	{
		public Delegate Callback = null;
		public int PriorityOrder = 0;

		protected EventHandler(Delegate callback, int priorityOrder)
		{
			Callback = callback;
			PriorityOrder = priorityOrder;
		}

		public static bool operator ==(EventHandler handler, Delegate callback)
		{
			return handler != null && handler.Callback == callback;
		}

		public static bool operator !=(EventHandler handler, Delegate callback)
		{
			return !(handler == callback);
		}
	}

	internal class EventHandler<TEvent> : EventHandler where TEvent : VDEvent
	{
		protected EventHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(TEvent eventToRaise)
		{
			(Callback as Action<TEvent>)?.Invoke(eventToRaise);
		}
	}
}