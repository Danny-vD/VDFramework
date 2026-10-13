using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace VDFramework.Extensions
{
	/// <summary>
	/// Contains utility functions for Span
	/// </summary>
	public static class SpanExtensions
	{
		/// <summary>
		/// Turn this Span into a list (allocates memory!)
		/// </summary>
		[Pure]
		public static List<T> ToList<T>(this ReadOnlySpan<T> span)
		{
			List<T> list = new List<T>(span.Length);

			for (int i = 0; i < span.Length; i++)
			{
				list.Add(span[i]);
			}

			return list;
		}
		
		/// <summary>
		/// Turn this Span into a list (allocates memory!)
		/// </summary>
		[Pure]
		public static List<T> ToList<T>(this Span<T> span)
		{
			List<T> list = new List<T>(span.Length);

			for (int i = 0; i < span.Length; i++)
			{
				list.Add(span[i]);
			}

			return list;
		}
	}
}