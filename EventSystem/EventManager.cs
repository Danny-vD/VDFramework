using System;
using System.Collections.Generic;

namespace VDFramework.EventSystem
{
	using Singleton;
	
	public class EventManager : Singleton<EventManager>
	{
		private Dictionary<Type, EventHandler> eventHandlerPerEventType = new Dictionary<Type, EventHandler>();
		
		public EventManager() 
		{
		}

		public void RaiseEvent<TEvent>(TEvent eventToRaise) where TEvent : VDEvent
		{
			//List<EventHandler> handlers = GetEventHandlers<TEvent>();
		}
	}
}