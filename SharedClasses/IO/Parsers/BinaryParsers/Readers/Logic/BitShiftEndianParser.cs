using VDFramework.Utility.Unsafe;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.Logic
{
	/// <summary>
	/// Contains functions to get primitives from a byte[]
	/// </summary>
	public static class BitShiftEndianParser
	{
		//\\//\\//\\//\\//\\//\\//\\//
		// Little Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static ushort GetUShortLittleEndian(byte[] data, ulong startIndex)
		{
			return (ushort)(data[startIndex] | data[startIndex + 1] << 8);
		}

		public static short GetShortLittleEndian(byte[] data, ulong startIndex)
		{
			return (short)(data[startIndex] | data[startIndex + 1] << 8);
		}

		public static uint GetUIntLittleEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] | (uint)data[startIndex + 1] << 8 | (uint)data[startIndex + 2] << 16 | (uint)data[startIndex + 3] << 24;
		}

		public static int GetIntLittleEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] | data[startIndex + 1] << 8 | data[startIndex + 2] << 16 | data[startIndex + 3] << 24;
		}

		public static long Get6ByteIntegerLittleEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] | (long)data[startIndex + 1] << 8 | (long)data[startIndex + 2] << 16 |
				   (long)data[startIndex + 3] << 24 | (long)data[startIndex + 4] << 32 | (long)data[startIndex + 5] << 40;
		}

		public static ulong GetULongLittleEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] | (ulong)data[startIndex + 1] << 8 | (ulong)data[startIndex + 2] << 16 | (ulong)data[startIndex + 3] << 24 |
				   (ulong)data[startIndex + 4] << 32 | (ulong)data[startIndex + 5] << 40 | (ulong)data[startIndex + 6] << 48 | (ulong)data[startIndex + 7] << 56;
		}

		public static long GetLongLittleEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] | (long)data[startIndex + 1] << 8 | (long)data[startIndex + 2] << 16 | (long)data[startIndex + 3] << 24 |
				   (long)data[startIndex + 4] << 32 | (long)data[startIndex + 5] << 40 | (long)data[startIndex + 6] << 48 | (long)data[startIndex + 7] << 56;
		}

		public static float GetFloatLittleEndian(byte[] data, ulong startIndex)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntLittleEndian(data, startIndex));
		}

		public static double GetDoubleLittleEndian(byte[] data, ulong startIndex)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongLittleEndian(data, startIndex));
		}

		//\\//\\//\\//\\//\\//\\//\\//
		// Big Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static ushort GetUShortBigEndian(byte[] data, ulong startIndex)
		{
			return (ushort)(data[startIndex] << 8 | data[startIndex + 1]);
		}

		public static short GetShortBigEndian(byte[] data, ulong startIndex)
		{
			return (short)(data[startIndex] << 8 | data[startIndex + 1]);
		}

		public static uint GetUIntBigEndian(byte[] data, ulong startIndex)
		{
			return (uint)data[startIndex] << 24 | (uint)data[startIndex + 1] << 16 | (uint)data[startIndex + 2] << 8 | data[startIndex + 3];
		}

		public static int GetIntBigEndian(byte[] data, ulong startIndex)
		{
			return data[startIndex] << 24 | data[startIndex + 1] << 16 | data[startIndex + 2] << 8 | data[startIndex + 3];
		}

		public static long Get6ByteIntegerBigEndian(byte[] data, ulong startIndex)
		{
			return (long)data[startIndex] << 40 | (long)data[startIndex + 1] << 32 | (long)data[startIndex + 2] << 24 |
				   (long)data[startIndex + 3] << 16 | (long)data[startIndex + 4] << 8 | data[startIndex + 5];
		}

		public static ulong GetULongBigEndian(byte[] data, ulong startIndex)
		{
			return (ulong)data[startIndex] << 56 | (ulong)data[startIndex + 1] << 48 | (ulong)data[startIndex + 2] << 40 | (ulong)data[startIndex + 3] << 32 |
				   (ulong)data[startIndex + 4] << 24 | (ulong)data[startIndex + 5] << 16 | (ulong)data[startIndex + 6] << 8 | data[startIndex + 7];
		}

		public static long GetLongBigEndian(byte[] data, ulong startIndex)
		{
			return (long)data[startIndex] << 56 | (long)data[startIndex + 1] << 48 | (long)data[startIndex + 2] << 40 | (long)data[startIndex + 3] << 32 |
				   (long)data[startIndex + 4] << 24 | (long)data[startIndex + 5] << 16 | (long)data[startIndex + 6] << 8 | data[startIndex + 7];
		}

		public static float GetFloatBigEndian(byte[] data, ulong startIndex)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntBigEndian(data, startIndex));
		}

		public static double GetDoubleBigEndian(byte[] data, ulong startIndex)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongBigEndian(data, startIndex));
		}
	}
}