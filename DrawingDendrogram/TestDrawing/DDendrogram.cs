using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TestDrawing
{
    class DDendrogram
    {
        Panel panel;
        int calismaAlaniYukseklik;
        public DDendrogram(Panel gelenPanel)
        {
            panel = gelenPanel;
            calismaAlaniYukseklik = panel.Height;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
        }
        
        
        int YukseklikHesapla(int Yukseklik)
        {
            return calismaAlaniYukseklik - Yukseklik;
        }
        Point CerceveCiz(Point solAlt, Point sagAlt, int yukseklik, PaintEventArgs e, Pen pen)
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
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            // ders 9 
            //1. frame
            Point solAlt = new Point(50, YukseklikHesapla(0));
            Point sagAlt = new Point(70, YukseklikHesapla(0));

            Point FramePoint1 = CerceveCiz(solAlt, sagAlt, 50, e, pen);


            //2. frame
            Point FramePoint2 = CerceveCiz(new Point(100, YukseklikHesapla(0)), new Point(120, YukseklikHesapla(0)), 100, e, pen);

            //3. frame

            Point FramePoint3 = CerceveCiz(FramePoint1, FramePoint2, 150, e, pen);


            //Ust. frame
            solAlt = FramePoint3;
            sagAlt = new Point(150, YukseklikHesapla(0));
            Point FramePoint4 = CerceveCiz(solAlt, sagAlt, 200, e, pen);

            // soldan aşşağıya doğru metin yazıyor
            //string Name = "sdasas";
            //var g = e.Graphics;
            //g.DrawString(Name, new Font("Tahoma", 8), Brushes.Black, 0, 0,
            //new StringFormat(StringFormatFlags.DirectionVertical));


        }
    }
}
