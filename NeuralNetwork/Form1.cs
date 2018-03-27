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
        public Form1()
        {
            InitializeComponent();
            Service.MNISTLoader loader = new Service.MNISTLoader("train-images.idx3-ubyte", "train-labels.idx1-ubyte");
            loader.Load();
            Service.MNISTLoader testLoader = new Service.MNISTLoader("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
            testLoader.Load();

            List<int> size = new List<int> { 784, 30, 10 };
            Core.NeuralNet network = new Core.NeuralNet(size);
            network.SGD(loader.Data, 30, 10, 0.075, testLoader.Data);
        }
    }
}
