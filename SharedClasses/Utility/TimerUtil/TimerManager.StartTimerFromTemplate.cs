using System;
using VDFramework.Utility.TimerUtil.TimerHandles;
using VDFramework.Utility.TimerUtil.TimerHandles.Parameters;

namespace VDFramework.Utility.TimerUtil
{
	public static partial class TimerManager
	{
		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <returns>A new TimerHandle</returns>
		public static TimerHandle StartNewTimerFromTemplate(AbstractTimerHandle<Action> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping);
		}
		
		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1> StartNewTimerFromTemplate<TParam1>(ParameterTimerHandler<TParam1> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2> StartNewTimerFromTemplate<TParam1, TParam2>(ParameterTimerHandler<TParam1, TParam2> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3> StartNewTimerFromTemplate<TParam1, TParam2, TParam3>(ParameterTimerHandler<TParam1, TParam2, TParam3> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
		/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
		/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
		/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
		/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
		/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
		/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
		/// </summary>
		/// <typeparam name="TParam1">The type of the first parameter</typeparam>
		/// <typeparam name="TParam2">The type of the second parameter</typeparam>
		/// <typeparam name="TParam3">The type of the third parameter</typeparam>
		/// <typeparam name="TParam4">The type of the fourth parameter</typeparam>
		/// <typeparam name="TParam5">The type of the fifth parameter</typeparam>
		/// <typeparam name="TParam6">The type of the sixth parameter</typeparam>
		/// <typeparam name="TParam7">The type of the seventh parameter</typeparam>
		/// <typeparam name="TParam8">The type of the eighth parameter</typeparam>
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
			TParam7, TParam8>(ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5,
			TParam6, TParam7, TParam8, TParam9>(ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4,
			TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> StartNewTimerFromTemplate<TParam1, TParam2, TParam3,
			TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> StartNewTimerFromTemplate<TParam1, TParam2,
			TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> StartNewTimerFromTemplate<TParam1,
			TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>(
			ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>
			StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>(
				ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>
			StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15>(
				ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}

		/// <summary>
		/// Starts a new timer using the data from the given TimerHandle
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
		/// <returns>A new ParameterTimerHandler with the given parameters</returns>
		public static ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>
			StartNewTimerFromTemplate<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16>(
				ParameterTimerHandler<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TParam16> handle)
		{
			return StartNewTimer(handle.StartTime, handle.OnTimerExpire, handle.IsLooping, handle.GetParameters());
		}
	}
}