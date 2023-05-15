using System;

namespace VDFramework.Utility.TimerUtil.TimerHandles.Parameters
{
	/// <summary>
	/// A Handle for a timer that has a callback that has 1 parameter
	/// </summary>
	/// <typeparam name="TParam1">The type of the parameter</typeparam>
	public class ParameterTimerHandler<TParam1> : AbstractParametersTimerHandle<Action<TParam1>>
	{
		/// <summary>
		/// The parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 1;

		/// <summary>
		/// A Handle for a timer that has a callback that has 1 parameter
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime, Action<TParam1> callback, bool loop, TParam1 param1) : base(startTime, callback, loop)
		{
			Param1 = param1;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 1 parameter
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1> callback, bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 2 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2> : AbstractParametersTimerHandle<Action<TParam1, TParam2>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 2;

		/// <summary>
		/// A Handle for a timer that has a callback that has 2 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2> callback, bool loop, TParam1 param1, TParam2 param2) : base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 2 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 3 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3> : AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 3;

		/// <summary>
		/// A Handle for a timer that has a callback that has 3 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3> callback, bool loop, TParam1 param1, TParam2 param2, TParam3 param3)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 3 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 4 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> : AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 4;

		/// <summary>
		/// A Handle for a timer that has a callback that has 4 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4> callback, bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 4 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 5 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> : AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// A Handle for a timer that has a callback that has no parameters
		/// </summary>
		public override int ParameterCount => 5;

		/// <summary>
		/// A Handle for a timer that has a callback that has 5 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double         startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5> callback,
			bool                                                loop,
			TParam1                                             param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
			Param5 = param5;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 5 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 6 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 6;

		/// <summary>
		/// A Handle for a timer that has a callback that has 6 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double                  startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> callback,
			bool                                                         loop,
			TParam1                                                      param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
			Param5 = param5;
			Param6 = param6;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 6 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 7 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 7;

		/// <summary>
		/// A Handle for a timer that has a callback that has 7 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double                           startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> callback,
			bool                                                                  loop,
			TParam1                                                               param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
			Param5 = param5;
			Param6 = param6;
			Param7 = param7;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 7 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> callback, bool loop, params object[] callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 8 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> : AbstractParametersTimerHandle<
		Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 8;

		/// <summary>
		/// A Handle for a timer that has a callback that has 8 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
			Param5 = param5;
			Param6 = param6;
			Param7 = param7;
			Param8 = param8;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 8 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> callback, bool loop,
			params object[]                             callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 9 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 9;

		/// <summary>
		/// A Handle for a timer that has a callback that has 9 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9)
			: base(startTime, callback, loop)
		{
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Param4 = param4;
			Param5 = param5;
			Param6 = param6;
			Param7 = param7;
			Param8 = param8;
			Param9 = param9;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 9 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> callback, bool loop,
			params object[]                             callbackParameters)
			: base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 10 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 10;

		/// <summary>
		/// A Handle for a timer that has a callback that has 10 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 10 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 11 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 11;

		/// <summary>
		/// A Handle for a timer that has a callback that has 11 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		/// <param name="param11">The eleventh parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 11 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 12 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	/// <typeparam name="TParam12">The type of the twelfth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <summary>
		/// The twelfth parameter that is used to invoke the callback
		/// </summary>
		public TParam12 Param12 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 12;

		/// <summary>
		/// A Handle for a timer that has a callback that has 12 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		/// <param name="param11">The eleventh parameter that is used to invoke the callback</param>
		/// <param name="param12">The twelfth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11, TParam12 param12)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
			Param12 = param12;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 12 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
				case 11:
					Param12 = (TParam12)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				11 => Param12,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 13 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	/// <typeparam name="TParam12">The type of the twelfth parameter</typeparam>
	/// <typeparam name="TParam13">The type of the thirteenth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <summary>
		/// The twelfth parameter that is used to invoke the callback
		/// </summary>
		public TParam12 Param12 { get; set; }

		/// <summary>
		/// The thirteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam13 Param13 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 13;

		/// <summary>
		/// A Handle for a timer that has a callback that has 13 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		/// <param name="param11">The eleventh parameter that is used to invoke the callback</param>
		/// <param name="param12">The twelfth parameter that is used to invoke the callback</param>
		/// <param name="param13">The thirteenth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11, TParam12 param12, TParam13 param13)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
			Param12 = param12;
			Param13 = param13;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 13 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
				case 11:
					Param12 = (TParam12)parameterValue;
					break;
				case 12:
					Param13 = (TParam13)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				11 => Param12,
				12 => Param13,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 14 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	/// <typeparam name="TParam12">The type of the twelfth parameter</typeparam>
	/// <typeparam name="TParam13">The type of the thirteenth parameter</typeparam>
	/// <typeparam name="TParam14">The type of the fourteenth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <summary>
		/// The twelfth parameter that is used to invoke the callback
		/// </summary>
		public TParam12 Param12 { get; set; }

		/// <summary>
		/// The thirteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam13 Param13 { get; set; }

		/// <summary>
		/// The fourteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam14 Param14 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 14;

		/// <summary>
		/// A Handle for a timer that has a callback that has 14 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11, TParam12 param12, TParam13 param13, TParam14 param14)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
			Param12 = param12;
			Param13 = param13;
			Param14 = param14;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 14 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
				case 11:
					Param12 = (TParam12)parameterValue;
					break;
				case 12:
					Param13 = (TParam13)parameterValue;
					break;
				case 13:
					Param14 = (TParam14)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				11 => Param12,
				12 => Param13,
				13 => Param14,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13, Param14);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 15 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	/// <typeparam name="TParam12">The type of the twelfth parameter</typeparam>
	/// <typeparam name="TParam13">The type of the thirteenth parameter</typeparam>
	/// <typeparam name="TParam14">The type of the fourteenth parameter</typeparam>
	/// <typeparam name="TParam15">The type of the fifteenth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <summary>
		/// The twelfth parameter that is used to invoke the callback
		/// </summary>
		public TParam12 Param12 { get; set; }

