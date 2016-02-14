using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingDendrogram;

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

            Point solAlt2 = dendrogramim.AddFrame(solAlt, sagAlt, 50);


            Point sagAlt2 = dendrogramim.CreateStartPoint(90, 0);

            Point fp = dendrogramim.AddFrame(solAlt2, sagAlt2, 100);
            dendrogramim.Draw();
        }
     
        //private Point PointFromRef(Point RefPoint, int x,int y)
        //{
        //    Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
        //    return returnPoint;
        //}
        
    }
}
