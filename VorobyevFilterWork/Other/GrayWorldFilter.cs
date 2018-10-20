using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.Other
{
    class GrayWorldFilter : Filters
    {
        protected int avg;
        protected int r, g, b;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * avg / r), 0, 255), Clamp((int)(sourceColor.G * avg / g), 0, 255), Clamp((int)(sourceColor.B * avg / b), 0, 255));

            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            r = 0;
            g = 0;
            b = 0;
            avg = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    r += sourceColor.R;
                    g += sourceColor.G;
                    b += sourceColor.B;
                }
            }
            r = (int)(r / (sourceImage.Width * sourceImage.Height));
            g = (int)(g / (sourceImage.Width * sourceImage.Height));
            b = (int)(b / (sourceImage.Width * sourceImage.Height));
            avg = (r + g + b) / 3;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    }
}
