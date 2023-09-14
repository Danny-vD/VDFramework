using VDFramework.IO.Parsers.BinaryParsers.Readers.Logic;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers.PrimitiveReaders.Internal
{
	internal class BitShiftLittleEndianPrimitiveReader : AbstractPrimitiveReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ushort));

			return BitShiftEndianParser.GetUShortLittleEndian(array, 0);
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(short));

			return BitShiftEndianParser.GetShortLittleEndian(array, 0);
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return BitShiftEndianParser.GetUIntLittleEndian(array, 0);
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(uint));

			return BitShiftEndianParser.GetIntLittleEndian(array, 0);
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(ulong));

			return BitShiftEndianParser.GetULongLittleEndian(array, 0);
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(long));

			return BitShiftEndianParser.GetLongLittleEndian(array, 0);
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(float));

			return BitShiftEndianParser.GetFloatLittleEndian(array, 0);
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			ByteReader.ReadBytes(ref pointer, out byte[] array, sizeof(double));

			return BitShiftEndianParser.GetDoubleLittleEndian(array, 0);
		}
	}
}