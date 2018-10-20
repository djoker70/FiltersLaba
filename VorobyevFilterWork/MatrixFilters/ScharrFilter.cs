using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VorobyevFilterWork
{
    class ScharrFilter : MatrixFilter
    {
        public ScharrFilter()
        {

        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int widthImage = sourceImage.Width;
            int heightImage = sourceImage.Height;
            double sumX, sumY;
            int SUM = 0;
            int[,] kernelX = new int[3, 3] { { 3, 0, -3 }, { 10, 0, -10 }, { 3, 0, -3 } };
            int[,] kernelY = new int[3, 3] { { 3, 10, 3 }, { 0, 0, 0 }, { -3, -10, -3 } };

            int lengthKernel = kernelX.Rank;
            int radiusKernel = (int)(lengthKernel / 2);
            sumX = 0;
            sumY = 0;
            if (y == 0 || y == heightImage)
                SUM = 0;
            else if (x == 0 || x == widthImage)
                SUM = 0;
            else
            {
                for (int i = -radiusKernel; i <= radiusKernel; i++)
                {
                    for (int j = -radiusKernel; j <= radiusKernel; j++)
                    {
                        int piX = Clamp(j + x, 0, widthImage - radiusKernel);
                        int piY = Clamp(i + y, 0, heightImage - radiusKernel);
                        Color sourceImagePixel = sourceImage.GetPixel(piX, piY);
                        int R = sourceImagePixel.R;
                        int G = sourceImagePixel.G;
                        int B = sourceImagePixel.B;
                        double gradient = ((R + G + B) / 3);
                        sumX = sumX + (gradient * kernelX[j + 1, i + 1]);
                        sumY = sumY + (gradient * kernelY[j + 1, i + 1]);
                    }
                }
                SUM = Clamp((int)(Math.Sqrt(sumX * sumX + sumY * sumY)), 0, 255);
            }
            Color newPixCol = Color.FromArgb(SUM, SUM, SUM);
            return newPixCol;
        }
    }
}
