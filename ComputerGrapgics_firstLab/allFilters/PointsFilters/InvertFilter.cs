using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class InvertFilter : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            return Color.FromArgb(
                                  255 - sourceColor.R,
                                  255 - sourceColor.G,
                                  255 - sourceColor.B);
        }
    }
}
