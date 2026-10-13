namespace VDFramework.Utility.ArrayUtility
{
	/// <summary>
	/// Contains utility functions for arrays
	/// </summary>
	public class ArrayUtils
	{
		/// <summary>
		/// <para>Mirrors the y-axis of the array</para>
		/// <para>This function mirrors the y axis (rows) of the 2d data represented by the given byte[]</para>
		/// </summary>
		/// <param name="data">The data to mirror</param>
		/// <param name="height">The amount of rows in the data<br/>The width will be determined as length / height</param>
		/// <returns>A new array filled with data, but the 'columns' are reversed</returns>
		public static byte[] MirrorYAxisOfArray(byte[] data, int height)
		{
			byte[] flippedData = new byte[data.Length];

			int width = data.Length / height;

			int flippedIndex = 0; // Overarching index used for the new array
			
			for (int y = height - 1; y >= 0; y--)
			{
				int index = y * width; // index used to get data from the original array, offset by height so not a continuous value
				
				for (int x = 0; x < width; x++, index++, flippedIndex++)
				{
					flippedData[flippedIndex] = data[index];
				}
			}

			return flippedData;
		}
	}
}