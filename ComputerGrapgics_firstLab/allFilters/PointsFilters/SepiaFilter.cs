using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            return Color.FromArgb(
                                   Clamp((int)(intensity + 2 * k), 0, 255),
                                   Clamp((int)(intensity + 0.5 * k),0,255),
                                   Clamp((int)(intensity - 1 * k),0,255)
                                   );
        }
    }
}
