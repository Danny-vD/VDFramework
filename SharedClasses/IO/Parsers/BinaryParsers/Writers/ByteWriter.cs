using System.Text;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers
{
	/// <summary>
	/// Contains functions for parsing and writing bytes
	/// </summary>
	public static class ByteWriter
	{
		public static unsafe void WriteByte(ref byte* pointer, byte value)
		{
			*pointer = value;

			pointer += sizeof(byte);
		}

		public static unsafe void WriteSByte(ref byte* pointer, sbyte value)
		{
			*(sbyte*)pointer = value;

			pointer += sizeof(byte);
		}

		/// <summary>
		/// <para>Write an <see cref="Encoding.UTF8"/> string to the byte pointer</para>
		/// <para>Optionally append a NULL-character at the end of the string</para>
		/// </summary>
		public static unsafe void WriteString(ref byte* pointer, string value, bool nullTerminated)
		{
			string valueToWrite = nullTerminated ? value + '\0' : value;

			byte[] arraytoWrite = Encoding.UTF8.GetBytes(valueToWrite);

			WriteBytes(ref pointer, arraytoWrite, 0);
		}

		public static unsafe void WriteBytes(ref byte* pointer, byte[] arrayToWrite, int startIndex = 0, int length = -1)
		{
			int arrayLength = arrayToWrite.Length;

			if (startIndex < 0 || startIndex > arrayLength)
			{
				startIndex = 0;
			}

			int lengthToWrite = length;

			if (length <= 0 || length >= arrayLength - startIndex)
			{
				lengthToWrite = arrayLength - startIndex;
			}

			fixed (byte* arrayData = arrayToWrite)
			{
				byte* arrayPointer = arrayData + startIndex;

				for (int i = 0; i < lengthToWrite; i++)
				{
					*pointer = *(arrayPointer + i);
					++pointer;
				}
			}
		}

		public static unsafe void WriteBytes(ref byte* pointer, byte[] arrayToWrite, ulong startIndex = 0, ulong length = 0)
		{
			ulong arrayLength = (ulong)arrayToWrite.LongLength;

			if (startIndex > arrayLength)
			{
				startIndex = 0;
			}

			ulong lengthToWrite = length;

			if (length >= arrayLength - startIndex)
			{
				lengthToWrite = arrayLength - startIndex;
			}

			fixed (byte* arrayData = arrayToWrite)
			{
				byte* arrayPointer = arrayData + startIndex;

				for (ulong i = 0; i < lengthToWrite; i++)
				{
					*pointer = *(arrayPointer + i);
					++pointer;
				}
			}
		}
	}
}