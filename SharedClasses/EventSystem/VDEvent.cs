using System;

namespace VDFramework.EventSystem
{
	public abstract class VDEvent<TEvent> : VDEvent where TEvent : VDEvent<TEvent>
	{
		public static event Action<TEvent> Listeners
		{
			add => EventManager.AddListener(value);
			remove => EventManager.RemoveListener(value);
		}

		public static event Action ParameterlessListeners
		{
			add => EventManager.AddListener<TEvent>(value);
			remove => EventManager.RemoveListener<TEvent>(value);
		}
	}

	public abstract class VDEvent
	{
		public bool Consumed { get; private set; }

		public void Consume()
		{
			Consumed = true;
		}
	}
}