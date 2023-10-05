using System;
using VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters
{
	/// <summary>
	/// Contains functions for writing bytes in the little endian format (will automatically pick the algorithm depending on the endianness of the system)
	/// </summary>
	public static class PrimitiveWriterLittleEndian
	{
		private static readonly AbstractPrimitiveWriter primitiveWriter;
		
		static PrimitiveWriterLittleEndian()
		{
			if (BitConverter.IsLittleEndian)
			{
				primitiveWriter = new PointerCastPrimitiveWriter();
			}
			else
			{
				primitiveWriter = new BitShiftLittleEndianPrimitiveWriter();
			}
		}
		
		public static unsafe void WriteUShort(ref byte* pointer, ushort value)
		{
			primitiveWriter.WriteUShort(ref pointer, value);
		}

		public static unsafe void WriteShort(ref byte* pointer, short value)
		{
			primitiveWriter.WriteShort(ref pointer, value);
		}

		public static unsafe void WriteUInt(ref byte* pointer, uint value)
		{
			primitiveWriter.WriteUInt(ref pointer, value);
		}

		public static unsafe void WriteInt(ref byte* pointer, int value)
		{
			primitiveWriter.WriteInt(ref pointer, value);
		}

		public static unsafe void WriteULong(ref byte* pointer, ulong value)
		{
			primitiveWriter.WriteULong(ref pointer, value);
		}

		public static unsafe void WriteLong(ref byte* pointer, long value)
		{
			primitiveWriter.WriteLong(ref pointer, value);
		}

		public static unsafe void WriteFloat(ref byte* pointer, float value)
		{
			primitiveWriter.WriteFloat(ref pointer, value);
		}

		public static unsafe void WriteDouble(ref byte* pointer, double value)
		{
			primitiveWriter.WriteDouble(ref pointer, value);
		}
		
		public static unsafe void WriteDecimal(ref byte* pointer, decimal value)
		{
			primitiveWriter.WriteDecimal(ref pointer, value);
		}
	}
}