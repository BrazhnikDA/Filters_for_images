namespace ComputerGraphics_firstLab.allFilters.MatrixFilters
{
    class MotionBlurFilter : MatrixFilter
    {   
        public MotionBlurFilter()
        {
            int sizeX = 9;
            int sizeY = 9;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == j) { kernel[i, j] = 1.0f / (float)(sizeX); }
                    else
                    {
                        kernel[i, j] = 0;
                    }
                }
            }
        }
    }
}
    

