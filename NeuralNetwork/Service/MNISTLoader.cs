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
        public List<Tuple<double[,], double[,]>> Data;

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

        private int ToInt(byte[] input, int index)
        {
            byte[] endian = new byte[4];
            Array.Copy(input, index, endian, 0, 4);
            Array.Reverse(endian);
            return BitConverter.ToInt32(endian, 0);
        }

        private List<double[,]> LoadImages()
        {
            imageFileStream.Read(imageBytes, 0, imageBytes.Length);
            List<double[,]> output = new List<double[,]>();

            int images = ToInt(imageBytes, 4);
            int rows = ToInt(imageBytes, 8);
            int cols = ToInt(imageBytes, 12);
            int area = rows * cols;

            for (int imageNum = 0; imageNum < images; imageNum++)
            {
                double[,] image = new double[1, area];
                for (int px = 0; px < area; px++)
                {
                    image[0, px] = imageBytes[16 + (imageNum * area) + px];
                }
                output.Add(image);
            }

            return output;
        }

        private List<Tuple<double[,], double[,]>> LoadLabels(List<double[,]> images)
        {
            labelFileStream.Read(labelBytes, 0, labelBytes.Length);
            List<Tuple<double[,], double[,]>> output = new List<Tuple<double[,], double[,]>>();

            int labels = ToInt(labelBytes, 4);//BitConverter.ToInt32(labelBytes, 4);

            if (labels == images.Count)
            {
                for (int label = 0; label < labels; label++)
                {
                    Tuple<double[,], double[,]> imageLabel = Tuple.Create<double[,], double[,]>(images[label], IntToVector((int)labelBytes[8 + label]));
                    output.Add(imageLabel);
                }
            }
            else
            {
                errorState = true;
            }

            return output;
        }

        private double[,] IntToVector(int number)
        {
            double[,] output = new double[1, 10];

            output[0, number] = 1;

            return output;
        }
    }
}
