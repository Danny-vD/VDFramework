using System;
using System.Collections;
using UnityEngine;

namespace VDFramework.UnityExtensions
{
	/// <summary>
	/// Contains several extension methods that add extra functions to coroutines
	/// </summary>
	public static class CoroutineExtensions
	{
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//				IEnumerator
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//

		/// <summary>
		///     Execute another coroutine immediately after this one is done
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
		///     Wait for a set amount of seconds immediately after this coroutine
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
		///     Wait for a set amount of real-time seconds immediately after this coroutine
		/// </summary>
		public static IEnumerator WaitRealTime(this IEnumerator first, float time)
		{
			while (first.MoveNext())
			{
				yield return first.Current;
			}

			yield return new WaitForSecondsRealtime(time);
		}

		/// <summary>
		///     Repeats the given Coroutine.
		/// </summary>
		/// <param name="enumerator">The Coroutine that is being repeated.</param>
		/// <param name="count">The Amount of repetitions. -1 to repeat indefinetly</param>
		/// <returns>Repeating Coroutine</returns>
		public static IEnumerator Repeat(this IEnumerator enumerator, int count = -1)
		{
			int loopsRemaining = count;

			while (count < 0 || loopsRemaining >= 1)
			{
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}

				loopsRemaining--;
			}
		}

		/// <summary>
		/// Executes the coroutine if the condition is true
		/// </summary>
		/// <param name="enumerator">The coroutine to be executed</param>
		/// <param name="condition">The condition that has to be met for the execution</param>
		public static ConditionalEnumerator If(this IEnumerator enumerator, Func<bool> condition)
		{
			return new IfEnumerator(enumerator, condition);
		}

		/// <summary>
		/// Executes the coroutine if the <see cref="If(System.Collections.IEnumerator,System.Func{bool})"/> is false
		/// </summary>
		/// <param name="enumerator">The <see cref="ConditionalEnumerator"/> whose condition to check</param>
		/// <param name="elseCoroutine">The coroutine to be executed</param>
		public static IEnumerator Else(this ConditionalEnumerator enumerator, IEnumerator elseCoroutine)
		{
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}

