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
using zadanie_1.Networks;
using zadanie_1.Forms;

namespace zadanie_1
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private Function1D f;
        //private MLPNetwork mlpNetwork;
        //private RbfNetwork rbfNetwork;
        private MLPNetworkForm mlpForm;
        private RBFNetworkForm rbfForm;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.Clear(Color.White);
            pictureBox1.Refresh();

            f = new Function1D(-9, 9, 110, pictureBox1.Width, pictureBox1.Height);
            //f.DrawMesh(pictureBox1, g);
            //f.DrawFunction(pictureBox1,g);

          
            //f.DrawResultAsCurve(pictureBox1, g, mlpNetwork.ReturnResult());
            mlpForm = new MLPNetworkForm(pictureBox1, g, f);
            rbfForm = new RBFNetworkForm(pictureBox1, g, f);
            //rbfNetwork = new RbfNetwork(f);
            //rbfNetwork.TrainNetwork();
            //f.DrawResultAsCurve(pictureBox1, g, rbfNetwork.ReturnResult());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mLPNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mlpForm.IsDisposed)
                mlpForm = new MLPNetworkForm(pictureBox1, g, f);

            mlpForm.StartPosition = FormStartPosition.Manual;
            mlpForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            mlpForm.Show();
        }

        private void rBFNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rbfForm.IsDisposed)
                rbfForm = new RBFNetworkForm(pictureBox1, g, f);

            rbfForm.StartPosition = FormStartPosition.Manual;
            rbfForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            rbfForm.Show();
        }
    }
}
