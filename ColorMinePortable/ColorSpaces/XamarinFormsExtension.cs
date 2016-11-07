using System;
using Xamarin.Forms;

namespace ColorMine.ColorSpaces
{
	public static class XamarinFormsExtension
	{
		/// <summary>
		/// Convert Xamarin.Forms.Color to any IColorSpace
		/// </summary>
		/// <param name="color"></param>
		/// <typeparam name="T">IColorSpace</typeparam>
		public static T To<T> (this Color color) where T:IColorSpace,new(){
			var rgb = new Rgb
			{
				R = color.R * 255,
				G = color.G * 255,
				B = color.B * 255,
			};
			return rgb.To<T>();
		}

		/// <summary>
		/// Convert any IColorSpace to Xamarin.Forms.Color
		/// </summary>
		/// <returns>Xamarin.Forms.Color</returns>
		/// <param name="color"></param>
		public static Color ToXamarinForms (this IColorSpace color) {
			var rgb = color.ToRgb();
			return Color.FromRgb(
				(int)Math.Round(rgb.R,0),
				(int)Math.Round(rgb.G,0),
				(int)Math.Round(rgb.B,0)
			);
		}
	}
}

