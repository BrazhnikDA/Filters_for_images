using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.ColorBalance
{
    class B : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            return Color.FromArgb(
                                   Clamp((sourceColor.B),0, 255),
                                   Clamp((sourceColor.G), 0, 255),
                                   Clamp(255, 0, 255)
                                   );
        }
    }
}
