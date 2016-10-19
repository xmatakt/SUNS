using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

#region Encog
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.Networks.Training.Propagation.Manhattan;
using Encog.Neural.Networks.Training.Propagation.Quick;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.SCG;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog;
#endregion

namespace zadanie_1.Networks
{
    class MLPCompressionNetwork
    {
        private BasicNetwork network;
        private double[][][] trainPicture;
        private double[][][] testPicture;
        private double[][] trainingResult;

        public int Width { get; set; }
        public int Height { get; set; }
        public double LearningRate { get; set; }
        public double Momentum { get; set; }
        public double Error { get; set; }

        #region constructors
        public MLPCompressionNetwork(double[][][] trainPicture)
        {
            this.trainPicture = trainPicture;
        }

        public MLPCompressionNetwork(double[][][] trainPicture, double[][][] testPicture)
        {
            this.trainPicture = trainPicture;
            this.testPicture = testPicture;
        }

        public void SetTestPicture(double[][][] testPicture)
        {
            this.testPicture = testPicture;
        }

        public void SetNetwork(BasicNetwork network)
        {
            this.network = network;
        }

        #endregion

        public void Train(System.Windows.Forms.ProgressBar progressBar)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            StreamWriter sw = new StreamWriter("networkTraining.log");
            double tmp = 100 / (double)trainPicture.Length;
            StringBuilder logContent = new StringBuilder();
            Backpropagation train = null;

            logContent.AppendLine("Elapsed time: elapsedTime");
            logContent.AppendLine("MSE: mse");
            logContent.AppendLine("Bit difficulty: bitDiff");
            logContent.Append("Compression ratio: compRatio");
            stopWatch.Start();
            for (int i = 0; i < trainPicture.Length; i++)
            {
                double[][] data = new double[1][];
                data[0] = DataManipulation.Get1DArrayFrom2DArray(trainPicture[i], 8, 8);
                IMLDataSet trainingSet = new BasicMLDataSet(data, data);

                // train the neural network
                train = new Backpropagation(network, trainingSet, LearningRate, Momentum);
                //Backpropagation train = new Backpropagation(network, trainingSet);
                //ResilientPropagation train = new ResilientPropagation(network, trainingSet);

                int epoch = 1;
                do
                {
                    train.Iteration();
                    epoch++;
                } while ((epoch <= 100000) && (train.Error > Error));

                logContent.Append("\n" + i + " =--> epoch# " + epoch + " error# " + train.Error);
                //sw.WriteLine("{0} =--> epoch# {1}, error# {2}", i, epoch, train.Error);
                train.FinishTraining();
                progressBar.Value = (int)(i * tmp);
            }
            stopWatch.Stop();
            
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            logContent.Replace("elapsedTime", elapsedTime);
            logContent.Replace("mse", train.Error.ToString("0.###E+0", System.Globalization.CultureInfo.InvariantCulture));
            double compRatio = 64.0d / network.GetLayerNeuronCount(1);
            double bitDiff = 8.0d / compRatio;
            logContent.Replace("bitDiff", bitDiff.ToString());
            logContent.Replace("compRatio", compRatio.ToString());

            sw.Write(logContent.ToString());
            sw.Flush();
            sw.Close();
            System.Windows.Forms.MessageBox.Show("Network succesfuly trained!");
        }

        public Bitmap CompressPicture()
        {
            trainingResult = new double[testPicture.Length][];
            for (int i = 0; i < trainingResult.Length; i++)
                trainingResult[i] = new double[64];

            for (int i = 0; i < trainingResult.Length; i++)
            {
                double[][] data = new double[1][];
                data[0] = DataManipulation.Get1DArrayFrom2DArray(testPicture[i], 8, 8);
                IMLDataSet testSet = new BasicMLDataSet(data, data);
                network.Compute(data[0], trainingResult[i]);
            }

            byte[] compressedPicture = DataManipulation.GetPictureArrayFrom2D(trainingResult, Width, Height);

            var bitmap2 = new Bitmap(Width, Height);
            for (int y = 0; y < bitmap2.Height; y++)
                for (int x = 0; x < bitmap2.Width; x++)
                    bitmap2.SetPixel(x, y, Color.FromArgb(compressedPicture[x + y * bitmap2.Width], compressedPicture[x + y * bitmap2.Width],
                        compressedPicture[x + y * bitmap2.Width]));

            var result = bitmap2 as Image;
            result.Save("compressedPicture.png", ImageFormat.Png);

            return bitmap2;
        }
    }
}
