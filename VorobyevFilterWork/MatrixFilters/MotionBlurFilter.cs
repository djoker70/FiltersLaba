using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            createMotionBlurKernel(10);
        }
        public void createMotionBlurKernel(int radius)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    if (i == j)
                        kernel[i + radius, j + radius] = (float) (1 / (float)(radius));
                    else
                        kernel[i + radius, j + radius] = 0;
                }
        }
    }
}