		/// <summary>
		/// The thirteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam13 Param13 { get; set; }

		/// <summary>
		/// The fourteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam14 Param14 { get; set; }

		/// <summary>
		/// The fifteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam15 Param15 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 15;

		/// <summary>
		/// A Handle for a timer that has a callback that has 15 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		/// <param name="param11">The eleventh parameter that is used to invoke the callback</param>
		/// <param name="param12">The twelfth parameter that is used to invoke the callback</param>
		/// <param name="param13">The thirteenth parameter that is used to invoke the callback</param>
		/// <param name="param14">The fourteenth parameter that is used to invoke the callback</param>
		/// <param name="param15">The fifteenth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11, TParam12 param12, TParam13 param13, TParam14 param14, TParam15 param15)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
			Param12 = param12;
			Param13 = param13;
			Param14 = param14;
			Param15 = param15;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 15 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
				case 11:
					Param12 = (TParam12)parameterValue;
					break;
				case 12:
					Param13 = (TParam13)parameterValue;
					break;
				case 13:
					Param14 = (TParam14)parameterValue;
					break;
				case 14:
					Param15 = (TParam15)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				11 => Param12,
				12 => Param13,
				13 => Param14,
				14 => Param15,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13, Param14, Param15);
		}
	}

	/// <summary>
	/// A Handle for a timer that has a callback that has 16 parameters
	/// </summary>
	/// <typeparam name="TParam1">The type of the first parameter</typeparam>
	/// <typeparam name="TParam2">The type of the second parameter</typeparam>
	/// <typeparam name="TParam3">The type of the third parameter</typeparam>
	/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
	/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
	/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
	/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
	/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
	/// <typeparam name="TParam9">The type of the ninth parameter</typeparam>
	/// <typeparam name="TParam10">The type of the tenth parameter</typeparam>
	/// <typeparam name="TParam11">The type of the eleventh parameter</typeparam>
	/// <typeparam name="TParam12">The type of the twelfth parameter</typeparam>
	/// <typeparam name="TParam13">The type of the thirteenth parameter</typeparam>
	/// <typeparam name="TParam14">The type of the fourteenth parameter</typeparam>
	/// <typeparam name="TParam15">The type of the fifteenth parameter</typeparam>
	/// <typeparam name="TParam16">The type of the sixteenth parameter</typeparam>
	public class ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
		: AbstractParametersTimerHandle<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>>
	{
		/// <summary>
		/// The first parameter that is used to invoke the callback
		/// </summary>
		public TParam1 Param1 { get; set; }

		/// <summary>
		/// The second parameter that is used to invoke the callback
		/// </summary>
		public TParam2 Param2 { get; set; }

		/// <summary>
		/// The third parameter that is used to invoke the callback
		/// </summary>
		public TParam3 Param3 { get; set; }

		/// <summary>
		/// The fourth parameter that is used to invoke the callback
		/// </summary>
		public TParam4 Param4 { get; set; }

		/// <summary>
		/// The fifth parameter that is used to invoke the callback
		/// </summary>
		public TParam5 Param5 { get; set; }

		/// <summary>
		/// The sixth parameter that is used to invoke the callback
		/// </summary>
		public TParam6 Param6 { get; set; }

		/// <summary>
		/// The seventh parameter that is used to invoke the callback
		/// </summary>
		public TParam7 Param7 { get; set; }

		/// <summary>
		/// The eighth parameter that is used to invoke the callback
		/// </summary>
		public TParam8 Param8 { get; set; }

		/// <summary>
		/// The ninth parameter that is used to invoke the callback
		/// </summary>
		public TParam9 Param9 { get; set; }

		/// <summary>
		/// The tenth parameter that is used to invoke the callback
		/// </summary>
		public TParam10 Param10 { get; set; }

		/// <summary>
		/// The eleventh parameter that is used to invoke the callback
		/// </summary>
		public TParam11 Param11 { get; set; }

		/// <summary>
		/// The twelfth parameter that is used to invoke the callback
		/// </summary>
		public TParam12 Param12 { get; set; }

		/// <summary>
		/// The thirteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam13 Param13 { get; set; }

		/// <summary>
		/// The fourteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam14 Param14 { get; set; }

		/// <summary>
		/// The fifteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam15 Param15 { get; set; }

		/// <summary>
		/// The sixteenth parameter that is used to invoke the callback
		/// </summary>
		public TParam16 Param16 { get; set; }

		/// <inheritdoc />
		public override int ParameterCount => 16;

		/// <summary>
		/// A Handle for a timer that has a callback that has 16 parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="callback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <param name="param9">The ninth parameter that is used to invoke the callback</param>
		/// <param name="param10">The tenth parameter that is used to invoke the callback</param>
		/// <param name="param11">The eleventh parameter that is used to invoke the callback</param>
		/// <param name="param12">The twelfth parameter that is used to invoke the callback</param>
		/// <param name="param13">The thirteenth parameter that is used to invoke the callback</param>
		/// <param name="param14">The fourteenth parameter that is used to invoke the callback</param>
		/// <param name="param15">The fifteenth parameter that is used to invoke the callback</param>
		/// <param name="param16">The sixteenth parameter that is used to invoke the callback</param>
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16> callback,
			bool loop, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10,
			TParam11 param11, TParam12 param12, TParam13 param13, TParam14 param14, TParam15 param15, TParam16 param16)
			: base(startTime, callback, loop)
		{
			Param1  = param1;
			Param2  = param2;
			Param3  = param3;
			Param4  = param4;
			Param5  = param5;
			Param6  = param6;
			Param7  = param7;
			Param8  = param8;
			Param9  = param9;
			Param10 = param10;
			Param11 = param11;
			Param12 = param12;
			Param13 = param13;
			Param14 = param14;
			Param15 = param15;
			Param16 = param16;
		}

		/// <summary>
		/// A Handle for a timer that has a callback that has 16 parameters
		/// </summary>
		/// <inheritdoc />
		public ParameterTimerHandler(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16> callback,
			bool loop, params object[] callbackParameters) : base(startTime, callback, loop, callbackParameters)
		{
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			switch (parameterIndex)
			{
				case 0:
					Param1 = (TParam1)parameterValue;
					break;
				case 1:
					Param2 = (TParam2)parameterValue;
					break;
				case 2:
					Param3 = (TParam3)parameterValue;
					break;
				case 3:
					Param4 = (TParam4)parameterValue;
					break;
				case 4:
					Param5 = (TParam5)parameterValue;
					break;
				case 5:
					Param6 = (TParam6)parameterValue;
					break;
				case 6:
					Param7 = (TParam7)parameterValue;
					break;
				case 7:
					Param8 = (TParam8)parameterValue;
					break;
				case 8:
					Param9 = (TParam9)parameterValue;
					break;
				case 9:
					Param10 = (TParam10)parameterValue;
					break;
				case 10:
					Param11 = (TParam11)parameterValue;
					break;
				case 11:
					Param12 = (TParam12)parameterValue;
					break;
				case 12:
					Param13 = (TParam13)parameterValue;
					break;
				case 13:
					Param14 = (TParam14)parameterValue;
					break;
				case 14:
					Param15 = (TParam15)parameterValue;
					break;
				case 15:
					Param16 = (TParam16)parameterValue;
					break;
			}
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameterIndex switch
			{
				0 => Param1,
				1 => Param2,
				2 => Param3,
				3 => Param4,
				4 => Param5,
				5 => Param6,
				6 => Param7,
				7 => Param8,
				8 => Param9,
				9 => Param10,
				10 => Param11,
				11 => Param12,
				12 => Param13,
				13 => Param14,
				14 => Param15,
				15 => Param16,
				_ => null,
			};
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.Invoke(Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13, Param14, Param15, Param16);
		}
	}
}