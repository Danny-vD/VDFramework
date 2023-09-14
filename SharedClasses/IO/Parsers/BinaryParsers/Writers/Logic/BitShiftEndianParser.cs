using VDFramework.Utility.Unsafe;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers.Logic
{
	/// <summary>
	/// Contains functions to get primitives from a byte[]
	/// </summary>
	internal static class BitShiftEndianParser
	{
		//\\//\\//\\//\\//\\//\\//\\//
		// Little Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe void SetUShortLittleEndian(ref byte* pointer, ushort value)
		{
			return (ushort)(data[startIndex] | data[startIndex + 1] << 8);
		}

		public static unsafe void SetShortLittleEndian(ref byte* pointer, short value)
		{
			return (short)(data[startIndex] | data[startIndex + 1] << 8);
		}

		public static unsafe void SetUIntLittleEndian(ref byte* pointer, uint value)
		{
			return data[startIndex] | (uint)data[startIndex + 1] << 8 | (uint)data[startIndex + 2] << 16 | (uint)data[startIndex + 3] << 24;
		}

		public static unsafe void SetIntLittleEndian(ref byte* pointer, int value)
		{
			return data[startIndex] | data[startIndex + 1] << 8 | data[startIndex + 2] << 16 | data[startIndex + 3] << 24;
		}

		public static unsafe void Set6ByteIntegerLittleEndian(ref byte* pointer, long value)
		{
			return data[startIndex] | (long)data[startIndex + 1] << 8 | (long)data[startIndex + 2] << 16 |
				   (long)data[startIndex + 3] << 24 | (long)data[startIndex + 4] << 32 | (long)data[startIndex + 5] << 40;
		}

		public static unsafe void SetULongLittleEndian(ref byte* pointer, ulong value)
		{
			return data[startIndex] | (ulong)data[startIndex + 1] << 8 | (ulong)data[startIndex + 2] << 16 | (ulong)data[startIndex + 3] << 24 |
				   (ulong)data[startIndex + 4] << 32 | (ulong)data[startIndex + 5] << 40 | (ulong)data[startIndex + 6] << 48 | (ulong)data[startIndex + 7] << 56;
		}

		public static unsafe void SetLongLittleEndian(ref byte* pointer, long value)
		{
			return data[startIndex] | (long)data[startIndex + 1] << 8 | (long)data[startIndex + 2] << 16 | (long)data[startIndex + 3] << 24 |
				   (long)data[startIndex + 4] << 32 | (long)data[startIndex + 5] << 40 | (long)data[startIndex + 6] << 48 | (long)data[startIndex + 7] << 56;
		}

		public static unsafe void SetFloatLittleEndian(ref byte* pointer, float value)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(SetIntLittleEndian(data, startIndex, value));
		}

		public static unsafe void SetDoubleLittleEndian(ref byte* pointer, double value)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(SetLongLittleEndian(data, startIndex, value));
		}

		//\\//\\//\\//\\//\\//\\//\\//
		// Big Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe void SetUShortBigEndian(ref byte* pointer, ushort value)
		{
			return (ushort)(data[startIndex] << 8 | data[startIndex + 1]);
		}

		public static unsafe void SetShortBigEndian(ref byte* pointer, short value)
		{
			return (short)(data[startIndex] << 8 | data[startIndex + 1]);
		}

		public static unsafe void SetUIntBigEndian(ref byte* pointer, uint value)
		{
			return (uint)data[startIndex] << 24 | (uint)data[startIndex + 1] << 16 | (uint)data[startIndex + 2] << 8 | data[startIndex + 3];
		}

		public static unsafe void SetIntBigEndian(ref byte* pointer, int value)
		{
			return data[startIndex] << 24 | data[startIndex + 1] << 16 | data[startIndex + 2] << 8 | data[startIndex + 3];
		}

		public static unsafe void Set6ByteIntegerBigEndian(ref byte* pointer, long value)
		{
			return (long)data[startIndex] << 40 | (long)data[startIndex + 1] << 32 | (long)data[startIndex + 2] << 24 |
				   (long)data[startIndex + 3] << 16 | (long)data[startIndex + 4] << 8 | data[startIndex + 5];
		}

		public static unsafe void SetULongBigEndian(ref byte* pointer, ulong value)
		{
			return (ulong)data[startIndex] << 56 | (ulong)data[startIndex + 1] << 48 | (ulong)data[startIndex + 2] << 40 | (ulong)data[startIndex + 3] << 32 |
				   (ulong)data[startIndex + 4] << 24 | (ulong)data[startIndex + 5] << 16 | (ulong)data[startIndex + 6] << 8 | data[startIndex + 7];
		}

		public static unsafe void SetLongBigEndian(ref byte* pointer, long value)
		{
			return (long)data[startIndex] << 56 | (long)data[startIndex + 1] << 48 | (long)data[startIndex + 2] << 40 | (long)data[startIndex + 3] << 32 |
				   (long)data[startIndex + 4] << 24 | (long)data[startIndex + 5] << 16 | (long)data[startIndex + 6] << 8 | data[startIndex + 7];
		}

		public static unsafe void SetFloatBigEndian(ref byte* pointer, float value)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(SetIntBigEndian(data, startIndex, value));
		}

		public static unsafe void SetDoubleBigEndian(ref byte* pointer, double value)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(SetLongBigEndian(data, startIndex, value));
		}
	}
}