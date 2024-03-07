﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals
{
    public class JuliaFractal : FractalBase
    { 
        public static int R { get; set; }

        public static int B { get; set; }

        public static int G { get; set; }

        const double CReal = -0.71;

        const double CImaginary = 0.25015;

        private int iter;

        private double zX;
        private double zY;

        private double temp;

        public static Color[] Colors => Enumerable.Range(0, 256)
            .Select(c => Color.FromArgb((c & R) * 85 % 256, (c >> G) * 36 % 256, (c >> R & B) * 36 % 256))
            .ToArray();

        public JuliaFractal(Bitmap image, int r, int g, int b, int zoom = 1) : base(image, zoom)
        {
            R = r;
            G = g;
            B = b;
        }

        public override Bitmap Draw()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    iter = 256;

                    zX = 1.5 * (x - width / 2) / (0.5 * zoom * width);
                    zY = 1.0 * (y - height / 2) / (0.5 * zoom * height);

                    while (zX * zX + zY * zY < 4 && iter > 1)
                    {
                        temp = zX * zX - zY * zY + CReal;
                        zY = 2.0 * zX * zY + CImaginary;
                        zX = temp;

                        iter--;
                    }

                    Color color = Colors[iter];

                    Image.SetPixel(x, y, color);
                }
            }
            return Image;
        }
    }
}