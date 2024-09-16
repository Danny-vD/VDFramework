namespace VDFramework.ObserverPattern.Constants
{
	/// <summary>
	/// A helper class that provides constants for priorities (can be used in for example the <see cref="EventSystem.EventManager"/> and <see cref="PrioritisedAction"/>
	/// </summary>
	public static class Priority
	{
		public const int Highest = int.MaxValue;
		public const int Default = 0;
		public const int Lowest = int.MinValue;
	}
}