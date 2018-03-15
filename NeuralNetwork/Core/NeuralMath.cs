using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Core
{
    static class NeuralMath
    {

        public static double[,] Sigmoid(double[,] z)
        {
            double[,] output = new double[z.GetLength(0), z.GetLength(1)];

            for (int i = 0; i < z.GetLength(0); i++)
            {
                output[i, 1] = 1.0 / (1.0 + Math.Pow(Math.E, -z[i, 1]));
            }

            return output;
        }

        public static double[,] AddMatrix(double[,] leftMatrix, double[,] rightMatrix)
        {
            int rows = leftMatrix.GetLength(0);
            int cols = leftMatrix.GetLength(1);
            double[,] output = new double[rows, cols];

            if (rows == rightMatrix.GetLength(0) && cols == rightMatrix.GetLength(1))
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        output[row, col] = leftMatrix[row, col] + rightMatrix[row, col];
                    }
                }
            }

            return output;
        }

        public static double[,] DotMatrix(double[,] leftMatrix, double[,] rightMatrix)
        {
            int rows = leftMatrix.GetLength(0);
            int cols = rightMatrix.GetLength(1);
            int xSize = leftMatrix.GetLength(1) == rightMatrix.GetLength(0) ?
                leftMatrix.GetLength(1) : 0;
            double[,] output = new double[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double sum = 0;
                    for (int cross = 0; cross < xSize; cross++)
                    {
                        sum += leftMatrix[row, cross] * rightMatrix[cross, col];
                    }
                    output[row, col] = sum;
                }
            }

            return output;
        }
    }
}
