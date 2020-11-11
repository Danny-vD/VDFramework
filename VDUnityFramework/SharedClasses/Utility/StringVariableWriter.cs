namespace VDFramework.Utility
{
	public class StringVariableWriter
	{
		private readonly string originalString;

		public StringVariableWriter(string stringToModify)
		{
			originalString = stringToModify;
		}

		public string UpdateText(params object[] variables)
		{
			return string.Format(originalString, variables);
		}
	}
}