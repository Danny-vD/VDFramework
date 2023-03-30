using System;
using System.Reflection;

namespace VDFramework.EventSystem
{
	internal abstract class EventHandler : IComparable<EventHandler>
	{
		protected readonly Delegate Callback = null;
		private readonly int priorityOrder = 0;

		private Type callbackDeclaringType = null;
		public Type DeclaringType => callbackDeclaringType ??= Callback.GetMethodInfo().DeclaringType;

		protected EventHandler(Delegate callback, int priorityOrder)
		{
			Callback           = callback;
			this.priorityOrder = priorityOrder;
		}

		public static bool operator ==(EventHandler handler, Delegate callback)
		{
			return !ReferenceEquals(handler, null) && handler.Callback == callback;
		}

		public static bool operator !=(EventHandler handler, Delegate callback)
		{
			return !(handler == callback);
		}

		public int CompareTo(EventHandler other)
		{
			// Check if they have a higher priority than us. Used for sorting the list.
			return other.priorityOrder.CompareTo(priorityOrder);
		}
		
		protected bool Equals(EventHandler other)
		{
			return Callback == other.Callback;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			return Equals((EventHandler)obj);
		}

		public override int GetHashCode()
		{
			return Callback.GetHashCode();
		}
	}

	internal class EventHandler<TEvent> : EventHandler
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