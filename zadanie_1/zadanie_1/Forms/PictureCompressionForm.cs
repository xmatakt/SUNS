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


#region Encog
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.Networks.Training.Propagation.Manhattan;
using Encog.Neural.Networks.Training.Propagation.Quick;
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
        
        private string trainFile = "";
        private string testFile = "";
        private byte[][][] dividedTrainPicture;
        private byte[][][] dividedTestPicture; 

        public PictureCompressionForm()
        {
            InitializeComponent();
            dividedTrainPicture = null;
            dividedTestPicture = null;
            //Tmp();
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
                //StreamWriter sw = new StreamWriter("output.pgm");

                //sw.WriteLine("P2");
                //sw.WriteLine(bitmap.Width + " " + bitmap.Height);
                //sw.WriteLine("255");

                //for (int i = 0; i < arr.Length; i++)
                //{
                //    sw.Write("{0} ", arr[i]);
                //    if (i != 0 && i % bitmap.Width == 0)
                //        sw.WriteLine("");
                //}

                //sw.Flush();
                //sw.Close();
            }
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            //return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void PictureCompressionForm_Load(object sender, EventArgs e)
        {
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSigmoid.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationTanh.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationSin.ToString());
            activationFunctionMenuStrip.Items.Add(ActivationFunctionEnum.ActivationRamp.ToString());
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

        private void train_button_Click(object sender, EventArgs e)
        {
            if (dividedTrainPicture != null)
            {
                mlpNetwork = new MLPCompressionNetwork(dividedTrainPicture);
                GenerateNetwork();
                //mlpNetwork.Train();
                train_button.BackColor = Color.Lime;
                mlpNetwork.Train();
            }
            else
                MessageBox.Show("You have to load training data first!");
        }

        #region Network manipulation
        private void GenerateNetwork()
        {
            BasicNetwork network = new BasicNetwork();

            //input layer
            network.AddLayer(new BasicLayer(null, true, 1));
            //hidden layers
            AddLayer(network,second_neuronsCont,second_activationFunctionButton,second_biasCheckBox);
            //output layer
            //AddLayer(network, third_neuronsCount, third_activationFunctionButton, third_biasCheckBox);
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));

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
                default:
                    break;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (dividedTestPicture != null)
            {
                mlpNetwork.SetTestPicture(dividedTestPicture);
                mlpNetwork.CompressPicture();
            }
            else
                MessageBox.Show("You have to load test data first!");
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
            }
        }
    }
}
