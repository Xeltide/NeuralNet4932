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

        public void StartNewMNISTNetwork()
        {
            Service.MNISTLoader loader;
            Service.MNISTLoader testLoader;
            LoadMNISTDataset(out loader, out testLoader);
            List<int> size = new List<int> { 784, 30, 10 };
            network = new Core.NeuralNet(size);
            network.SGD(loader.Data, 2, 10, 3.0, testLoader.Data);
        }

        public void StartMNISTNetworkFromFile(string filename)
        {
            Service.MNISTLoader loader;
            Service.MNISTLoader testLoader;
            LoadMNISTDataset(out loader, out testLoader);
            network = Service.XMLBridge.Load(filename);
            network.SGD(loader.Data, 2, 10, 0.5, testLoader.Data);
        }

        public void StartNewCIFARNetwork()
        {
            Service.CIFALoader loader;
            LoadCIFARDataSet(out loader);
            List<int> size = new List<int> { 3072, 20, 7, 5, 10 };
            network = new Core.NeuralNet(size);
            network.SGD(loader.Data, 2, 10, 3.0, loader.TestData);
        }

        public void StartCIFARNetworkFromFile(string filename)
        {
            Service.CIFALoader loader;
            LoadCIFARDataSet(out loader);
            network = Service.XMLBridge.Load(filename);
            network.SGD(loader.Data, 1, 10, 3.0, loader.TestData);
        }

        private void LoadMNISTDataset(out Service.MNISTLoader loader, out Service.MNISTLoader testLoader)
        {
            loader = new Service.MNISTLoader("train-images.idx3-ubyte", "train-labels.idx1-ubyte");
            loader.Load();
            testLoader = new Service.MNISTLoader("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
            testLoader.Load();
        }

        private void LoadCIFARDataSet(out Service.CIFALoader loader)
        {
            loader = new Service.CIFALoader("data_batch_1.bin", "data_batch_2.bin",
                "data_batch_3.bin", "data_batch_4.bin", "data_batch_5.bin", "test_batch.bin");
            loader.Load();
        }

        public Form1()
        {
            InitializeComponent();
            numberToDraw = Core.NeuralRandom.Instance.GetRandom();
            numToDrawLabel.Text = numberToDraw.ToString();

            // ---- Uncomment to train new MNIST network ---- //
            //StartNewMNISTNetwork();
            // ---------------------------------------------- //

            // ---- Uncomment to train MNIST network from file ---- //
            //StartMNISTNetworkFromFile("MNIST.xml");
            // ---------------------------------------------------- //

            // ---- Uncomment to train new CIFAR network ---- //
            //StartNewCIFARNetwork();
            // ---------------------------------------------- //

            // ---- Uncomment to train CIFAR network from file ---- //
            //StartCIFARNetworkFromFile("CIFAR.xml");
            // ---------------------------------------------------- //

            // ---- Uncomment to save network weights/biases to file ---- //
            //Service.XMLBridge.Save(network, "CIFAR.xml");
            // ---------------------------------------------------------- //
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
