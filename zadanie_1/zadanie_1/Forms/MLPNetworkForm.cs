using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;

using zadanie_1.Enums;
using zadanie_1.Networks;
using zadanie_1.functions;

namespace zadanie_1.Forms
{
    public partial class MLPNetworkForm : Form
    {
        private int numOfLayers = 1;
        private Function1D function;
        private Button actualButton;
        private MLPNetwork mlpNetwork;
        private PictureBox pictureBox;
        private Graphics graphics;

        public MLPNetworkForm(PictureBox pictureBox, Graphics graphics, object function)
        {
            this.function = (Function1D)function;
            this.pictureBox = pictureBox;
            this.graphics = graphics;

            this.mlpNetwork = new MLPNetwork(this.function);
            //this.mlpNetwork.TrainNetwork();

            InitializeComponent();

            //DrawFunction();
        }

        private void MLPNetworkForm_Load(object sender, EventArgs e)
        {
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSigmoid.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationTanh.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSin.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationRamp.ToString());
        }

        #region Drawing

        private void DrawFunction(bool drawMesh = true)
        {
            function.DrawFunction(pictureBox, graphics);
            function.DrawLegend(pictureBox, graphics, mlpNetwork.ReturnError().Length, "Epochs: ");

            if(drawMesh)
                function.DrawMesh(pictureBox, graphics);
        }

        private void DrawResult()
        {
            function.DrawResultAsCurve(pictureBox, graphics, mlpNetwork.ReturnResult());
        }

        #endregion

        #region AddingControls
        private void AddNewButton()
        {
            Button newButton = new Button();
            int yOffset = activationFunctionButton_1.Location.Y + numOfLayers * 25;

            newButton.Size = activationFunctionButton_1.Size;
            newButton.Location = new Point(activationFunctionButton_1.Location.X, yOffset);
            newButton.Name = "activationFunctionButton_" + (numOfLayers + 1);
            newButton.Text = ActivationFunctionEnum.ActivationSigmoid.ToString();
            newButton.Click += new System.EventHandler(this.activationFunctionButton_1_Click);
            this.Controls.Add(newButton);
        }

        private void AddNewNumUpDown()
        {
            NumericUpDown newUpDown = new NumericUpDown();
            int yOffset = activationFunctionButton_1.Location.Y + numOfLayers * 25;

            newUpDown.Size = neuronsCount_1.Size;
            newUpDown.Location = new Point(neuronsCount_1.Location.X, yOffset);
            newUpDown.Name = "neuronsCount_" + (numOfLayers + 1);
            newUpDown.Minimum = neuronsCount_1.Minimum;
            newUpDown.Maximum = neuronsCount_1.Maximum;
            newUpDown.Increment = 1;
            newUpDown.TextAlign = neuronsCount_1.TextAlign;
            newUpDown.Value = neuronsCount_1.Value;
            //newUpDown.Click += new System.EventHandler(this.activationFunctionButton_1_Click);

            this.Controls.Add(newUpDown);
        }

        private void AddNewCheckBox()
        {
            CheckBox newCheckBox = new CheckBox();
            int yOffset = activationFunctionButton_1.Location.Y + numOfLayers * 25;

            newCheckBox.Location = new Point(biasCheckBox_1.Location.X, yOffset);
            newCheckBox.Checked = true;
            newCheckBox.Name = "biasCheckBox_" + (numOfLayers + 1);
            this.Controls.Add(newCheckBox);
        }

        private void GrowWindow()
        {
            int yOffset = 25;
            this.Height += yOffset;
            numOfLayers++;
        }

        private void ShrinkWindow()
        {
            int yOffset = -25;
            this.Height += yOffset;
            numOfLayers--;
        }
        #endregion

        #region RemovingControls
        private void RemoveLastControls()
        {
            if(numOfLayers > 1)
            {
                this.Controls.RemoveByKey("activationFunctionButton_" + numOfLayers);
                this.Controls.RemoveByKey("neuronsCount_" + numOfLayers);
                this.Controls.RemoveByKey("biasCheckBox_" + numOfLayers);
                ShrinkWindow();
            }
        }
        #endregion

        #region Layer adding
        private void AddLayer(BasicNetwork network, int i)
        {
            Button button = (Button)this.Controls.Find("activationFunctionButton_" + i, false).First();
            NumericUpDown numUpDown = (NumericUpDown)this.Controls.Find("neuronsCount_" + i, false).First();
            CheckBox checkBox = (CheckBox)this.Controls.Find("biasCheckBox_" + i, false).First();
            bool hasBias = checkBox.Checked;

            switch (DataManipulation.GetActivationFunctionEnum(button.Text.Trim()))
            {
                case ActivationFunctionEnum.ActivationSigmoid:
                    network.AddLayer(new BasicLayer(new ActivationSigmoid(), hasBias, (int)numUpDown.Value));
                    break;
                case ActivationFunctionEnum.ActivationTanh:
                    network.AddLayer(new BasicLayer(new ActivationTANH(), hasBias, (int)numUpDown.Value));
                    break;
                case ActivationFunctionEnum.ActivationSin:
                    network.AddLayer(new BasicLayer(new ActivationSIN(), hasBias, (int)numUpDown.Value));
                    break;
                case ActivationFunctionEnum.ActivationRamp:
                    network.AddLayer(new BasicLayer(new ActivationRamp(), hasBias, (int)numUpDown.Value));
                    break;
                default:
                    break;
            }
        }

        private ActivationFunctionEnum AddLayer(string functionName)
        {
            switch (functionName)
            {
                case ActivationFunctionStrings.ActivationSigmoid:
                    return ActivationFunctionEnum.ActivationSigmoid;
                case ActivationFunctionStrings.ActivationTanh:
                    return ActivationFunctionEnum.ActivationTanh;
                case ActivationFunctionStrings.ActivationSin:
                    return ActivationFunctionEnum.ActivationSin;
                case ActivationFunctionStrings.ActivationRamp:
                    return ActivationFunctionEnum.ActivationRamp;
                default:
                    return ActivationFunctionEnum.ActivationSigmoid;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (numOfLayers < 10)
            {
                AddNewButton();
                AddNewNumUpDown();
                AddNewCheckBox();
                GrowWindow();
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            actualButton.Text = e.ClickedItem.Text;
        }

        private void activationFunctionButton_1_Click(object sender, EventArgs e)
        {
            Button clickedButton = actualButton = (Button)sender;
            activationFunctionMenuStrip.Show(clickedButton, new Point(0, clickedButton.Height));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RemoveLastControls();
        }

        private void MLPNetworkForm_Shown(object sender, EventArgs e)
        {
            //DrawFunction();
        }

        private void generateNetworkButton_Click(object sender, EventArgs e)
        {
            BasicNetwork network = new BasicNetwork();
            
            //input layer
            network.AddLayer(new BasicLayer(null, true, 1));
            //hidden layers
            for (int i = 1; i <= numOfLayers; i++)
                AddLayer(network, i);
            //output layer
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));

            network.Structure.FinalizeStructure();
            network.Reset();
            mlpNetwork.SetNetwork(network);
            mlpNetwork.Error = (double)requiredErrorUpDown.Value;
            mlpNetwork.maxEpochCount = (int)maxCountNumericUpDown.Value;
            mlpNetwork.TrainNetwork();

            graphics.Clear(Color.White);
            DrawFunction();
            DrawResult();

            showLogButton.Enabled = true;
            errorGraphButton.Enabled = true;
        }

        private void errorGraphButton_Click(object sender, EventArgs e)
        {
            ErrorGraphForm form = new ErrorGraphForm();
            form.Error = mlpNetwork.ReturnError();
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
