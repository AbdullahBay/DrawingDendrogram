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

        int Bosluk = 50;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            Point RefPoint;
            //1
            RefPoint= new Point(MyMargin, MyMargin);
            
            Point solUst = RefPoint;
            Point solAlt = PointFromRef(solUst, 0, Yükseklik);
            Point sagUst = PointFromRef(solUst, Genislik, 0);
            Point sagAlt = PointFromRef(solUst, Genislik, Yükseklik);
      
            
            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);
            //2
            RefPoint = PointFromRef(sagUst, Bosluk, 0);

            solUst = RefPoint;
            solAlt = PointFromRef(solUst, 0, Yükseklik);
            sagUst = PointFromRef(solUst, Genislik, 0);
            sagAlt = PointFromRef(solUst, Genislik, Yükseklik);

            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);
            //3
            RefPoint = PointFromRef(sagUst, Bosluk, 0);

            solUst = RefPoint;
            solAlt = PointFromRef(solUst, 0, Yükseklik);
            sagUst = PointFromRef(solUst, Genislik, 0);
            sagAlt = PointFromRef(solUst, Genislik, Yükseklik);

            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);
            //4
            RefPoint = PointFromRef(sagUst, Bosluk, 0);

            solUst = RefPoint;
            solAlt = PointFromRef(solUst, 0, Yükseklik);
            sagUst = PointFromRef(solUst, Genislik, 0);
            sagAlt = PointFromRef(solUst, Genislik, Yükseklik);

            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);

        }
        private Point PointFromRef(Point RefPoint, int x,int y)
        {
            Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
            return returnPoint;
        }
    }
}
