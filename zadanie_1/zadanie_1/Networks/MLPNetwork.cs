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
        private double[] result;
        private List<double> error;

        public int NumOfEpochs { get; set; }
        public double Error { get; set; }

        public MLPNetwork(Function1D function)
        {
            this.function = function;
            this.NumOfEpochs = 10000;
            this.Error = 0.01;
            //network = new BasicNetwork();

            //// the input layer does not have an activation function, because activation functions affects data coming
            //// from the previous layer 
            //network.AddLayer(new BasicLayer(null, true, 1));
            ////hidden layer
            //network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 1));
            //// the output layer does not have bias neurons, because bias neuron affects the next layer
            //network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));

            //network.Structure.FinalizeStructure();
            //network.Reset();
        }

        public void SetNetwork(BasicNetwork network)
        { 
            this.network = network;
        }

        public void TrainNetwork()
        {
            this.error = new List<double>();
            // create training data
            //double[][] input = GetNormalized2DData(function.GetFInput());
            //double[][] ideal = GetNormalized2DData(function.GetFIdeal());

            //IMLDataSet trainingSet = new BasicMLDataSet(input, ideal);
            IMLDataSet trainingSet = DataManipulation.GetBasicDataSetFromOneDimensionalArrays(function.GetFInput(), function.GetFIdeal());

            // train the neural network
            IMLTrain train = new ResilientPropagation(network, trainingSet);
            //IMLTrain train = new ManhattanPropagation(network, trainingSet, 5);
            //IMLTrain train = new QuickPropagation(network, trainingSet, 0.0005);

            int epoch = 1;

            do
            {
                train.Iteration();
                System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                error.Add(train.Error);
                epoch++;
            } while ((epoch <= NumOfEpochs) && (train.Error > Error));

            train.FinishTraining();

            // test the neural network
            //System.Diagnostics.Debug.WriteLine(@"Neural Network Results:");
            result = new double[trainingSet.Count];
            int index = 0;
            foreach (IMLDataPair pair in trainingSet)
            {
                result[index++] = network.Compute(pair.Input)[0];
                //IMLData output = network.Compute(pair.Input);
                //System.Diagnostics.Debug.WriteLine(pair.Input[0] 
                //                  + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }
        }

        public double[] ReturnResult()
        { 
            double[] res = new double[result.Length];
            double a = 1.0d, b = 1.0d;
            double min = function.GetFIdeal().Min();
            double max = function.GetFIdeal().Max();

            a = max - min;
            b = min;
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = a * result[i] + b;
            }

            return res; 
        }

        public double[] ReturnError()
        {
            return error.ToArray();
        }
    }
}
