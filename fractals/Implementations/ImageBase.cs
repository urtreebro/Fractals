using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace fractals
{
    public abstract class ImageBase
    {
        public Bitmap Image { get; private set; }

        protected int width;

        protected int height;

        protected int zoom;

        public ImageBase(Bitmap image, int r, int g, int b, int zoom = 1)
        {
            Image = image;

            width = image.Width;
            height = image.Height;

            this.zoom = zoom;

            ColorsProvider.R = r; ColorsProvider.G = g; ColorsProvider.B = b;
        }

        public abstract Bitmap Draw();
    }
}
