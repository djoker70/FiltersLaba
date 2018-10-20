using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VorobyevFilterWork
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            double k = 40;
            int R = Clamp(((int)(intensity + 2 * k)),0,255);
            int G = Clamp(((int)(intensity + 0.5 * k)), 0, 255);
            int B = Clamp(((int)(intensity - k)), 0, 255);
            Color resultColor = Color.FromArgb(R,G,B);
            return resultColor;
        }
    }
}
