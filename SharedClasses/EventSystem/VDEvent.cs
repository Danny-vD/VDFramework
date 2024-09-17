using System;
using VDFramework.ObserverPattern.Constants;

namespace VDFramework.EventSystem
{
	/// <summary>
	/// An abstract representation of a global event that provides an easier way to add/remove listeners 
	/// </summary>
	public abstract class VDEvent<TEvent> : VDEvent where TEvent : VDEvent<TEvent>
	{
		/// <summary>
		/// The listeners to this global event that take in an instance of this event as a parameter
		/// </summary>
		public static event Action<TEvent> Listeners
		{
			add => EventManager.AddListener(value);
			remove => EventManager.RemoveListener(value);
		}

		/// <summary>
		/// The listeners to this global event that have no parameters
		/// </summary>
		public static event Action ParameterlessListeners
		{
			add => EventManager.AddListener<TEvent>(value);
			remove => EventManager.RemoveListener<TEvent>(value);
		}

		/// <summary>
		/// A shortcut to add a listener with a given priority to this event
		/// </summary>
		/// <param name="handler">The function that will be invoked when this event is raised</param>
		/// <param name="priorityOrder">Higher priority will be invoked over lower priority</param>
		public static void AddListener(Action<TEvent> handler, int priorityOrder = Priority.DEFAULT)
		{
			EventManager.AddListener(handler, priorityOrder);
		}

		/// <summary>
		/// A shortcut to add a listener with a given priority to this event
		/// </summary>
		/// <param name="handler">The function that will be invoked when this event is raised</param>
		/// <param name="priorityOrder">Higher priority will be invoked over lower priority</param>
		public static void AddListener(Action handler, int priorityOrder = Priority.DEFAULT)
		{
			EventManager.AddListener<TEvent>(handler, priorityOrder);
		}
		
		/// <summary>
		/// A shortcut to remove a listener from this event
		/// </summary>
		public static void RemoveListener(Action<TEvent> handler)
		{
			EventManager.RemoveListener(handler);
		}
		
		/// <summary>
		/// A shortcut to remove a listener from this event
		/// </summary>
		public static void RemoveListener(Action handler)
		{
			EventManager.RemoveListener<TEvent>(handler);
		}
	}

	/// <summary>
	/// An abstract representation of a global event
	/// </summary>
	public abstract class VDEvent
	{
		/// <summary>
		/// If an event is consumed it will invoke no more listeners
		/// </summary>
		public bool Consumed { get; private set; }

		/// <summary>
		/// Consume this event and prevent any additional listeners from being invoked
		/// </summary>
		public void Consume()
		{
			Consumed = true;
		}
	}
}