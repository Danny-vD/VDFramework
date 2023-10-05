using VDFramework.IO.Parsers.BinaryParsers.Parsers;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal
{
	internal class BitShiftBigEndianPrimitiveReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ushort value = BitShiftEndianParser.GetUShortBigEndian(pointer);

			pointer += sizeof(ushort);

			return value;
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			short value = BitShiftEndianParser.GetShortBigEndian(pointer);

			pointer += sizeof(short);

			return value;
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			uint value = BitShiftEndianParser.GetUIntBigEndian(pointer);

			pointer += sizeof(uint);

			return value;
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			int value = BitShiftEndianParser.GetIntBigEndian(pointer);

			pointer += sizeof(int);

			return value;
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ulong value = BitShiftEndianParser.GetULongBigEndian(pointer);

			pointer += sizeof(ulong);

			return value;
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			long value = BitShiftEndianParser.GetLongBigEndian(pointer);

			pointer += sizeof(long);

			return value;
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			float value = BitShiftEndianParser.GetFloatBigEndian(pointer);

			pointer += sizeof(float);

			return value;
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			double value = BitShiftEndianParser.GetDoubleBigEndian(pointer);

			pointer += sizeof(double);

			return value;
		}
		
		public override unsafe decimal ReadDecimal(ref byte* pointer)
		{
			decimal value = BitShiftEndianParser.GetDecimalBigEndian(pointer);

			pointer += sizeof(decimal);

			return value;
		}
	}
}