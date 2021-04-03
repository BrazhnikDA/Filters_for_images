using System.Drawing;
using System.Collections.Generic;
using System;

namespace ComputerGraphics_firstLab.allFilters.MatrixFilters
{
    class MedianFilter : Filters
    {
        int radius;
        public MedianFilter(int radius_)
        {
            radius = Clamp(radius_,1,4);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x < radius || y < radius) 
            {
                Color sourceColor = sourceImage.GetPixel(x, y);
                return Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B); 
            }

            int cR_, cB_, cG_;      // Выходные цвета
            int k = 1;              // Счётчик для цикла
            int rad = radius;       // 1 = 3*3, 2 = 5*5, 3 = 7*7, 4 = 9*9        
            int size = (2 * rad + 1) * (2 * rad + 1); // Размер матрицы

            int[] cR = new int[size + 1];
            int[] cB = new int[size + 1];
            int[] cG = new int[size + 1];

            for (int i = x - rad; i < x + rad + 1; i++)
            {
                for (int j = y - rad; j < y + rad + 1; j++)
                {
                    if (k < size + 1)
                    {
                        if (i < sourceImage.Width && j < sourceImage.Height)
                        {
                            Color c = sourceImage.GetPixel(i, j);
                            cR[k] = Convert.ToInt32(c.R);
                            cG[k] = Convert.ToInt32(c.G);
                            cB[k] = Convert.ToInt32(c.B);
                            k++;
                        }                       
                    }
                }
            }            

            quicksort(cR, 0, size - 1);
            quicksort(cG, 0, size - 1);
            quicksort(cB, 0, size - 1);

            int center = (size / 2) + 1;    // Центр

            cR_ = cR[center];
            cG_ = cG[center];
            cB_ = cB[center];

            return Color.FromArgb(cR_, cG_, cB_);
        }

        private void quicksort(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = partition(a, p, r);
                quicksort(a, p, q - 1);
                quicksort(a, q + 1, r);
            }
        }

        private int partition(int[] a, int p, int r)
        {
            int x = a[r];
            int i = p - 1;
            int tmp;
            for (int j = p; j < r; j++)
            {

                if (a[j] <= x)
                {
                    i++;
                    tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;

                }
            }
            tmp = a[r];
            a[r] = a[i + 1];
            a[i + 1] = tmp;
            return (i + 1);

        }
    }
}
