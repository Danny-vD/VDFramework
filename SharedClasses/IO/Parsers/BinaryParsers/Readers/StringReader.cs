using System.Text;

namespace VDFramework.IO.Parsers.BinaryParsers.Readers
{
	/// <summary>
	/// Contains functions for parsing and reading strings
	/// </summary>
	public static class StringReader
	{
		/// <summary>
		/// Read a NULL-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte pointer
		/// </summary>
		/// <returns>
		/// A string up to a NULL-character or up to maxCount characters
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
		/// Read a NULL-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte pointer
		/// </summary>
		/// <returns>
		/// A string up to a NULL-character or up to maxCount characters
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
		
		/// <summary>
		/// Read a NULL-terminated <see cref="Encoding.UTF8"/> string with the byte pointer
		/// </summary>
		/// <warning>
		/// There is no predefined limit, it will keep reading until either a NULL-character is found or until it has read Int32.<see cref="int.MaxValue"/> characters
		/// </warning>
		/// <returns>
		/// A string up to a NULL-character
		/// </returns>
		public static unsafe string ReadString(ref byte* pointer)
		{
			bool nullFound = false;

			byte* oldPosition = pointer;

			for (int i = 0; i < int.MaxValue; i++)
			{
				if (*pointer == 0) // NULL-terminated
				{
					nullFound = true;
					break;
				}

				++pointer;
			}

			if (!nullFound)
			{
				throw new System.Exception("The string is not NULL-terminated (or is too long)!");
			}

			long actualCount = pointer - oldPosition;

			string result = Encoding.UTF8.GetString(oldPosition, (int)actualCount);

			++pointer; // Move it past the NULL-character
			return result;
		}
		
		/// <summary>
		/// Read a NULL-terminated string with maxCount characters from the byte array
		/// </summary>
		/// <returns>
		/// A string up to a NULL-character or up to maxCount characters
		/// </returns>
		public static string GetString(byte[] data, int maxCount = 0)
		{
			return GetString(data, (ulong)maxCount);
		}

		/// <summary>
		/// Read a NULL-terminated <see cref="Encoding.UTF8"/> string with maxCount characters from the byte array
		/// </summary>
		/// <returns>
		/// A string up to a NULL-character or up to maxCount characters
		/// </returns>
		public static unsafe string GetString(byte[] data, ulong maxCount)
		{
			maxCount = maxCount == 0 ? (ulong)data.LongLength : maxCount;
			
			fixed (byte* array = data)
			{
				byte* ptr = array;

				return ReadString(ref ptr, maxCount);
			}
		}
	}
}