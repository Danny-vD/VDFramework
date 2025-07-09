using JetBrains.Annotations;

namespace VDFramework.Utility
{
	/// <summary>
	/// A simple class provides an easy way to write variables to a string using <see cref="string.Format(string, object[])"/>
	/// </summary>
	public class StringVariableWriter
	{
		private readonly string originalString;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="stringToModify">
		/// <para>The string that this instance needs to write variables into</para>
		/// <para>The string itself will not be modified, only a copy is used</para>
		/// </param>
		public StringVariableWriter(string stringToModify)
		{
			originalString = stringToModify;
		}

		/// <summary>
		/// Uses <see cref="string.Format(string, object[])"/> to replace placeholders in the string by variables and returns a copy of the new string
		/// </summary>
		[MustUseReturnValue]
		public string UpdateText(params object[] variables)
		{
			return string.Format(originalString, variables);
		}
	}
}