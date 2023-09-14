using VDFramework.IO.Parsers.ByteParsers.Static;

namespace VDFramework.IO.Parsers.ByteParsers.LittleEndian
{
	internal class BitShiftLittleEndianParser : AbstractByteParser
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(ushort));

			return EndianParser.GetUShortLittleEndian(array, 0);
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(short));

			return EndianParser.GetShortLittleEndian(array, 0);
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianParser.GetUIntLittleEndian(array, 0);
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianParser.GetIntLittleEndian(array, 0);
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(ulong));

			return EndianParser.GetULongLittleEndian(array, 0);
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(long));

			return EndianParser.GetLongLittleEndian(array, 0);
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(float));

			return EndianParser.GetFloatLittleEndian(array, 0);
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			ByteParser.ReadBytes(ref pointer, out byte[] array, sizeof(double));

			return EndianParser.GetDoubleLittleEndian(array, 0);
		}
	}
}