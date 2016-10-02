using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using zadanie_1.Enums;
using zadanie_1.Networks;
using zadanie_1.functions;


namespace zadanie_1.Forms
{
    public partial class RBFNetworkForm : Form
    {
        private Function1D function;
        private RbfNetwork rbfNetwork;
        private PictureBox pictureBox;
        private Graphics graphics;

        public RBFNetworkForm(PictureBox pictureBox, Graphics graphics, object function)
        {
            this.function = (Function1D)function;
            this.rbfNetwork = new RbfNetwork(this.function);
            this.pictureBox = pictureBox;
            this.graphics = graphics;

            InitializeComponent();
        }

        private void RBFNetworkForm_Load(object sender, EventArgs e)
        {

        }

        private void generateNetworkButton_Click(object sender, EventArgs e)
        {
            rbfNetwork.NumNeuronsPerDimension = 1;
            rbfNetwork.Error = (double)requiredErrorUpDown.Value;
            rbfNetwork.maxEpochCount = (int)maxCountNumericUpDown.Value;
            rbfNetwork.TrainNetwork();

            graphics.Clear(Color.White);
            DrawFunction();
            DrawResult();

            showLogButton.Enabled = true;
            errorGraphButton.Enabled = true;
        }

        #region Drawing
        private void DrawFunction(bool drawMesh = true)
        {
            function.DrawFunction(pictureBox, graphics);
            function.DrawLegend(pictureBox, graphics, rbfNetwork.ReturnError().Length, "Neurons: ");

            if (drawMesh)
                function.DrawMesh(pictureBox, graphics);
        }

        private void DrawResult()
        {
            function.DrawResultAsCurve(pictureBox, graphics, rbfNetwork.ReturnResult());
        }
        #endregion

        private void errorGraphButton_Click(object sender, EventArgs e)
        {
            ErrorGraphForm form = new ErrorGraphForm();
            form.Error = rbfNetwork.ReturnError();
            form.ShowDialog();
            //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    MessageBox.Show("je to ok");
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
    }
}
