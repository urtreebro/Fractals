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
            string name = Console.ReadLine();

            Bitmap bmp = new Bitmap(2400, 1600);

            Random rnd = new Random();

            JuliaFractal fractal = new JuliaFractal(bmp, 1, 1, 1, 1);
            fractal.Draw();

            string workingDirectory = Environment.CurrentDirectory.ToString();
            string fractalDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @$"\images\{name}.jpg";

            fractal.Image.Save(fractalDirectory);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(fractalDirectory) { UseShellExecute = true };
            p.Start();
        }
    }
}