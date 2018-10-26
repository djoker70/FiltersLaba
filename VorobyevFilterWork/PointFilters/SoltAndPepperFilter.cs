using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorobyevFilterWork.PointFilters
{
    class SoltAndPepperFilter : Filters
    {
        Random r;
        public SoltAndPepperFilter()
        {
           this.r = new Random();
        }
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int ver = r.Next(0, 100);
            if(ver < 20)
            {
                int ver2 = r.Next(0, 100);
                if(ver2 < 50)
                {
                    return Color.White;
                } else
                {
                    return Color.Black;
                }
            } else
            {
                return sourceImage.GetPixel(x,y);
            }
          
        }
    }
}
