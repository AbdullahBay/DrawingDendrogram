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
        Pen Pen;
        Brush Brush;
        public void Customize (Color lineColor )
        {
            Brush = new SolidBrush(lineColor);
            Pen = new Pen(Brush, 6);
        }
        int PanelHeight, PanelWidth;
        public DDendrogram(Panel gelenPanel)
        {
            Frames = new List<DFrame>();
            panel = gelenPanel;
            PanelHeight = panel.Height;
            PanelWidth = panel.Width;
            Brush = new SolidBrush(System.Drawing.Color.Blue);
            Pen = new Pen(Brush, 6);
        }
        int DendrogramHeigh = 0;
        public Point AddFrame(Point bottomleftPoint, Point bottomrightPoint, int height)
        {
            if (DendrogramHeigh < height)
            {
                DendrogramHeigh = height;
            }
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
        int LeftX = 0, RightX, DendrogramWidth;
        public Point CreateStartPoint(int X)
        {
            if (X < LeftX)
            {
                LeftX = X;
            }
            else if (X > RightX)
            {
                RightX = X;
            }
            return new Point(X, YukseklikHesapla(0));
        }
        int YukseklikHesapla(int Yukseklik)
        {
            return PanelHeight - Yukseklik;
        }
       
        public void Draw()
        {
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
        }
        float WidthScale, HeightScale;
        public void Scale()
        {
            DendrogramWidth = RightX - LeftX;
            WidthScale = PanelWidth / (float)DendrogramWidth;
            HeightScale = PanelHeight / (float)DendrogramHeigh;
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
            
            Draw(e,  Pen);
        }
    }
}
