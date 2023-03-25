using System.Collections;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	public static class CoroutineExtensions
	{
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//				IEnumerator
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		
		/// <summary>
		/// Execute another coroutine immediately after this one is done
		/// </summary>
		public static IEnumerator Then(this IEnumerator first, IEnumerator second)
		{
			while (first.MoveNext())
			{
				yield return first.Current;
			}

			while (second.MoveNext())
			{
				yield return second.Current;
			}
		}

		/// <summary>
		/// Wait for a set amount of seconds immediately after this coroutine
		/// </summary>
		public static IEnumerator Wait(this IEnumerator first, float time)
		{
			while (first.MoveNext())
			{
				yield return first.Current;
			}

			yield return new WaitForSeconds(time);
		}

		/// <summary>
		/// Wait for a set amount of real-time seconds immediately after this coroutine
		/// </summary>
		public static IEnumerator WaitRealTime(this IEnumerator first, float time)
		{
			while (first.MoveNext())
			{
				yield return first.Current;
			}

			yield return new WaitForSecondsRealtime(time);
		}
		
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//				IEnumerable
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//

		/// <summary>
		/// Execute another coroutine immediately after this one is done
		/// </summary>
		public static IEnumerable Then(this IEnumerable first, IEnumerable second)
		{
			foreach (object item in first)
			{
				yield return item;
			}

			foreach (object item in second)
			{
				yield return item;
			}
		}

		/// <summary>
		/// Wait for a set amount of seconds immediately after this coroutine
		/// </summary>
		public static IEnumerable Wait(this IEnumerable first, float time)
		{
			foreach (object item in first)
			{
				yield return item;
			}

			yield return new WaitForSeconds(time);
		}
		
		/// <summary>
		/// Wait for a set amount of real-time seconds immediately after this coroutine
		/// </summary>
		public static IEnumerable WaitRealTime(this IEnumerable first, float time)
		{
			foreach (object item in first)
			{
				yield return item;
			}

			yield return new WaitForSecondsRealtime(time);
		}
	}
}