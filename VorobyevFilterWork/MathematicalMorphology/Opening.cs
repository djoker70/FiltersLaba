using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.MathematicalMorphology
{
    class Opening : MathMorphology
    {
        public Opening()
        {
            kernel = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } };
        }
        public Opening(bool[,] newKernel)
        {
            kernel = newKernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap currImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            isDilation = false;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    currImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            isDilation = true;
            for (int i = 0; i < currImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                for (int j = 0; j < currImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(currImage, i, j));
                }
            }
            return resultImage;
        }
    }
}
