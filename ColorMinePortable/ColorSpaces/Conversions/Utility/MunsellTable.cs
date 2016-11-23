using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Linq;


namespace ColorMine.ColorSpaces.Conversions.Utility
{

    public class MunsellDat
    {
        public MunsellHue H { get; set; }
        public double V { get; set; }
        public double C { get; set; }
        public Yxy Yxy { get; set; }
        public Lch Lch { get; set; }

        public MunsellDat Clone()
        {
            return new MunsellDat {
                H = H == null ? null : new MunsellHue { Base = H.Base, Number = H.Number },
                V = V,
                C = C,
                Yxy = Yxy == null ? null : new Yxy { Y1 = Yxy.Y1, X = Yxy.X, Y2 = Yxy.Y2 },
                Lch = Lch == null ? null : new Lch { L = Lch.L, C = Lch.C, H = Lch.H }
            };
        }
    }


    public class MunsellTable : IEnumerable<MunsellDat>
    {

        private HashSet<MunsellDat> items;

        public MunsellTable()
        {
            items = new HashSet<MunsellDat>();

            var asm = typeof(MunsellTable).GetTypeInfo().Assembly;
            var resource = asm.GetManifestResourceNames()
                              .FirstOrDefault(x => x.EndsWith("Munsell.csv", StringComparison.CurrentCultureIgnoreCase));
            using (var stream = asm.GetManifestResourceStream(resource)) {
                using (var sr = new StreamReader(stream))
                    while (sr.Peek() >= 0) {
                        var line = sr.ReadLine().Split(',');

                        var dat = new MunsellDat {
                            H = new MunsellHue(Convert.ToDouble(line[0]), (HueBase)Enum.Parse(typeof(HueBase), line[1])),
                            V = Convert.ToDouble(line[2]),
                            C = Convert.ToDouble(line[3]),
                            Yxy = new Yxy { X = Convert.ToDouble(line[4]), Y2 = Convert.ToDouble(line[5]), Y1 = Convert.ToDouble(line[6]) },
                            Lch = new Lch { L = Convert.ToDouble(line[7]), C = Convert.ToDouble(line[8]), H = Convert.ToDouble(line[9]) }
                        };

                        items.Add(dat);
                    }
            }
        }

        public IEnumerator<MunsellDat> GetEnumerator()
        {
            foreach (var m in items) {
                yield return m;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }


}
