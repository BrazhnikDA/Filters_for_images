using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComputerGraphics_firstLab
{
    abstract class Filters
    {
        // Для изменения отрисовки пикселя полученного из фильтра
        protected int i_res = -1;
        protected int j_res = -1;
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);


        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            if (sourceImage == null)    
            { 
                MessageBox.Show("Изображение не загружено!", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return sourceImage; 
            }

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for(int i = 0; i < resultImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending) { return null; }

                for (int j = 0; j < resultImage.Height; j++)
                {
                    if (i_res == -1) { resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j)); }
                    else
                    {
                        resultImage.SetPixel(i_res, j_res, calculateNewPixelColor(sourceImage, i, j));
                    }
                }
            }
         return resultImage;
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }


    }
}
