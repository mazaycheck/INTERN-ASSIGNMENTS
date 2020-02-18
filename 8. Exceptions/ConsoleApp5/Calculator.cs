using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
	public class Calcutator
	{
		public double Calculate(double a, double b, MyDelegate m)
		{
			try
			{
				m(a, b);
			}
			catch (DivideByZeroException e)
			{
				throw new DivideByZeroException("Rethrown from calculator class DivideByZeroException", e);
			}
			return m(a, b);
		}
	}

}
