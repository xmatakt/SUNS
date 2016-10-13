using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private byte[][][] trainPicture;
        private byte[][][] testPicture;

        #region constructors
        public MLPCompressionNetwork(byte[][][] trainPicture)
        {
            this.trainPicture = trainPicture;
        }

        public MLPCompressionNetwork(byte[][][] trainPicture, byte[][][] testPicture)
        {
            this.trainPicture = trainPicture;
            this.testPicture = testPicture;
        }

        public void SetTestPicture(byte[][][] testPicture)
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
                // MOZNO BUDE TREBA NORMALIZOVAT VSTUP (RESP. URCITE BUDE TREBA)
                byte[] data = DataManipulation.Get1DArrayFrom2DArray(trainPicture[i], 8, 8);
                IMLDataSet trainingSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(
                    data, data, false);
                //IMLDataSet testSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(function.GetTestInput(), function.GetTestIdeal());

                // train the neural network
                IMLTrain train = new ResilientPropagation(network, trainingSet);

                int epoch = 1;
                do
                {
                    train.Iteration();
                    //System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                    //error.Add(train.Error);
                    epoch++;
                } while ((epoch <= 1000) && (train.Error > 0.01));
                train.FinishTraining();
                System.Diagnostics.Debug.WriteLine("{0}",i);
            }
            System.Windows.Forms.MessageBox.Show("Network succesfuly trained!");
        }

        public void CompressPicture()
        {
            // test the neural network
            int tmp = testPicture.Length;
            //trainingResult = new double[testSet.Count];
            //int index = 0;
            //foreach (IMLDataPair pair in testSet)
                //trainingResult[index++] = network.Compute(pair.Input)[0];
        }
    }
}
