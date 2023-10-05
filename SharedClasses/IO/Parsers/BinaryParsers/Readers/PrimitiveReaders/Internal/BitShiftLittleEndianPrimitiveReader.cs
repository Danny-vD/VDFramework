using VDFramework.IO.Parsers.BinaryParsers.Parsers;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal
{
	internal class BitShiftLittleEndianPrimitiveReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ushort value = BitShiftEndianParser.GetUShortLittleEndian(pointer);

			pointer += sizeof(ushort);

			return value;
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			short value = BitShiftEndianParser.GetShortLittleEndian(pointer);

			pointer += sizeof(short);

			return value;
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			uint value = BitShiftEndianParser.GetUIntLittleEndian(pointer);

			pointer += sizeof(uint);

			return value;
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			int value = BitShiftEndianParser.GetIntLittleEndian(pointer);

			pointer += sizeof(int);

			return value;
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ulong value = BitShiftEndianParser.GetULongLittleEndian(pointer);

			pointer += sizeof(ulong);

			return value;
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			long value = BitShiftEndianParser.GetLongLittleEndian(pointer);

			pointer += sizeof(long);

			return value;
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			float value = BitShiftEndianParser.GetFloatLittleEndian(pointer);

			pointer += sizeof(float);

			return value;
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			double value = BitShiftEndianParser.GetDoubleLittleEndian(pointer);

			pointer += sizeof(double);

			return value;
		}
		
		public override unsafe decimal ReadDecimal(ref byte* pointer)
		{
			decimal value = BitShiftEndianParser.GetDecimalLittleEndian(pointer);

			pointer += sizeof(decimal);

			return value;
		}
	}
}