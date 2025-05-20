using System;
using VDFramework.Timer.TimerHandles.Parameters;

namespace VDFramework.Timer
{
	public static partial class TimerManager
	{
		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1> StartNewTimer<TParam1>(double startTime, Action<TParam1> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1> handle = new ParameterTimerHandler<TParam1>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1> StartNewTimer<TParam1>(double startTime, Action<TParam1> timerExpiredCallback, bool loop = false, TParam1 param1 = default)
		{
			ParameterTimerHandler<TParam1> handle = new ParameterTimerHandler<TParam1>(startTime, timerExpiredCallback, loop, param1);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2> StartNewTimer<TParam1, TParam2>(double startTime, Action<TParam1, TParam2> timerExpiredCallback, bool loop,
			params object[]                                                                          callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2> handle = new ParameterTimerHandler<TParam1, TParam2>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2> StartNewTimer<TParam1, TParam2>(double startTime,        Action<TParam1, TParam2> timerExpiredCallback, bool loop = false,
			TParam1                                                                                  param1 = default, TParam2                  param2 = default)
		{
			ParameterTimerHandler<TParam1, TParam2> handle = new ParameterTimerHandler<TParam1, TParam2>(startTime, timerExpiredCallback, loop, param1, param2);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3> StartNewTimer<TParam1, TParam2, TParam3>(double startTime, Action<TParam1, TParam2, TParam3> timerExpiredCallback, bool loop,
			params object[]                                                                                            callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3> handle = new ParameterTimerHandler<TParam1, TParam2, TParam3>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3> StartNewTimer<TParam1, TParam2, TParam3>(double startTime, Action<TParam1, TParam2, TParam3> timerExpiredCallback,
			bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3> handle = new ParameterTimerHandler<TParam1, TParam2, TParam3>(startTime, timerExpiredCallback, loop, param1, param2, param3);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> StartNewTimer<TParam1, TParam2, TParam3, TParam4>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> handle = new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> StartNewTimer<TParam1, TParam2, TParam3, TParam4>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> handle = new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4>(startTime, timerExpiredCallback, loop, param1, param2,
				param3, param4);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default,
			TParam4 param4 = default, TParam5 param5 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5>(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(double startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default,
			TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
			double startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
			double  startTime,        Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default,
			TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default, TParam7 param7 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>           timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="param1">The first parameter that is used to invoke the callback</param>
		/// <param name="param2">The second parameter that is used to invoke the callback</param>
		/// <param name="param3">The third parameter that is used to invoke the callback</param>
		/// <param name="param4">The fourth parameter that is used to invoke the callback</param>
		/// <param name="param5">The fifth parameter that is used to invoke the callback</param>
		/// <param name="param6">The sixth parameter that is used to invoke the callback</param>
		/// <param name="param7">The seventh parameter that is used to invoke the callback</param>
		/// <param name="param8">The eighth parameter that is used to invoke the callback</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default,
				TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default, TParam7 param7 = default, TParam8 param8 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(startTime, timerExpiredCallback, loop,
					param1, param2, param3, param4, param5, param6, param7, param8);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>           timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> timerExpiredCallback, bool loop = false, TParam1 param1 = default, TParam2 param2 = default,
				TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default, TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>(startTime, timerExpiredCallback, loop,
					param1, param2, param3, param4, param5, param6, param7, param8, param9);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>           timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> timerExpiredCallback, bool loop = false, TParam1 param1 = default,
				TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default, TParam7 param7 = default, TParam8 param8 = default,
				TParam9 param9 = default, TParam10 param10 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(startTime, timerExpiredCallback, loop, param1, param2, param3,
					param4, param5, param6, param7, param8, param9, param10);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> StartNewTimer<TParam1, TParam2, TParam3, TParam4,
			TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(double                                     startTime,
			Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> timerExpiredCallback, bool loop, params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(startTime, timerExpiredCallback, loop,
					callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> timerExpiredCallback, bool loop = false, TParam1 param1 = default,
				TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default, TParam7 param7 = default, TParam8 param8 = default,
				TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(startTime, timerExpiredCallback, loop, param1, param2,
					param3, param4, param5, param6, param7, param8, param9, param10, param11);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> StartNewTimer<TParam1, TParam2, TParam3,
			TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>
		(double             startTime, Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> timerExpiredCallback, bool loop,
			params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>(startTime, timerExpiredCallback, loop,
					callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> timerExpiredCallback,
				bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default,
				TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default, TParam12 param12 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>
					(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
					timerExpiredCallback,
				bool            loop,
				params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
				handle =
					new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
						(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> timerExpiredCallback,
				bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default,
				TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default, TParam12 param12 = default,
				TParam13 param13 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>
					(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
					timerExpiredCallback,
				bool            loop,
				params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
				handle =
					new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
						(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> timerExpiredCallback,
				bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default,
				TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default, TParam12 param12 = default,
				TParam13 param13 = default, TParam14 param14 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
					(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
					timerExpiredCallback,
				bool            loop,
				params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
				handle =
					new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
						(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15> timerExpiredCallback,
				bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default,
				TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default, TParam12 param12 = default,
				TParam13 param13 = default, TParam14 param14 = default, TParam15 param15 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
					(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
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
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16> timerExpiredCallback,
				bool loop = false, TParam1 param1 = default, TParam2 param2 = default, TParam3 param3 = default, TParam4 param4 = default, TParam5 param5 = default, TParam6 param6 = default,
				TParam7 param7 = default, TParam8 param8 = default, TParam9 param9 = default, TParam10 param10 = default, TParam11 param11 = default, TParam12 param12 = default,
				TParam13 param13 = default, TParam14 param14 = default, TParam15 param15 = default, TParam16 param16 = default)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16> handle =
				new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
					(startTime, timerExpiredCallback, loop, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);

			AddHandleToUpdateList(handle);

			return handle;
		}

		/// <summary>
		/// Start a new timer
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callBack will be called</param>
		/// <param name="timerExpiredCallback">The callback to invoke once the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		/// <returns>A handle to the timer, this can be used to pause the timer or change properties
		/// <para>It can also be safely ignored if not needed</para></returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
			StartNewTimer<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
			(double startTime,
				Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
					timerExpiredCallback,
				bool            loop,
				params object[] callbackParameters)
		{
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
				handle =
					new ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
						(startTime, timerExpiredCallback, loop, callbackParameters);

			AddHandleToUpdateList(handle);

			return handle;
		}
	}
}