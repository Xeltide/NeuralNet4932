﻿using System;
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

            //Service.MNISTLoader loader = new Service.MNISTLoader("train-images.idx3-ubyte", "train-labels.idx1-ubyte");
            //loader.Load();
            //Service.MNISTLoader testLoader = new Service.MNISTLoader("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
            //testLoader.Load();

            //List<int> size = new List<int> { 784, 100, 10 };
            ////Core.NeuralNet network = new Core.NeuralNet(size);


            //network.SGD(loader.Data, 2, 10, 2.0, testLoader.Data);
            //Service.XMLBridge.Save(network, "BrainChild3.xml");
        }

        private void submitButton_Click(object sender, EventArgs e) {
            if (network != null)
            {
                Graphics g = panel1.CreateGraphics();
                g.Clear(Color.AliceBlue);
                g.DrawImage(new Bitmap(drawPanel.image, 28, 28), Point.Empty);
                double[,] expected = Service.MNISTLoader.IntToVector(numberToDraw);
                bool evaluated = network.EvaluateDrawn(Tuple.Create(drawPanel.GetImageData(), expected));

                totalDrawn++;
                if (evaluated)
                {
                    correctDrawn++;
                }
                correctLabel.Text = correctDrawn + " of " + totalDrawn + " Correct";

                numberToDraw = Core.NeuralRandom.Instance.GetRandom();
                numToDrawLabel.Text = numberToDraw.ToString();
            }
            drawPanel.ClearPanel();
        }

        private void loadNetMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML Files (*.xml) | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                network = Service.XMLBridge.Load(dialog.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e) {
            drawPanel.ClearPanel();
        }
    }
}
