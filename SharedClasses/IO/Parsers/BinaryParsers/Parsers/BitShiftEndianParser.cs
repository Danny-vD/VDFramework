using VDFramework.Utility.Unsafe;

namespace VDFramework.IO.Parsers.BinaryParsers.Parsers
{
	/// <summary>
	/// Contains functions to get or set primitives from a byte*
	/// </summary>
	internal static class BitShiftEndianParser
	{
		//\\//\\//\\//\\//\\//\\//\\//
		//	Getters
		//\\//\\//\\//\\//\\//\\//\\//

		//\\//\\//\\//\\//\\//\\//\\//
		// Little Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe ushort GetUShortLittleEndian(byte* pointer)
		{
			return (ushort)(*(pointer) | (int)*(pointer + 1) << 8);
		}

		public static unsafe short GetShortLittleEndian(byte* pointer)
		{
			return (short)(*(pointer) | (int)*(pointer + 1) << 8);
		}

		public static unsafe uint GetUIntLittleEndian(byte* pointer)
		{
			return *(pointer) | (uint)*(pointer + 1) << 8 | (uint)*(pointer + 2) << 16 | (uint)*(pointer + 3) << 24;
		}

		public static unsafe int GetIntLittleEndian(byte* pointer)
		{
			return *(pointer) | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24;
		}

		public static unsafe long Get6ByteIntegerLittleEndian(byte* pointer)
		{
			return *(pointer) | (long)*(pointer + 1) << 8 | (long)*(pointer + 2) << 16 |
				   (long)*(pointer + 3) << 24 | (long)*(pointer + 4) << 32 | (long)*(pointer + 5) << 40;
		}

		public static unsafe ulong GetULongLittleEndian(byte* pointer)
		{
			return *(pointer) | (ulong)*(pointer + 1) << 8 | (ulong)*(pointer + 2) << 16 | (ulong)*(pointer + 3) << 24 |
				   (ulong)*(pointer + 4) << 32 | (ulong)*(pointer + 5) << 40 | (ulong)*(pointer + 6) << 48 | (ulong)*(pointer + 7) << 56;
		}

		public static unsafe long GetLongLittleEndian(byte* pointer)
		{
			return *(pointer) | (long)*(pointer + 1) << 8 | (long)*(pointer + 2) << 16 | (long)*(pointer + 3) << 24 |
				   (long)*(pointer + 4) << 32 | (long)*(pointer + 5) << 40 | (long)*(pointer + 6) << 48 | (long)*(pointer + 7) << 56;
		}

