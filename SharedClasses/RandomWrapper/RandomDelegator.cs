using System;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.RandomWrapper
{
	/// <summary>
	/// Provides an implementation of <see cref="IRandomNumberGenerator"/> that delegates all implementation to an underlying field
	/// </summary>
	/// <remarks>
	/// The idea is that you can reuse a single instance but still change the implementation of the random
	/// </remarks>
	public class RandomDelegator : IRandomNumberGenerator
	{
		/// <summary>
		/// The implementation of <see cref="IRandomNumberGenerator"/> that is used for all the functions
		/// </summary>
		public IRandomNumberGenerator RandomNumberGenerator;

		/// <summary>
		/// Create a new instance of this class using the provided <see cref="IRandomNumberGenerator"/> implementation
		/// </summary>
		public RandomDelegator(IRandomNumberGenerator randomNumberGenerator)
		{
			RandomNumberGenerator = randomNumberGenerator;
		}

		/// <inheritdoc />
		public void SetSeed(int seed)
		{
			RandomNumberGenerator.SetSeed(seed);
		}

		/// <inheritdoc />
		public int GetSeed()
		{
			return RandomNumberGenerator.GetSeed();
		}

		/// <inheritdoc />
		public int Next()
		{
			return RandomNumberGenerator.Next();
		}

		/// <inheritdoc />
		public int Next(int exclusiveUpperBound)
		{
			return RandomNumberGenerator.Next(exclusiveUpperBound);
		}

		/// <inheritdoc />
		public int Next(int inclusiveLowerBound, int exclusiveUpperBound)
		{
			return RandomNumberGenerator.Next(inclusiveLowerBound, exclusiveUpperBound);
		}

		/// <inheritdoc />
		public float Next(float upperBound)
		{
			return RandomNumberGenerator.Next(upperBound);
		}

		/// <inheritdoc />
		public float Next(float lowerBound, float upperBound)
		{
			return RandomNumberGenerator.Next(lowerBound, upperBound);
		}

		/// <inheritdoc />
		public void NextBytes(Span<byte> buffer)
		{
			RandomNumberGenerator.NextBytes(buffer);
		}

		/// <inheritdoc />
		public void NextBytes(byte[] buffer)
		{
			RandomNumberGenerator.NextBytes(buffer);
		}

		/// <inheritdoc />
		public double NextDouble()
		{
			return RandomNumberGenerator.NextDouble();
		}

		/// <inheritdoc />
		public float NextFloat()
		{
			return RandomNumberGenerator.NextFloat();
		}

		/// <inheritdoc />
		public double GetPercentage()
		{
			return RandomNumberGenerator.GetPercentage();
		}
	}
}