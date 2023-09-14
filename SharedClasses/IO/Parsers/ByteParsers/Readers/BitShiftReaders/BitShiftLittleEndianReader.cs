using VDFramework.IO.Parsers.ByteParsers.Readers.Static;

namespace VDFramework.IO.Parsers.ByteParsers.Readers.BitShiftReaders
{
	internal class BitShiftLittleEndianReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ushort));

			return EndianReader.GetUShortLittleEndian(array, 0);
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(short));

			return EndianReader.GetShortLittleEndian(array, 0);
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianReader.GetUIntLittleEndian(array, 0);
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianReader.GetIntLittleEndian(array, 0);
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ulong));

			return EndianReader.GetULongLittleEndian(array, 0);
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(long));

			return EndianReader.GetLongLittleEndian(array, 0);
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(float));

			return EndianReader.GetFloatLittleEndian(array, 0);
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(double));

			return EndianReader.GetDoubleLittleEndian(array, 0);
		}
	}
}