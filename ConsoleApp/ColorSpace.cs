using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSpaces
{
	public static class ColorSpace
	{
		public static void HSVToRGB(int h, double s, double v, out double r, out double g, out double b)
		{
			if (h < 0 || h > 360 || s < 0.0 || s > 1.0 || v < 0.0 || v > 1.0)
			{
				throw new ArgumentException("Unacceptable h, s, or v value(s)");
			}
			var segment = h / 60;
			if (segment == 6) segment = 0;
			while (h >= 60)
				h -= 60;

			if (segment == 0)
			{
				r = v;
				g = PositiveGradient(h, s) * v;
				b = (1.0 - s) * v;
			}
			else if (segment == 1)
			{
				r = NegativeGradient(h, s) * v;
				g = v;
				b = (1.0 - s) * v;
			}
			else if (segment == 2)
			{
				r = (1.0 - s) * v;
				g = v;
				b = PositiveGradient(h, s) * v;
			}
			else if (segment == 3)
			{
				r = (1.0 - s) * v;
				g = NegativeGradient(h, s) * v;
				b = v;
			}
			else if (segment == 4)
			{
				r = PositiveGradient(h, s) * v;
				g = (1.0 - s) * v;
				b = v;
			}
			else if (segment == 5)
			{
				r = v;
				g = (1.0 - s) * v;
				b = NegativeGradient(h, s) * v;
			}
			else
			{
				r = -1.0;
				g = -1.0;
				b = -1.0;
			}
		}
		public static void HSVToRGB(int h, double s, double v, out byte r, out byte g, out byte b)
		{
			HSVToRGB(h, s, v, out double r1, out double g1, out double b1);
			r = Convert.ToByte(Math.Round(r1 * 255.0));
			g = Convert.ToByte(Math.Round(g1 * 255.0));
			b = Convert.ToByte(Math.Round(b1 * 255.0));
		}

		public static void HSLToRGB(double h, double s, double l, out double r, out double g, out double b)
		{
			if (h < 0 || h > 360.0 || s < 0.0 || s > 1.0 || l < 0.0 || l > 1.0)
			{
				throw new ArgumentException("Unacceptable h, s, or l value(s)");
			}
			var segment = (int)(h / 60.0);
			if (segment == 6) segment = 0;
			while (h >= 60.0) h -= 60.0;
			double lightness_direction = - 1;
			if (l < 0.5)
			{
				l *= 2;
				lightness_direction = 0.0;
			}
			if(l > 0.5)
			{
				l = (1 - l) * 2;
				lightness_direction = 1.0;
			}
			double r1, g1, b1;
			if (segment == 0)
			{
				r = ((1.0 - s) * l + s * 1.0) * (1 - l) + lightness_direction * l;
				g = (PositiveGradient(h) * s + (1.0 - s) * l) * (1 - l) + lightness_direction * l;
				b = ((1.0 - s) * l) * (1 - l) + lightness_direction * l;
			}
			else if (segment == 1)
			{
				r = NegativeGradient(h, s) * l;
				g = l;
				b = (1.0 - s) * l;
			}
			else if (segment == 2)
			{
				r = (1.0 - s) * l;
				g = l;
				b = PositiveGradient(h, s) * l;
			}
			else if (segment == 3)
			{
				r = (1.0 - s) * l;
				g = NegativeGradient(h, s) * l;
				b = l;
			}
			else if (segment == 4)
			{
				r = PositiveGradient(h, s) * l;
				g = (1.0 - s) * l;
				b = l;
			}
			else if (segment == 5)
			{
				r = l;
				g = (1.0 - s) * l;
				b = NegativeGradient(h, s) * l;
			}
			else
			{
				r = -1.0;
				g = -1.0;
				b = -1.0;
			}
		}
		public static void HSLToRGB(double h, double s, double l, out byte r, out byte g, out byte b)
		{
			HSLToRGB(h, s, l, out double r1, out double g1, out double b1);
			r = Convert.ToByte(Math.Round(r1 * 255.0));
			g = Convert.ToByte(Math.Round(g1 * 255.0));
			b = Convert.ToByte(Math.Round(b1 * 255.0));
		}
		private static double PositiveGradient(double h, double s)
		{
			return s / 60.0 * h + (1.0 - s);
		}
		private static double PositiveGradient(double h)
		{
			return 1 / 60.0 * h;
		}
		private static double NegativeGradient(double h, double s)
		{
			return -1.0 * (s / 60.0) * h + 1.0;
		}
	}
}
