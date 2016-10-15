using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#region Encog
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.Networks.Training.Propagation.Manhattan;
using Encog.Neural.Networks.Training.Propagation.Quick;
using Encog.Neural.Networks.Training.Strategy;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog;
#endregion

using zadanie_1.Enums;
using zadanie_1.Networks;

namespace zadanie_1.Forms
{
    public partial class PictureCompressionForm : Form
    {
        private Button actualButton;
        private MLPCompressionNetwork mlpNetwork;
        private PictureBox pictureBox;
        private PictureForm pictureForm;
        
        private string trainFile = "";
        private string testFile = "";
        private double[][][] dividedTrainPicture;
        private double[][][] dividedTestPicture; 

        public PictureCompressionForm(PictureBox pictureBox)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
            this.dividedTrainPicture = null;
            this.dividedTestPicture = null;
        }

        private void train_button_Click(object sender, EventArgs e)
        {
            if (dividedTrainPicture != null)
            {
                mlpNetwork = new MLPCompressionNetwork(dividedTrainPicture);
                mlpNetwork.LearningRate = (double)learningRate_upDown.Value;
                mlpNetwork.Momentum = (double)momentum_upDown.Value;
                mlpNetwork.Error = (double)error_upDown.Value;
                GenerateNetwork();
                mlpNetwork.Train(training_progressBar);

                loadTestData_button.Enabled = true;
                ReadProperties("networkTraining.log");
                //training_progressBar.Value = 50;
            }
            else
                MessageBox.Show("You have to load training data first!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dividedTestPicture != null)
            {
                mlpNetwork.SetTestPicture(dividedTestPicture);
                pictureForm = new PictureForm(mlpNetwork.CompressPicture());
                if(pictureForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            else
                MessageBox.Show("You have to load test data first!");
        }

        #region Network manipulation
        private void GenerateNetwork()
        {
            BasicNetwork network = new BasicNetwork();
            //input layer
            network.AddLayer(new BasicLayer(null, true, 64));
            //hidden layers
            AddLayer(network, second_neuronsCont, second_activationFunctionButton, second_biasCheckBox);
            //network.AddLayer(new BasicLayer(new ActivationLOG(), true, (int)second_neuronsCont.Value));
            //output layer
            //network.AddLayer(new BasicLayer(new ActivationRamp(), false, 64));
            AddLayer(network, third_neuronsCount, third_activationFunctionButton, third_biasCheckBox);

            network.Structure.FinalizeStructure();
            network.Reset();
            mlpNetwork.SetNetwork(network);
        }

        private void AddLayer(BasicNetwork network, NumericUpDown upDown, Button button, CheckBox box)
        {
            bool hasBias = box.Checked;
            int neuronsCount = (int)upDown.Value;
            switch (DataManipulation.GetActivationFunctionEnum(button.Text.Trim()))
            {
                case ActivationFunctionEnum.ActivationSigmoid:
                    network.AddLayer(new BasicLayer(new ActivationSigmoid(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationTanh:
                    network.AddLayer(new BasicLayer(new ActivationTANH(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationSin:
                    network.AddLayer(new BasicLayer(new ActivationSIN(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationRamp:
                    network.AddLayer(new BasicLayer(new ActivationRamp(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationLog:
                    network.AddLayer(new BasicLayer(new ActivationLOG(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationLinear:
                    network.AddLayer(new BasicLayer(new ActivationLinear(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.ActivationClippedLinear:
                    network.AddLayer(new BasicLayer(new ActivationClippedLinear(), hasBias, neuronsCount));
                    break;
                case ActivationFunctionEnum.None:
                    network.AddLayer(new BasicLayer(null, hasBias, neuronsCount));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Data loading

        private void ReadProperties(string pathToFile)
        {
            StreamReader sr = new StreamReader(pathToFile);

            trainingTime_label.Text = sr.ReadLine().Trim().Split(' ')[2].Trim();
            mse_label.Text = sr.ReadLine().Trim().Split(':')[1].Trim();
            bitDiff_label.Text = sr.ReadLine().Trim().Split(':')[1].Trim();
            compressionRatio_label.Text = sr.ReadLine().Trim().Split(':')[1].Trim();

            sr.Close();
        }

        private void loadTrainData_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trainFile = openFileDialog.FileName;
                Bitmap bitmap = new Bitmap(trainFile);
                byte[] arr = new byte[bitmap.Width * bitmap.Height];

                int index = 0;

                for (int i = 0; i < bitmap.Height; i++)
                    for (int j = 0; j < bitmap.Width; j++)
                        arr[index++] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).G + bitmap.GetPixel(j, i).B) / 3);

                dividedTrainPicture = DataManipulation.DividePicture(arr, bitmap.Width, bitmap.Height);
                trainDataLoaded_label.Text = "Train data: " + new FileInfo(trainFile).Name;
                
                train_button.BackColor = Color.Lime;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                testFile = openFileDialog.FileName;
                Bitmap bitmap = new Bitmap(testFile);
                byte[] arr = new byte[bitmap.Width * bitmap.Height];

                int index = 0;

                for (int i = 0; i < bitmap.Height; i++)
                    for (int j = 0; j < bitmap.Width; j++)
                        arr[index++] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).G + bitmap.GetPixel(j, i).B) / 3);

                dividedTestPicture = DataManipulation.DividePicture(arr, bitmap.Width, bitmap.Height);
                mlpNetwork.Width = bitmap.Width;
                mlpNetwork.Height = bitmap.Height;

                testDataLoaded_label.Text = "Test data: " + new FileInfo(testFile).Name;
                compress_button.Enabled = true;
                compress_button.BackColor = Color.Lime;
            }
        }
        #endregion

        #region Bordel
        private void PictureCompressionForm_Load(object sender, EventArgs e)
        {
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSigmoid.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationTanh.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSin.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationRamp.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationLog.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationLinear.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationClippedLinear.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.None.ToString());
        }

        private void first_activationFunctionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = actualButton = (Button)sender;
            activationFunctionMenuStrip.Show(clickedButton, new Point(0, clickedButton.Height));
        }

        private void second_activationFunctionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = actualButton = (Button)sender;
            activationFunctionMenuStrip.Show(clickedButton, new Point(0, clickedButton.Height));
        }

        private void third_activationFunctionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = actualButton = (Button)sender;
            activationFunctionMenuStrip.Show(clickedButton, new Point(0, clickedButton.Height));
        }

        private void activationFunctionMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            actualButton.Text = e.ClickedItem.Text;
        }
        #endregion
    }
}
