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
            //Test1();
            Test2();
        }

        void Test1()
        {
            int XKonum = 0;
            int Yukseklik = 0;
            int YukseklikArtisi = 50;
            int Bosluk = 30;

            dendrogramim = new DDendrogram(panel1);
            Point solAlt = dendrogramim.CreateStartPoint(XKonum);
            Point sagAlt;
            for (int i = 0; i < 10; i++)
            {
                XKonum += Bosluk;
                sagAlt = dendrogramim.CreateStartPoint(XKonum);
                Yukseklik += YukseklikArtisi;
                solAlt = dendrogramim.AddFrame(solAlt, sagAlt, Yukseklik);
            }

            dendrogramim.Customize(Color.Black, 5);
            dendrogramim.Scale();
            dendrogramim.Draw();
        }
        void Test2()
        {
            int XKonum = 150;
            int Yukseklik = 40;
            int YukseklikArtisi = 50;
            int Bosluk = 150;

            dendrogramim = new DDendrogram(panel1);
            Point solAlt = dendrogramim.CreateStartPoint(XKonum);
            Point sagAlt;
            for (int i = 0; i < 10; i++)
            {
                XKonum += Bosluk;
                sagAlt = dendrogramim.CreateStartPoint(XKonum);
                Yukseklik += YukseklikArtisi*i;
                solAlt = dendrogramim.AddFrame(solAlt, sagAlt, Yukseklik);
            }

            dendrogramim.Customize(Color.Black, 9);
            dendrogramim.Scale();
            dendrogramim.Draw();
        }

    }
}
