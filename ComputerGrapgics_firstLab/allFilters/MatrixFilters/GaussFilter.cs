using System;

namespace ComputerGraphics_firstLab.allFilters.MatrixFilters
{
    class GaussFilter : MatrixFilter
    {
        public GaussFilter()
        {
            createGaussianKernel(3, 2);
        }

        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm;
                }
            }
        }
    }
}
