using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NeuralNetwork.GUI
{
    class DrawPanel : Panel
    {
        private float x, y;
        private float lastX, lastY;
        private bool isDrawing = false;
        private Bitmap image;
        public double[,] Image {
            get {
                Bitmap scaled = new Bitmap(image, 28, 28);
                double[,] output = new double[784, 1];
                for (int row = 0; row < scaled.Height; row++)
                {
                    for (int col = 0; col < scaled.Width; col++)
                    {
                        double r = scaled.GetPixel(col, row).A;
                        output[col + (row * scaled.Width), 0] = scaled.GetPixel(col, row).A / 255.0;
                    }
                }

                return output;
            }
        }

        public DrawPanel()
        {
            MouseDown += new MouseEventHandler(DrawStart);
            MouseMove += new MouseEventHandler(DrawMove);
            MouseUp += new MouseEventHandler(DrawEnd);
            Resize += new EventHandler(ResizePanel);
        }

        private void ResizePanel(object sender, EventArgs e)
        {
            image = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        private void DrawStart(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            lastX = x;
            lastY = y;
            isDrawing = true;
        }

        private void DrawMove(object sender, MouseEventArgs e)
        {
            lastX = x;
            lastY = y;
            x = e.X;
            y = e.Y;

            if (isDrawing)
            {
                Graphics g = Graphics.FromImage(image);
                Pen p = new Pen(Color.Black, 5);
                g.DrawLine(p, lastX, lastY, x, y);

                Graphics g_panel = CreateGraphics();
                g_panel.DrawImage(image, Point.Empty);
            }
        }

        private void DrawEnd(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        public void ClearPanel()
        {
            //image = new Bitmap(image, 28, 28);
            image = new Bitmap(ClientSize.Width, ClientSize.Height);

            Graphics g = CreateGraphics();
            g.DrawImage(image, Point.Empty);
            Invalidate();
        }
    }
}
