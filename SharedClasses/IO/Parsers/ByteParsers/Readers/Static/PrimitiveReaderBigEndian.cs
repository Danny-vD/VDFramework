using System;
using VDFramework.IO.Parsers.ByteParsers.Readers.BitShiftReaders;
using VDFramework.IO.Parsers.ByteParsers.Readers.PointerCastReaders;

namespace VDFramework.IO.Parsers.ByteParsers.Readers.Static
{
	/// <summary>
	/// Contains functions for parsing bytes in the big endian format (will automatically pick the algorithm depending on the endianness of the system)
	/// </summary>
	public static class PrimitiveReaderBigEndian
	{
		private static readonly AbstractPrimitiveReader primitiveReader;
		
		static PrimitiveReaderBigEndian()
		{
			if (BitConverter.IsLittleEndian)
			{
				primitiveReader = new BitShiftBigEndianReader();
			}
			else
			{
				primitiveReader = new PointerCastPrimitiveReader();
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
	}
}