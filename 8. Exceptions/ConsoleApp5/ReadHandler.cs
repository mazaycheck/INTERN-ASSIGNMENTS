using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp5
{
	public class ReadStreamHandler
	{
		bool Status { get; set; }
		public ReadStreamHandler() => Status = true;
		public void CloseReadStream() { Status = false; }

		public void CheckStatus()
		{

			if (!Status) { throw new ReadStreamError("Stream must be opened for read!"); }
		}
		public string ReadOperation()
		{
			CheckStatus();
			string[] operationlist = new string[] { "sub", "div", "mul", "add" };
			Console.WriteLine("Enter operation : add / sub / div / mul");
			string operation = Console.ReadLine();
			var found = operationlist.FirstOrDefault(m => m == operation);

			if (found != "") { return operation; }
			else
			{
				throw new InvalidUserInputException("Must be a valid operation");
			}
		}

		public void ReadInput(out double a, out double b)
		{
			CheckStatus();
			Console.WriteLine("Enter 2 numbers");
			bool aa = double.TryParse(Console.ReadLine(), out a);
			if (!aa) throw new InvalidUserInputException("Must be a number");
			bool bb = double.TryParse(Console.ReadLine(), out b);
			if (!bb) throw new InvalidUserInputException("Must be a number");
		}
	}

}
