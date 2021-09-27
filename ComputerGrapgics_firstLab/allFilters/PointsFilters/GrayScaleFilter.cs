using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            return Color.FromArgb(intensity, intensity, intensity);
        }
    }
}
