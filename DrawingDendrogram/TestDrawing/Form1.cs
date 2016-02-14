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
        DDendrogram dendrogramim;
        public Form1()
        {
            InitializeComponent();
            
            dendrogramim = new DDendrogram(panel1);

            Point solAlt = dendrogramim.CreateStartPoint(50, 0);
            Point sagAlt = dendrogramim.CreateStartPoint(70, 0);

            Point FramePoint1 = dendrogramim.AddFrame(solAlt, sagAlt, 50);
            dendrogramim.Draw();

            ////2. frame
            //Point FramePoint2 = CerceveCiz(new Point(100, YukseklikHesapla(0)), new Point(120, YukseklikHesapla(0)), 100, e, pen);

            ////3. frame

            //Point FramePoint3 = CerceveCiz(FramePoint1, FramePoint2, 150, e, pen);


            ////Ust. frame
            //solAlt = FramePoint3;
            //sagAlt = new Point(150, YukseklikHesapla(0));
            //Point FramePoint4 = CerceveCiz(solAlt, sagAlt, 200, e, pen);
            //dendrogramim.AddFrame()
            //new DDendrogram(panel2);
        }
     
        //private Point PointFromRef(Point RefPoint, int x,int y)
        //{
        //    Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
        //    return returnPoint;
        //}
        
    }
}
