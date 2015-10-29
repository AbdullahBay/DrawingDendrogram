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
        int MyMargin = 50;
        int Yükseklik = 200;
        int Genislik = 50;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point solUst = new Point(MyMargin, MyMargin);
            Point solAlt = new Point(MyMargin, MyMargin + Yükseklik);
            Point sagUst = new Point(MyMargin + Genislik, MyMargin);
            Point sagAlt = new Point(MyMargin + Genislik, MyMargin + Yükseklik);
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush,6);
            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);


            /*e.Graphics.DrawLine(pen, 10, 10, 10, Yükseklik);
            e.Graphics.DrawLine(pen, 10, 10, Genislik, 10);
            e.Graphics.DrawLine(pen, Genislik, 10, Genislik, Yükseklik);*/

        }
    }
}
