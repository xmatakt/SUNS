using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FaceRecognition.Classes;

namespace FaceRecognition
{
    public partial class Form1 : Form
    {
        SVMImageClassificator imageClassificator;
        public Form1()
        {
            InitializeComponent();

            testBtn.Enabled = false;
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            imageClassificator = new SVMImageClassificator(richTextBox);
            testBtn.Enabled = true;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            imageClassificator.TestNetwork();
        }
    }
}
