namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal class PointerCastPrimitiveWriter : AbstractPrimitiveWriter
	{
		public override unsafe void WriteUShort(ref byte* pointer, ushort value)
		{
			*(ushort*)pointer = value;

			pointer += sizeof(ushort);
		}

		public override unsafe void WriteShort(ref byte* pointer, short value)
		{
			*(short*)pointer = value;
            
            pointer += sizeof(short);
		}

		public override unsafe void WriteUInt(ref byte* pointer, uint value)
		{
			*(uint*)pointer = value;
            
            pointer += sizeof(uint);
		}

		public override unsafe void WriteInt(ref byte* pointer, int value)
		{
			*(int*)pointer = value;
            
            pointer += sizeof(int);
		}

		public override unsafe void WriteULong(ref byte* pointer, ulong value)
		{
			*(ulong*)pointer = value;
            
            pointer += sizeof(ulong);
		}

		public override unsafe void WriteLong(ref byte* pointer, long value)
		{
			*(long*)pointer = value;
            
            pointer += sizeof(long);
		}

		public override unsafe void WriteFloat(ref byte* pointer, float value)
		{
			*(float*)pointer = value;
            
            pointer += sizeof(float);
		}

		public override unsafe void WriteDouble(ref byte* pointer, double value)
		{
			*(double*)pointer = value;
            
            pointer += sizeof(double);
		}
		
		public override unsafe void WriteDecimal(ref byte* pointer, decimal value)
		{
			*(decimal*)pointer = value;
            
			pointer += sizeof(decimal);
		}
	}
}