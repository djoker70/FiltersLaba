using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.MathematicalMorphology
{
    class Dilation : MathMorphology
    {
        public Dilation()
        {
            isDilation = true;
            kernel = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } };
        }

        public Dilation(bool[,] newKernel)
        {
            isDilation = true;
            kernel = newKernel;
        }
    }
}
