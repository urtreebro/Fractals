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
            Console.WriteLine("Input name of the fractal:");
            string fractalDirectory = DirectoryProvider.GetDirectory(Console.ReadLine());

            Bitmap bmp = new Bitmap(2400, 1600);

            JuliaFractal fractal = new JuliaFractal(bmp, 42, 228, 69, 2, 300, 25);
            fractal.Draw();

            fractal.Image.Save(fractalDirectory);

            ImageOpener.Open(fractalDirectory);
        }
    }
}