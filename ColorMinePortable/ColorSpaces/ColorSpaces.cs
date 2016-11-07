








//Note: This is a generated file.
using ColorMine.ColorSpaces.Conversions;

namespace ColorMine.ColorSpaces
{

	public interface IRgb : IColorSpace
    {

		double R { get; set; }

		double G { get; set; }

		double B { get; set; }

    }

    public class Rgb : ColorSpace, IRgb
    {

		public double R { get; set; }

		public double G { get; set; }

		public double B { get; set; }


        public override void Initialize(IRgb color)
        {
            RgbConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return RgbConverter.ToColor(this);
        }
    }


	public interface IXyz : IColorSpace
    {

		double X { get; set; }

		double Y { get; set; }

		double Z { get; set; }

    }

    public class Xyz : ColorSpace, IXyz
    {

		public double X { get; set; }

		public double Y { get; set; }

		public double Z { get; set; }


        public override void Initialize(IRgb color)
        {
            XyzConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return XyzConverter.ToColor(this);
        }
    }


	public interface IHsl : IColorSpace
    {

		double H { get; set; }

		double S { get; set; }

		double L { get; set; }

    }

    public class Hsl : ColorSpace, IHsl
    {

		public double H { get; set; }

		public double S { get; set; }

		public double L { get; set; }


        public override void Initialize(IRgb color)
        {
            HslConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return HslConverter.ToColor(this);
        }
    }


	public interface ILab : IColorSpace
    {

		double L { get; set; }

		double A { get; set; }

		double B { get; set; }

    }

    public class Lab : ColorSpace, ILab
    {

		public double L { get; set; }

		public double A { get; set; }

		public double B { get; set; }


        public override void Initialize(IRgb color)
        {
            LabConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return LabConverter.ToColor(this);
        }
    }


	public interface ILch : IColorSpace
    {

		double L { get; set; }

		double C { get; set; }

		double H { get; set; }

    }

    public class Lch : ColorSpace, ILch
    {

		public double L { get; set; }

		public double C { get; set; }

		public double H { get; set; }


        public override void Initialize(IRgb color)
        {
            LchConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return LchConverter.ToColor(this);
        }
    }


	public interface ILuv : IColorSpace
    {

		double L { get; set; }

		double U { get; set; }

		double V { get; set; }

    }

    public class Luv : ColorSpace, ILuv
    {

		public double L { get; set; }

		public double U { get; set; }

		public double V { get; set; }


        public override void Initialize(IRgb color)
        {
            LuvConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return LuvConverter.ToColor(this);
        }
    }


	public interface IYxy : IColorSpace
    {

		double Y1 { get; set; }

		double X { get; set; }

		double Y2 { get; set; }

    }

    public class Yxy : ColorSpace, IYxy
    {

		public double Y1 { get; set; }

		public double X { get; set; }

		public double Y2 { get; set; }


        public override void Initialize(IRgb color)
        {
            YxyConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return YxyConverter.ToColor(this);
        }
    }


	public interface ICmy : IColorSpace
    {

		double C { get; set; }

		double M { get; set; }

		double Y { get; set; }

    }

    public class Cmy : ColorSpace, ICmy
    {

		public double C { get; set; }

		public double M { get; set; }

		public double Y { get; set; }


        public override void Initialize(IRgb color)
        {
            CmyConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return CmyConverter.ToColor(this);
        }
    }


	public interface ICmyk : IColorSpace
    {

		double C { get; set; }

		double M { get; set; }

		double Y { get; set; }

		double K { get; set; }

    }

    public class Cmyk : ColorSpace, ICmyk
    {

		public double C { get; set; }

		public double M { get; set; }

		public double Y { get; set; }

		public double K { get; set; }


        public override void Initialize(IRgb color)
        {
            CmykConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return CmykConverter.ToColor(this);
        }
    }


	public interface IHsv : IColorSpace
    {

		double H { get; set; }

		double S { get; set; }

		double V { get; set; }

    }

    public class Hsv : ColorSpace, IHsv
    {

		public double H { get; set; }

		public double S { get; set; }

		public double V { get; set; }


        public override void Initialize(IRgb color)
        {
            HsvConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return HsvConverter.ToColor(this);
        }
    }


	public interface IHsb : IColorSpace
    {

		double H { get; set; }

		double S { get; set; }

		double B { get; set; }

    }

    public class Hsb : ColorSpace, IHsb
    {

		public double H { get; set; }

		public double S { get; set; }

		public double B { get; set; }


        public override void Initialize(IRgb color)
        {
            HsbConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return HsbConverter.ToColor(this);
        }
    }


	public interface IHunterLab : IColorSpace
    {

		double L { get; set; }

		double A { get; set; }

		double B { get; set; }

    }

    public class HunterLab : ColorSpace, IHunterLab
    {

		public double L { get; set; }

		public double A { get; set; }

		public double B { get; set; }


        public override void Initialize(IRgb color)
        {
            HunterLabConverter.ToColorSpace(color,this);
        }

        public override IRgb ToRgb()
        {
            return HunterLabConverter.ToColor(this);
        }
    }


}