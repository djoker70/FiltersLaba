using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class TransferFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int transferCoefX = 50;
            int widthImage = sourceImage.Width;
            int R = 0;
            int G = 0;
            int B = 0;
            if (widthImage > x+transferCoefX)
            {
                Color sourceColor = sourceImage.GetPixel(x + transferCoefX, y);
                R = sourceColor.R;
                G = sourceColor.G;
                B = sourceColor.B;
            }
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
