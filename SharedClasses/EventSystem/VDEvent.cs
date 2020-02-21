namespace VDFramework.EventSystem
{
	public abstract class VDEvent
	{
		public bool Consumed { get; private set; }

		public void Consume()
		{
			Consumed = true;
		}
	}
}