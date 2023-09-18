namespace VDFramework.IO.Parsers.BinaryParsers.Writers
{
	/// <summary>
	/// Contains functions for parsing and writing bytes
	/// </summary>
	public static class ByteWriter
	{
		/// <summary>
		/// Write a byte to the location of the pointer
		/// </summary>
		public static unsafe void WriteByte(ref byte* pointer, byte value)
		{
			*pointer = value;

			pointer += sizeof(byte);
		}

		/// <summary>
		/// Write a signed byte to the location of the pointer
		/// </summary>
		public static unsafe void WriteSByte(ref byte* pointer, sbyte value)
		{
			*(sbyte*)pointer = value;

			pointer += sizeof(byte);
		}

		/// <summary>
		/// Write the data given in the array to the location of the pointer, only a specific part of the given array can be used by using the startIndex and length parameters
		/// </summary>
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

		/// <summary>
		/// Write the data given in the array to the location of the pointer, only a specific part of the given array can be used by using the startIndex and length parameters
		/// </summary>
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