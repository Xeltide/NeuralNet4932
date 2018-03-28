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
        public Bitmap image;
        private List<Point> points;

        public DrawPanel()
        {
            points = new List<Point>();

            MouseDown += new MouseEventHandler(DrawStart);
            MouseMove += new MouseEventHandler(DrawMove);
            MouseUp += new MouseEventHandler(DrawEnd);
            Resize += new EventHandler(ResizePanel);
            Paint += new PaintEventHandler(PaintPanel);
        }

        private void ResizePanel(object sender, EventArgs e)
        {
            image = new Bitmap(ClientSize.Width, ClientSize.Height);
            Invalidate();
        }

        private void DrawStart(object sender, MouseEventArgs e)
        {
            points.Add(new Point(e.X, e.Y));
            //x = e.X;
            //y = e.Y;
            //lastX = x;
            //lastY = y;
            isDrawing = true;
        }

        private void DrawMove(object sender, MouseEventArgs e)
        {
            
            //lastX = x;
            //lastY = y;
            //x = e.X;
            //y = e.Y;

            if (isDrawing)
            {
                points.Add(new Point(e.X, e.Y));

                Graphics g = Graphics.FromImage(image);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                Pen p = new Pen(Color.Black, 25);
                g.DrawLines(p, points.ToArray());

                PaintPanel();
            }
        }

        private void DrawEnd(object sender, MouseEventArgs e)
        {
            points.Clear();
            isDrawing = false;
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            PaintPanel();
        }

        public void PaintPanel()
        {
            Graphics g_panel = CreateGraphics();
            g_panel.DrawImage(image, Point.Empty);
        }

        public double[,] GetImageData()
        {
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

        public void ClearPanel()
        {
            image = new Bitmap(ClientSize.Width, ClientSize.Height);

            Invalidate();
        }
    }
}
