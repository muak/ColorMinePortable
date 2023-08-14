using System;
using System.Drawing;

namespace ColorMine.ColorSpaces;

public static class SystemColorExtension
{
    /// <summary>
    /// Convert System.Drawing.Color to any IColorSpace
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="color"></param>
    /// <returns></returns>
    public static T To<T>(this Color color) where T: IColorSpace, new()
    {
        var rgb = new Rgb {
            R = color.R,
            G = color.G,
            B = color.B
        };

        return rgb.To<T>();
    }

    /// <summary>
    /// Convert any IColorSpace to System.Drawing.Color
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color ToSystemColor(this IColorSpace color)
    {
        var rgb = color.ToRgb();
        return Color.FromArgb(
            (int)Math.Round(rgb.R, 0),
            (int)Math.Round(rgb.G, 0),
            (int)Math.Round(rgb.B, 0)
        );
    }
}

