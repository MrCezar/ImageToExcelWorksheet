using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToExcelWorksheet.Entities
{
    public class ImageHandler
    {
        public static Color[,] ConvertImageToMatrixColor(string path)
        {
            var bm = new Bitmap(path);
            var pixelMatrix = new Color[bm.Width, bm.Height];

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    pixelMatrix[x, y] = bm.GetPixel(x, y);
                }
            }

            pixelMatrix = TransposeMatrix(pixelMatrix);

            return pixelMatrix;
        }

        public static T[,] TransposeMatrix<T>(T[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var result = new T[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = matrix[r, c];
                }
            }

            return result;
        }
    }
}