			if (!enumerator.ExecutedOnce)
			{
				while (elseCoroutine.MoveNext())
				{
					yield return elseCoroutine.Current;
				}
			}
		}

		/// <summary>
		/// Executes the coroutine while the condition is true
		/// </summary>
		/// <param name="enumerator">The coroutine to be executed</param>
		/// <param name="condition">The condition that has to be met for the execution</param>
		public static IEnumerator While(this IEnumerator enumerator, Func<bool> condition)
		{
			return new WhileEnumerator(enumerator, condition);
		}

		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//				IEnumerable
		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//

		/// <summary>
		///     Execute another coroutine immediately after this one is done
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
		///     Wait for a set amount of seconds immediately after this coroutine
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
		///     Wait for a set amount of real-time seconds immediately after this coroutine
		/// </summary>
		public static IEnumerable WaitRealTime(this IEnumerable first, float time)
		{
			foreach (object item in first)
			{
				yield return item;
			}

			yield return new WaitForSecondsRealtime(time);
		}

		/// <summary>
		///     Repeats the given Coroutine.
		/// </summary>
		/// <param name="enumerable">The Coroutine that is being repeated.</param>
		/// <param name="count">The Amount of repetitions. -1 to repeat indefinetly</param>
		/// <returns>Repeating Coroutine</returns>
		public static IEnumerable Repeat(this IEnumerable enumerable, int count = -1)
		{
			int loopsRemaining = count;

			while (count < 0 || loopsRemaining >= 1)
			{
				// ReSharper disable once PossibleMultipleEnumeration // Multiple Enumeration is intended
				foreach (object item in enumerable)
				{
					yield return item;
				}

				loopsRemaining--;
			}
		}

		/// <summary>
		/// Executes the coroutine if the condition is true
		/// </summary>
		/// <param name="enumerable">The coroutine to be executed</param>
		/// <param name="condition">The condition that has to be met for the execution</param>
		public static ConditionalEnumerable If(this IEnumerable enumerable, Func<bool> condition)
		{
			return new IfEnumerable(enumerable, condition);
		}

		/// <summary>
		/// Executes the coroutine if the <see cref="If(System.Collections.IEnumerable,System.Func{bool})"/> is false
		/// </summary>
		/// <param name="enumerable">The <see cref="ConditionalEnumerator"/> whose condition to check</param>
		/// <param name="elseCoroutine">The coroutine to be executed</param>
		public static IEnumerable Else(this ConditionalEnumerable enumerable, IEnumerable elseCoroutine)
		{
			ConditionalEnumerator enumerator = (ConditionalEnumerator)enumerable.GetEnumerator();

			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}

			if (!enumerator.ExecutedOnce)
			{
				foreach (object item in elseCoroutine)
				{
					yield return item;
				}
			}
		}

		/// <summary>
		/// Executes the coroutine while the condition is true
		/// </summary>
		/// <param name="enumerable">The coroutine to be executed</param>
		/// <param name="condition">The condition that has to be met for the execution</param>
		public static ConditionalEnumerable While(this IEnumerable enumerable, Func<bool> condition)
		{
			return new WhileEnumerable(enumerable, condition);
		}
	}

	/// <summary>
	/// An abstract base class that has properties specificially aimed at conditional execution
	/// </summary>
	public abstract class ConditionalEnumerator : IEnumerator
	{
		/// <summary>
		/// The enumerator to execute depending on the <see cref="executionCondition"/>
		/// </summary>
		protected IEnumerator enumerator;

		/// <summary>
		/// The condition for the execution
		/// </summary>
		protected Func<bool> executionCondition;

		/// <summary>
		/// An abstract base class that has properties specificially aimed at conditional execution
		/// </summary>
		/// <param name="enumerator">The enumerator to execute depending on the <see cref="executionCondition"/></param>
		/// <param name="condition">The condition for the execution</param>
		public ConditionalEnumerator(IEnumerator enumerator, Func<bool> condition)
		{
			this.enumerator    = enumerator;
			executionCondition = condition;
		}

		/// <summary>
		/// Will be true if the enumerator has ran at least once
		/// </summary>
		public bool ExecutedOnce { get; private set; }


		/// <inheritdoc />
		public abstract bool MoveNext();

		/// <inheritdoc />
		public void Reset()
		{
			enumerator.Reset();
		}

		/// <inheritdoc />
		public object Current => enumerator.Current;

		/// <summary>
		/// Flag this enumerator as 'has ran at least once'
		/// </summary>
		/// <seealso cref="ExecutedOnce"/>
		protected void SetExecutedOnce()
		{
			ExecutedOnce = true;
		}
	}

	/// <summary>
	/// An Enumerator that executes the enumerator if the condition is true
	/// </summary>
	public class IfEnumerator : ConditionalEnumerator
	{
		/// <summary>
		/// An Enumerator that executes the enumerator if the condition is true
		/// </summary>
		/// <inheritdoc />
		public IfEnumerator(IEnumerator enumerable, Func<bool> condition) : base(enumerable, condition)
		{
			if (condition())
			{
				SetExecutedOnce();
			}
		}

		/// <inheritdoc />
		public override bool MoveNext()
		{
			return ExecutedOnce && enumerator.MoveNext();
		}
	}

	/// <summary>
	/// An Enumerator that executes as long as the condition is true
	/// </summary>
	public class WhileEnumerator : ConditionalEnumerator
	{
		/// <summary>
		/// An Enumerator that executes as long as the condition is true
		/// </summary>
		/// <inheritdoc />
		public WhileEnumerator(IEnumerator enumerable, Func<bool> condition) : base(enumerable, condition)
		{
		}

		/// <inheritdoc />
		public override bool MoveNext()
		{
			if (executionCondition())
			{
				SetExecutedOnce();

				return enumerator.MoveNext();
			}

			return false;
		}
	}

	/// <summary>
	/// An abstract base class that has properties specificially aimed at conditional execution
	/// </summary>
	public abstract class ConditionalEnumerable : IEnumerable
	{
		/// <summary>
		/// The enumerable to execute depending on the <see cref="executionCondition"/>
		/// </summary>
		protected IEnumerable enumerable;

		/// <summary>
		/// The condition for the execution
		/// </summary>
		protected Func<bool> executionCondition;

		/// <summary>
		/// An abstract base class that has properties specificially aimed at conditional execution
		/// </summary>
		/// <param name="enumerable">The enumerable to execute depending on the <see cref="executionCondition"/></param>
		/// <param name="condition">The condition for the execution</param>
		protected ConditionalEnumerable(IEnumerable enumerable, Func<bool> condition)
		{
			this.enumerable    = enumerable;
			executionCondition = condition;
		}

		/// <inheritdoc />
		public IEnumerator GetEnumerator()
		{
			return InnerGetEnumerator();
		}

		///<summary>
		/// Returns the Enumerator of the underlaying Enumerable
		///</summary>
		/// <inheritdoc cref="GetEnumerator"/>
		protected abstract ConditionalEnumerator InnerGetEnumerator();
	}

	/// <summary>
	/// An Enumerable that executes the enumerator if the condition is true
	/// </summary>
	public class IfEnumerable : ConditionalEnumerable
	{
		/// <summary>
		/// An Enumerable that executes the enumerator if the condition is true
		/// </summary>
		/// <inheritdoc />
		public IfEnumerable(IEnumerable enumerable, Func<bool> condition) : base(enumerable, condition)
		{
		}

		/// <inheritdoc />
		protected override ConditionalEnumerator InnerGetEnumerator()
		{
			return new IfEnumerator(enumerable.GetEnumerator(), executionCondition);
		}
	}

	/// <summary>
	/// An Enumerable that executes as long as the condition is true
	/// </summary>
	public class WhileEnumerable : ConditionalEnumerable
	{
		/// <summary>
		/// An Enumerable that executes as long as the condition is true
		/// </summary>
		/// <inheritdoc />
		public WhileEnumerable(IEnumerable enumerable, Func<bool> condition) : base(enumerable, condition)
		{
		}

		/// <inheritdoc />
		protected override ConditionalEnumerator InnerGetEnumerator()
		{
			return new WhileEnumerator(enumerable.GetEnumerator(), executionCondition);
		}
	}
}