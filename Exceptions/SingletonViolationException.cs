using System;

namespace VDFramework.Exceptions
{
	/// <summary>
	/// The exception that is thrown once you create a 2nd instance of a singleton
	/// </summary>
	internal class SingletonViolationException : Exception
	{
		private const string exceptionMessage = "There can only be one instance of a singleton";
		
		public SingletonViolationException() : base(exceptionMessage)
		{
			
		}
		
		public SingletonViolationException(string message) : base(GetErrorMessage(message))
		{
			
		}
		
		public SingletonViolationException(string message, Exception innerException) : base(GetErrorMessage(message), innerException)
		{
			
		}

		private static string GetErrorMessage(string message)
		{
			string errorMessage = exceptionMessage;
			errorMessage += Environment.NewLine;
			errorMessage += message;

			return errorMessage;
		}
	}
}