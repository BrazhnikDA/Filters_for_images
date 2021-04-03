using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class RotateFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Пиксели которые мы получим
            double x_r;
            double y_r;         

            // Центр
            int x0 = sourceImage.Width / 2;
            int y0 = sourceImage.Height / 2;
            // Угол поворота
            int u = 30;

            // Формула

            x_r = x0 + (x - x0) * Math.Cos(u) - (y - y0) * Math.Sin(u);
            y_r = y0 + (x - x0) * Math.Sin(u) + (y - y0) * Math.Cos(u);

            i_res = Clamp(Convert.ToInt32(x_r), 0, sourceImage.Width - 1);
            j_res = Clamp(Convert.ToInt32(y_r), 0, sourceImage.Height - 1);

            Color sourceColor = sourceImage.GetPixel(i_res, j_res);

            return sourceColor;
        }
    }
}
