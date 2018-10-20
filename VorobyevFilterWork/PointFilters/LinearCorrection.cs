using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.PointFilters
{
    class LinearCorrection : Filters
    {
        int intensityMin = int.MaxValue;
        int intensityMax = 0;
        public LinearCorrection()
        {
            
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap currImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
                    if (intensity>intensityMax)
                        intensityMax = intensity;
                    if (intensity < intensityMin)
                        intensityMin = intensity;
                }
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int resultIntensity = (int)((intensity - intensityMin) * 255 / (intensityMax - intensityMin));
            int koef = (int)(resultIntensity / 3);
            int R = Clamp((sourceColor.R + koef), 0, 255);
            int G = Clamp((sourceColor.G + koef), 0, 255);
            int B = Clamp((sourceColor.B + koef), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
