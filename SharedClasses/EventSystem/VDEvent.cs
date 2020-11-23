using System;

namespace VDFramework.EventSystem
{
	public abstract class VDEvent<TEvent> : VDEvent where TEvent : VDEvent<TEvent>
	{
		public static event Action<TEvent> Listeners
		{
			add => EventManager.Instance.AddListener(value);
			remove => EventManager.Instance.RemoveListener(value);
		}
		
		public static event Action ParameterlessListeners
		{
			add => EventManager.Instance.AddListener<TEvent>(value);
			remove => EventManager.Instance.RemoveListener<TEvent>(value);
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