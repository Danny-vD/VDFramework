using VDFramework.IO.Parsers.BinaryParsers.Readers.Logic;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal
{
	internal class BitShiftBigEndianPrimitiveReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ushort));

			return BitShiftEndianParser.GetUShortBigEndian(array, 0);
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(short));

			return BitShiftEndianParser.GetShortBigEndian(array, 0);
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return BitShiftEndianParser.GetUIntBigEndian(array, 0);
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return BitShiftEndianParser.GetIntBigEndian(array, 0);
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ulong));

			return BitShiftEndianParser.GetULongBigEndian(array, 0);
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(long));

			return BitShiftEndianParser.GetLongBigEndian(array, 0);
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(float));

			return BitShiftEndianParser.GetFloatBigEndian(array, 0);
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(double));

			return BitShiftEndianParser.GetDoubleBigEndian(array, 0);
		}
	}
}