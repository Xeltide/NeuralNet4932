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
            //List<int> size = new List<int> { 3, 5, 2 };
            //Core.NeuralNet network = new Core.NeuralNet(size);
            //Service.XMLBridge.Save(network, "XMLTest.xml");
            Core.NeuralNet network = Service.XMLBridge.Load("XMLTest.xml");
        }
    }
}
