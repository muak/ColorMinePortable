using System;
using ColorMine.ColorSpaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
namespace ColorMine.Tests.ColorSpaces
{
	[TestFixture]
	public class XamarinFormsTest
	{
		private double diff = 0.01;
			
		[Test]
		public void WhiteXamarinToRgb()
		{
			var knownColor = Xamarin.Forms.Color.White;
			var expectedColor = new Rgb { R = 255, G = 255, B = 255, };

			var conv = knownColor.To<Rgb>();
			(conv.R - expectedColor.R < diff).IsTrue();
			(conv.G - expectedColor.G < diff).IsTrue();
			(conv.B - expectedColor.B < diff).IsTrue();
		}
		[Test]
		public void GoldenrodXamarinToRgb()
		{
			var knownColor = Xamarin.Forms.Color.FromRgb(218, 165, 32);
			var expectedColor = new Rgb { R = 218, G = 165, B = 32, };

			var conv = knownColor.To<Rgb>();
			(conv.R - expectedColor.R < diff).IsTrue();
			(conv.G - expectedColor.G < diff).IsTrue();
			(conv.B - expectedColor.B < diff).IsTrue();
		}
		[Test]
		public void MaroonXamarinToRgb()
		{
			var knownColor = Xamarin.Forms.Color.Maroon;
			var expectedColor = new Rgb { R = 128, G = 0, B = 0 };

			var conv = knownColor.To<Rgb>();
			(conv.R - expectedColor.R < diff).IsTrue();
			(conv.G - expectedColor.G < diff).IsTrue();
			(conv.B - expectedColor.B < diff).IsTrue();
		}

	}
}
