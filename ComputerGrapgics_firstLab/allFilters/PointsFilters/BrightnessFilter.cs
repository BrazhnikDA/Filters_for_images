using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);

            return Color.FromArgb(
                                   Clamp((sourceColor.R + k), 0, 255),
                                   Clamp((sourceColor.G + k), 0, 255),
                                   Clamp((sourceColor.B + k), 0, 255)
                                   );
        }
    }
}