		public static unsafe float GetFloatLittleEndian(byte* pointer)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntLittleEndian(pointer));
		}

		public static unsafe double GetDoubleLittleEndian(byte* pointer)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongLittleEndian(pointer));
		}

		//\\//\\//\\//\\//\\//\\//\\//
		// Big Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe ushort GetUShortBigEndian(byte* pointer)
		{
			return (ushort)(*(pointer) << 8 | *(pointer + 1));
		}

		public static unsafe short GetShortBigEndian(byte* pointer)
		{
			return (short)(*(pointer) << 8 | *(pointer + 1));
		}

		public static unsafe uint GetUIntBigEndian(byte* pointer)
		{
			return (uint)*(pointer) << 24 | (uint)*(pointer + 1) << 16 | (uint)*(pointer + 2) << 8 | *(pointer + 3);
		}

		public static unsafe int GetIntBigEndian(byte* pointer)
		{
			return *(pointer) << 24 | *(pointer + 1) << 16 | *(pointer + 2) << 8 | *(pointer + 3);
		}

		public static unsafe long Get6ByteIntegerBigEndian(byte* pointer)
		{
			return (long)*(pointer) << 40 | (long)*(pointer + 1) << 32 | (long)*(pointer + 2) << 24 |
				   (long)*(pointer + 3) << 16 | (long)*(pointer + 4) << 8 | *(pointer + 5);
		}

		public static unsafe ulong GetULongBigEndian(byte* pointer)
		{
			return (ulong)*(pointer) << 56 | (ulong)*(pointer + 1) << 48 | (ulong)*(pointer + 2) << 40 | (ulong)*(pointer + 3) << 32 |
				   (ulong)*(pointer + 4) << 24 | (ulong)*(pointer + 5) << 16 | (ulong)*(pointer + 6) << 8 | *(pointer + 7);
		}

		public static unsafe long GetLongBigEndian(byte* pointer)
		{
			return (long)*(pointer) << 56 | (long)*(pointer + 1) << 48 | (long)*(pointer + 2) << 40 | (long)*(pointer + 3) << 32 |
				   (long)*(pointer + 4) << 24 | (long)*(pointer + 5) << 16 | (long)*(pointer + 6) << 8 | *(pointer + 7);
		}

		public static unsafe float GetFloatBigEndian(byte* pointer)
		{
			return UnsafeUtil.reinterpret_cast<int, float>(GetIntBigEndian(pointer));
		}

		public static unsafe double GetDoubleBigEndian(byte* pointer)
		{
			return UnsafeUtil.reinterpret_cast<long, double>(GetLongBigEndian(pointer));
		}

		//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//
		//\\//\\//\\//\\//\\//\\//\\//
		//	Setters
		//\\//\\//\\//\\//\\//\\//\\//

		//\\//\\//\\//\\//\\//\\//\\//
		// Little Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe void SetUShortLittleEndian(byte* pointer, ushort value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
		}

		public static unsafe void SetShortLittleEndian(byte* pointer, short value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
		}

		public static unsafe void SetUIntLittleEndian(byte* pointer, uint value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
			*(pointer + 2) = (byte)(value >> 16);
			*(pointer + 3) = (byte)(value >> 24);
		}

		public static unsafe void SetIntLittleEndian(byte* pointer, int value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
			*(pointer + 2) = (byte)(value >> 16);
			*(pointer + 3) = (byte)(value >> 24);
		}

		public static unsafe void Set6ByteIntegerLittleEndian(byte* pointer, long value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
			*(pointer + 2) = (byte)(value >> 16);
			*(pointer + 3) = (byte)(value >> 24);
			*(pointer + 4) = (byte)(value >> 32);
			*(pointer + 5) = (byte)(value >> 40);
		}

		public static unsafe void SetULongLittleEndian(byte* pointer, ulong value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
			*(pointer + 2) = (byte)(value >> 16);
			*(pointer + 3) = (byte)(value >> 24);
			*(pointer + 4) = (byte)(value >> 32);
			*(pointer + 5) = (byte)(value >> 40);
			*(pointer + 6) = (byte)(value >> 48);
			*(pointer + 7) = (byte)(value >> 56);
		}

		public static unsafe void SetLongLittleEndian(byte* pointer, long value)
		{
			*pointer       = (byte)value;
			*(pointer + 1) = (byte)(value >> 8);
			*(pointer + 2) = (byte)(value >> 16);
			*(pointer + 3) = (byte)(value >> 24);
			*(pointer + 4) = (byte)(value >> 32);
			*(pointer + 5) = (byte)(value >> 40);
			*(pointer + 6) = (byte)(value >> 48);
			*(pointer + 7) = (byte)(value >> 56);
		}

		public static unsafe void SetFloatLittleEndian(byte* pointer, float value)
		{
			SetIntLittleEndian(pointer, UnsafeUtil.reinterpret_cast<float, int>(value));
		}

		public static unsafe void SetDoubleLittleEndian(byte* pointer, double value)
		{
			SetLongLittleEndian(pointer, UnsafeUtil.reinterpret_cast<double, long>(value));
		}

		//\\//\\//\\//\\//\\//\\//\\//
		// Big Endian
		//\\//\\//\\//\\//\\//\\//\\//
		public static unsafe void SetUShortBigEndian(byte* pointer, ushort value)
		{
			*(pointer + 1) = (byte)value;
			*pointer       = (byte)(value >> 8);
		}

		public static unsafe void SetShortBigEndian(byte* pointer, short value)
		{
			*(pointer + 1) = (byte)value;
			*pointer       = (byte)(value >> 8);
		}

		public static unsafe void SetUIntBigEndian(byte* pointer, uint value)
		{
			*(pointer + 3) = (byte)value;
			*(pointer + 2) = (byte)(value >> 8);
			*(pointer + 1) = (byte)(value >> 16);
			*pointer       = (byte)(value >> 24);
		}

		public static unsafe void SetIntBigEndian(byte* pointer, int value)
		{
			*(pointer + 3) = (byte)value;
			*(pointer + 2) = (byte)(value >> 8);
			*(pointer + 1) = (byte)(value >> 16);
			*pointer       = (byte)(value >> 24);
		}

		public static unsafe void Set6ByteIntegerBigEndian(byte* pointer, long value)
		{
			*(pointer + 5) = (byte)value;
			*(pointer + 4) = (byte)(value >> 8);
			*(pointer + 3) = (byte)(value >> 16);
			*(pointer + 2) = (byte)(value >> 24);
			*(pointer + 1) = (byte)(value >> 32);
			*pointer       = (byte)(value >> 40);
		}

		public static unsafe void SetULongBigEndian(byte* pointer, ulong value)
		{
			*(pointer + 7) = (byte)value;
			*(pointer + 6) = (byte)(value >> 8);
			*(pointer + 5) = (byte)(value >> 16);
			*(pointer + 4) = (byte)(value >> 24);
			*(pointer + 3) = (byte)(value >> 32);
			*(pointer + 2) = (byte)(value >> 40);
			*(pointer + 1) = (byte)(value >> 48);
			*pointer       = (byte)(value >> 56);
		}

		public static unsafe void SetLongBigEndian(byte* pointer, long value)
		{
			*(pointer + 7) = (byte)value;
			*(pointer + 6) = (byte)(value >> 8);
			*(pointer + 5) = (byte)(value >> 16);
			*(pointer + 4) = (byte)(value >> 24);
			*(pointer + 3) = (byte)(value >> 32);
			*(pointer + 2) = (byte)(value >> 40);
			*(pointer + 1) = (byte)(value >> 48);
			*pointer       = (byte)(value >> 56);
		}

		public static unsafe void SetFloatBigEndian(byte* pointer, float value)
		{
			SetIntBigEndian(pointer, UnsafeUtil.reinterpret_cast<float, int>(value));
		}

		public static unsafe void SetDoubleBigEndian(byte* pointer, double value)
		{
			SetLongBigEndian(pointer, UnsafeUtil.reinterpret_cast<double, long>(value));
		}
	}
}