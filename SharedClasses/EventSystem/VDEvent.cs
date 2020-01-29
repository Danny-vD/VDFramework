namespace VDFramework.EventSystem
{
	public class VDEvent
	{
		public bool Consumed { get; private set; }

		public void Consume()
		{
			Consumed = true;
		}
	}
}