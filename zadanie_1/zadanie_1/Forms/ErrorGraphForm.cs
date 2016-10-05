using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace zadanie_1.Forms
{
    public partial class ErrorGraphForm : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private int offset = 40;
        public double[] Error { get; set; }

        public ErrorGraphForm()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox.Width, pictureBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;
            g.Clear(Color.White);
            pictureBox.Refresh();
        }

        private void ErrorGraphForm_Load(object sender, EventArgs e)
        {

        }

        private void ErrorGraphForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter ||
                e.KeyCode == Keys.Escape)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #region Drawing
        private void DrawAxes()
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Brushes.Black);
            //double min = Error.Min();
            //double max = Error.Max();
            //int epochCount = Error.Length;
            //double delX = pictureBox.Width / (double)epochCount;

            g.DrawLine(pen, offset, pictureBox.Height - offset, pictureBox.Width - offset, pictureBox.Height - offset);
            g.DrawLine(pen, offset, pictureBox.Height - offset, offset, offset);
            pictureBox.Refresh();
        }

        public void DrawErrorCurve(double[] trainError, double[] testError)
        {
            Pen pen = new Pen(Brushes.Red, 2);
            double min = Math.Min(trainError.Min(), testError.Min());
            double max = Math.Max(trainError.Max(), testError.Max());
            int epochCount = Math.Max(trainError.Length, testError.Length);
            double delX = (pictureBox.Width - 2 * offset) / (double)epochCount;

            double a = (2 * (offset + 20) - pictureBox.Height) / (double)(max - min);
            double b = pictureBox.Height - (offset + 20) - a * min;

            for (int i = 1; i < trainError.Length; i++)
            {
                g.DrawLine(pen, (i - 1) * (float)delX + offset, (float)(a * trainError[i - 1] + b),
                    i * (float)delX + offset, (float)(a * trainError[i] + b));
            }

            DrawAxesDivision(delX, epochCount, min, max);

            pictureBox.Refresh();
        }

        private void DrawAxesDivision(double delX, int epochCount, double min, double max)
        {
            //x axis
            //int tmp = epochCount / 10;
            int tmp = (pictureBox.Width - 2 * offset)/10;
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(new Pen(Brushes.Black),
                    (float)(i * tmp + offset), pictureBox.Height - offset, (float)(i * tmp + offset), pictureBox.Height - offset - 5);
                g.DrawString((i * epochCount/10).ToString(), new Font(FontFamily.GenericSansSerif, 10),
                    Brushes.Black, (float)(i * tmp + offset) - (i * epochCount / 10).ToString().Length * 4, pictureBox.Height - offset + 10);
            }
            //last point
            //g.DrawLine(new Pen(Brushes.Black),
            //        (float)(delX * epochCount + offset), pictureBox.Height - offset, (float)(delX * epochCount + offset), pictureBox.Height - offset - 5);
            //g.DrawString((epochCount).ToString(), new Font(FontFamily.GenericSansSerif, 10),
            //    Brushes.Black, (float)(delX * epochCount + offset) - (epochCount).ToString().Length * 4, pictureBox.Height - offset + 10);

            //y axis
            double delY = (double)(pictureBox.Height - 2 * offset - 40) / 10.0d;
            double a = (max - min) / (double)(2 * offset + 40 - pictureBox.Height);
            double b = min - a * (pictureBox.Height - offset - 20);

            for (int i = 0; i <= 10; i++) 
            {
                g.DrawLine(new Pen(Brushes.Black),
                    offset, pictureBox.Height - offset - 20 - i * (float)delY, offset - 5, pictureBox.Height - offset - 20 - i * (float)delY);
                g.DrawString((a * (pictureBox.Height - offset - 20 - i * (float)delY) + b).ToString("0.#E+0", CultureInfo.InvariantCulture), new Font(FontFamily.GenericSansSerif, 8),
                    Brushes.Black, offset - 40, pictureBox.Height - offset - 27 - i * (float)delY);
            }
        }

        #endregion

        private void ErrorGraphForm_Shown(object sender, EventArgs e)
        {
            DrawAxes();
            DrawErrorCurve(Error, Error);
        }
    }
}
