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
            int XKonum =3;
            int Yukseklik = 0;
            int YukseklikArtisi = 50;
            int Bosluk = 30;

            dendrogramim = new DDendrogram(panel1);
            Point solAlt = dendrogramim.CreateStartPoint(XKonum);
            Point sagAlt;
            for (int i = 0; i <50; i++)
            {
                XKonum += Bosluk;
                sagAlt = dendrogramim.CreateStartPoint(XKonum);
                Yukseklik += YukseklikArtisi;
                solAlt = dendrogramim.AddFrame(solAlt, sagAlt, Yukseklik);
            }


            dendrogramim.Scale();
            dendrogramim.Customize(Color.Black);
            dendrogramim.Draw();
        }
     
        //private Point PointFromRef(Point RefPoint, int x,int y)
        //{
        //    Point returnPoint = new Point(RefPoint.X + x, RefPoint.Y + y);
        //    return returnPoint;
        //}
        
    }
}
