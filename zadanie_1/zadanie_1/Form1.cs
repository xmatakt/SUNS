using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using zadanie_1.functions;

namespace zadanie_1
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private Function1D f;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.Clear(Color.White);
            pictureBox1.Refresh();

            f = new Function1D(-9,9,10000,pictureBox1.Width,pictureBox1.Height);
            f.DrawMesh(pictureBox1, g);
            f.DrawFunction(pictureBox1,g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
