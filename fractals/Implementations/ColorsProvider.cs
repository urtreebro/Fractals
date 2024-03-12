using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals
{
    public class ColorsProvider
    {
        public static int R { get; set; }

        public static int B { get; set; }

        public static int G { get; set; }

        public static Color[] Colors => Enumerable.Range(0, 256)
            .Select(c => Color.FromArgb((c & R) * 85 % 256, (c >> G) * 36 % 256, (c >> R & B) * 36 % 256))
            .ToArray();
    }
}
