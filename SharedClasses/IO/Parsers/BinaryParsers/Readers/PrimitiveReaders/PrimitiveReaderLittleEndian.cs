using System;
using VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders
{
	/// <summary>
	/// Contains functions for reading bytes in the little endian format (will automatically pick the algorithm depending on the endianness of the system)
	/// </summary>
	public static class PrimitiveReaderLittleEndian // TODO: Too similar to PrimitiveReaderBigEndian
	{
		private static readonly AbstractPrimitiveReader primitiveReader;
		
		static PrimitiveReaderLittleEndian()
		{
			if (BitConverter.IsLittleEndian)
			{
				primitiveReader = new PointerCastPrimitiveReader();
			}
			else
			{
				primitiveReader = new BitShiftLittleEndianPrimitiveReader();
			}
		}

		public static unsafe ushort ReadUShort(ref byte* pointer)
		{
			return primitiveReader.ReadUShort(ref pointer);
		}

		public static unsafe short ReadShort(ref byte* pointer)
		{
			return primitiveReader.ReadShort(ref pointer);
		}

		public static unsafe uint ReadUInt(ref byte* pointer)
		{
			return primitiveReader.ReadUInt(ref pointer);
		}

		public static unsafe int ReadInt(ref byte* pointer)
		{
			return primitiveReader.ReadInt(ref pointer);
		}

		public static unsafe ulong ReadULong(ref byte* pointer)
		{
			return primitiveReader.ReadULong(ref pointer);
		}

		public static unsafe long ReadLong(ref byte* pointer)
		{
			return primitiveReader.ReadLong(ref pointer);
		}

		public static unsafe float ReadFloat(ref byte* pointer)
		{
			return primitiveReader.ReadFloat(ref pointer);
		}

		public static unsafe double ReadDouble(ref byte* pointer)
		{
			return primitiveReader.ReadDouble(ref pointer);
		}
		
		public static unsafe decimal ReadDecimal(ref byte* pointer)
		{
			return primitiveReader.ReadDecimal(ref pointer);
		}
	}
}