using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
	public class InvalidUserInputException : ApplicationException
	{
		public InvalidUserInputException(string msg) : base(msg)
		{

		}

		public InvalidUserInputException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
	public class ReadStreamError : ApplicationException
	{
		public ReadStreamError(string msg) : base(msg)
		{

		}

		public ReadStreamError(string message, Exception innerException) : base(message, innerException)
		{
		}

	}

	public class WrongOperaionException : Exception
	{
		public WrongOperaionException()
		{
		}

		public WrongOperaionException(string message) : base(message)
		{
		}

		public WrongOperaionException(string message, Exception innerException) : base(message, innerException)
		{
		}

	}
}
