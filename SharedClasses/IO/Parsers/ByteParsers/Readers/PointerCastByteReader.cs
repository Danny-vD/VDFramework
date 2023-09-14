namespace VDFramework.IO.Parsers.ByteParsers.Readers
{
	internal class PointerCastByteReader : AbstractByteReader
	{
		public override unsafe ushort ReadUShort(ref byte* pointer)
		{
			ushort value = *(ushort*)pointer;

			pointer += sizeof(ushort);

			return value;
		}

		public override unsafe short ReadShort(ref byte* pointer)
		{
			short value = *(short*)pointer;

			pointer += sizeof(short);

			return value;
		}

		public override unsafe uint ReadUInt(ref byte* pointer)
		{
			uint value = *(uint*)pointer;

			pointer += sizeof(uint);

			return value;
		}

		public override unsafe int ReadInt(ref byte* pointer)
		{
			int value = *(int*)pointer;

			pointer += sizeof(int);

			return value;
		}

		public override unsafe ulong ReadULong(ref byte* pointer)
		{
			ulong value = *(ulong*)pointer;

			pointer += sizeof(ulong);

			return value;
		}

		public override unsafe long ReadLong(ref byte* pointer)
		{
			long value = *(long*)pointer;

			pointer += sizeof(long);

			return value;
		}

		public override unsafe float ReadFloat(ref byte* pointer)
		{
			float value = *(float*)pointer;

			pointer += sizeof(float);

			return value;
		}

		public override unsafe double ReadDouble(ref byte* pointer)
		{
			double value = *(double*)pointer;

			pointer += sizeof(double);

			return value;
		}
	}
}