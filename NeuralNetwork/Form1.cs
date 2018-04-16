using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        private Core.NeuralNet network;
        private int numberToDraw;
        private int totalDrawn = 0;
        private int correctDrawn = 0;

        public Form1()
        {
            InitializeComponent();
            numberToDraw = Core.NeuralRandom.Instance.GetRandom();
            numToDrawLabel.Text = numberToDraw.ToString();

            // ---- Uncomment to load MNIST dataset ---- //
            //Service.MNISTLoader loader = new Service.MNISTLoader("train-images.idx3-ubyte", "train-labels.idx1-ubyte");
            //loader.Load();
            //Service.MNISTLoader testLoader = new Service.MNISTLoader("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
            //testLoader.Load();
            // ----------------------------------------- //

            // ---- Uncomment to load CIFAR-10 dataset ---- //
            //Service.CIFALoader loader = new Service.CIFALoader("data_batch_1.bin", "data_batch_2.bin",
            //    "data_batch_3.bin", "data_batch_4.bin", "data_batch_5.bin", "test_batch.bin");
            //loader.Load();
            // -------------------------------------------- //

            // ---- Uncomment and change filename to load weights/biases from file ---- //
            //network = Service.XMLBridge.Load("CIFA.xml");
            // ------------------------------------------------------------------------ //

            // ---- Uncomment to create new network without file for MNIST dataset ---- //
            //List<int> size = new List<int> { 768, 30, 10 };
            //network = new Core.NeuralNet(size);
            // ------------------------------------------------------------------------ //

            // ---- Uncomment to create new network without file for CIFAR-10 dataset ---- //
            //List<int> size = new List<int> { 3072, 20, 7, 5, 10 };
            //network = new Core.NeuralNet(size);
            // --------------------------------------------------------------------------- //

            // ---- Uncomment to start gradient descent for MNIST dataset ---- //
            //network.SGD(loader.Data, 5, 10, 3.0, testLoader.Data);
            // --------------------------------------------------------------- //

            // ---- Uncomment to start gradient descent for CIFAR-10 dataset ---- //
            //network.SGD(loader.Data, 5, 10, 3.0, loader.TestData);
            // ------------------------------------------------------------------ //

            // ---- Uncomment to save weights and biases to file ---- //
            //Service.XMLBridge.Save(network, "CIFA.xml");
            // ------------------------------------------------------ //
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (network != null)
            {
                double[,] expected = Service.MNISTLoader.IntToVector(numberToDraw);
                int guess = 0;
                bool evaluated = network.EvaluateDrawn(Tuple.Create(drawPanel.GetImageData(), expected), out guess);

                Graphics g = panel1.CreateGraphics();
                g.Clear(SystemColors.ControlLightLight);
                g.DrawImage(new Bitmap(drawPanel.scaledImage, 28, 28), Point.Empty);

                totalDrawn++;
                if (evaluated)
                {
                    correctDrawn++;
                }

                prevGuessLabel.Text = "Previous Guess: " + guess;

                correctLabel.Text = correctDrawn + " of " + totalDrawn + " Correct";

                numberToDraw = Core.NeuralRandom.Instance.GetRandom();
                numToDrawLabel.Text = numberToDraw.ToString();
            }
            Focus();
            drawPanel.ClearPanel();
        }

        private void loadNetMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML Files (*.xml) | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                network = Service.XMLBridge.Load(dialog.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            drawPanel.ClearPanel();
        }
    }
}
