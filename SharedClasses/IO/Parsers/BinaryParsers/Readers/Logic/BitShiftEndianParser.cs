using VDFramework.Utility.Unsafe;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.Logic
{
	/// <summary>
	/// Contains functions to get primitives from a byte[]
	/// </summary>
	internal static class BitShiftEndianParser
	{
		//\\//\\//\\//\\//\\//\\//\\//
		// Little Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe ushort GetUShortLittleEndian(byte* pointer, ulong startOffset)
		{
			return (ushort)(*(pointer + startOffset) | (int)*(pointer + startOffset + 1) << 8);
		}

		public static unsafe short GetShortLittleEndian(byte* pointer, ulong startOffset)
		{
			return (short)(*(pointer + startOffset) | (int)*(pointer + startOffset + 1) << 8);
		}

		public static unsafe uint GetUIntLittleEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) | (uint)*(pointer + startOffset + 1) << 8 | (uint)*(pointer + startOffset + 2) << 16 | (uint)*(pointer + startOffset + 3) << 24;
		}

		public static unsafe int GetIntLittleEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) | *(pointer + startOffset + 1) << 8 | *(pointer + startOffset + 2) << 16 | *(pointer + startOffset + 3) << 24;
		}

		public static unsafe long Get6ByteIntegerLittleEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) | (long)*(pointer + startOffset + 1) << 8 | (long)*(pointer + startOffset + 2) << 16 |
				   (long)*(pointer + startOffset + 3) << 24 | (long)*(pointer + startOffset + 4) << 32 | (long)*(pointer + startOffset + 5) << 40;
		}

		public static unsafe ulong GetULongLittleEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) | (ulong)*(pointer + startOffset + 1) << 8 | (ulong)*(pointer + startOffset + 2) << 16 | (ulong)*(pointer + startOffset + 3) << 24 |
				   (ulong)*(pointer + startOffset + 4) << 32 | (ulong)*(pointer + startOffset + 5) << 40 | (ulong)*(pointer + startOffset + 6) << 48 | (ulong)*(pointer + startOffset + 7) << 56;
		}

		public static unsafe long GetLongLittleEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) | (long)*(pointer + startOffset + 1) << 8 | (long)*(pointer + startOffset + 2) << 16 | (long)*(pointer + startOffset + 3) << 24 |
				   (long)*(pointer + startOffset + 4) << 32 | (long)*(pointer + startOffset + 5) << 40 | (long)*(pointer + startOffset + 6) << 48 | (long)*(pointer + startOffset + 7) << 56;
		}

		public static unsafe float GetFloatLittleEndian(byte* pointer, ulong startOffset)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntLittleEndian(pointer, startOffset));
		}

		public static unsafe double GetDoubleLittleEndian(byte* pointer, ulong startOffset)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongLittleEndian(pointer, startOffset));
		}

		//\\//\\//\\//\\//\\//\\//\\//
		// Big Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe ushort GetUShortBigEndian(byte* pointer, ulong startOffset)
		{
			return (ushort)(*(pointer + startOffset) << 8 | *(pointer + startOffset + 1));
		}

		public static unsafe short GetShortBigEndian(byte* pointer, ulong startOffset)
		{
			return (short)(*(pointer + startOffset) << 8 | *(pointer + startOffset + 1));
		}

		public static unsafe uint GetUIntBigEndian(byte* pointer, ulong startOffset)
		{
			return (uint)*(pointer + startOffset) << 24 | (uint)*(pointer + startOffset + 1) << 16 | (uint)*(pointer + startOffset + 2) << 8 | *(pointer + startOffset + 3);
		}

		public static unsafe int GetIntBigEndian(byte* pointer, ulong startOffset)
		{
			return *(pointer + startOffset) << 24 | *(pointer + startOffset + 1) << 16 | *(pointer + startOffset + 2) << 8 | *(pointer + startOffset + 3);
		}

		public static unsafe long Get6ByteIntegerBigEndian(byte* pointer, ulong startOffset)
		{
			return (long)*(pointer + startOffset) << 40 | (long)*(pointer + startOffset + 1) << 32 | (long)*(pointer + startOffset + 2) << 24 |
				   (long)*(pointer + startOffset + 3) << 16 | (long)*(pointer + startOffset + 4) << 8 | *(pointer + startOffset + 5);
		}

		public static unsafe ulong GetULongBigEndian(byte* pointer, ulong startOffset)
		{
			return (ulong)*(pointer + startOffset) << 56 | (ulong)*(pointer + startOffset + 1) << 48 | (ulong)*(pointer + startOffset + 2) << 40 | (ulong)*(pointer + startOffset + 3) << 32 |
				   (ulong)*(pointer + startOffset + 4) << 24 | (ulong)*(pointer + startOffset + 5) << 16 | (ulong)*(pointer + startOffset + 6) << 8 | *(pointer + startOffset + 7);
		}

		public static unsafe long GetLongBigEndian(byte* pointer, ulong startOffset)
		{
			return (long)*(pointer + startOffset) << 56 | (long)*(pointer + startOffset + 1) << 48 | (long)*(pointer + startOffset + 2) << 40 | (long)*(pointer + startOffset + 3) << 32 |
				   (long)*(pointer + startOffset + 4) << 24 | (long)*(pointer + startOffset + 5) << 16 | (long)*(pointer + startOffset + 6) << 8 | *(pointer + startOffset + 7);
		}

		public static unsafe float GetFloatBigEndian(byte* pointer, ulong startOffset)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntBigEndian(pointer, startOffset));
		}

		public static unsafe double GetDoubleBigEndian(byte* pointer, ulong startOffset)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongBigEndian(pointer, startOffset));
		}
	}
}