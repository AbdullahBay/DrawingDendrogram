using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingDendrogram
{
    public class DDendrogram
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
                frame.Draw(e, pen);
            }
        }
        
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(System.Drawing.Color.Blue);
            Pen pen = new Pen(myBrush, 6);
            Draw(e,  pen);
        }
    }
}
