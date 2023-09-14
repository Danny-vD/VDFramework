using System;
using VDFramework.IO.Parsers.ByteParsers.Readers.BitShiftReaders;

namespace VDFramework.IO.Parsers.ByteParsers.Readers.Static
{
	/// <summary>
	/// Contains functions for parsing bytes in the little endian format (will automatically pick the algorithm depending on the endianness of the system)
	/// </summary>
	public static class ByteReaderLittleEndian
	{
		private static readonly AbstractByteReader byteParser;
		
		static ByteReaderLittleEndian()
		{
			if (BitConverter.IsLittleEndian)
			{
				byteParser = new PointerCastByteReader();
			}
			else
			{
				byteParser = new BitShiftLittleEndianReader();
			}
		}

		public static unsafe ushort ReadUShort(ref byte* pointer)
		{
			return byteParser.ReadUShort(ref pointer);
		}

		public static unsafe short ReadShort(ref byte* pointer)
		{
			return byteParser.ReadShort(ref pointer);
		}

		public static unsafe uint ReadUInt(ref byte* pointer)
		{
			return byteParser.ReadUInt(ref pointer);
		}

		public static unsafe int ReadInt(ref byte* pointer)
		{
			return byteParser.ReadInt(ref pointer);
		}

		public static unsafe ulong ReadULong(ref byte* pointer)
		{
			return byteParser.ReadULong(ref pointer);
		}

		public static unsafe long ReadLong(ref byte* pointer)
		{
			return byteParser.ReadLong(ref pointer);
		}

		public static unsafe float ReadFloat(ref byte* pointer)
		{
			return byteParser.ReadFloat(ref pointer);
		}

		public static unsafe double ReadDouble(ref byte* pointer)
		{
			return byteParser.ReadDouble(ref pointer);
		}
	}
}