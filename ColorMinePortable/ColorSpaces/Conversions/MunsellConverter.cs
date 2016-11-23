using ColorMine.ColorSpaces.Conversions.Utility;
using System;
using System.Linq;

namespace ColorMine.ColorSpaces.Conversions
{
    internal static class MunsellConverter
    {
        internal static readonly MunsellTable Table;

        static MunsellConverter()
        {
            Table = new MunsellTable();
        }

        internal static void ToColorSpace(IRgb color, IMunsell item)
        {
            if ((int)Math.Round(color.R, 0) == (int)Math.Round(color.G, 0) && (int)Math.Round(color.G, 0) == (int)Math.Round(color.B, 0)) {
                var lab = color.To<Lab>();
                item.H = new MunsellHue { Base = HueBase.N };
                item.V = Math.Round(ConvertLtoV(lab.L), 1);
                return;
            }

            var lch = color.To<Lch>();

            var q = Table.Select(x => new {
                diff = Math.Abs(x.Lch.L - lch.L) + Math.Abs(x.Lch.C - lch.C) + Math.Abs(x.Lch.H - lch.H),
                self = x
            });
            var min = q.Min(x => x.diff);
            var munsell = q.Where(x => Math.Abs(x.diff - min) < float.Epsilon).FirstOrDefault().self;

            if (min < 3.0d) {
                item.H = munsell.H;
                item.V = munsell.V;
                item.C = munsell.C;
                return;
            }

            var hue = new MunsellHue { Base = munsell.H.Base, Number = munsell.H.Number };
            MunsellHue newHue;
            if (munsell.Lch.H > lch.H) {
                hue.Number -= 2.5d;
                newHue = new MunsellHue { Base = hue.Base, Number = hue.Number };
            }
            else {
                hue.Number += 2.5d;
                newHue = new MunsellHue { Base = munsell.H.Base, Number = munsell.H.Number };
            }
            var munsellX = FindMunsell(hue, munsell.V, munsell.C, true);

            newHue.Number += Math.Round((lch.H - Math.Min(munsell.Lch.H, munsellX.Lch.H))
                / Math.Abs(munsell.Lch.H - munsellX.Lch.H) * 2.5d, 1, MidpointRounding.AwayFromZero);


            double newChroma;
            //彩度max min
            var c = Table.Where(x => x.H == munsell.H && Math.Abs(x.V - munsell.V) < float.Epsilon)
                .GroupBy(x => x.V).Select(x => new { min = x.Min(y => y.C), max = x.Max(y => y.C) }).First();

            if (c.min < munsell.C && munsell.C < c.max) {
                var chroma = munsell.Lch.C > lch.C ? munsell.C - 2.0d : munsell.C + 2.0d;
                var munsellY = FindMunsell(munsell.H, munsell.V, chroma);
                newChroma = Math.Round(Math.Min(munsell.C, munsellY.C) + (lch.C - Math.Min(munsell.Lch.C, munsellY.Lch.C))
                                / Math.Abs(munsell.Lch.C - munsellY.Lch.C) * 2.0d, 1, MidpointRounding.AwayFromZero);
            }
            else {
                newChroma = Math.Round(munsell.C / munsell.Lch.C * lch.C, 1, MidpointRounding.AwayFromZero);
            }

            var newValue = Math.Round(ConvertLtoV(lch.L), 1, MidpointRounding.AwayFromZero);

            item.H = newHue;
            item.C = newChroma;
            item.V = newValue;
        }

        internal static IRgb ToColor(IMunsell item)
        {
            //明度max or minは白黒で返す
            if (item.V <= 0.0d) return new Rgb { R = 0, G = 0, B = 0 };
            if (item.V >= 10.0d) return new Rgb { R = 255, G = 255, B = 255 };
            if (item.H.Base == HueBase.N) {
                return ConvertAchromatic(item);
            }

            //2.5刻み値ジャストならマンセル検索→Lab値変換
            if (System.Linq.Enumerable.Range(1, 4).Select(x => x * 2.5d).Contains(item.H.Number)) {
                return ConvertLch(item, item.H).To<Rgb>();
            }

            //2.5刻み値以外は両隣の色相から補完値を計算
            var lowH = new MunsellHue(Math.Floor(item.H.Number / 2.5d) * 2.5d, item.H.Base);
            var highH = new MunsellHue(Math.Ceiling(item.H.Number / 2.5d) * 2.5d, item.H.Base);
            var rate = (item.H.Number % 2.5d) / 2.5d;    //2.5の間の割合
                                                         //両隣の色相の補完値同士の補完値を求める
            var lch = GetInterpolatedValue(item, ConvertLch(item, lowH), ConvertLch(item, highH), rate);

            return lch.To<Rgb>();

        }

