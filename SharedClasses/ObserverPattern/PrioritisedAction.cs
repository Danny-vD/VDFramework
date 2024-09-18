using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;
using VDFramework.ObserverPattern.Constants;

namespace VDFramework.ObserverPattern
{
	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke()
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				((ParameterlessCallbackHandler)callbackHandler).Invoke();
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1> handler:
						handler.Invoke(arg1);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2> handler:
						handler.Invoke(arg1, arg2);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3> handler:
						handler.Invoke(arg1, arg2, arg3);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4> handler:
						handler.Invoke(arg1, arg2, arg3, arg4);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
						break;
				}
			}
		}
	}

	/// <summary>
	/// A class that mimics System.Action but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Action ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Action callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new ParameterlessCallbackHandler(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		/// <param name="callback">The callback to remove</param>
		public void RemoveCallback(Action callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		///<summary>
		/// Removes all the callbacks from this delegate
		///</summary>
		public void ClearCallbacks()
		{
			eventHandlers.Clear();
		}

		/// <summary>
		/// Invoke the callbacks according to their priority
		/// </summary>
		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				switch (callbackHandler)
				{
					case ParameterlessCallbackHandler parameterlessEventHandler:
						parameterlessEventHandler.Invoke();
						break;
					case CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler:
						handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
						break;
				}
			}
		}
	}
}