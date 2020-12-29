using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lecture2
{
	class Lecture
	{
		public static void Run()
		{
			// Вызов метода
			Console.WriteLine(Square(10.186));
		}

		
		// Описание метода
		static double Square(double x)
		{
			return x * x;
		}
	}
}
