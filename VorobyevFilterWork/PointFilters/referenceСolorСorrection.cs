using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VorobyevFilterWork.PointFilters
{
    class referenceСolorСorrection : Filters
    {
        Color dstColor = Color.FromArgb(128, 128, 128);
        Color srcColor;

        public referenceСolorСorrection(Color srcColor)
        {
            this.srcColor = srcColor;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color c = sourceImage.GetPixel(x, y);
            
            int resultColorR = Clamp(c.R * dstColor.R / srcColor.R, 0, 255);
            int resultColorG = Clamp(c.G * dstColor.G / srcColor.G, 0, 255);
            int resultColorB = Clamp(c.B * dstColor.B / srcColor.B, 0, 255);

            return Color.FromArgb(resultColorR, resultColorG, resultColorB); 
        }


    }
}
