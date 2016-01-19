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
            calismaAlaniYukseklik = this.panel1.Height;
        }
        int MyMargin = 150;
        int Yukseklik = 100;
        int Genislik = 20;
        int Bosluk = 50;
        int calismaAlaniYukseklik;
        int YukseklikHesapla(int Yukseklik)
        {
            return calismaAlaniYukseklik - Yukseklik ;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private Point PointFromRef(Point RefPoint, int x,int y)
        {
            Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
            return returnPoint;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            // ders 9 
            //1. frame
            Size ortaNokta;
            Yukseklik = 50;
            Point solAlt = new Point(50, YukseklikHesapla(0));
            Point sagAlt = new Point(70, YukseklikHesapla(0));

            Point FramePoint1 =CerceveCiz(solAlt, sagAlt, Yukseklik, e, pen);
            

            //2. frame
            Point FramePoint2 = CerceveCiz(new Point(100, YukseklikHesapla(0)), new Point(120, YukseklikHesapla(0)), 100, e, pen);
            
            //3. frame
            
            Point FramePoint3 = CerceveCiz(FramePoint1, FramePoint2, 150, e, pen);
            

            //Ust. frame
            Yukseklik = 200;
            solAlt = FramePoint3;
            sagAlt = new Point(150, YukseklikHesapla(0));
            Point FramePoint4 = CerceveCiz(solAlt, sagAlt, Yukseklik, e, pen);
            
            // soldan aşşağıya doğru metin yazıyor
            string Name ="sdasas";
            var g = e.Graphics;
            g.DrawString(Name, new Font("Tahoma", 8), Brushes.Black, 0, 0,
            new StringFormat(StringFormatFlags.DirectionVertical));
          

        }
        Point CerceveCiz(Point solAlt, Point sagAlt, int yukseklik , PaintEventArgs e, Pen pen)
        {
            Point solUst;
            Point sagUst;
            solUst = new Point((Size)solAlt);
            solUst.Y = YukseklikHesapla(yukseklik);
            sagUst = new Point((Size)sagAlt);
            sagUst.Y = YukseklikHesapla(yukseklik);
            Size ortaNokta = new Size((sagUst.X - solUst.X) / 2, 0);
            Point FramePoint = Point.Add(solUst, ortaNokta);

            e.Graphics.DrawLine(pen, solUst, solAlt);
            e.Graphics.DrawLine(pen, sagUst, sagAlt);
            e.Graphics.DrawLine(pen, sagUst, solUst);
            return FramePoint;
        }

    }
}
