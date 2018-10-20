using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class GlassFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int widthImage = sourceImage.Width;
            int heightImage = sourceImage.Height;
            Random rnd = new Random();
            double random = rnd.NextDouble();
            int R = 0;
            int G = 0;
            int B = 0;

            int k = (int) (x + (random - 0.5) * 10);
            int l = (int) (y + (random - 0.5) * 10);

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
