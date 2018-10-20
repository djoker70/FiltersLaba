using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.MathematicalMorphology
{
    class BlackHat : MathMorphology
    {
        public BlackHat()
        {
            isDilation = true;
            kernel = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } };
        }

        public BlackHat(bool[,] newKernel)
        {
            isDilation = true;
            kernel = newKernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap currImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultResultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            isDilation = true;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    currImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            resultResultImage = dilationImgsOneSize(currImage, sourceImage, worker);

            return resultResultImage;
        }

        public Bitmap dilationImgsOneSize(Bitmap img1, Bitmap img2, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(img2.Width, img2.Height);
            int minWidth = Math.Min(img1.Width, img2.Width);
            int minHeight = Math.Min(img1.Height, img2.Height);
            for (int i = 0; i < img2.Width; i++)
            {
                worker.ReportProgress(Clamp(50 + (int)((float)i / resultImage.Width * 50),0,100));
                for (int j = 0; j < img2.Height;j++)
                {
                    Color pixel1 = img1.GetPixel(i, j);
                    Color pixel2 = img2.GetPixel(i, j);
                    int intensity1 = (int)(0.36 * pixel1.R + 0.53 * pixel1.G + 0.11 * pixel1.B);
                    int intensity2 = (int)(0.36 * pixel2.R + 0.53 * pixel2.G + 0.11 * pixel2.B);
                   
                    if (intensity1 <= intensity2)
                    {
                        Color tmp = Color.FromArgb(0,0,0);
                        resultImage.SetPixel(i, j, tmp);
                    } 
                    if (intensity1 > intensity2)
                    {
                        resultImage.SetPixel(i, j, pixel2);
                    }
                }
            }
            return resultImage;
        }
    }
}
