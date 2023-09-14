using System.Runtime.CompilerServices;
using System.Text;

namespace VDFramework.IO.Parsers.ByteParsers.Static
{
	/// <summary>
	/// Contains functions for parsing and reading bytes
	/// </summary>
	public static class ByteParser
	{
		public static unsafe byte ReadByte(ref byte* pointer)
		{
			byte value = *pointer;

			pointer += sizeof(byte);

			return value;
		}

		public static unsafe sbyte ReadSByte(ref byte* pointer)
		{
			sbyte value = *(sbyte*)pointer;

			pointer += sizeof(sbyte);

			return value;
		}
		
		/// <summary>
		/// Read a null-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte pointer
		/// </summary>
		/// <returns>
		/// A string up to a null-character or up to maxCount characters
		/// </returns>
		public static unsafe string ReadString(ref byte* pointer, int maxCount)
		{
			int actualCount = 0;

			for (int i = 0; i < maxCount; i++)
			{
				if (*(pointer + i) == 0) // NULL-terminated
				{
					break;
				}

				++actualCount;
			}

			string result = Encoding.UTF8.GetString(pointer, actualCount);
			pointer += maxCount;

			return result;
		}

		/// <summary>
		/// Read a null-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte pointer
		/// </summary>
		/// <returns>
		/// A string up to a null-character or up to maxCount characters
		/// </returns>
		public static unsafe string ReadString(ref byte* pointer, ulong maxCount)
		{
			int actualCount = 0;

			for (ulong i = 0; i < maxCount; i++)
			{
				if (*(pointer + i) == 0) // NULL-terminated
				{
					break;
				}

				++actualCount;
			}

			string result = Encoding.UTF8.GetString(pointer, actualCount);
			pointer += maxCount;

			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

		/// <summary>
		/// Read a null-terminated string with maxCount characters from the byte array
		/// </summary>
		/// <returns>
		/// A string up to a null-character or up to maxCount characters
		/// </returns>
		public static string GetString(byte[] data, int maxCount = -1)
		{
			maxCount = maxCount < 0 ? data.Length : maxCount;
			return GetString(data, (ulong)maxCount);
		}

		/// <summary>
		/// Read a null-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte array
		/// </summary>
		/// <returns>
		/// A string up to a null-character or up to maxCount characters
		/// </returns>
		public static unsafe string GetString(byte[] data, ulong maxCount)
		{
			fixed (byte* array = data)
			{
				byte* ptr = array;

				return ReadString(ref ptr, maxCount);
			}
		}
	}
}