using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace fractals
{
    class Program
    {
        public static void Main()
        {
            Bitmap bmp = new Bitmap(1080, 720);
            Fractal fractal = new Fractal(bmp, 69, 12, 42);
            Bitmap bmp2 = fractal.Image;
            bmp2.Save(Environment.CurrentDirectory.ToString() + "fractal1.jpg");
            Process.Start(Environment.CurrentDirectory.ToString() + "fractal1.jpg");
        }
    }
}