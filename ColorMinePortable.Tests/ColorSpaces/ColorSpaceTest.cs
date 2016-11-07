using ColorMine.ColorSpaces;
using System;
using NUnit.Framework;

namespace ColorMine.Tests.ColorSpaces
{
	public abstract class ColorSpaceTest
    {

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, ICmy expectedColor)
		{
			var target = knownColor.To<Cmy>();

			Assert.IsTrue(CloseEnough(expectedColor.C,target.C),"(C)" + expectedColor.C + " != " + target.C);
			Assert.IsTrue(CloseEnough(expectedColor.M,target.M),"(M)" + expectedColor.M + " != " + target.M);
			Assert.IsTrue(CloseEnough(expectedColor.Y,target.Y),"(Y)" + expectedColor.Y + " != " + target.Y);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, ICmyk expectedColor)
		{
			var target = knownColor.To<Cmyk>();

			Assert.IsTrue(CloseEnough(expectedColor.C,target.C),"(C)" + expectedColor.C + " != " + target.C);
			Assert.IsTrue(CloseEnough(expectedColor.M,target.M),"(M)" + expectedColor.M + " != " + target.M);
			Assert.IsTrue(CloseEnough(expectedColor.Y,target.Y),"(Y)" + expectedColor.Y + " != " + target.Y);
			Assert.IsTrue(CloseEnough(expectedColor.K,target.K),"(K)" + expectedColor.K + " != " + target.K);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IHsl expectedColor)
		{
			var target = knownColor.To<Hsl>();

			Assert.IsTrue(CloseEnough(expectedColor.H,target.H),"(H)" + expectedColor.H + " != " + target.H);
			Assert.IsTrue(CloseEnough(expectedColor.S,target.S),"(S)" + expectedColor.S + " != " + target.S);
			Assert.IsTrue(CloseEnough(expectedColor.L,target.L),"(L)" + expectedColor.L + " != " + target.L);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IHsb expectedColor)
		{
			var target = knownColor.To<Hsb>();

			Assert.IsTrue(CloseEnough(expectedColor.H,target.H),"(H)" + expectedColor.H + " != " + target.H);
			Assert.IsTrue(CloseEnough(expectedColor.S,target.S),"(S)" + expectedColor.S + " != " + target.S);
			Assert.IsTrue(CloseEnough(expectedColor.B,target.B),"(B)" + expectedColor.B + " != " + target.B);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, ILab expectedColor)
		{
			var target = knownColor.To<Lab>();

			Assert.IsTrue(CloseEnough(expectedColor.L,target.L),"(L)" + expectedColor.L + " != " + target.L);
			Assert.IsTrue(CloseEnough(expectedColor.A,target.A),"(A)" + expectedColor.A + " != " + target.A);
			Assert.IsTrue(CloseEnough(expectedColor.B,target.B),"(B)" + expectedColor.B + " != " + target.B);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, ILch expectedColor)
		{
			var target = knownColor.To<Lch>();

			Assert.IsTrue(CloseEnough(expectedColor.L,target.L),"(L)" + expectedColor.L + " != " + target.L);
			Assert.IsTrue(CloseEnough(expectedColor.C,target.C),"(C)" + expectedColor.C + " != " + target.C);
			Assert.IsTrue(CloseEnough(expectedColor.H,target.H),"(H)" + expectedColor.H + " != " + target.H);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IRgb expectedColor)
		{
			var target = knownColor.To<Rgb>();

			Assert.IsTrue(CloseEnough(expectedColor.R,target.R),"(R)" + expectedColor.R + " != " + target.R);
			Assert.IsTrue(CloseEnough(expectedColor.G,target.G),"(G)" + expectedColor.G + " != " + target.G);
			Assert.IsTrue(CloseEnough(expectedColor.B,target.B),"(B)" + expectedColor.B + " != " + target.B);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IXyz expectedColor)
		{
			var target = knownColor.To<Xyz>();

			Assert.IsTrue(CloseEnough(expectedColor.X,target.X),"(X)" + expectedColor.X + " != " + target.X);
			Assert.IsTrue(CloseEnough(expectedColor.Y,target.Y),"(Y)" + expectedColor.Y + " != " + target.Y);
			Assert.IsTrue(CloseEnough(expectedColor.Z,target.Z),"(Z)" + expectedColor.Z + " != " + target.Z);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IYxy expectedColor)
		{
			var target = knownColor.To<Yxy>();

			Assert.IsTrue(CloseEnough(expectedColor.Y1,target.Y1),"(Y1)" + expectedColor.Y1 + " != " + target.Y1);
			Assert.IsTrue(CloseEnough(expectedColor.X,target.X),"(X)" + expectedColor.X + " != " + target.X);
			Assert.IsTrue(CloseEnough(expectedColor.Y2,target.Y2),"(Y2)" + expectedColor.Y2 + " != " + target.Y2);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, ILuv expectedColor)
		{
			var target = knownColor.To<Luv>();

			Assert.IsTrue(CloseEnough(expectedColor.L,target.L),"(L)" + expectedColor.L + " != " + target.L);
			Assert.IsTrue(CloseEnough(expectedColor.U,target.U),"(U)" + expectedColor.U + " != " + target.U);
			Assert.IsTrue(CloseEnough(expectedColor.V,target.V),"(V)" + expectedColor.V + " != " + target.V);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IHsv expectedColor)
		{
			var target = knownColor.To<Hsv>();

			Assert.IsTrue(CloseEnough(expectedColor.H,target.H),"(H)" + expectedColor.H + " != " + target.H);
			Assert.IsTrue(CloseEnough(expectedColor.S,target.S),"(S)" + expectedColor.S + " != " + target.S);
			Assert.IsTrue(CloseEnough(expectedColor.V,target.V),"(V)" + expectedColor.V + " != " + target.V);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IHunterLab expectedColor)
		{
			var target = knownColor.To<HunterLab>();

			Assert.IsTrue(CloseEnough(expectedColor.L,target.L),"(L)" + expectedColor.L + " != " + target.L);
			Assert.IsTrue(CloseEnough(expectedColor.A,target.A),"(A)" + expectedColor.A + " != " + target.A);
			Assert.IsTrue(CloseEnough(expectedColor.B,target.B),"(B)" + expectedColor.B + " != " + target.B);
		}

