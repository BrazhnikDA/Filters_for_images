using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ComputerGraphics_firstLab.allFilters.MatrixFilters
{
	class Dilation : MatrixFilter
	{
		public Dilation(int size)
		{
			int mid = size / 2;
			kernel = new float[size, size];
			for (int i = 0; i < size / 2; i++)
			{
				for (int j1 = 0; j1 < mid - i; j1++)
				{
					kernel[i, j1] = 1;
				}
				for (int j2 = mid - i; j2 <= mid + i; j2++)
				{
					kernel[i, j2] = 0;
				}
				for (int j3 = mid + i + 1; j3 < size; j3++)
				{
					kernel[i, j3] = 1;
				}
			}
			for (int i = 0; i < size; i++)
			{
				kernel[size / 2, i] = 0;
			}
			for (int i = size / 2 + 1, counter = 1; i < size; i++, counter++)
			{
				for (int j1 = 0; j1 < i - mid; j1++)
				{
					kernel[i, j1] = 1;
				}

				for (int j2 = i - mid; j2 < size - (i - mid); j2++)
				{
					kernel[i, j2] = 0;
				}

				for (int j3 = size - (i - mid); j3 < size; j3++)
				{
					kernel[i, j3] = 1;
				}
			}
		}
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			int radiusX = kernel.GetLength(0) / 2;
			int radiusY = kernel.GetLength(1) / 2;
			List<byte> R = new List<byte>();
			List<byte> G = new List<byte>();
			List<byte> B = new List<byte>();
			float resultR;
			float resultG;
			float resultB;
			for (int l = -radiusY, c1 = 0; l <= radiusY; l++, c1++)
			{
				for (int k = -radiusX, c2 = 0; k <= radiusX; k++, c2++)
				{
					int idX = Clamp(x + k, 0, sourceImage.Width - 1);
					int idY = Clamp(y + l, 0, sourceImage.Height - 1);

					Color neighborColor = sourceImage.GetPixel(idX, idY);
					if (kernel[k + radiusX, l + radiusY] == 1)
					{
						R.Add(neighborColor.R);
						G.Add(neighborColor.G);
						B.Add(neighborColor.B);
					}
				}

			}
			//R.Sort();
			//G.Sort();
			//B.Sort();
			resultR = R.Max();
			resultG = G.Max();
			resultB = B.Max();
			return Color.FromArgb(
				Clamp((int)resultR, 0, 255),
				Clamp((int)resultG, 0, 255),
				Clamp((int)resultB, 0, 255)
				);
		}
	}
}
