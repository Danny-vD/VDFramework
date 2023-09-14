using VDFramework.IO.Parsers.BinaryParsers.Readers.Logic;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal
{
	internal class BitShiftLittleEndianPrimitiveReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ushort value = BitShiftEndianParser.GetUShortLittleEndian(pointer, 0);

			pointer += sizeof(ushort);

			return value;
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			short value = BitShiftEndianParser.GetShortLittleEndian(pointer, 0);

			pointer += sizeof(short);

			return value;
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			uint value = BitShiftEndianParser.GetUIntLittleEndian(pointer, 0);

			pointer += sizeof(uint);

			return value;
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			int value = BitShiftEndianParser.GetIntLittleEndian(pointer, 0);

			pointer += sizeof(int);

			return value;
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ulong value = BitShiftEndianParser.GetULongLittleEndian(pointer, 0);

			pointer += sizeof(ulong);

			return value;
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			long value = BitShiftEndianParser.GetLongLittleEndian(pointer, 0);

			pointer += sizeof(long);

			return value;
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			float value = BitShiftEndianParser.GetFloatLittleEndian(pointer, 0);

			pointer += sizeof(float);

			return value;
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			double value = BitShiftEndianParser.GetDoubleLittleEndian(pointer, 0);

			pointer += sizeof(double);

			return value;
		}
	}
}