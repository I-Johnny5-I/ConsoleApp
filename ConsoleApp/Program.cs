using System;

namespace ColorSpaces
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			byte r, g, b;
			ColorSpace.HSLToRGB(30, 1, 0.75, out r, out g, out b);
			Console.WriteLine($"{r} {g} {b}");
		}	
	}
}
