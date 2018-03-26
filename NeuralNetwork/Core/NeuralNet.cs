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
                weights.Add(SeedWeights(sizes[layer], sizes[layer + 1]));
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
            double[,] output = new double[1, size];

            for (int bias = 0; bias < size; bias++)
            {
                output[0, bias] = NeuralRandom.Instance.GetRandom(0, 1);
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
                double[,] wa = NeuralMath.DotMatrix(weights[0], output);
                output = NeuralMath.Sigmoid(NeuralMath.AddMatrix(wa, biases[layer]));
            }

            return output;
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

        }

        private int Evaluate(List<Tuple<double[,], double[,]>> testData)
        {
            return 0;
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
