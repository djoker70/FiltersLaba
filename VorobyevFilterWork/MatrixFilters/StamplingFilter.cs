using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.MatrixFilters
{
    class StamplingFilter : MatrixFilter
    {
        int[,] kern = { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };
        public StamplingFilter()
        {
            creatKernel();
        }

        public void creatKernel()
        {
            kernel = new float[3, 3];

            float norm = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    kernel[i, j] = (float)kern[i, j];
                    norm += kernel[i, j];
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int r = -radiusX; r <= radiusX; r++)
                {
                    int idX = Clamp(x + r, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[r + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[r + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[r + radiusX, l + radiusY];
                }
            }

            float sum = resultR + resultG + resultB / 3;
            return Color.FromArgb(Clamp((int)sum + 100, 0, 255), Clamp((int)sum + 100, 0, 255), Clamp((int)sum + 100, 0, 255));
        }

    }

}
