using UnityEngine;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains extension methods for <see cref="UnityEngine.Collider"/>
	/// </summary>
	public static class ColliderExtensions
	{
		/// <summary>
		/// Disable this collider
		/// </summary>
		/// <seealso cref="Collider.enabled"/>
		public static void Enable(this Collider collider)
		{
			collider.enabled = true;
		}

		/// <summary>
		/// Enable this collider
		/// </summary>
		/// <seealso cref="Collider.enabled"/>
		public static void Disable(this Collider collider)
		{
			collider.enabled = false;
		}
	}
}