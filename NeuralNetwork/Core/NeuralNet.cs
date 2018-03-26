using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Core
{
    class NeuralNet
    {

        private int numberLayers;
        private List<int> sizes;
        private List<double[,]> weights, biases;

        // Seeds new NeuralNet
        public NeuralNet(List<int> layerSizes)
        {
            numberLayers = layerSizes.Count;
            sizes = layerSizes;
            weights = new List<double[,]>();
            biases = new List<double[,]>();

            // Generate seed weights
            for (int layer = 0; layer < numberLayers - 1; layer++)
            {
                weights.Add(SeedWeights(sizes[layer + 1], sizes[layer]));
            }

            // Generate seed biases
            for (int layer = 1; layer < numberLayers; layer++)
            {
                biases.Add(SeedBiases(sizes[layer]));
            }
        }

        // Loads NeuralNet
        public NeuralNet(List<double[,]> weights, List<double[,]> biases)
        {
            this.weights = weights;
            this.biases = biases;
            this.numberLayers = weights.Count;

            sizes = new List<int>();
            for (int layer = 0; layer < numberLayers; layer++)
            {
                sizes.Add(weights[layer].GetLength(1));
            }
        }

        private double[,] SeedBiases(int size)
        {
            double[,] output = new double[size, 1];

            for (int bias = 0; bias < size; bias++)
            {
                output[bias, 0] = NeuralRandom.Instance.GetRandom(0, 1);
            }

            return output;
        }

        private double[,] SeedWeights(int inputSize, int outputSize)
        {
            double[,] output = new double[inputSize, outputSize];

            for (int k = 0; k < inputSize; k++)
            {
                for (int j = 0; j < outputSize; j++)
                {
                    output[k, j] = NeuralRandom.Instance.GetRandom(0, 1);
                }
            }

            return output;
        }

        private double[,] FeedForward(double[,] a)
        {
            double[,] output = a;

            for (int layer = 0; layer < numberLayers - 1; layer++)
            {
                double[,] wa = NeuralMath.DotMatrix(weights[layer], output);
                output = NeuralMath.Sigmoid(NeuralMath.AddMatrix(wa, biases[layer]));
            }

            return output;
        }

        private List<Tuple<double[,], double[,]>> BackPropogation(Tuple<double[,], double[,]> batch)
        {
            List<Tuple<double[,], double[,]>> nablas = new List<Tuple<double[,], double[,]>>();
            for (int i = 0; i < numberLayers - 1; i++)
            {
                nablas.Add(Tuple.Create(
                    new double[biases[i].GetLength(0), biases[i].GetLength(1)], new double[weights[i].GetLength(0), weights[i].GetLength(1)]));
            }

            // feed forward
            double[,] activation = batch.Item1;
            List<double[,]> activations = new List<double[,]> { batch.Item1 };
            List<double[,]> zs = new List<double[,]>();

            for (int i = 0; i < numberLayers - 1; i++)
            {
                double[,] z = NeuralMath.AddMatrix(NeuralMath.DotMatrix(weights[i], activation), biases[i]);
                zs.Add(z);
                activation = NeuralMath.Sigmoid(z);
                activations.Add(activation);
            }

            // backward pass
            double[,] delta = NeuralMath.MultiplyMatrix(NeuralMath.CostDerivative(activations[activations.Count - 1], batch.Item2),
                                                    NeuralMath.SigmoidPrime(zs[zs.Count - 1]));
            double[,] nablaB = delta;
            double[,] nablaW = NeuralMath.DotMatrix(delta, NeuralMath.Transpose(activations[activations.Count - 2]));
            nablas[nablas.Count - 1] = Tuple.Create(nablaB, nablaW);

            for (int l = 2; l < numberLayers; l++)
            {
                double[,] z = zs[zs.Count - l];
                double[,] sp = NeuralMath.SigmoidPrime(z);
                delta = NeuralMath.MultiplyMatrix(NeuralMath.DotMatrix(
                                        NeuralMath.Transpose(weights[weights.Count - l + 1]), delta), sp);
                nablaB = delta;
                nablaW = NeuralMath.DotMatrix(delta, NeuralMath.Transpose(activations[activations.Count - l - 1]));
                nablas[nablas.Count - l] = Tuple.Create(nablaB, nablaW);
            }
            return nablas;
        }

        public void SGD(List<Tuple<double[,], double[,]>> trainingData,
            int epochs,
            int miniBatchSize,
            double eta,
            List<Tuple<double[,], double[,]>> testData = null)
        {
            int nTest = 0;
            if (testData != null)
            {
                nTest = testData.Count;
            }
            int n = trainingData.Count;

            for (int epoch = 0; epoch < epochs; epoch++)
            {
                List<Tuple<double[,], double[,]>> shuffled = (List<Tuple<double[,], double[,]>>)NeuralRandom.Instance.Shuffle(trainingData);
                List<List<Tuple<double[,], double[,]>>> miniBatches = SplitBatch(shuffled, miniBatchSize);
                foreach (List<Tuple<double[,], double[,]>> miniBatch in miniBatches)
                {
                    UpdateMiniBatch(miniBatch, eta);
                }
                if (testData != null)
                {
                    Console.WriteLine("Epoch " + epoch + ": " + Evaluate(testData) + " / " + nTest);
                } else
                {
                    Console.WriteLine("Epoch " + epoch + " complete");
                }
            }
        }

        private List<List<Tuple<double[,], double[,]>>> SplitBatch(List<Tuple<double[,], double[,]>> trainingData, int size)
        {
            List<List<Tuple<double[,], double[,]>>> output = new List<List<Tuple<double[,], double[,]>>>();

            for (int batch = 0; batch < trainingData.Count; batch += size)
            {
                List<Tuple<double[,], double[,]>> miniBatch = new List<Tuple<double[,], double[,]>>();
                for (int i = 0; i < size; i++)
                {
                    if (batch + i >= trainingData.Count)
                    {
                        break;
                    }
                    miniBatch.Add(trainingData[batch + i]);
                }
                output.Add(miniBatch);
            }

            return output;
        }

        private void UpdateMiniBatch(List<Tuple<double[,], double[,]>> miniBatch, double eta)
        {
            List<Tuple<double[,], double[,]>> nablas = new List<Tuple<double[,], double[,]>>();
            for (int i = 0; i < numberLayers - 1; i++)
            {
                nablas.Add(Tuple.Create(
                    new double[biases[i].GetLength(0), biases[i].GetLength(1)], new double[weights[i].GetLength(0), weights[i].GetLength(1)]));
            }

            for (int i = 0; i < miniBatch.Count; i++)
            {
                List<Tuple<double[,], double[,]>> deltaNablas = BackPropogation(miniBatch[i]);
                for (int j = 0; j < nablas.Count; j++)
                {
                    double[,] nablaB = NeuralMath.AddMatrix(nablas[j].Item1, deltaNablas[j].Item1);
                    double[,] nablaW = NeuralMath.AddMatrix(nablas[j].Item2, deltaNablas[j].Item2);
                    nablas[j] = Tuple.Create(nablaB, nablaW);
                }
            }

            for (int i = 0; i < numberLayers - 1; i++)
            {
                biases[i] = NeuralMath.SubtractMatrix(biases[i], NeuralMath.ScaleMatrix(nablas[i].Item1, eta / miniBatch.Count));
                weights[i] = NeuralMath.SubtractMatrix(weights[i], NeuralMath.ScaleMatrix(nablas[i].Item2, eta / miniBatch.Count));
            }
        }

        private int Evaluate(List<Tuple<double[,], double[,]>> testData)
        {
            int count = 0;
            for (int i = 0; i < testData.Count; i++)
            {
                double[,] output = FeedForward(testData[i].Item1);

                int maxIndex = 0;
                double maxValue = output[0, 0];
                int expectedIndex = 0;
                for (int row = 1; row < output.GetLength(0); row++)
                {
                    if (output[row, 0] > maxValue)
                    {
                        maxValue = output[row, 0];
                        maxIndex = row;
                    }
                    if ((int)(Math.Round(testData[0].Item2[row, 0], MidpointRounding.AwayFromZero)) == 1)
                    {
                        expectedIndex = i;
                    }
                }

                if (maxIndex == expectedIndex)
                {
                    count++;
                }
            }

            return count;
        }

        public int GetNumLayers()
        {
            return numberLayers;
        }

        public Tuple<int, int> GetWeightDimensions(int layer)
        {
            return Tuple.Create<int, int>(weights[layer].GetLength(0), weights[layer].GetLength(1));
        }

        public double[,] GetWeights(int layer)
        {
            return weights[layer];
        }

        public double[,] GetBiases(int layer)
        {
            return biases[layer];
        }
    }
}
