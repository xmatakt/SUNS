using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_1.Forms
{
    public partial class PictureForm : Form
    {
        public PictureForm(Bitmap image)
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(PictureForm_MouseWheel);
            this.Width = image.Width + 20;
            this.Height = image.Height + 20;
            pictureBox.Image = image;
        }

        private void PictureForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                default:
                    break;
            }

        }

        private void PictureForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta>0)
            {
                this.Width += 40;
                this.Height += 40;
            }
            else
            {
                this.Width -= 40;
                this.Height -= 40;
            }
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {

        }
    }
}
