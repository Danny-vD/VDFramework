using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Singleton;

namespace VDFramework.EventSystem
{
	public class EventManager : Singleton<EventManager>
	{
		private readonly Dictionary<Type, List<EventHandler>> eventHandlersPerEventType =
			new Dictionary<Type, List<EventHandler>>();

		/////////////////////////////////////RaiseEvent/////////////////////////////////////
		public void RaiseEvent<TEvent>(TEvent eventToRaise)
			where TEvent : VDEvent
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

		/////////////////////////////////////AddListener/////////////////////////////////////
		public void AddListener<TEvent>(Action<TEvent> listener, int priorityOrder = 0)
			where TEvent : VDEvent
		{
			EventHandler handler = new VDFramework.EventSystem.EventHandler<TEvent>(listener, priorityOrder);

			AddListenerInternal<TEvent>(handler);
		}

		public void AddListener<TEvent>(Action listener, int priorityOrder = 0)
			where TEvent : VDEvent
		{
			AddListener(typeof(TEvent), listener, priorityOrder);
		}

		public void AddListener(Type eventType, Action listener, int priorityOrder = 0)
		{
			EventHandler handler = new ParameterlessEventHandler(listener, priorityOrder);
			AddListenerInternal(eventType, handler);
		}

		/////////////////////////////////////RemoveListener/////////////////////////////////////
		public void RemoveListener<TEvent>(Action<TEvent> listener)
			where TEvent : VDEvent
		{
			RemoveListenerInternal<TEvent>(listener);
		}

		public void RemoveListener<TEvent>(Action listener)
			where TEvent : VDEvent
		{
			RemoveListenerInternal<TEvent>(listener);
		}

		/////////////////////////////////////AddListenerInternal/////////////////////////////////////
		private void AddListenerInternal<TEvent>(EventHandler handler)
		{
			AddListenerInternal(typeof(TEvent), handler);
		}

		private void AddListenerInternal(Type eventType, EventHandler handler)
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
		private void RemoveListenerInternal<TEvent>(Delegate listener)
			where TEvent : VDEvent
		{
			RemoveListenerInternal(typeof(TEvent), listener);
		}

		private void RemoveListenerInternal(Type eventType, Delegate listener)
		{
			List<EventHandler> eventHandlers = GetEventHandlers(eventType);

			if (eventHandlers.Count == 0)
			{
				return;
			}

			EventHandler handler = eventHandlers.FirstOrDefault(handlerInList => handlerInList == listener);

			eventHandlers.Remove(handler);
		}

		/////////////////////////////////////GetEventHandlers/////////////////////////////////////
		private List<EventHandler> GetEventHandlers<TEvent>()
			where TEvent : VDEvent
		{
			return GetEventHandlers(typeof(TEvent));
		}

		private List<EventHandler> GetEventHandlers(Type eventType)
		{
			return eventHandlersPerEventType.TryGetValue(eventType, out List<EventHandler> handlers)
				? handlers
				: new List<EventHandler>();
		}
	}
}