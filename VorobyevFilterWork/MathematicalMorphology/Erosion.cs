using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VorobyevFilterWork.MathematicalMorphology
{
    class Erosion : MathMorphology
    {
        public Erosion()
        {
            isDilation = false;
            kernel = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } };
        }

        public Erosion(bool[,] newKernel)
        {
            isDilation = false;
            kernel = newKernel;
        }
    }
}
