using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.Extensions;
using VDFramework.ObserverPattern.Constants;

namespace VDFramework.ObserverPattern
{
	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke()
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = ((CallbackHandlerWithReturnType<TResult>)callbackHandler).Invoke();
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, TResult> handler => handler.Invoke(arg1),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, TResult> handler => handler.Invoke(arg1, arg2),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, TResult> handler => handler.Invoke(arg1, arg2, arg3),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
						arg13),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
						arg13, arg14),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
						arg12, arg13, arg14, arg15),
					_ => result,
				};
			}

			return result;
		}
	}

	/// <summary>
	/// A class that mimics System.Func but allows giving a priority to the callbacks
	/// </summary>
	public class PrioritisedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>
	{
		private readonly List<CallbackHandler> eventHandlers = new List<CallbackHandler>();

		/// <summary>
		/// The callbacks associated with this delegate
		/// </summary>
		public event Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Callbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// The callbacks associated with this delegate that have no parameters
		/// </summary>
		public event Func<TResult> ParameterlessCallbacks
		{
			add => AddCallback(value);
			remove => RemoveCallback(value);
		}

		/// <summary>
		/// Add a new callback to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> callback)
		{
			eventHandlers.Remove(eventHandlers.FirstOrDefault(handler => handler == callback));
		}

		/// <summary>
		/// Add a new callback without parameters to this delegate
		/// </summary>
		/// <param name="callback">The callback to add</param>
		/// <param name="priority">The priority of this callback, higher priority will be invoked before lower</param>
		public void AddCallback(Func<TResult> callback, int priority = Priority.DEFAULT)
		{
			eventHandlers.AddSorted(new CallbackHandlerWithReturnType<TResult>(callback, priority));
		}

		/// <summary>
		/// Remove a callback from this delegate
		/// </summary>
		public void RemoveCallback(Func<TResult> callback)
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
		/// Invoke the callbacks according to their priority <br/>
		/// Only the last result will be returned
		/// </summary>
		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			TResult result = default;

			foreach (CallbackHandler callbackHandler in eventHandlers)
			{
				result = callbackHandler switch
				{
					CallbackHandlerWithReturnType<TResult> parameterlessHandler => parameterlessHandler.Invoke(),
					CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> handler => handler.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10,
						arg11, arg12, arg13, arg14, arg15, arg16),
					_ => result,
				};
			}

			return result;
		}
	}
}