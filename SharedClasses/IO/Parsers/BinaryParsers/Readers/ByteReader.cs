using System.Runtime.CompilerServices;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers
{
	/// <summary>
	/// Contains functions for parsing and reading bytes
	/// </summary>
	public static class ByteReader
	{
		/// <summary>
		/// Read a byte from the location of the pointer
		/// </summary>
		public static unsafe byte ReadByte(ref byte* pointer)
		{
			byte value = *pointer;

			pointer += sizeof(byte);

			return value;
		}

		/// <summary>
		/// Read a signed byte from the location of the pointer
		/// </summary>
		public static unsafe sbyte ReadSByte(ref byte* pointer)
		{
			sbyte value = *(sbyte*)pointer;

			pointer += sizeof(sbyte);

			return value;
		}

		/// <summary>
		/// Read a specified amount of bytes from the location of the pointer and store them in the given byte[]
		/// </summary>
		public static unsafe void ReadBytes(ref byte* data, out byte[] array, int count)
		{
			array = new byte[count];

			fixed (byte* pointer = array)
			{
				for (int i = 0; i < count; i++)
				{
					*(pointer + i) = *data;
					++data;
				}
			}
		}

		/// <summary>
		/// Read a specified amount of bytes from the location of the pointer and store them in the given byte[]
		/// </summary>
		public static unsafe void ReadBytes(ref byte* data, out byte[] array, ulong count)
		{
			array = new byte[count];

			fixed (byte* pointer = array)
			{
				for (ulong i = 0; i < count; i++)
				{
					*(pointer + i) = *data;
					++data;
				}
			}
		}
	}
}