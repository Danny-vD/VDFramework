namespace VDFramework
{
	/// <summary>
	/// <para>A variation of an <see cref="BetterMonoBehaviour"/> that does <b>not</b> invoke <see cref="OnEnabled"/> before <see cref="Start"/></para>
	/// <para>Set <see cref="invokeOnEnabledAfterStart"/> to false if you do not want to immediately invoke <see cref="OnEnabled"/></para>
	/// </summary>
	/// <order>Awake() → Start() → OnEnabled()</order>
	public class SafeEnableBehaviour : BetterMonoBehaviour
	{
		/// <summary>
		/// If true, <see cref="OnEnabled"/> will be invoked immediately after <see cref="Start"/> (instead of waiting until the object is enabled again)
		/// </summary>
		protected bool invokeOnEnabledAfterStart = true;
		
		private bool hasStartRun = false;
		
		private void OnEnable()
		{
			if (!hasStartRun)
			{
				return;
			}
			
			OnEnabled();
		}

		/// <summary>
		/// This function is called when the object becomes enabled and active, but never before <see cref="Start"/>
		/// </summary>
		protected virtual void OnEnabled()
		{
		}

		/// <summary>
		/// Unity's start function
		/// </summary>
		protected virtual void Start()
		{
			hasStartRun = true;

			if (invokeOnEnabledAfterStart)
			{
				OnEnabled();
			}
		}
	}
}