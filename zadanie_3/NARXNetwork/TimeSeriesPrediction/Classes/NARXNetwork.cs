#region Zdroje
//  https://github.com/encog/encog-dotnet-core/blob/master/ConsoleExamples/Examples/Predict/PredictSunspot.cs
//  http://stackoverflow.com/questions/26853922/encog-earlystoppingstrategy-with-validation-set
//  (1) Programming Neural Networks with Encog3 in C# (Jeff Heaton)
#endregion

using System;

#region encog
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Data.Temporal;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Util;
using Encog.Util.Arrayutil;
using Encog.ML.Train.Strategy;
#endregion
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



namespace TimeSeriesPrediction.Classes
{
    class NARXNetwork
    {
        private const int WindowSize = 5;
        private TimeSeriesData timeSeriesData = new TimeSeriesData();

        private IMLDataSet trainingSet;
        private IMLDataSet validationSet;
        private IMLDataSet testSet;
        private BasicNetwork network;
        
        public NARXNetwork()
        {
            //TODO: Doplnit konstruktor
            network = CreateNetwork();
            var arr = timeSeriesData.ReturnSet("TrainingSet");
            trainingSet = GenerateDataSet(timeSeriesData.ReturnSet("TrainingSet"));
            validationSet = GenerateDataSet(timeSeriesData.ReturnSet("ValidationSet"));

            System.Diagnostics.Debug.Assert(timeSeriesData.ReturnSet("TrainingSet").Length == trainingSet.Count + WindowSize + 1,
                "Lengths of training sets are not the same!");
            System.Diagnostics.Debug.Assert(timeSeriesData.ReturnSet("ValidationSet").Length == validationSet.Count + WindowSize + 1,
                "Lengths of validation sets are not the same!");

            TrainNetwork();
        }

        private BasicNetwork CreateNetwork()
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(WindowSize));
            network.AddLayer(new BasicLayer(10));
            network.AddLayer(new BasicLayer(1));
            network.Structure.FinalizeStructure();
            network.Reset();
            return network;
        }

        private IMLDataSet GenerateDataSet(double[] data)
        {
            //  TemporalMLDataSet(inputWindowSize, predictWindowSize)
            var result = new TemporalMLDataSet(WindowSize, 1);

            //  (1) pages 128, 132
            var description = new TemporalDataDescription(TemporalDataDescription.Type.Raw, true, true);
            result.AddDescription(description);

            //  alebo i = WindowsSize???
            for (int i = 0; i < data.Length; i++)
            {
                var point = new TemporalPoint(1) { Sequence = i };
                point.Data[0] = data[i];
                result.Points.Add(point);
            }

            result.Generate();

            return result;
        }

        private void TrainNetwork()
        {
            EarlyStoppingStrategy strategy = new EarlyStoppingStrategy(validationSet, trainingSet);
            ITrain training = new ResilientPropagation(network, trainingSet);
            training.AddStrategy(strategy);

            int epoch = 1;
            //  (1) page 112, 113
            while(!strategy.ShouldStop())
            {
                training.Iteration();   // weights are updated here
                System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error: " + training.Error
                    + @"Validation Error: " + network.CalculateError(validationSet));
                epoch++;
            }
        }
    }
}
