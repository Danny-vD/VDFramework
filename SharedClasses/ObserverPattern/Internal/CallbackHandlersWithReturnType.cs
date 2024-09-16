using System;

namespace VDFramework.ObserverPattern
{
	internal class CallbackHandlerWithReturnType<TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke()
		{
			if (Callback is Func<TResult> func)
			{
				return func.Invoke();
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1)
		{
			if (Callback is Func<TResult> func)
			{
				return func.Invoke();
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2)
		{
			if (Callback is Func<T1, T2, TResult> func)
			{
				return func.Invoke(arg1, arg2);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
		{
			if (Callback is Func<T1, T2, T3, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			if (Callback is Func<T1, T2, T3, T4, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}

	internal class CallbackHandlerWithReturnType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : CallbackHandler
	{
		public CallbackHandlerWithReturnType(Delegate callback, int priorityOrder) : base(callback, priorityOrder)
		{
		}

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			if (Callback is Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func)
			{
				return func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			}

			throw new InvalidCastException("The delegate is not of a valid type!");
		}
	}
}