﻿using System;
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
    public partial class ErrorForm : Form
    {
        private bool maximized = false;

        public ErrorForm()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
        }

        private void ErrorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            if (e.KeyCode == Keys.Escape)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void zedGraph_error_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            if (e.KeyCode == Keys.Escape)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            if (e.KeyCode == Keys.F2)
            {
                if(maximized)
                    WindowState = FormWindowState.Normal;
                else
                    WindowState = FormWindowState.Maximized;
                maximized = !maximized;
            }
        }
    }
}
