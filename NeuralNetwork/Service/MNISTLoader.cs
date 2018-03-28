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

        private List<double[,]> LoadImages()
        {
            imageFileStream.Read(imageBytes, 0, imageBytes.Length);
            List<double[,]> output = new List<double[,]>();

            int images = ByteToInt(imageBytes, 4);
            int rows = ByteToInt(imageBytes, 8);
            int cols = ByteToInt(imageBytes, 12);
            int area = rows * cols;

            for (int imageNum = 0; imageNum < images; imageNum++)
            {
                double[,] image = new double[area, 1];
                for (int px = 0; px < area; px++)
                {
                    image[px, 0] = (imageBytes[16 + (imageNum * area) + px]) / 255.0;
                }
                output.Add(image);
            }

            return output;
        }

        private List<Tuple<double[,], double[,]>> LoadLabels(List<double[,]> images)
        {
            labelFileStream.Read(labelBytes, 0, labelBytes.Length);
            List<Tuple<double[,], double[,]>> output = new List<Tuple<double[,], double[,]>>();

            int labels = ByteToInt(labelBytes, 4);

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
        
        private int ByteToInt(byte[] input, int index)
        {
            byte[] endian = new byte[4];
            Array.Copy(input, index, endian, 0, 4);
            Array.Reverse(endian);
            return BitConverter.ToInt32(endian, 0);
        }

        public static double[,] IntToVector(int number)
        {
            double[,] output = new double[10, 1];

            output[number, 0] = 1;

            return output;
        }
    }
}
