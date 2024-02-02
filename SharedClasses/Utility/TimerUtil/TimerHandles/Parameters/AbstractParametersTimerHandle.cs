using System;

namespace VDFramework.Utility.TimerUtil.TimerHandles.Parameters
{
	/// <summary>
	/// An abstract TimerHandle that has additional methods specifically aimed at parameters
	/// </summary>
	/// <inheritdoc />
	public abstract class AbstractParametersTimerHandle<TDelegate> : AbstractTimerHandle<TDelegate> where TDelegate : Delegate
	{
		/// <summary>
		/// Get the amount of parameters of the callback that will be invoked when the timer expires
		/// </summary>
		/// <returns>The amount of parameters of the callback function</returns>
		public abstract int ParameterCount { get; }

		/// <summary>
		/// An abstract TimerHandle that has additional methods specifically aimed at parameters
		/// </summary>
		/// <inheritdoc />
		protected AbstractParametersTimerHandle(double startTime, TDelegate callback, bool loop) : base(startTime, callback, loop)
		{
		}

		/// <summary>
		/// An abstract TimerHandle that has additional methods specifically aimed at parameters
		/// </summary>
		/// <param name="startTime">The time in seconds after which the callback will be invoked</param>
		/// <param name="loop">Whether this timer should loop (restart once it ends)</param>
		/// <param name="callback">The callback that will be invoked after the timer expires</param>
		/// <param name="callbackParameters">Parameters that will be used to invoke the callback, any undefined parameters will be their default value and any excess will be ignored</param>
		protected AbstractParametersTimerHandle(double startTime, TDelegate callback, bool loop, params object[] callbackParameters) : this(startTime, callback, loop)
		{
			SetParameters(callbackParameters);
		}

		/// <summary>
		/// Get the currently set parameters of this TimerHandle
		/// </summary>
		/// <returns>The parameters that will be used to invoke the callback</returns>
		public virtual object[] GetParameters()
		{
			object[] parameters = new object[ParameterCount];

			for (int i = 0; i < parameters.Length; i++)
			{
				parameters[i] = GetParameter(i);
			}

			return parameters;
		}

		/// <summary>
		/// Return the parameter at the specified index
		/// </summary>
		/// <param name="parameterIndex">The index of the parameter (zero-indexed)</param>
		/// <returns>The boxed parameter</returns>
		public abstract object GetParameter(int parameterIndex);

		/// <summary>
		/// <para>Set parameters that will be used to invoke the callback</para>
		/// <para>Setting this to more than the <see cref="ParameterCount"/> will not cause an out of bounds exception because any excess will be ignored</para>
		/// <para>Setting this to less than the <see cref="ParameterCount"/> will only change the parameters up to callbackParameters.Length</para>
		/// </summary>
		/// <param name="callbackParameters">The new parameters to be used for invoking the callback</param>
		public void SetParameters(object[] callbackParameters)
		{
			for (int i = 0; i < ParameterCount && i < callbackParameters.Length; i++)
			{
				SetParameter(i, callbackParameters[i]);
			}
		}

		/// <summary>
		/// Set the respective parameter to the given value
		/// </summary>
		/// <param name="parameterIndex">The index of the parameter (zero-indexed)</param>
		/// <param name="parameterValue">the new value of the parameter</param>
		public abstract void SetParameter(int parameterIndex, object parameterValue);
	}
}