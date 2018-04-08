using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuralNetwork.Service
{
    class CIFALoader
    {
        private byte[] rawBytes;
        private string[] bins;
        private string test;
        private bool errorState = false;
        public List<Tuple<double[,], double[,]>> Data, TestData;

        public CIFALoader(string bin1, string bin2, string bin3, string bin4, string bin5, string test)
        {
            this.bins = new string[5];
            this.bins[0] = bin1;
            this.bins[1] = bin2;
            this.bins[2] = bin3;
            this.bins[3] = bin4;
            this.bins[4] = bin5;
            this.test = test;

            Data = new List<Tuple<double[,], double[,]>>();
        }

        // Returns whether the load function succeeded
        public bool Load()
        {
            if (!errorState)
            {
                foreach (string bin in bins)
                {
                    try
                    {
                        FileStream imageFileStream = new FileStream(bin, FileMode.Open);
                        rawBytes = new byte[imageFileStream.Length];
                        Data.AddRange(LoadCIFA(imageFileStream));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        errorState = true;
                        break;
                    }
                }
                if (!errorState)
                {
                    try
                    {
                        FileStream imageFileStream = new FileStream(test, FileMode.Open);
                        rawBytes = new byte[imageFileStream.Length];
                        TestData = LoadCIFA(imageFileStream);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        errorState = true;
                    }
                }
            }

            return errorState;
        }

        private List<Tuple<double[,], double[,]>> LoadCIFA(FileStream imageFileStream)
        {
            imageFileStream.Read(rawBytes, 0, rawBytes.Length);
            List<Tuple<double[,], double[,]>> output = new List<Tuple<double[,], double[,]>>();

            for (int image = 0; image < 10000; image++)
            {
                double[,] answer = IntToVector(rawBytes[image * 3073]);
                double[,] imageData = new double[3072, 1];
                for (int i = 0; i < 3072; i++)
                {
                    imageData[i, 0] = rawBytes[(image * 3073) + i + 1] / 255.0;
                }
                Tuple<double[,], double[,]> pair = Tuple.Create(imageData, answer);
                output.Add(pair);
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
