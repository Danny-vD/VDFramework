using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VDFramework.EventSystem
{
	/// <summary>
	/// The manager class for the global event system, use this class to add and remove listeners from events and to raise an event
	/// </summary>
	/// <seealso cref="AddListener{TEvent}(System.Action,int)"/>
	/// <seealso cref="RemoveListener{TEvent}(System.Action)"/>
	/// <seealso cref="RaiseEvent{TEvent}"/>
	public static class EventManager
	{
		// A dictionary of EventHandlers per Event Type
		private static readonly Dictionary<Type, List<EventHandler>> eventHandlersPerEventType = new Dictionary<Type, List<EventHandler>>();

		// Used by the non-generic RaiseEvent(Type) function to construct a RaiseEvent<T> where T is the type of the given event
		private static readonly MethodInfo genericRaiseEventMethodInfo = typeof(EventManager).GetMethod(nameof(RaiseEvent), BindingFlags.Static);
		private static readonly Dictionary<Type, MethodInfo> specificRaiseEventMethods = new Dictionary<Type, MethodInfo>();

		/////////////////////////////////////RaiseEvent/////////////////////////////////////
		public static void RaiseEvent<TEvent>(TEvent eventToRaise) where TEvent : VDEvent
		{
			List<EventHandler> handlers = GetEventHandlers<TEvent>();

			if (handlers.Count == 0 || eventToRaise.Consumed)
			{
				return;
			}

			// Copy so that we can add and remove from the original list without editing the list we loop through
			foreach (EventHandler handler in new List<EventHandler>(handlers).Where(handler => handler != null))
			{
				if (eventToRaise.Consumed)
				{
					return;
				}

				switch (handler)
				{
					case EventHandler<TEvent> eventHandler:
						eventHandler.Invoke(eventToRaise);
						break;
					case ParameterlessEventHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
				}
			}
		}

		public static void RaiseEvent(Type eventToRaiseType, params object[] eventArguments)
		{
			if (!eventToRaiseType.IsSubclassOf(typeof(VDEvent)))
			{
				throw new ArgumentException("The given type does not inherit from " + nameof(VDEvent), nameof(eventToRaiseType));
			}

			object eventObject = Activator.CreateInstance(eventToRaiseType, eventArguments);
			
			if (!specificRaiseEventMethods.TryGetValue(eventToRaiseType, out MethodInfo raiseEventMethod))
			{
				// Construct the RaiseEvent<T> method where T is the specific type of this event
				raiseEventMethod = genericRaiseEventMethodInfo.MakeGenericMethod(eventToRaiseType);
				
				specificRaiseEventMethods.Add(eventToRaiseType, raiseEventMethod);
			}

			raiseEventMethod.Invoke(null, new object[] { eventObject });
		}

		/////////////////////////////////////AddListener/////////////////////////////////////
		public static void AddListener<TEvent>(Action<TEvent> listener, int priorityOrder = 0) where TEvent : VDEvent
		{
			EventHandler handler = new EventHandler<TEvent>(listener, priorityOrder);

			AddListenerInternal<TEvent>(handler);
		}

		public static void AddListener<TEvent>(Action listener, int priorityOrder = 0) where TEvent : VDEvent
		{
			AddListener(typeof(TEvent), listener, priorityOrder);
		}

		public static void AddListener(Type eventType, Action listener, int priorityOrder = 0)
		{
			EventHandler handler = new ParameterlessEventHandler(listener, priorityOrder);
			AddListenerInternal(eventType, handler);
		}

		/////////////////////////////////////RemoveListener/////////////////////////////////////
		public static void RemoveListener<TEvent>(Action<TEvent> listener) where TEvent : VDEvent
		{
			RemoveListenerInternal<TEvent>(listener);
		}

		public static void RemoveListener<TEvent>(Action listener) where TEvent : VDEvent
		{
			RemoveListener(typeof(TEvent), listener);
		}

		public static void RemoveListener(Type eventType, Action listener)
		{
			RemoveListenerInternal(eventType, listener);
		}

		public static void RemoveAllListeners<TEvent>() where TEvent : VDEvent
		{
			RemoveAllListeners(typeof(TEvent));
		}

		public static void RemoveAllListeners(Type type)
		{
			if (!type.IsAssignableFrom(typeof(VDEvent)) && !type.IsAssignableFrom(typeof(VDEvent<>)))
			{
				throw new ArgumentException("The type has to be a subclass of VDEvent!", nameof(type));
			}

			RemoveAllListenersInternal(type);
		}

		/////////////////////////////////////AddListenerInternal/////////////////////////////////////
		private static void AddListenerInternal<TEvent>(EventHandler handler)
		{
			AddListenerInternal(typeof(TEvent), handler);
		}

		private static void AddListenerInternal(Type eventType, EventHandler handler)
		{
			if (!eventHandlersPerEventType.ContainsKey(eventType))
			{
				eventHandlersPerEventType.Add(eventType, new List<EventHandler>());
			}

			List<EventHandler> eventHandlers = eventHandlersPerEventType[eventType];
			eventHandlers.Add(handler);

			eventHandlers.Sort();
		}

		/////////////////////////////////////RemoveListenerInternal/////////////////////////////////////
		private static void RemoveListenerInternal<TEvent>(Delegate listener) where TEvent : VDEvent
		{
			RemoveListenerInternal(typeof(TEvent), listener);
		}

		private static void RemoveListenerInternal(Type eventType, Delegate listener)
		{
			List<EventHandler> eventHandlers = GetEventHandlers(eventType);

			if (eventHandlers.Count == 0)
			{
				return;
			}

			EventHandler handler = eventHandlers.FirstOrDefault(handlerInList => handlerInList == listener);

			eventHandlers.Remove(handler);
		}

		private static void RemoveAllListenersInternal(Type eventType)
		{
			if (!eventHandlersPerEventType.TryGetValue(eventType, out List<EventHandler> eventHandlers))
			{
				return;
			}

			eventHandlers.Clear();
		}

		/////////////////////////////////////GetEventHandlers/////////////////////////////////////
		private static List<EventHandler> GetEventHandlers<TEvent>() where TEvent : VDEvent
		{
			return GetEventHandlers(typeof(TEvent));
		}

		private static List<EventHandler> GetEventHandlers(Type eventType)
		{
			return eventHandlersPerEventType.TryGetValue(eventType, out List<EventHandler> handlers) ? handlers : new List<EventHandler>();
		}
	}
}