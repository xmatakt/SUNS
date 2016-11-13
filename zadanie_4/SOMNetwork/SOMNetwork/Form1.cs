#region Zdroje
//  http://stackoverflow.com/questions/13631673/how-do-i-make-a-u-matrix
//  http://users.ics.aalto.fi/jhollmen/dippa/node9.html
//  Programming Neural Networks with Encog3 in C# (Jeff Heaton)
//  Source kode from: encog-dotnet-more-examples - SOMColors example
#endregion

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

using SOMnetwork.Classes;

namespace SOMnetwork
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        KohonensMap som;
        Color color = Color.FromName("Control");
        private const int W = 10;
        private const int H = 10;
        double[] arr = new double[W * H];

        public Form1()
        {
            InitializeComponent();
            gridWidth_numeUpDown.Value = 5;
            gridHeight_numeUpDown.Value = 5;
            iterations_UpDown.Value = 500;
            colorRadio.Checked = true;
            stopContinueBtn.Enabled = false;
            
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.Clear(color);
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //g.Clear(color);
            som.TrainNetwork(g, timer1, (int)frameRate_upDown.Value);
            pictureBox1.Refresh();
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            g.Clear(color);
            pictureBox1.Refresh();
            som = new KohonensMap((int)gridWidth_numeUpDown.Value, (int)gridHeight_numeUpDown.Value,
                (int)iterations_UpDown.Value, (int)groupsCount_UpDown.Value,
                pictureBox1.Width, pictureBox1.Height, colorRadio.Checked);
            if (animationChckBox.Checked)
            {
                stopContinueBtn.Text = "Stop";
                stopContinueBtn.Enabled = true;
                timer1.Enabled = true;
            }
            else
            {
                stopContinueBtn.Enabled = false;
                som.TrainNetwork();
                som.GenerateHexGrid();
                som.VisualizeUMatrix(g);
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if(timer1.Enabled)
                stopContinueBtn.Text = "Stop";
            else
                stopContinueBtn.Text = "Continue";
        }

        private void colorRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
