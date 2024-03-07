using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace fractals
{
    public abstract class FractalBase
    {
        public Bitmap Image { get; set; }

        protected int width;

        protected int height;

        protected int zoom;

        public FractalBase(Bitmap image, int zoom = 1)
        {
            Image = image;

            width = image.Width;
            height = image.Height;

            this.zoom = zoom;
        }

        public abstract Bitmap Draw();
    }
}
