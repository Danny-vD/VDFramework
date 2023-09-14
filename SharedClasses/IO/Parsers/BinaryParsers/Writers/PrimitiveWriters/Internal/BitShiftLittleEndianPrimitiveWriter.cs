using VDFramework.IO.Parsers.BinaryParsers.Writers.Logic;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal class BitShiftLittleEndianPrimitiveWriter : AbstractPrimitiveWriter
	{
		public override unsafe void WriteUShort(ref byte* pointer, ushort value)
		{
			BitShiftEndianParser.SetUShortLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteShort(ref byte* pointer, short value)
		{
			BitShiftEndianParser.SetShortLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteUInt(ref byte* pointer, uint value)
		{
			BitShiftEndianParser.SetUIntLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteInt(ref byte* pointer, int value)
		{
			BitShiftEndianParser.SetIntLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteULong(ref byte* pointer, ulong value)
		{
			BitShiftEndianParser.SetULongLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteLong(ref byte* pointer, long value)
		{
			BitShiftEndianParser.SetLongLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteFloat(ref byte* pointer, float value)
		{
			BitShiftEndianParser.SetFloatLittleEndian(ref pointer, value);
		}

		public override unsafe void WriteDouble(ref byte* pointer, double value)
		{
			BitShiftEndianParser.SetDoubleLittleEndian(ref pointer, value);
		}
	}
}