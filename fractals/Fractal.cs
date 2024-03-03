using System;
using System.Drawing;
using System.IO;


namespace fractals
{
    public class Fractal
    {
        public Bitmap Image {  get; set; }

        int width;

        int height;

        const double CReal = -0.71;

        const double CImaginary = 0.25015;
        public static Color[] Colors => Enumerable.Range(0, 256)
            .Select(c => Color.FromArgb((c & 3) * 85 % 256, (c >> 7) * 36 % 256, (c >> 3 & 5) * 36 % 256))
            .ToArray();

        public Fractal(Bitmap image)
        {
            this.Image = image;
            width = image.Width;
            height = image.Height;
            Draw(Image);
        }

        public Bitmap Draw(Bitmap bmp)
        {
            double zoom = 1;
            int iter;
            double zX;
            double zY;
            double temp;
            int[,] lst = new int[width,height];

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

                    lst[x, y] = iter;
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = Colors[lst[x,y]];
                    bmp.SetPixel(x, y, color);
                }
            }

            return bmp;
        }
    }
}
