//http://stackoverflow.com/questions/39069416/encog-c-sharp-rbf-network-how-to-start
//https://searchcode.com/codesearch/view/13630203/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using zadanie_1.functions;

#region Encog
using Encog.MathUtil.RBF;
using Encog.Neural.Data.Basic;
using Encog.Neural.NeuralData;
using Encog.Neural.Rbf.Training;
using Encog.Neural.RBF;
using Encog.ML.Data;
#endregion

namespace zadanie_1.Networks
{
    class RbfNetwork
    {
        private RBFNetwork network;
        private SVDTraining train;
        private Function1D function;
        private double[] result;
        //Specify the number of dimensions and the number of neurons per dimension
        private int dimensions = 1;
        // could be also 16, 64, 256. I suppose it should accept 8, 32 but it needs additional investigation
        public int NumNeuronsPerDimension { get; set; }
        public double Error { get; set; }
        //RBF can struggle when it comes to flats at the edge of the sample space.
        //We have added the ability to include wider neurons on the sample space boundary which greatly
        //improves fitting to flats
        private bool includeEdgeRBFs = true;

        public RbfNetwork(Function1D function, int neuronsCount = 1)
        {
            this.function = function;
            this.NumNeuronsPerDimension = neuronsCount;
            //Set the standard RBF neuron width. 
        }

        private void InitNetwork(INeuralDataSet trainingSet)
        {
            //Literature seems to suggest this is a good default value.
            double volumeNeuronWidth = 2.0 / ++NumNeuronsPerDimension;
            network = new RBFNetwork(dimensions, NumNeuronsPerDimension, 1, RBFEnum.Gaussian);
            network.SetRBFCentersAndWidthsEqualSpacing(0, 1, RBFEnum.Gaussian, volumeNeuronWidth, includeEdgeRBFs);
            SVDTraining train = new SVDTraining(network, trainingSet);
            Error = 0.01d;
        }

        public void TrainNetwork()
        {
            INeuralDataSet trainingSet = DataManipulation.GetNeuralDataSetFromOneDimensionalArrays(function.GetFInput(), function.GetFIdeal());

            int epoch = 1;
            do
            {
                InitNetwork(trainingSet);
                train = new SVDTraining(network, trainingSet);
                train.Iteration();
                Console.WriteLine("Epoch #" + epoch + " Error:" + train.Error + " Neurons count: " + -100);
                epoch++;
            } while ((train.Error > Error));

            result = new double[trainingSet.Count];
            int index = 0;
            foreach (IMLDataPair pair in trainingSet)
            {
                result[index++] = network.Compute(pair.Input)[0];
                //IMLData output = network.Compute(pair.Input);
                //System.Diagnostics.Debug.WriteLine(pair.Input[0] 
                //                  + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }

            //System.Windows.Forms.MessageBox.Show("number of neurons = " + NumNeuronsPerDimension);
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
    }
}
