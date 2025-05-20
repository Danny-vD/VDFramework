using UnityEngine;

namespace VDFramework.Timer
{
	/// <summary>
	/// <para>A simple utility behaviour for Unity that updates the TimerManager in Update using Time.deltaTime</para>
	/// <para>(makes the object DontDestroyOnLoad)</para>
	/// </summary>
	public class TimerManagerUpdater : BetterMonoBehaviour
	{
		private static bool exists = false;
		private bool destroyStatic = true;
		
		private void Awake()
		{
			if (exists)
			{
				destroyStatic = false;
				
				// Prevent updating the TimerManager twice
				Destroy(this);
				return;
			}
			
			exists = true;
			
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			TimerManager.Update(Time.deltaTime);
		}

		private void OnDestroy()
		{
			if (destroyStatic)
			{
				exists = false;
			}
		}
	}
}