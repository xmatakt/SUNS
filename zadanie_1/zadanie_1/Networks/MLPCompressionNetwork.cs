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

        public void Train()
        {
            for (int i = 0; i < trainPicture.Length; i++)
            {
                double[][] data = new double[1][];
                data[0] = DataManipulation.Get1DArrayFrom2DArray(trainPicture[i], 8, 8);
                IMLDataSet trainingSet = new BasicMLDataSet(data, data);
                //IMLDataSet testSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(function.GetTestInput(), function.GetTestIdeal());

                // train the neural network
                ResilientPropagation train = new ResilientPropagation(network, trainingSet);

                int epoch = 1;
                do
                {
                    train.Iteration();
                    //System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                    //error.Add(train.Error);
                    epoch++;
                } while ((epoch <= 1000) && (train.Error > 0.0016));
                train.FinishTraining();
                System.Diagnostics.Debug.WriteLine("{0}", i);
            }
            System.Windows.Forms.MessageBox.Show("Network succesfuly trained!");
        }

        public void CompressPicture()
        {
            trainingResult = new double[testPicture.Length][];
            for (int i = 0; i < trainingResult.Length; i++)
                trainingResult[i] = new double[64];

            //for (int i = 0; i < testPicture.Length; i++)
            //{
            //    int ind = 0;
            //    for (int y = 0; y < 8; y++)
            //    {
            //        for (int x = 0; x < 8; x++)
            //        {
            //            trainingResult[i][ind++] = testPicture[i][x][y];
            //        }
            //    }
            //}

            // test the neural networktrainingResult.Length
//            for(MLDataPair pair: trainingSet ) {
//            final MLData output = network.compute(pair.getInput());
//            for(int z=0;z<input;z++){
//outputquant[x+xoff][y+z]=output.getData()[z];

            for (int i = 0; i < trainingResult.Length; i++)
            {
                double[][] data = new double[1][];
                data[0] = DataManipulation.Get1DArrayFrom2DArray(testPicture[i], 8, 8);
                //trainingResult[i] = DataManipulation.Get1DArrayFrom2DArray(testPicture[i], 8, 8);
                IMLDataSet testSet = new BasicMLDataSet(data, data);
                int index = 0;

                //network.Compute(data[0], trainingResult[i]);
                foreach (IMLDataPair pair in testSet)
                    //trainingResult[i] = 
                    network.Compute(pair.Input).CopyTo(trainingResult[i], 0, 64);
                ////System.Diagnostics.Debug.WriteLine(index.ToString());

                //foreach (IMLDataPair pair in testSet)
                //{
                //    IMLData output = network.Compute(pair.Input);
                //    Console.WriteLine(pair.Input[0] + @"," + pair.Input[1]
                //                      + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
                //}
            }
            System.Windows.Forms.MessageBox.Show("Picture was succesfuly compressed!");

            byte[] compressedPicture = DataManipulation.GetPictureArrayFrom2D(trainingResult, Width, Height);

            var bitmap2 = new Bitmap(Width, Height);
            for (int y = 0; y < bitmap2.Height; y++)
                for (int x = 0; x < bitmap2.Width; x++)
                    bitmap2.SetPixel(x, y, Color.FromArgb(compressedPicture[x + y * bitmap2.Width], compressedPicture[x + y * bitmap2.Width],
                        compressedPicture[x + y * bitmap2.Width]));
            var result = bitmap2 as Image;
            result.Save("kokotina.png", ImageFormat.Png);
        }
    }
}