        private static double ConvertVtoL(double v)
        {
            return -0.0421d * Math.Pow(v, 2.0d) + 10.527d * v - 0.1402d;
        }
        private static double ConvertLtoV(double l)
        {
            if (l < 5.0d) {
                return 0.0977d * Math.Pow(l, 0.9988d);
            }
            else {
                return 0.0846d * Math.Pow(l, 1.0342d);
            }
        }

        private static Rgb ConvertAchromatic(IMunsell item)
        {
            var lab = new Lab { L = ConvertVtoL(item.V), A = 0, B = 0 };
            return lab.To<Rgb>();
        }

        private static Lch ConvertLch(IMunsell item, MunsellHue hue)
        {
            //見込み明度
            var tmpV = Math.Round(item.V, MidpointRounding.AwayFromZero);
            if (Math.Abs(tmpV) < float.Epsilon) tmpV = 1.0d;
            if (Math.Abs(tmpV - 10.0) < float.Epsilon) tmpV = 9.0d;
            //彩度max min
            var c = Table.Where(x => x.H == hue && Math.Abs(x.V - tmpV) < float.Epsilon)
                .GroupBy(x => x.V).Select(x => new { min = x.Min(y => y.C), max = x.Max(y => y.C) }).First();

            Lch lch;
            //彩度の範囲内
            if (c.min <= item.C && item.C <= c.max) {
                //2刻みの値ならテーブル値を取得
                if (Enumerable.Range((int)c.min, (int)c.max)
                    .Where(x => x % 2 == 0).Select(x => (double)x).Contains(item.C)) {
                    lch = FindMunsell(hue, tmpV, item.C).Lch;
                }
                //上記以外は両隣の彩度を基準とする
                else {
                    var lowC = Math.Floor(item.C / 2d) * 2d;
                    var highC = Math.Ceiling(item.C / 2d) * 2d;

                    var lowLch = FindMunsell(hue, tmpV, lowC).Lch;
                    var highLch = FindMunsell(hue, tmpV, highC).Lch;
                    //補完値計算
                    lch = GetInterpolatedValue(item, lowLch, highLch);
                }
            }
            //彩度の範囲外
            else {
                var tmpC = item.C > c.max ? c.max : c.min;
                lch = FindMunsell(hue, tmpV, tmpC).Lch;
                //補完値
                lch.C = lch.C / tmpC * item.C;
            }

            lch.L -= ConvertVtoL(tmpV - item.V);
            return lch;
        }

        private static Lch GetInterpolatedValue(IMunsell item, Lch lowlch, Lch highlch, double rate = 0.5d)
        {
            //彩度の調整
            var diffC = Math.Abs(highlch.C - lowlch.C);
            var newMetricC = (item.C % 2.0d) / 2.0d * diffC + Math.Min(lowlch.C, highlch.C);
            //色相の調整
            var diffH = Math.Abs(lowlch.H - highlch.H);
            var newMetricH = Math.Min(lowlch.H, highlch.H) + diffH * rate;

            return new Lch { L = lowlch.L, C = newMetricC, H = newMetricH };
        }

        private static MunsellDat FindMunsell(MunsellHue hue, double value, double chroma, bool retry = false)
        {
            var rec = Table.Where(x => x.H == hue && Math.Abs(x.V - value) < float.Epsilon && Math.Abs(x.C - chroma) < float.Epsilon).FirstOrDefault();

            if (rec != null) {
                return rec.Clone();
            }
            else {
                if (!retry) return null;
                //見つからなかった場合は彩度を下げて再検索
                for (var i = chroma - 2.0; i >= 2.0; i -= 2.0) {
                    var m = Table.Where(x => x.H == hue && Math.Abs(x.V - value) < float.Epsilon && Math.Abs(x.C - i) < float.Epsilon).FirstOrDefault();
                    if (m != null) {
                        return m.Clone();
                    }
                }
                return null;
            }
        }
    }
}
