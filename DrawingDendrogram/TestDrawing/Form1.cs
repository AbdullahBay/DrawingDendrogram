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
            calismaAlaniYukseklik = this.Height;
            /*Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(pen, 20, 10, 300, 100);
            pen.Dispose();
            formGraphics.Dispose();*/
        }
        int MyMargin = 150;
        int Yukseklik = 100;
        int Genislik = 50;
        int Bosluk = 50;
        int calismaAlaniYukseklik;
        int YukseklikHesapla(int Yukseklik)
        {
            return calismaAlaniYukseklik - Yukseklik - 10;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            Point RefPoint;
            //1
            RefPoint= new Point(MyMargin, YukseklikHesapla(Yukseklik));
            
            Point solUst = RefPoint;
            Point solAlt = PointFromRef(solUst, 0, Yukseklik);
            Point sagUst = PointFromRef(solUst, Genislik, 0);
            Point sagAlt = PointFromRef(solUst, Genislik, Yukseklik);
            Point FramePoint1 = Point.Add(RefPoint, new Size(Genislik/2,0));
            
            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);
            //2
            Yukseklik = 75;
            RefPoint = PointFromRef(sagUst, Bosluk, 25);

            solUst = RefPoint;
            solAlt = PointFromRef(solUst, 0, Yukseklik);
            sagUst = PointFromRef(solUst, Genislik, 0);
            sagAlt = PointFromRef(solUst, Genislik, Yukseklik);
            Point FramePoint2 = Point.Add(RefPoint, new Size(Genislik / 2, 0));

            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);

            Yukseklik = 150;

            solUst = new Point((Size)FramePoint1);
            solUst.Y = YukseklikHesapla(Yukseklik);
            sagUst = new Point((Size)FramePoint2);
            sagUst.Y = YukseklikHesapla(Yukseklik);
            solAlt = FramePoint1;
            sagAlt = FramePoint2;

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
