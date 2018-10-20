using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class WaveTwoFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int widthImage = sourceImage.Width;
            int heightImage = sourceImage.Height;

            int R = 0;
            int G = 0;
            int B = 0;

            int k = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
            int l = y;

            if ((k > 0) && (k < widthImage))
            {
                if ((l > 0) && (l < heightImage))
                {
                    Color sourceColor = sourceImage.GetPixel(k, l);
                    R = sourceColor.R;
                    G = sourceColor.G;
                    B = sourceColor.B;
                }
            }

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
