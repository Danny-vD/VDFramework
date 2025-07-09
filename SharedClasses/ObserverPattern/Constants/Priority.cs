namespace VDFramework.ObserverPattern.Constants
{
	/// <summary>
	/// A helper class that provides constants for priorities
	/// </summary>
	/// <remarks>
	/// Useful in for example the <see cref="EventSystem.EventManager"/> and <see cref="PrioritisedAction"/>
	/// </remarks>
	public static class Priority
	{
		/// <summary>
		/// The highest possible priority, should always be first
		/// </summary>
		public const int HIGHEST = int.MaxValue;
		
		/// <summary>
		/// A higher than default priority
		/// </summary>
		public const int HIGH = 100;
		
		/// <summary>
		/// The default priority
		/// </summary>
		public const int DEFAULT = 0;

		/// <summary>
		/// A lower than default priority
		/// </summary>
		public const int LOW = -100;
		
		/// <summary>
		/// The priority for UI based systems (low so it can use changes from other systems)
		/// </summary>
		public const int UI = -500;
		
		/// <summary>
		/// The lowest possible priority, should always be last
		/// </summary>
		public const int LOWEST = int.MinValue;
	}
}