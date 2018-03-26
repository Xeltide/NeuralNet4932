using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuralNetwork.Service
{
    class MNISTLoader
    {
        private FileStream imageFileStream, labelFileStream;
        private byte[] imageBytes, labelBytes;
        private bool errorState = false;
        public List<Tuple<double[,], int>> Data;

        public MNISTLoader(string imageFilePath, string labelFilePath)
        {
            try
            {
                imageFileStream = new FileStream(imageFilePath, FileMode.Open);
                labelFileStream = new FileStream(labelFilePath, FileMode.Open);
                imageBytes = new byte[imageFileStream.Length];
                labelBytes = new byte[labelFileStream.Length];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                errorState = true;
            }
        }

        // Returns whether the load function succeeded
        public bool Load()
        {
            if (!errorState)
            {
                List<double[,]> images = LoadImages();
                Data = LoadLabels(images);
            }

            return errorState;
        }

        private List<double[,]> LoadImages()
        {
            imageFileStream.Read(imageBytes, 0, imageBytes.Length);
            List<double[,]> output = new List<double[,]>();

            int images = BitConverter.ToInt32(imageBytes, 4);
            int rows = BitConverter.ToInt32(imageBytes, 8);
            int cols = BitConverter.ToInt32(imageBytes, 12);
            int area = rows * cols;

            for (int imageNum = 0; imageNum < images; imageNum++)
            {
                double[,] image = new double[1, area];
                for (int px = 0; px < area; px++)
                {
                    image[1, px] = imageBytes[16 + (imageNum * area) + px];
                }
                output.Add(image);
            }

            return output;
        }

        private List<Tuple<double[,], int>> LoadLabels(List<double[,]> images)
        {
            labelFileStream.Read(labelBytes, 0, labelBytes.Length);
            List<Tuple<double[,], int>> output = new List<Tuple<double[,], int>>();

            int labels = BitConverter.ToInt32(labelBytes, 4);

            if (labels == images.Count)
            {
                for (int label = 0; label < labels; label++)
                {
                    Tuple<double[,], int> imageLabel = Tuple.Create<double[,], int>(images[label], (int)labelBytes[8 + label]);
                    output.Add(imageLabel);
                }
            }
            else
            {
                errorState = true;
            }

            return output;
        }
    }
}
