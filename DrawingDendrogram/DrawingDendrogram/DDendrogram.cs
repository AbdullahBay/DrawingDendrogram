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
        List<DFrame> ScaledFrames;
        Panel panel;
        Pen Pen;
        Brush Brush;
        int LineWidth;
        public void Customize (Color lineColor )
        {
            Brush = new SolidBrush(lineColor);
            Pen = new Pen(Brush,LineWidth );
        }
        int PanelHeight, PanelWidth , DrawHeight, DrawWidth;
        public DDendrogram(Panel gelenPanel)
        {
            LineWidth = 1;
            Frames = new List<DFrame>();
            ScaledFrames = new List<DFrame>();
            panel = gelenPanel;
            DrawHeight = panel.Height - LineWidth / 2;
            PanelHeight = panel.Height;
            DrawWidth = panel.Width - LineWidth;
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
            topLeft.Y = height;
            topRihgt = new Point((Size)bottomrightPoint);
            topRihgt.Y = height;
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
            return new Point(X, 0);//YukseklikHesapla(0));
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
            WidthScale = DrawWidth / (float)DendrogramWidth;
            HeightScale = DrawHeight / (float)DendrogramHeigh;
            foreach (var frame in Frames)
            {
                ScaledFrames.Add(new DFrame()
                {
                    BottomLeftPoint = new Point( (int)(frame.BottomLeftPoint.X*WidthScale), YukseklikHesapla( (int)(frame.BottomLeftPoint.Y * HeightScale) ) ),
                    BottomRightPoint = new Point((int)(frame.BottomRightPoint.X * WidthScale), YukseklikHesapla((int)(frame.BottomRightPoint.Y * HeightScale))),
                    Height = frame.Height*HeightScale,
                    TopLeftPoint = new Point((int)(frame.TopLeftPoint.X * WidthScale), YukseklikHesapla((int)(frame.TopLeftPoint.Y * HeightScale))),
                    TopRightPoint = new Point((int)(frame.TopRightPoint.X * WidthScale), YukseklikHesapla((int)(frame.TopRightPoint.Y * HeightScale)))
                });
            }
        }
        void Draw(PaintEventArgs e, Pen pen)
        {
            foreach (var frame in ScaledFrames)
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
