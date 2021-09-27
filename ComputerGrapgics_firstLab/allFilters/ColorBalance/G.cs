using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.ColorBalance
{
    class G : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            return Color.FromArgb(
                                   Clamp(sourceColor.R, 0, 255),
                                   Clamp(255, 0, 255),
                                   Clamp((sourceColor.B), 0, 255)
                                   );
        }
    }
}
