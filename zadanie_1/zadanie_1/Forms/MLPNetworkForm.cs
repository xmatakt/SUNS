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

namespace zadanie_1.Forms
{
    public partial class MLPNetworkForm : Form
    {
        private int numOfLayers = 1;
        private Button actualButton;
        private MLPNetwork mlpNetwork;
        private Form1 mainForm;

        public MLPNetworkForm(Form1 mainForm, object mlpNetwork)
        {
            this.mlpNetwork = (MLPNetwork)mlpNetwork;
            this.mainForm = mainForm;

            InitializeComponent();
        }

        private void MLPNetworkForm_Load(object sender, EventArgs e)
        {
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSigmoid.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationTanh.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSin.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationRamp.ToString());
        }

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
            newUpDown.Value = 1m;
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

            addLayerButton.Location = new Point(addLayerButton.Location.X, addLayerButton.Location.Y + yOffset);
            removeLayerButton.Location = new Point(removeLayerButton.Location.X, removeLayerButton.Location.Y + yOffset);
            generateNetworkButton.Location = new Point(generateNetworkButton.Location.X, generateNetworkButton.Location.Y + yOffset); 
            this.Height += yOffset;

            numOfLayers++;
        }

        private void ShrinkWindow()
        {
            int yOffset = -25;

            addLayerButton.Location = new Point(addLayerButton.Location.X, addLayerButton.Location.Y + yOffset);
            removeLayerButton.Location = new Point(removeLayerButton.Location.X, removeLayerButton.Location.Y + yOffset);
            generateNetworkButton.Location = new Point(generateNetworkButton.Location.X, generateNetworkButton.Location.Y + yOffset);
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
    }
}
