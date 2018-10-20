using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork
{
    class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter()
        {
           kernel = new float[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        }
    }
}
