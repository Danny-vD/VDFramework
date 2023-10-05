using VDFramework.IO.Parsers.BinaryParsers.Parsers;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal class BitShiftLittleEndianPrimitiveWriter : AbstractPrimitiveWriter
	{
		public override unsafe void WriteUShort(ref byte* pointer, ushort value)
		{
			BitShiftEndianParser.SetUShortLittleEndian(pointer, value);
            
            pointer += sizeof(ushort);
		}

		public override unsafe void WriteShort(ref byte* pointer, short value)
		{
			BitShiftEndianParser.SetShortLittleEndian(pointer, value);
            
            pointer += sizeof(short);
		}

		public override unsafe void WriteUInt(ref byte* pointer, uint value)
		{
			BitShiftEndianParser.SetUIntLittleEndian(pointer, value);
            
            pointer += sizeof(uint);
		}

		public override unsafe void WriteInt(ref byte* pointer, int value)
		{
			BitShiftEndianParser.SetIntLittleEndian(pointer, value);
            
            pointer += sizeof(int);
		}

		public unsafe void Write6ByteInt(ref byte* pointer, long value)
		{
			// Limit to 6-byte
			value &= 0b_11111111_11111111_11111111_11111111_11111111_11111111;
			
			BitShiftEndianParser.Set6ByteIntegerBigEndian(pointer, value);
            
			pointer += 6;
		}

		public override unsafe void WriteULong(ref byte* pointer, ulong value)
		{
			BitShiftEndianParser.SetULongLittleEndian(pointer, value);
            
            pointer += sizeof(ulong);
		}

		public override unsafe void WriteLong(ref byte* pointer, long value)
		{
			BitShiftEndianParser.SetLongLittleEndian(pointer, value);
            
            pointer += sizeof(long);
		}

		public override unsafe void WriteFloat(ref byte* pointer, float value)
		{
			BitShiftEndianParser.SetFloatLittleEndian(pointer, value);
            
            pointer += sizeof(float);
		}

		public override unsafe void WriteDouble(ref byte* pointer, double value)
		{
			BitShiftEndianParser.SetDoubleLittleEndian(pointer, value);
            
            pointer += sizeof(double);
		}
		
		public override unsafe void WriteDecimal(ref byte* pointer, decimal value)
		{
			BitShiftEndianParser.SetDecimalLittleEndian(pointer, value);
            
			pointer += sizeof(decimal);
		}
	}
}