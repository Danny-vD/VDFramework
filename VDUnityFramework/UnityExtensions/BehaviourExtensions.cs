using UnityEngine;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains extension methods for <see cref="UnityEngine.Behaviour"/>
	/// </summary>
	public static class BehaviourExtensions
	{
		/// <summary>
		/// Disable this behaviour
		/// </summary>
		/// <seealso cref="Behaviour.enabled"/>
		public static void Enable(this Behaviour behaviour)
		{
			behaviour.enabled = true;
		}

		/// <summary>
		/// Enable this behaviour
		/// </summary>
		/// <seealso cref="Behaviour.enabled"/>
		public static void Disable(this Behaviour behaviour)
		{
			behaviour.enabled = false;
		}
	}
}