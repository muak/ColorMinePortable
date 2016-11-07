using System;
using ColorMine.ColorSpaces.Conversions.Utility;

namespace ColorMine.ColorSpaces.Conversions
{
	internal static class HslConverter
	{
		internal static void ToColorSpace (IRgb color, IHsl item)
		{
			var hsl = ToHsl(color);

			item.H = hsl.Item1;
			item.S = hsl.Item2;
			item.L = hsl.Item3;
		}

		private static Tuple<double, double, double> ToHsl(IRgb color)
		{
			color.R = Math.Round(color.R,0);
			color.G = Math.Round(color.G,0);
			color.B = Math.Round(color.B,0);
			var max = Max(color.R, Max(color.G, color.B));
			var min = Min(color.R, Min(color.G, color.B));

			double h, s, l;

			//saturation
			var cnt = (max + min) / 2d;
			if (cnt <= 127d)
			{
				s = ((max - min) / (max + min));
			}
			else {
				s = ((max - min) / (510d - max - min));
			}

			//lightness
			l = ((max + min) / 2d) / 255d;

			//hue
			if (Math.Abs(max - min) <= float.Epsilon)
			{
				h = 0d;
				s = 0d;
			}
			else
			{
				double diff = max - min;

				if (Math.Abs(max - color.R) <= float.Epsilon)
				{
					h = 60d * (color.G - color.B) / diff;
				}
				else if (Math.Abs(max - color.G) <= float.Epsilon)
				{
					h = 60d * (color.B - color.R) / diff + 120d;
				}
				else
				{
					h = 60d * (color.R - color.G) / diff + 240d;
				}

				if (h < 0d)
				{
					h += 360d;
				}
			}

			return new Tuple<double, double, double>(h, s, l);
		}

		private static double Max(double a, double b)
		{
			return a > b ? a : b;
		}

		private static double Min(double a, double b)
		{
			return a < b ? a : b;
		}

		internal static IRgb ToColor (IHsl item)
		{
			var rangedH = item.H / 360.0;
			var r = 0.0;
			var g = 0.0;
			var b = 0.0;
			var s = item.S ;
			var l = item.L ;

			if (!l.BasicallyEqualTo (0)) {
				if (s.BasicallyEqualTo (0)) {
					r = g = b = l;
				} else {
					var temp2 = (l < 0.5) ? l * (1.0 + s) : l + s - (l * s);
					var temp1 = 2.0 * l - temp2;

					r = GetColorComponent (temp1, temp2, rangedH + 1.0 / 3.0);
					g = GetColorComponent (temp1, temp2, rangedH);
					b = GetColorComponent (temp1, temp2, rangedH - 1.0 / 3.0);
				}
			}
			return new Rgb {
				R = 255.0 * r,
				G = 255.0 * g,
				B = 255.0 * b
			};
		}

		private static double GetColorComponent (double temp1, double temp2, double temp3)
		{
			temp3 = MoveIntoRange (temp3);
			if (temp3 < 1.0 / 6.0) {
				return temp1 + (temp2 - temp1) * 6.0 * temp3;
			}

			if (temp3 < 0.5) {
				return temp2;
			}

			if (temp3 < 2.0 / 3.0) {
				return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
			}

			return temp1;
		}

		private static double MoveIntoRange (double temp3)
		{
			if (temp3 < 0.0) return temp3 + 1.0;
			if (temp3 > 1.0) return temp3 - 1.0;
			return temp3;
		}
	}
}