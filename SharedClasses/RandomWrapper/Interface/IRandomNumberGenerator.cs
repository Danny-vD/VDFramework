using System;

namespace VDFramework.RandomWrapper.Interface
{
	/// <summary>
	/// Provides an interface for an RNG so that it is easy to swap it out with a different implementation
	/// </summary>
	/// <seealso cref="SystemRandom"/>
	public interface IRandomNumberGenerator
	{
		/// <summary>
		/// Set the seed of the associated random number generator
		/// </summary>
		public void SetSeed(int seed);
		
		/// <summary>
		/// Get the seed of the associated random number generator
		/// </summary>
		public int GetSeed();
		
		/// <summary>
		/// Returns a random integer<br/>
		/// The bounds are implementation defined
		/// </summary>
		public int Next();
		
		/// <summary>
		/// Returns a random non-negative integer between 0 and the upper bound (exclusive)
		/// </summary>
		public int Next(int exclusiveUpperBound);
		
		/// <summary>
		/// Returns a random integer between the lower bound (inclusive) and the upper bound (exclusive)
		/// </summary>
		public int Next(int inclusiveLowerBound, int exclusiveUpperBound);
		
		/// <summary>
		/// Returns a random non-negative floating point number between 0 and the upper bound<br/>
		/// Which bounds are inclusive and exclusive is implementation defined
		/// </summary>
		public float Next(float upperBound);
		
		/// <summary>
		/// Returns a random floating point number between the lower bound and the upper bound<br/>
		/// Which bounds are inclusive and exclusive is implementation defined
		/// </summary>
		public float Next(float lowerBound, float upperBound);

		/// <summary>
		/// Fills the elements of a specified span of bytes with random numbers
		/// </summary>
		/// <param name="buffer">The span to be filled with random numbers.</param>
		public void NextBytes(Span<byte> buffer);
		
		/// <summary>
		/// Fills the elements of a specified array of bytes with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextBytes(byte[] buffer);

		/// <summary>
		/// Returns a random double precision floating-point number between 0 and 1<br/>
		/// Which bounds are inclusive and exclusive is implementation defined
		/// </summary>
		public double NextDouble();

		/// <summary>
		/// Returns a random single precision floating-point number between 0 and 1<br/>
		/// Which bounds are inclusive and exclusive is implementation defined
		/// </summary>
		public float NextFloat();
	}
}