namespace VDFramework.IO.Parsers.ByteParsers
{
	internal abstract class AbstractByteParser
	{
		public abstract unsafe ushort ReadUShort(ref byte* pointer);

		public abstract unsafe short ReadShort(ref byte* pointer);

		public abstract unsafe uint ReadUInt(ref byte* pointer);

		public abstract unsafe int ReadInt(ref byte* pointer);

		public abstract unsafe ulong ReadULong(ref byte* pointer);

		public abstract unsafe long ReadLong(ref byte* pointer);

		public abstract unsafe float ReadFloat(ref byte* pointer);

		public abstract unsafe double ReadDouble(ref byte* pointer);
	}
}