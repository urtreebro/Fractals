using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace fractals
{
    class Program
    {
        public static void Main()
        {
            Bitmap bmp = new Bitmap(1080, 720);
            Fractal fractal = new Fractal(bmp);
            Bitmap bmp2 = fractal.Image;
            bmp2.Save("fractal1.jpg");  
        }
    }
}