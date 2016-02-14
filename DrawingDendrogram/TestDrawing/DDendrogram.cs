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
        List<DFrame> Frames;
        Panel panel;
        int calismaAlaniYukseklik;
        public DDendrogram(Panel gelenPanel)
        {
            Frames = new List<DFrame>();
            panel = gelenPanel;
            calismaAlaniYukseklik = panel.Height;
            
        }
        public Point AddFrame(Point bottomleftPoint, Point bottomrightPoint, int height)
        {
            Point topLeft;
            Point topRihgt;
            topLeft = new Point((Size)bottomleftPoint);
            topLeft.Y = YukseklikHesapla(height);
            topRihgt = new Point((Size)bottomrightPoint);
            topRihgt.Y = YukseklikHesapla(height);
            Size ortaNokta = new Size((topRihgt.X - topLeft.X) / 2, 0);
            Frames.Add(new DFrame()
            {
                BottomLeftPoint = bottomleftPoint,
                BottomRightPoint = bottomrightPoint,
                Height = height,
                TopLeftPoint = topLeft,
                TopRightPoint = topRihgt
            });
            return Point.Add(topLeft, ortaNokta);
        }
        public Point CreateStartPoint(int X,int Y)
        {
            return new Point(X, YukseklikHesapla(Y));
        }
        int YukseklikHesapla(int Yukseklik)
        {
            return calismaAlaniYukseklik - Yukseklik;
        }
        public void Draw()
        {
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
        }
        void Draw(PaintEventArgs e, Pen pen)
        {
            foreach (var frame in Frames)
            {
                CerceveCiz(frame, e, pen);
            }
        }
        void CerceveCiz(DFrame frame, PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawLine(pen, frame.TopLeftPoint, frame.BottomLeftPoint);
            e.Graphics.DrawLine(pen, frame.TopRightPoint, frame.BottomRightPoint);
            e.Graphics.DrawLine(pen, frame.TopRightPoint, frame.TopLeftPoint);
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {

            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            Draw( e,  pen);


            //// ders 9 
            ////1. frame
            //Point solAlt = new Point(50, YukseklikHesapla(0));
            //Point sagAlt = new Point(70, YukseklikHesapla(0));

            //Point FramePoint1 = CerceveCiz(solAlt, sagAlt, 50, e, pen);


            ////2. frame
            //Point FramePoint2 = CerceveCiz(new Point(100, YukseklikHesapla(0)), new Point(120, YukseklikHesapla(0)), 100, e, pen);

            ////3. frame

            //Point FramePoint3 = CerceveCiz(FramePoint1, FramePoint2, 150, e, pen);


            ////Ust. frame
            //solAlt = FramePoint3;
            //sagAlt = new Point(150, YukseklikHesapla(0));
            //Point FramePoint4 = CerceveCiz(solAlt, sagAlt, 200, e, pen);

            //// soldan aşşağıya doğru metin yazıyor
            ////string Name = "sdasas";
            ////var g = e.Graphics;
            ////g.DrawString(Name, new Font("Tahoma", 8), Brushes.Black, 0, 0,
            ////new StringFormat(StringFormatFlags.DirectionVertical));


        }
    }
}
