﻿using System;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.RandomWrapper
{
	/// <summary>
	/// Provides a implementation of <see cref="IRandomNumberGenerator"/> using <see cref="System.Random">System.Random</see>
	/// </summary>
	/// <seealso cref="StaticInstance">SystemRandom.StaticInstance</seealso>
	public class SystemRandom : IRandomNumberGenerator
	{
		private static readonly object staticLock = new object();
		
		private static volatile SystemRandom staticInstance = null;

		/// <summary>
		/// Returns a static instance of this class <br/>
		/// A new instance will be created the first time this field is used
		/// </summary>
		public static SystemRandom StaticInstance
		{
			get
			{
				if (staticInstance == null)
				{
					lock (staticLock)
					{
						if (staticInstance == null)
						{
							staticInstance = new SystemRandom();
						}
					}
				}

				return staticInstance;
			}
		}

		/// <summary>
		/// The underlaying <see cref="System.Random">System.Random</see> instance
		/// </summary>
		public System.Random Instance { get; private set; } = new System.Random();

		private int originalSeed = Environment.TickCount;

		/// <inheritdoc />
		public void SetSeed(int seed)
		{
			originalSeed = seed;
			Instance     = new Random(originalSeed);
		}

		/// <inheritdoc />
		public int GetSeed()
		{
			return originalSeed;
		}

		/// <inheritdoc cref="System.Random.Next()" />
		public int Next()
		{
			return Instance.Next();
		}

		/// <inheritdoc cref="System.Random.Next(int)" />
		public int Next(int exclusiveUpperBound)
		{
			return Instance.Next(exclusiveUpperBound);
		}

		/// <inheritdoc cref="System.Random.Next(int, int)" />
		public int Next(int inclusiveLowerBound, int exclusiveUpperBound)
		{
			return Instance.Next(inclusiveLowerBound, exclusiveUpperBound);
		}

		/// <summary>
		/// Returns a random non-negative floating point number between 0 and the upper bound (exclusive)
		/// </summary>
		public float Next(float exclusiveUpperbound)
		{
			return NextFloat() * exclusiveUpperbound;
		}

		/// <summary>
		/// Returns a random floating point number between the lower bound (inclusive) and the upper bound (exclusive)
		/// </summary>
		public float Next(float inclusiveLowerBound, float exclusiveUpperbound)
		{
			float delta = exclusiveUpperbound - inclusiveLowerBound;
			return inclusiveLowerBound + NextFloat() * delta;
		}

		/// <summary>Fills the elements of a specified span of bytes with random numbers.</summary>
		/// <param name="buffer">The span to be filled with random numbers.</param>
		public void NextBytes(Span<byte> buffer)
		{
			Instance.NextBytes(buffer);
		}

		/// <inheritdoc cref="System.Random.NextBytes(byte[])" />
		public void NextBytes(byte[] buffer)
		{
			Instance.NextBytes(buffer);
		}

		/// <inheritdoc cref="System.Random.NextDouble()" />
		public double NextDouble()
		{
			return Instance.NextDouble();
		}

		/// <inheritdoc cref="System.Random.NextDouble()" />
		/// <returns>A single-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
		public float NextFloat()
		{
			return (float)Instance.NextDouble();
		}

		/// <inheritdoc />
		public double GetPercentage()
		{
			return Instance.NextDouble();
		}
	}
}