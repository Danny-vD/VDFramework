namespace VDFramework.IO.Parsers.BinaryParsers.Writers.PrimitiveWriters.Internal
{
	internal abstract class AbstractPrimitiveWriter
	{
		public abstract unsafe ushort WriteUShort(ref byte* pointer);

		public abstract unsafe short WriteShort(ref byte* pointer);

		public abstract unsafe uint WriteUInt(ref byte* pointer);

		public abstract unsafe int WriteInt(ref byte* pointer);

		public abstract unsafe ulong WriteULong(ref byte* pointer);

		public abstract unsafe long WriteLong(ref byte* pointer);

		public abstract unsafe float WriteFloat(ref byte* pointer);

		public abstract unsafe double WriteDouble(ref byte* pointer);
	}
}