using System;
using System.Text;

namespace VDFramework.IO.Parsers.BinaryParsers.Writers
{
	/// <summary>
	/// Contains functions for parsing and writing strings
	/// </summary>
	public static class StringWriter
	{
		/// <summary>
		/// <para>Write an <see cref="Encoding.UTF8"/> string to the byte pointer</para>
		/// <para>Optionally append a NULL-character at the end of the string</para>
		/// </summary>
		public static unsafe void WriteString(ref byte* pointer, string value, bool nullTerminated)
		{
			string valueToWrite = nullTerminated ? value + '\0' : value;

			byte[] arraytoWrite = Encoding.UTF8.GetBytes(valueToWrite);

			ByteWriter.WriteBytes(ref pointer, arraytoWrite, 0);
		}
		
		/// <summary>
		/// <para>Write an <see cref="Encoding.UTF8"/> string to the byte pointer</para>
		/// <para>The string will be modified so that it is size <paramref name="bytesToWrite"/> either by cutting it off, or appending NULL-characters</para>
		/// </summary>
		/// <warning>
		/// This function does not gracefully handle cutting off a multi-byte character, it will split the bytes of these characters if it reached the <paramref name="bytesToWrite"/>
		/// </warning>
		public static unsafe void WriteString(ref byte* pointer, string value, int bytesToWrite)
		{
			int currentByteCount = Encoding.UTF8.GetByteCount(value);

			byte[] arrayToWrite;

			if (currentByteCount < bytesToWrite) // String should be lengthened
			{
				while (currentByteCount < bytesToWrite)
				{
					value += '\0';
					++currentByteCount;
				}
				
				arrayToWrite = Encoding.UTF8.GetBytes(value);
			}
			else if (currentByteCount > bytesToWrite) // String should be shortened
			{
				arrayToWrite = new byte[bytesToWrite];
				
				byte[] stringBytes = Encoding.UTF8.GetBytes(value);
				Buffer.BlockCopy(stringBytes, 0, arrayToWrite, 0, bytesToWrite);
			}
			else // String has right size
			{
				arrayToWrite = Encoding.UTF8.GetBytes(value);
			}

			ByteWriter.WriteBytes(ref pointer, arrayToWrite, 0);
		}
	}
}