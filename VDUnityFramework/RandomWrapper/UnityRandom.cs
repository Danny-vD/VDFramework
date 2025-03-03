using VDFramework.RandomWrapper.Interface;
using UnityEngine;

namespace VDFramework.RandomWrapper
{
	/// <summary>
	/// Provides a implementation of <see cref="IRandomNumberGenerator"/> using <see cref="UnityEngine.Random">UnityEngine.Random</see>
	/// </summary>
	/// <remarks>
	/// UnityEngine.Random is a static class so the underlaying random is shared between all instances of this class
	/// </remarks>
	public class UnityRandom : IRandomNumberGenerator
	{
		private static readonly object staticLock = new object();
		
		private static volatile UnityRandom staticInstance = null;

		/// <summary>
		/// Returns a static instance of this class <br/>
		/// A new instance will be created the first time this field is used
		/// </summary>
		public static UnityRandom StaticInstance
		{
			get
			{
				if (staticInstance == null)
				{
					lock (staticLock)
					{
						if (staticInstance == null)
						{
							staticInstance = new UnityRandom();
						}
					}
				}

				return staticInstance;
			}
		}

		private static int originalSeed; // Static because Unity uses a static Random class

		/// <inheritdoc cref="UnityEngine.Random.InitState" />
		/// <seealso cref="UnityEngine.Random.state"/>
		public void SetSeed(int seed)
		{
			originalSeed = seed;

			Random.InitState(seed);
		}

		/// <inheritdoc />
		/// <seealso cref="UnityEngine.Random.state"/>
		public int GetSeed()
		{
			return originalSeed;
		}

		/// <inheritdoc cref="System.Random.Next()" />
		public int Next()
		{
			return Random.Range(0, int.MaxValue);
		}

		/// <inheritdoc />
		public int Next(int exclusiveUpperBound)
		{
			return Random.Range(0, exclusiveUpperBound);
		}

		/// <inheritdoc cref="UnityEngine.Random.Range(int, int)"/>
		public int Next(int inclusiveLowerBound, int exclusiveUpperBound)
		{
			return Random.Range(inclusiveLowerBound, exclusiveUpperBound);
		}

		/// <summary>
		/// Returns a random non-negative floating point number between 0 (inclusive) and the upper bound (inclusive)
		/// </summary>
		public float Next(float inclusiveUpperBound)
		{
			return Random.Range(0, inclusiveUpperBound);
		}

		/// <inheritdoc cref="UnityEngine.Random.Range(float, float)"/>
		public float Next(float inclusiveLowerBound, float inclusiveUpperBound)
		{
			return Random.Range(inclusiveLowerBound, inclusiveUpperBound);
		}

		/// <inheritdoc />
		public void NextBytes(System.Span<byte> buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)Next(byte.MaxValue);
			}
		}

		/// <inheritdoc />
		public void NextBytes(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)Next(byte.MaxValue);
			}
		}

		/// <summary>
		/// Returns a random double precision floating-point number between 0 (inclusive) and 1 (inclusive)
		/// </summary>
		public double NextDouble()
		{
			return Random.value;
		}

		/// <summary>
		/// Returns a random single precision floating-point number between 0 (inclusive) and 1 (inclusive)
		/// </summary>
		public float NextFloat()
		{
			return Random.value;
		}

		/// <inheritdoc />
		public double GetPercentage()
		{
			double random = NextDouble();

			// ReSharper disable once CompareOfFloatsByEqualityOperator | Reason: I want to check if the result is exactly 1
			if (random == 1)
			{
				random -= double.Epsilon; // This technically skews the probability in favour of (1 - epsilon), but the chance is astronomically small so it is acceptable. I still hate it though.
			}

			return random;
		}
	}
}