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
            new DDendrogram(panel2);
        }
     
        //private Point PointFromRef(Point RefPoint, int x,int y)
        //{
        //    Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
        //    return returnPoint;
        //}
        
    }
}
