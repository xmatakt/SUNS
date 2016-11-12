using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using SOMNetwork.Classes;

namespace SOMNetwork
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        private const int W = 10;
        private const int H = 10;
        double[] arr = new double[W * H];

        public Form1()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < W * H; i++)
            {
                arr[i] = r.Next(-100, 100) / 200.0d;
                //Thread.Sleep(10);
            }

            InitializeComponent();
            
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.Clear(Color.White);

            HexGrid grid = new HexGrid();
            grid.GenerateGrid(new PointF(20, 20), W, H, 15, arr, g, pictureBox1);
            grid.DrawGrid(g);

            pictureBox1.Refresh();
        }
    }
}
