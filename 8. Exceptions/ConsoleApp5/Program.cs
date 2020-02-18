#define Debug
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Diagnostics;



namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {	
			
		
			Calcutator calculator1 = new Calcutator();
			do
			{
				var operation = "";
				double a = 0, b = 0, result = 0;
				MyDelegate Action = null;		
				var readStream1 = new ReadStreamHandler();

				try
				{
					readStream1.ReadInput(out  a, out  b);
					operation = readStream1.ReadOperation();
				}
				catch (InvalidUserInputException e)
				{
					Console.WriteLine(e.Message);
				}
															
				switch (operation)
				{
					case "add": Action = CalculatorActions.Add; ; break;
					case "sub": Action = CalculatorActions.Sub; break;
					case "mul": Action = CalculatorActions.Mul; break;
					case "div": Action = CalculatorActions.Div; break;
					default: throw new WrongOperaionException("Wrong operation");
				}
				
				try
				{
					result = calculator1.Calculate(a, b, Action);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"result:  {result}");
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				catch (NullReferenceException ne)
				{
					Console.WriteLine("Cannot reference null");
				}
				catch (DivideByZeroException dz) when (b == 0 && Action == CalculatorActions.Div)
				{
					Console.WriteLine("Cannot Divide By zero!");
#if Debug
					Trace.WriteLine($"{b} {Action.Method}");
					Debug.WriteLine(dz.Message);
					Debug.WriteLine("\n***************Stack Trace*************\n");
					Debug.WriteLine(dz.StackTrace);
					Debug.WriteLine("\n**************End of Stack Trace*********\n");
#endif
				}
				finally
				{
					readStream1.CloseReadStream();
					Console.WriteLine("Continue Y/n? ");
				}
			}
			while (Console.ReadLine() == "Y");
        }
	}
}
