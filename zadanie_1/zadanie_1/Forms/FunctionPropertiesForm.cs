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
    public partial class FunctionPropertiesForm : Form
    {
        public int nodesCount = 100;
        public FunctionPropertiesForm()
        {
            InitializeComponent();
        }

        private void FunctionPropertiesForm_Load(object sender, EventArgs e)
        {

        }

        private void nodesCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            nodesCount = (int)nodesCountUpDown.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
