using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NeuralNetwork.Service
{
    static class XMLBridge
    {

        public static void Save(Core.NeuralNet network, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("NeuralNet");
            doc.AppendChild(root);

            for (int layer = 0; layer < network.GetNumLayers() - 1; layer++)
            {
                XmlNode layerNode = doc.CreateElement("Layer");
                XmlNode weightNode = doc.CreateElement("Weights");
                XmlNode biasNode = doc.CreateElement("Biases");
                layerNode.AppendChild(weightNode);
                layerNode.AppendChild(biasNode);

                Tuple<int, int> dimensions = network.GetWeightDimensions(layer);
                // Generate weight nodes
                for (int row = 0; row < dimensions.Item1; row++)
                {
                    XmlNode weightChild = doc.CreateElement("Row");
                    for (int col = 0; col < dimensions.Item2; col++)
                    {
                        XmlNode rowChild = doc.CreateElement("Col");
                        rowChild.InnerText = "" + network.GetWeights(layer)[row, col];
                        weightChild.AppendChild(rowChild);
                    }
                    weightNode.AppendChild(weightChild);
                }
                // Generate bias nodes
                int biasRows = network.GetBiases(layer).GetLength(0);
                for (int row = 0; row < biasRows; row++)
                {
                    XmlNode biasChild = doc.CreateElement("Row");
                    biasChild.InnerText = "" + network.GetBiases(layer)[row, 0];
                    biasNode.AppendChild(biasChild);
                }
                root.AppendChild(layerNode);
            }

            doc.Save(filePath);
        }

        public static Core.NeuralNet Load(string filePath)
        {
            List<double[,]> weights = new List<double[,]>();
            List<double[,]> biases = new List<double[,]>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode root = doc.FirstChild;
            List<double> tagData = new List<double>();
            foreach (XmlNode layer in root.ChildNodes)
            {
                if (layer.ChildNodes.Count > 0)
                {
                    weights.Add(LoadLayerWeights(layer.ChildNodes[0]));
                    biases.Add(LoadLayerBiases(layer.ChildNodes[1]));
                }
            }

            return new Core.NeuralNet(weights, biases);
        }

        private static double[,] LoadLayerWeights(XmlNode weightTag)
        {
            // Load weight lists
            List<List<double>> layerWeights = new List<List<double>>();
            foreach (XmlNode row in weightTag.ChildNodes)
            {
                List<double> rowWeights = new List<double>();
                foreach (XmlNode col in row.ChildNodes)
                {
                    rowWeights.Add(Double.Parse(col.InnerText));
                }
                layerWeights.Add(rowWeights);
            }

            // Convert to 2D matrix
            double[,] weightMatrix = new double[layerWeights.Count, layerWeights[0].Count];
            for (int row = 0; row < weightMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < weightMatrix.GetLength(1); col++)
                {
                    weightMatrix[row, col] = layerWeights[row][col];
                }
            }

            return weightMatrix;
        }

        private static double[,] LoadLayerBiases(XmlNode biasTag)
        {
            // Load bias list
            List<double> biasWeights = new List<double>();
            foreach (XmlNode row in biasTag.ChildNodes)
            {
                biasWeights.Add(Double.Parse(row.InnerText));
            }

            // Convert to 2D matrix
            double[,] biasMatrix = new double[biasWeights.Count, 1];
            for (int row = 0; row < biasMatrix.GetLength(0); row++)
            {
                biasMatrix[row, 0] = biasWeights[row];
            }

            return biasMatrix;
        }
    }
}
