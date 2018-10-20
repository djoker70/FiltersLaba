using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class RotationFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int widthImage = sourceImage.Width;
            int midleX = (int)(widthImage / 2);
            int heightImage = sourceImage.Height;
            int midleY = (int)(heightImage / 2);
            double angleRotation = 0.5;
            int R = 0;
            int G = 0;
            int B = 0;

            int k = (int) ((x - midleX) * Math.Cos(angleRotation) - (y - midleY) * Math.Sin(angleRotation) + midleX);
            int l = (int) ((x - midleX) * Math.Sin(angleRotation) + (y - midleY) * Math.Cos(angleRotation) + midleY);

            if ( (k>0) && (k<widthImage) )
            {
                if((l>0) && (l<heightImage))
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
