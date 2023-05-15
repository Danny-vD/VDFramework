using System;

namespace VDFramework.Utility.TimerUtil.TimerHandles.Parameters
{
	/// <summary>
	/// <para>A Handle for a timer that has a callback that has any number of parameters (depends on the given callback)</para>
	/// <para>While the Delegate supports any amount of parameters it is encouraged to use another option because <see cref="Delegate.DynamicInvoke"/> and the boxing-unboxing of parameters is very slow</para>
	/// </summary>
	public class DelegateTimerHandle : AbstractParametersTimerHandle<Delegate>
	{
		/// <summary>
		/// All the parameters as an array of objects
		/// </summary>
		private object[] parameters;

		/// <inheritdoc />
		/// <seealso cref="Delegate.DynamicInvoke"/>
		public override Delegate OnTimerExpire
		{
			get => base.OnTimerExpire;
			set
			{
				base.OnTimerExpire = value;
				ResizeParameterArray();
			}
		}

		/// <summary>
		/// Get the amount of parameters that the callback of this TimerHandle can take
		/// </summary>
		/// <returns>The amount of parameters of the callback function</returns>
		public override int ParameterCount => OnTimerExpire.Method.GetParameters().Length;

		// Does not call Base(double, TDelegate, bool, object[]) because we want to do our own method first before the parameters are set

		/// <summary>
		/// <para>A Handle for a timer that has a callback that has any number of parameters (depends on the given callback)</para>
		/// <para>While the Delegate supports any amount of parameters it is encouraged to use another option because <see cref="Delegate.DynamicInvoke"/> and the boxing-unboxing of parameters is very slow</para>
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callback will be invoked</param>
		/// <param name="callback">The callback that will be invoked after the timer expires</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		public DelegateTimerHandle(double startTime, Delegate callback, bool loop, params object[] callbackParameters) : base(startTime, callback, loop)
		{
			ResizeParameterArray();

			if (parameters.Length > 0)
			{
				SetParameters(callbackParameters);
			}
		}

		/// <inheritdoc />
		/// <Warning>This array is not a copy, changing the elements changes the actual parameters of the TimerHandle</Warning>
		public override object[] GetParameters()
		{
			return parameters;
		}

		/// <inheritdoc />
		public override object GetParameter(int parameterIndex)
		{
			return parameters[parameterIndex];
		}

		/// <inheritdoc />
		public override void SetParameter(int parameterIndex, object parameterValue)
		{
			parameters[parameterIndex] = parameterValue;
		}

		/// <inheritdoc />
		protected override void InvokeCallback()
		{
			OnTimerExpire.DynamicInvoke(parameters);
		}

		/// <summary>
		/// Will setup the parameter object[] to match the parameter count of the current delegate, will reuse any existing parameter array if it exists
		/// </summary>
		protected void ResizeParameterArray()
		{
			if (parameters == null)
			{
				parameters = new object[ParameterCount];
				return;
			}

			object[] oldParameters = parameters; // Store the old parameters so we don't override them when changing the Delegate
			parameters = new object[ParameterCount];

			SetParameters(oldParameters);
		}
	}
}