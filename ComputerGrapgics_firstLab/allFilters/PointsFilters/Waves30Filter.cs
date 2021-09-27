using System;
using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class Waves30Filter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Пиксели которые мы получим
            double x_r;
            double y_r;

            // Формула
            x_r = x + 20 * Math.Sin((2 * Math.PI * y) / 30);
            y_r = y;

            i_res = Clamp(Convert.ToInt32(x_r), 0, sourceImage.Width - 1);
            j_res = Clamp(Convert.ToInt32(y_r), 0, sourceImage.Height - 1);

            Color sourceColor = sourceImage.GetPixel(i_res, j_res);

            return sourceColor;
        }
    }
}
