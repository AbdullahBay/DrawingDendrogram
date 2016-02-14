using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingDendrogram
{
    class DFrame
    {
        public Point BottomLeftPoint;
        public Point BottomRightPoint;
        public Point TopLeftPoint;
        public Point TopRightPoint;
        public float Height;

        public void Draw(PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawLine(pen, TopLeftPoint,  BottomLeftPoint);
            e.Graphics.DrawLine(pen, TopRightPoint, BottomRightPoint);
            e.Graphics.DrawLine(pen, TopRightPoint, TopLeftPoint);
        }
    }
}
