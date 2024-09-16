using System;

namespace VDFramework.ObserverPattern
{
	internal class ParameterlessCallbackHandler : CallbackHandler
	{
		public ParameterlessCallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke()
		{
			if (Callback is Action action)
			{
				action.Invoke();
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1)
		{
			if (Callback is Action<T1> action)
			{
				action.Invoke(arg1);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2)
		{
			if (Callback is Action<T1, T2> action)
			{
				action.Invoke(arg1, arg2);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3)
		{
			if (Callback is Action<T1, T2, T3> action)
			{
				action.Invoke(arg1, arg2, arg3);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			if (Callback is Action<T1, T2, T3, T4> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			if (Callback is Action<T1, T2, T3, T4, T5> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}

	internal class CallbackHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : CallbackHandler
	{
		public CallbackHandler(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			if (Callback is Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
			{
				action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			}
			else
			{
				throw new InvalidCastException("The delegate is not of a valid type!");
			}
		}
	}
}