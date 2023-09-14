using VDFramework.IO.Parsers.BinaryParsers.Writers.Logic;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal class BitShiftBigEndianPrimitiveWriter : AbstractPrimitiveWriter
	{
		public override unsafe void WriteUShort(ref byte* pointer, ushort value)
		{
			BitShiftEndianParser.SetUShortBigEndian(ref pointer, value);
		}

		public override unsafe void WriteShort(ref byte* pointer, short value)
		{
			BitShiftEndianParser.SetShortBigEndian(ref pointer, value);
		}

		public override unsafe void WriteUInt(ref byte* pointer, uint value)
		{
			BitShiftEndianParser.SetUIntBigEndian(ref pointer, value);
		}

		public override unsafe void WriteInt(ref byte* pointer, int value)
		{
			BitShiftEndianParser.SetIntBigEndian(ref pointer, value);
		}

		public override unsafe void WriteULong(ref byte* pointer, ulong value)
		{
			BitShiftEndianParser.SetULongBigEndian(ref pointer, value);
		}

		public override unsafe void WriteLong(ref byte* pointer, long value)
		{
			BitShiftEndianParser.SetLongBigEndian(ref pointer, value);
		}

		public override unsafe void WriteFloat(ref byte* pointer, float value)
		{
			BitShiftEndianParser.SetFloatBigEndian(ref pointer, value);
		}

		public override unsafe void WriteDouble(ref byte* pointer, double value)
		{
			BitShiftEndianParser.SetDoubleBigEndian(ref pointer, value);
		}
	}
}