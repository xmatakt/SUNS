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
#endregion

namespace zadanie_1.Networks
{
    class RbfNetwork
    {
        private RBFNetwork network;
        private Function1D function;
        private double[] result;

        public RbfNetwork(Function1D function)
        {
            this.function = function;

            //Specify the number of dimensions and the number of neurons per dimension
            int dimensions = 1;
            // could be also 16, 64, 256. I suppose it should accept 8, 32 but it needs additional investigation
            int numNeuronsPerDimension = 4;
            //Set the standard RBF neuron width. 
            //Literature seems to suggest this is a good default value.
            double volumeNeuronWidth = 2.0 / numNeuronsPerDimension;
            //RBF can struggle when it comes to flats at the edge of the sample space.
            //We have added the ability to include wider neurons on the sample space boundary which greatly
            //improves fitting to flats
            bool includeEdgeRBFs = true;

            network = new RBFNetwork(dimensions, numNeuronsPerDimension, 1, RBFEnum.Gaussian);
            network.SetRBFCentersAndWidthsEqualSpacing(0, 1, RBFEnum.Gaussian, volumeNeuronWidth, includeEdgeRBFs);
        }

        public void TrainNetwork()
        {
            INeuralDataSet trainingSet = DataManipulation.GetNeuralDataSetFromOneDimensionalArrays(function.GetFInput(), function.GetFIdeal());
            SVDTraining train = new SVDTraining(network, trainingSet);
        }
    }
}
