using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(pen, 20, 10, 300, 100);
            pen.Dispose();
            formGraphics.Dispose();*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush,6);
            e.Graphics.DrawLine(pen, 10, 10, 10, 100);
        }
    }
}
