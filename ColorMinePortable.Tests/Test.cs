using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ColorMine.ColorSpaces;
namespace ColorMine.Tests
{
	[TestFixture]
	public class TempTest
	{
		
		public TempTest()
		{
		}

		[Test]
		public void Temp(){
			var rgb = new Rgb{R=255,G=255,B=255};
			var bbb = rgb.ToXamarinForms();
			var xf = Xamarin.Forms.Color.FromRgb(10,10,10);
			var aaa = xf.To<Rgb>();
		}
	}
}

