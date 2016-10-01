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

        public MLPNetwork(Function1D function)
        {
            this.function = function;
            network = new BasicNetwork();

            // the input layer does not have an activation function, because activation functions affects data coming
            // from the previous layer 
            network.AddLayer(new BasicLayer(null, true, 1));
            //hidden layer
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));

            // the output layer does not have bias neurons, because bias neuron affects the next layer
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));

            network.Structure.FinalizeStructure();
            network.Reset();
        }

        public void TrainNetwork()
        {
            // create training data
            //double[][] input = GetNormalized2DData(function.GetFInput());
            //double[][] ideal = GetNormalized2DData(function.GetFIdeal());

            //IMLDataSet trainingSet = new BasicMLDataSet(input, ideal);
            IMLDataSet trainingSet = GetDataSetFromOneDimensionalArrays(function.GetFInput(), function.GetFIdeal());

            // train the neural network
            IMLTrain train = new ResilientPropagation(network, trainingSet);
            //IMLTrain train = new ManhattanPropagation(network, trainingSet, 5);
            //IMLTrain train = new QuickPropagation(network, trainingSet, 0.0005);

            int epoch = 1;

            do
            {
                train.Iteration();
                //System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.01);

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

        /// <summary>
        /// Method returns IMLDataSet from input and ideal double[] arrays.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <param name="ideal">The ideal data.</param>
        /// <param name="normalizeData">Indicates whether the data should be normalized.</param>
        /// <returns></returns>
        private IMLDataSet GetDataSetFromOneDimensionalArrays(double[] input, double[] ideal, bool normalizeData = true)
        {
            var result = new BasicMLDataSet();
            var minInput = input.Min();
            var maxInput = input.Max();
            var minIdeal = ideal.Min();
            var maxIdeal = ideal.Max();

            for (int i = 0; i < input.Length; i++)
            {
                var inputData = normalizeData ? 
                    new BasicMLData(GetNormalized1DData(input[i], minInput, maxInput)) : new BasicMLData(GetNormalized1DData(input[i], minInput, maxInput, false));
                var idealData = normalizeData ? 
                    new BasicMLData(GetNormalized1DData(ideal[i], minIdeal, maxIdeal)) : new BasicMLData(GetNormalized1DData(ideal[i], minIdeal, maxIdeal, false));
                result.Add(new BasicMLDataPair(inputData, idealData));
            }

            return result;
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

        #region Data normalization
        private double[][] GetNormalized2DData(double[] data)
        {
            double min = data.Min();
            double max = data.Max();

            //mapovanie na [-1,1]
            //double a = 2.0d / (double)(max - min);
            //double b = -a * min - 1;

            //mapovanie na [0,1]
            double a = 1.0d / (double)(max - min);
            double b = -a * min;

            double[][] normalizedData = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                normalizedData[i] = new double[1];
                normalizedData[i][0] = a * data[i] + b;
            }

            return normalizedData;
        }

        private double[] GetNormalized1DData(double[] data)
        {
            double min = data.Min();
            double max = data.Max();

            //mapovanie na [-1,1]
            //double a = 2.0d / (double)(max - min);
            //double b = -a * min - 1;

            //mapovanie na [0,1]
            double a = 1.0d / (double)(max - min);
            double b = -a * min;

            double[] normalizedData = new double[data.Length];

            for (int i = 0; i < data.Length; i++)
                normalizedData[i] = a * data[i] + b;

            return normalizedData;
        }

        private double[] GetNormalized1DData(double data, double min, double max, bool normalizeData = true)
        {
            //mapovanie na [-1,1]
            //double a = 2.0d / (double)(max - min);
            //double b = -a * min - 1;

            //mapovanie na [0,1]
            double a = 1.0d, b = 1.0d;
            if(normalizeData)
            {
                a = 1.0d / (double)(max - min);
                b = -a * min;
            }

            double[] normalizedData = new double[1];
            normalizedData[0] = a * data + b;

            return normalizedData;
        }

        #endregion
    }
}
