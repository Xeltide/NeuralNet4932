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
        private bool isDrawing = false;
        public Bitmap image;
        public Bitmap scaledImage;
        private Point lastPos;
        private float xMin, xMax, yMin, yMax;

        public DrawPanel()
        {
            ResetMinMaxDraw();
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

        private void ResetMinMaxDraw()
        {
            xMin = float.MaxValue;
            yMin = float.MaxValue;
            xMax = -1;
            yMax = -1;
        }

        private void SetMinMaxDraw(float x, float y)
        {
            if (x > xMax)
            {
                xMax = x;
            }
            if (x < xMin)
            {
                xMin = x;
            }
            if (y > yMax)
            {
                yMax = y;
            }
            if (y < yMin)
            {
                yMin = y;
            }
        }

        private void DrawStart(object sender, MouseEventArgs e)
        {
            lastPos = e.Location;
            SetMinMaxDraw(e.X, e.Y);
            isDrawing = true;
        }

        private void DrawMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                SetMinMaxDraw(e.X, e.Y);
                Graphics g = Graphics.FromImage(image);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                Pen p = new Pen(Color.Black, 20);
                p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawLine(p, lastPos, e.Location);

                lastPos = e.Location;

                PaintPanel();
            }
        }

        private void DrawEnd(object sender, MouseEventArgs e)
        {
            SetMinMaxDraw(e.X, e.Y);
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
            scaledImage = new Bitmap(28, 28);

            Graphics g = Graphics.FromImage(scaledImage);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            float ratio = 28.0f / ClientSize.Width;
            float scaledW = (xMax - xMin) * ratio;
            float scaledH = (yMax - yMin) * ratio;
            float w = (28 - scaledW) / 2.0f;
            float h = (28 - scaledH) / 2.0f;
            float scaledX = xMin * ratio;
            float scaledY = yMin * ratio;
            float adjustX = scaledX - w;
            float adjustY = scaledY - h;
            g.DrawImage(image, new Rectangle((int)-adjustX, (int)-adjustY, 28, 28));
            
            double[,] output = new double[784, 1];
            for (int row = 0; row < scaledImage.Height; row++)
            {
                for (int col = 0; col < scaledImage.Width; col++)
                {
                    output[col + (row * scaledImage.Width), 0] = scaledImage.GetPixel(col, row).A / 255.0;
                }
            }

            return output;
        }

        public void ClearPanel()
        {
            image = new Bitmap(ClientSize.Width, ClientSize.Height);
            ResetMinMaxDraw();
            Invalidate();
        }
    }
}
