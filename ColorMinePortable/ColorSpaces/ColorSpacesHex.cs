using System;
using ColorMine.ColorSpaces.Conversions;
using System.Text.RegularExpressions;

namespace ColorMine.ColorSpaces
{
	public interface IHex : IColorSpace
	{
		string R { get; set; }
		string G { get; set; }
		string B { get; set; }

		string Code { get; set; }

	}

	public class Hex : ColorSpace, IHex
	{
		private string _R;
		public string R { get { return _R; } 
			set {
				_R = SetterCheck(value);
			}
		}
		private string _G;
		public string G {
			get { return _G; }
			set {
				_G = SetterCheck(value);
			}
		}
		private string _B;
		public string B {
			get { return _B; }
			set {
				_B = SetterCheck(value);
			}
		}

		private string SetterCheck(string s) {
			var regex = new Regex(@"^[0-9A-Fa-f]{1,2}$");
			if (!regex.IsMatch(s)) {
				throw new FormatException();
			}
			return s;
		}

		public string Code {
			get { return "#" + R + G + B; }
			set {
				SetCode(value);
			}
		}

		private void SetCode(string value) {
			var regex1 = new Regex(@"^#{0,1}([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})$");
			var m = regex1.Match(value);
			if (m.Success) {
				this.R = string.Format("{0}{0}", m.Groups[1].Value);
				this.G = string.Format("{0}{0}", m.Groups[2].Value);
				this.B = string.Format("{0}{0}", m.Groups[3].Value);
				return;
			}

			var regex2 = new Regex(@"^#{0,1}([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})$");
			m = regex2.Match(value);
			if (m.Success) {
				this.R = m.Groups[1].Value;
				this.G = m.Groups[2].Value;
				this.B = m.Groups[3].Value;
				return;
			}

			throw new FormatException();
		}

		public Hex() { }
		public Hex(string code) {
			SetCode(code);
		}

		public override void Initialize(IRgb color) {
			HexConverter.ToColorSpace(color, this);
		}

		public override IRgb ToRgb() {
			return HexConverter.ToColor(this);
		}
	}
}
