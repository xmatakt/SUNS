using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using zadanie_1.functions;

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
    class MLPNetwork
    {
        private BasicNetwork network;
        private Function1D function;
        private double[] trainingResult;
        private List<double> error;

        public int maxEpochCount { get; set; }
        public double Error { get; set; }

        public MLPNetwork(Function1D function)
        {
            this.function = function;
            this.maxEpochCount = 1000;
            this.Error = 0.01;
        }

        public void SetNetwork(BasicNetwork network)
        { 
            this.network = network;
        }

        public void TrainNetwork()
        {
            this.error = new List<double>();
            IMLDataSet trainingSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(function.GetTrainInput(), function.GetTrainIdeal());
            IMLDataSet testSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(function.GetTestInput(), function.GetTestIdeal());
            
            // train the neural network
            IMLTrain train = new ResilientPropagation(network, trainingSet);

            int epoch = 1;
            do
            {
                train.Iteration();
                System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                error.Add(train.Error);
                epoch++;
            } while ((epoch <= maxEpochCount) && (train.Error > Error));
            train.FinishTraining();

            // test the neural network
            trainingResult = new double[testSet.Count];
            int index = 0;
            foreach (IMLDataPair pair in testSet)
                trainingResult[index++] = network.Compute(pair.Input)[0];
        }

        public double[] ReturnResult()
        {
            double[] res = new double[trainingResult.Length];
            double a = 1.0d, b = 1.0d;
            double min = function.GetTestIdeal().Min();
            double max = function.GetTestIdeal().Max();

            a = max - min;
            b = min;
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = a * trainingResult[i] + b;
            }

            return res; 
        }

        public double[] ReturnError()
        {
            return error.ToArray();
        }
    }
}
