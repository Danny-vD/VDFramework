using VDFramework.RandomWrapper.Interface;
using VDFramework.Utility.Unsafe;

namespace VDFramework.RandomWrapper
{
	/// <summary>
	/// Provides a implementation of <see cref="IRandomNumberGenerator"/> using <see cref="Unity.Mathematics.Random">Unity.Mathematics.Random</see>
	/// </summary>
	public class UnityMathRandom : IRandomNumberGenerator
	{
		private static readonly object staticLock = new object();
		
		private static volatile UnityMathRandom staticInstance = null;
		
		/// <summary>
		/// Returns a static instance of this class<br/>
		/// A new instance will be created the first time this field is used<br/>
		/// The seed *has* to be set first before this random can be used to generate numbers
		/// </summary>
		public static UnityMathRandom StaticInstance
		{
			get
			{
				if (staticInstance == null)
				{
					lock (staticLock)
					{
						if (staticInstance == null)
						{
							staticInstance = new UnityMathRandom();
						}
					}
				}

				return staticInstance;
			}
		}

		/// <summary>
		/// The underlaying <see cref="Unity.Mathematics.Random">Unity.Mathematics.Random</see> instance
		/// </summary>
		/// <warning>Do not use <see cref="Unity.Mathematics.Random.InitState(uint)"/> directly. Use <see cref="SetSeed(int)"/> to not break tracking what the original seed was</warning>
		/// <seealso cref="GetSeed()"/>
		public Unity.Mathematics.Random Instance { get; private set; }

		private uint originalSeed = 0;

		/// <summary>
		/// Create a new instance of this random<br/>
		/// The seed *has* to be set first before this random can be used to generate numbers
		/// </summary>
		public UnityMathRandom()
		{
			Instance = new Unity.Mathematics.Random();
		}
		
		/// <summary>
		/// Create a new instance of this random with an index<br/>
		/// The seed *has* to be set first before this random can be used to generate numbers<br/>
		/// <br/>the index must not be uint.maxValue
		/// </summary>
		/// <remarks>
		///	Use this function when you expect to create several Random instances in a loop<br/>
		///<br/>
		/// <see cref="GetSeed"/> will return <see cref="Unity.Mathematics.Random.state"/> when the random is created through this method
		/// </remarks>
		/// <seealso cref="Unity.Mathematics.Random.CreateFromIndex(uint)"/>
		public UnityMathRandom(uint index)
		{
			Instance     = Unity.Mathematics.Random.CreateFromIndex(index);
			originalSeed = Instance.state;
		}

		/// <summary>
		/// Set the seed of the underlaying <see cref="Unity.Mathematics.Random"/><br/>
		/// Because <see cref="Unity.Mathematics.Random.InitState(uint)"/> uses an uint, the given int will be <see cref="VDFramework.Utility.Unsafe.UnsafeUtil.reinterpret_cast{T,T}">reinterpret_cast()</see> to uint
		/// </summary>
		/// <seealso cref="Unity.Mathematics.Random.state"/>
		/// <seealso cref="VDFramework.Utility.Unsafe.UnsafeUtil.reinterpret_cast{T,T}"/>
		public void SetSeed(int seed)
		{
			uint newSeed = UnsafeUtil.reinterpret_cast<int, uint>(seed);
			
			SetSeed(newSeed);
		}
		
		/// <summary>
		/// Set the seed of the underlaying <see cref="Unity.Mathematics.Random"/>
		/// </summary>
		/// <seealso cref="Unity.Mathematics.Random.state"/>
		/// <seealso cref="Unity.Mathematics.Random.InitState(uint)"/>
		public void SetSeed(uint seed = 1851936439)
		{
			originalSeed = seed;
			Instance.InitState(seed);
		}

		/// <inheritdoc />
		/// <seealso cref="Unity.Mathematics.Random.state"/>
		public int GetSeed()
		{
			return UnsafeUtil.reinterpret_cast<uint, int>(originalSeed);
		}

		/// <inheritdoc cref="Unity.Mathematics.Random.NextInt()" />
		public int Next()
		{
			return Instance.NextInt();
		}

		/// <inheritdoc cref="Unity.Mathematics.Random.NextInt(int)" />
		public int Next(int exclusiveUpperBound)
		{
			return Instance.NextInt(exclusiveUpperBound);
		}

		/// <inheritdoc cref="Unity.Mathematics.Random.NextInt(int, int)" />
		public int Next(int inclusiveLowerBound, int exclusiveUpperBound)
		{
			return Instance.NextInt(inclusiveLowerBound, exclusiveUpperBound);
		}

		/// <summary>
		/// Returns a random non-negative floating point number between 0 (inclusive) and the upper bound (exclusive)
		/// </summary>
		/// <seealso cref="Unity.Mathematics.Random.NextFloat(float)"/>
		public float Next(float exclusiveUpperBound)
		{
			return Instance.NextFloat(exclusiveUpperBound);
		}

		/// <summary>
		/// Returns a random non-negative floating point number between the lower bound (inclusive) and the upper bound (exclusive)
		/// </summary>
		/// <seealso cref="Unity.Mathematics.Random.NextFloat(float, float)"/>
		public float Next(float inclusiveLowerBound, float exclusiveUpperBound)
		{
			return Instance.NextFloat(inclusiveLowerBound, exclusiveUpperBound);
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
		/// Returns a random double precision floating-point number between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public double NextDouble()
		{
			return Instance.NextDouble();
		}

		/// <summary>
		/// Returns a random single precision floating-point number between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public float NextFloat()
		{
			return Instance.NextFloat();
		}

		/// <inheritdoc />
		public double GetPercentage()
		{
			return NextDouble();
		}
	}
}