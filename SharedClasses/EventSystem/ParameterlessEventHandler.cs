using System;

// ReSharper disable once CheckNamespace
namespace VDFramework.EventSystem
{
	internal class ParameterlessEventHandler : EventHandler
	{
		public ParameterlessEventHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}
		
		public void Invoke()
		{
			(Callback as Action)?.Invoke();
		}
	}
}