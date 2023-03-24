using UnityEngine;
using VDFramework.Utility.TimerUtil;

namespace VDFramework.Monobehaviours
{
	/// <summary>
	/// A simple utility behaviour for Unity that updates the TimerManager in Update using Time.deltaTime
	/// (makes the object DontDestroyOnLoad)
	/// </summary>
	public class TimerManagerUpdater : BetterMonoBehaviour
	{
		private void Start()
		{
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			TimerManager.Update(Time.deltaTime);
		}
	}
}