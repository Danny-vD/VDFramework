namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal abstract class AbstractPrimitiveWriter
	{
		public abstract unsafe void WriteUShort(ref byte* pointer, ushort value);

		public abstract unsafe void WriteShort(ref byte* pointer, short value);

		public abstract unsafe void WriteUInt(ref byte* pointer, uint value);

		public abstract unsafe void WriteInt(ref byte* pointer, int value);

		public abstract unsafe void WriteULong(ref byte* pointer, ulong value);

		public abstract unsafe void WriteLong(ref byte* pointer, long value);

		public abstract unsafe void WriteFloat(ref byte* pointer, float value);

		public abstract unsafe void WriteDouble(ref byte* pointer, double value);
	}
}