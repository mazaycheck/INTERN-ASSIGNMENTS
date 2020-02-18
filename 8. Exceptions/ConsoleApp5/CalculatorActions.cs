using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class CalculatorActions
    {
		public static double Add(double a, double b) => a + b;

		public static double Sub(double a, double b) => a - b;

		public static double Div(double a, double b)
		{
			if (b == 0)
				throw new DivideByZeroException("Cannot divide by zero");
			return a / b;
		}
		public static double Mul(double a, double b) => a * b;
	}
}
