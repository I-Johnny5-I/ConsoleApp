using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSpaces
{
	public class Point
	{
		// Properties
		public double X { get; private set; }
		public double Y { get; private set; }

		// Constructors
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		// Methods
		public void Move(double newX, double newY)
		{
			X = newX;
			Y = newY;
		}s
	}
}
