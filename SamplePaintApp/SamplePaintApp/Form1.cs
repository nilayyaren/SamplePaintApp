using System;
using System.Drawing;
using System.Windows.Forms;

namespace SamplePaintApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ColorDialog clrBox = new ColorDialog();
        int size = 10;
        bool drawPic;
        int startX,startY;
        private void btnColor_Click(object sender, EventArgs e)
        {
            clrBox.ShowDialog();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Convert.ToInt32(cmbSize.SelectedItem);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panelSketch.Invalidate();
        }

        private void panelSketch_MouseDown(object sender, MouseEventArgs e)
        {
            drawPic = true;
            startX= e.X;
            startY=e.Y;
        }

        private void panelSketch_MouseUp(object sender, MouseEventArgs e)
        {
            drawPic = false;
        }

        private void panelSketch_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && drawPic)
            {
                Graphics graph = panelSketch.CreateGraphics();
                Pen pen = new Pen(clrBox.Color, size);
                Point point1 = new Point(startX, startY);
                Point point2 = new Point(e.X, e.Y);
                graph.DrawLine(pen, point1, point2);
                startX = e.X;
                startY = e.Y;
            }
            else if(e.Button==MouseButtons.Right && drawPic)
            {
                Graphics graph = panelSketch.CreateGraphics();
                Pen pen = new Pen(panelSketch.BackColor, size);
                Point point1 = new Point(startX, startY);
                Point point2 = new Point(e.X, e.Y);
                graph.DrawLine(pen, point1, point2);
                startX = e.X;
                startY = e.Y;
            }
        }
    }
}
