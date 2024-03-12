using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fractals
{
    public class DirectoryProvider
    {
        private static string workingDirectory = Environment.CurrentDirectory.ToString();

        public static string GetDirectory(string name)
        {
            string fractalDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @$"\images\{name}.jpg";
            return fractalDirectory;
        }
    }
}
