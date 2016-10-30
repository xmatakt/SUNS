using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSeriesPrediction.Forms
{
    public partial class BigGraphForm : Form
    {
        private bool maximized = false;

        public BigGraphForm()
        {
            InitializeComponent();
        }

        private void zedGraphControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maximized = false;
                WindowState = FormWindowState.Normal;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
                
            if (e.KeyCode == Keys.Escape)
            {
                maximized = false;
                WindowState = FormWindowState.Normal;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            if (e.KeyCode == Keys.F2)
            {
                if (maximized)
                    WindowState = FormWindowState.Normal;
                else
                    WindowState = FormWindowState.Maximized;
                maximized = !maximized;
            }
        }
    }
}
