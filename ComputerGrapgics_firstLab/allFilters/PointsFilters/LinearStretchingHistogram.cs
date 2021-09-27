using System.Drawing;

namespace ComputerGraphics_firstLab
{
    class LinearStretchingHistogram : Filters
    {
        private int min_i;
        private int max_i;
        private int k;
        private bool IsCalculated = false;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            if (!IsCalculated)
            {
                CalculateK(sourceImage);
                IsCalculated = true;
            }
            int intensity = (int)((sourceColor.R - min_i) / (double)k * 255);

            return Color.FromArgb(intensity, intensity, intensity);
        }

        public void CalculateK(Bitmap sourceImage)
        {
            min_i = sourceImage.GetPixel(0, 0).R;
            max_i = sourceImage.GetPixel(0, 0).R;
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    if (sourceImage.GetPixel(x, y).R < min_i)
                    {
                        min_i = sourceImage.GetPixel(x, y).R;
                    }
                    if (sourceImage.GetPixel(x, y).R > max_i)
                    {
                        max_i = sourceImage.GetPixel(x, y).R;
                    }
                }
            }
            k = max_i - min_i;
        }
    }
}
