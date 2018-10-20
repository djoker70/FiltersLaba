using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.Other
{
    class MedianFilter : Filters
    {
        protected int avg;
        protected int[] avg_r;
        protected const int size = 9;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            avg_r = new int[size];
            int k = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    Color currColor = sourceImage.GetPixel(Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    avg_r[k++] = (int)((currColor.R + currColor.G + currColor.B) / 3);
                }
            Color sourceColor = sourceImage.GetPixel(x, y);
            avg = sort_res();
            Color resultColor = Color.FromArgb(Clamp(avg, 0, 255), Clamp(avg, 0, 255), Clamp(avg, 0, 255));

            return resultColor;
        }

        protected int sort_res()
        {
            for (int i = 0; i < size - 1; i++)
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (avg_r[j] > avg_r[j + 1])
                    {
                        int c = 0;
                        c = avg_r[j];
                        avg_r[j] = avg_r[j + 1];
                        avg_r[j + 1] = c;
                    }
                }

            return avg_r[(int)(size / 2) - 1];
        }
    }
}
