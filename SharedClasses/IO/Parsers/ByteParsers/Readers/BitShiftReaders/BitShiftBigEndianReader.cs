using VDFramework.IO.Parsers.ByteParsers.Readers.Static;

namespace VDFramework.IO.Parsers.ByteParsers.Readers.BitShiftReaders
{
	internal class BitShiftBigEndianReader : AbstractByteReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ushort));

			return EndianReader.GetUShortBigEndian(array, 0);
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(short));

			return EndianReader.GetShortBigEndian(array, 0);
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianReader.GetUIntBigEndian(array, 0);
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return EndianReader.GetIntBigEndian(array, 0);
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ulong));

			return EndianReader.GetULongBigEndian(array, 0);
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(long));

			return EndianReader.GetLongBigEndian(array, 0);
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(float));

			return EndianReader.GetFloatBigEndian(array, 0);
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(double));

			return EndianReader.GetDoubleBigEndian(array, 0);
		}
	}
}