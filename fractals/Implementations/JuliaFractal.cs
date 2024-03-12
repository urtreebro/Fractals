using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fractals
{
    public class JuliaFractal : ImageBase
    { 
        private static ConstantsProvider _constantsProvider = new();

        private int mX;
        private int mY;

        public JuliaFractal(Bitmap image, int r, int g, int b, int zoom = 1, int mX = 0, int mY = 0) : base(image, r, g, b, zoom) 
        { 
            this.mX = mX;
            this.mY = mY;
        }

        public override Bitmap Draw()
        {
            int iter;
            double zX;
            double zY;
            double temp;

            BitmapData data = Image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        iter = 255;

                        zX = 1.5 * (x - width / 2 + mX) / (0.5 * zoom * width);
                        zY = 1.0 * (y - height / 2 + mY) / (0.5 * zoom * height);

                        while (zX * zX + zY * zY < 4 && iter > 1)
                        {
                            temp = zX * zX - zY * zY + _constantsProvider.CReal;
                            zY = 2.0 * zX * zY + _constantsProvider.CImaginary;
                            zX = temp;

                            iter--;
                        }

                        Color color = ColorsProvider.Colors[iter];

                        ptr[(x * 3) + y * stride] = color.B;
                        ptr[(x * 3) + y * stride + 1] = color.G;
                        ptr[(x * 3) + y * stride + 2] = color.R;
                    }
                }
            }
            Image.UnlockBits(data);

            return Image;
        }
    }
}
