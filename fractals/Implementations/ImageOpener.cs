using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals
{
    public class ImageOpener
    {
        public static void Open(string imageDirectory)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(imageDirectory) { UseShellExecute = true };
            p.Start();
        }
    }
}
