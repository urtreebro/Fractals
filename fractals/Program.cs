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
            Console.WriteLine("Input the number of fractal:");
            int n = int.Parse(Console.ReadLine());

            Bitmap bmp = new Bitmap(2160, 1440);

            Random rnd = new Random();

            Fractal fractal = new Fractal(bmp, 2, 5, 6, 2);
            Bitmap bmp2 = fractal.Image;

            string workingDirectory = Environment.CurrentDirectory.ToString();
            string fractalDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @$"\fractal{n}.jpg";

            bmp2.Save(fractalDirectory);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(fractalDirectory) { UseShellExecute = true };
            p.Start();
        }
    }
}