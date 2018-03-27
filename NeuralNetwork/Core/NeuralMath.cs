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
                for (int j = 0; j < z.GetLength(1); j++)
                {
                    output[i, j] = 1.0 / (1.0 + Math.Pow(Math.E, -z[i, j]));
                }
            }

            return output;
        }

        public static double[,] SigmoidPrime(double[,] z)
        {
            double[,] output = new double[z.GetLength(0), z.GetLength(1)];

            double[,] sigmoid = Sigmoid(z);
            for (int i = 0; i < z.GetLength(0); i++)
            {
                for (int j = 0; j < z.GetLength(1); j++)
                {
                    output[i, j] = sigmoid[i, j] * (1.0 - sigmoid[i, j]);
                }
            }

            return output;
        }

        public static double[,] CostDerivative(double[,] outputActivations, double[,] y)
        {
            double[,] output = new double[outputActivations.GetLength(0), outputActivations.GetLength(1)];

            for (int i = 0; i < outputActivations.GetLength(0); i++)
            {
                output[i, 0] = outputActivations[i, 0] - y[i, 0];
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

        public static double[,] SubtractMatrix(double[,] leftMatrix, double[,] rightMatrix)
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
                        output[row, col] = leftMatrix[row, col] - rightMatrix[row, col];
                    }
                }
            }

            return output;
        }

        public static double[,] MultiplyMatrix(double[,] leftMatrix, double[,] rightMatrix)
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
                        output[row, col] = leftMatrix[row, col] * rightMatrix[row, col];
                    }
                }
            }

            return output;
        }

        public static double[,] ScaleMatrix(double[,] matrix, double scale)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] output = new double[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    output[row, col] = matrix[row, col] * scale;
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

        public static double[,] Transpose(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] output = new double[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    output[col, row] = matrix[row, col];
                }
            }

            return output;
        }
    }
}
