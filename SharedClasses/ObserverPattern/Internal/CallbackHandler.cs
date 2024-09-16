using System;
using System.Reflection;

namespace VDFramework.ObserverPattern
{
	/// <summary>
	/// A wrapper class for a callback with priority
	/// </summary>
	internal abstract class CallbackHandler : IComparable<CallbackHandler>
	{
		protected readonly Delegate Callback = null;
		private readonly int priorityOrder = 0;

		private Type callbackDeclaringType = null;
		public Type DeclaringType => callbackDeclaringType ??= Callback.GetMethodInfo().DeclaringType;

		protected CallbackHandler(Delegate callback, int priorityOrder)
		{
			Callback           = callback;
			this.priorityOrder = priorityOrder;
		}

		public static bool operator ==(CallbackHandler handler, Delegate callback)
		{
			return !ReferenceEquals(handler, null) && handler.Callback == callback;
		}

		public static bool operator !=(CallbackHandler handler, Delegate callback)
		{
			return !(handler == callback);
		}

		public int CompareTo(CallbackHandler other)
		{
			// Check if they have a higher priority than us. Used for sorting the list.
			return other.priorityOrder.CompareTo(priorityOrder);
		}
		
		protected bool Equals(CallbackHandler other)
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

			return Equals((CallbackHandler)obj);
		}

		public override int GetHashCode()
		{
			return Callback.GetHashCode();
		}
	}
}