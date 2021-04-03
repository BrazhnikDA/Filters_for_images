using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class GreyWorld : Filters
    {
        private int R_;
        private int G_;
        private int B_;
        private int Avg;
        private bool IsCalculated = false;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            if (!IsCalculated)
            {
                List<int> R_G_B_ = Avg_brightness(sourceImage);
                R_ = R_G_B_[0];
                G_ = R_G_B_[1];
                B_ = R_G_B_[2];
                Avg = (R_ + G_ + B_) / 3;
                IsCalculated = true;
                if (R_ == 0) R_++;
                if (G_ == 0) G_++;
                if (B_ == 0) B_++;
            }
            return Color.FromArgb(
                                  Clamp((int)((double)sourceColor.R * (((double)Avg / (double)R_))), 0, 255),
                                  Clamp((int)((double)sourceColor.G * (((double)Avg / (double)G_))), 0, 255),
                                  Clamp((int)((double)sourceColor.B * (((double)Avg) / (double)(B_))), 0, 255));
        }
        public List<int> Avg_brightness(Bitmap sourceImage)
        {
            List<int> R_G_B_ = new List<int>();
            R_ = 0;
            G_ = 0;
            B_ = 0;
            int w = sourceImage.Width;
            int h = sourceImage.Height;
            int N = w * h;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    R_ += sourceImage.GetPixel(i, j).R;
                    G_ += sourceImage.GetPixel(i, j).G;
                    B_ += sourceImage.GetPixel(i, j).B;
                }
            }
            R_ /= N;
            G_ /= N;
            B_ /= N;

            R_G_B_.Add(R_);
            R_G_B_.Add(G_);
            R_G_B_.Add(B_);
            return R_G_B_;
        }
    }
}