		public static double diff = .01;
		private static bool CloseEnough(double a, double b)
		{
			// Define the tolerance for variation in their values 
			var difference = Math.Abs(a * diff);

			// Compare the values 
			// The output to the console indicates that the two values are equal 
			return Math.Abs(a - b) <= difference;
		}


		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IMunsell expectedColor) {
			var target = knownColor.To<Munsell>();

			Assert.IsTrue(CloseEnough(expectedColor.H, target.H), expectedColor.ToString() + "!=" + target.ToString());
			Assert.IsTrue(CloseEnough(expectedColor.V, target.V, 1.0), "(V)" + expectedColor.V + " != " + target.V);
			Assert.IsTrue(CloseEnough(expectedColor.C, target.C, 2.5), "(C)" + expectedColor.C + " != " + target.C);
		}

		protected static void ExpectedValuesForKnownColor(IColorSpace knownColor, IHex expectedColor) {
			var target = knownColor.To<Hex>();

			Assert.IsTrue(CloseEnough(expectedColor.R, target.R), "(R)" + expectedColor.R + " != " + target.R);
			Assert.IsTrue(CloseEnough(expectedColor.G, target.G), "(G)" + expectedColor.G + " != " + target.G);
			Assert.IsTrue(CloseEnough(expectedColor.B, target.B), "(B)" + expectedColor.B + " != " + target.B);
		}

		private static bool CloseEnough(double a, double b, double diff) {
			// Define the tolerance for variation in their values 
			var difference = diff;

			// Compare the values 
			// The output to the console indicates that the two values are equal 
			return Math.Abs(a - b) <= difference;
		}
		private static bool CloseEnough(MunsellHue a, MunsellHue b) {
			if (a.Base == b.Base) {
				return Math.Abs(a.Number - b.Number) <= 1.5;
			}
			else if ((a.Base == b.Base - 1 || a.Base - 1 == b.Base) ||
			         (a.Base == HueBase.R && b.Base == HueBase.RP) ||
			         (a.Base == HueBase.RP && b.Base == HueBase.R)) {
				return Math.Abs(a.Number % 10 - b.Number % 10) <= 1.5;
			}
			else {
				return false;
			}

		}
		private static bool CloseEnough(string a, string b) {
			return a.ToUpper() == b.ToUpper();
		}


	}

}