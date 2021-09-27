using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_firstLab.allFilters.PointsFilters
{
    class GlassFilter : MatrixFilter
    {
        public GlassFilter()
        {
            int sizeX = 5;
            int sizeY = 5;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i < 3)
                    {
                        kernel[i, j] = -1;
                    }
                    else { kernel[i, j] = 1; }
                }
            }
        }
        /*
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Пиксели которые мы получим
            double x_r;
            double y_r;

            Random rand = new Random(); 
            //Получить случайное число (в диапазоне от 0 до 10)

            // Формула
            x_r = x + (rand.NextDouble() - 0.5) * 10;
            y_r = y + (rand.NextDouble() - 0.5) * 10;

            i_res = Clamp(Convert.ToInt32(x_r), 0, sourceImage.Width - 1);
            j_res = Clamp(Convert.ToInt32(y_r), 0, sourceImage.Height - 1);

            Color sourceColor = sourceImage.GetPixel(i_res, j_res);

            return sourceColor;
        }
        */
    }
}
