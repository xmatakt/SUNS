#region Zdroje
//  https://github.com/encog/encog-dotnet-core/blob/master/ConsoleExamples/Examples/Predict/PredictSunspot.cs
//  http://stackoverflow.com/questions/26853922/encog-earlystoppingstrategy-with-validation-set
//  (1) Programming Neural Networks with Encog3 in C# (Jeff Heaton)
#endregion

using System;

#region encog
using Encog.ML.Data;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog.ML.Data.Temporal;
using Encog.Neural.Networks;
using Encog.Engine.Network.Activation;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Strategy;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Util;
using Encog.Util.Arrayutil;
using Encog.ML.Train.Strategy;
using Encog.Neural.Networks.Training.Anneal;
#endregion
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using TimeSeriesPrediction.Enumerations;

namespace TimeSeriesPrediction.Classes
{
    class NARXNetwork
    {
        private const int WindowSize = 30;
        private TimeSeriesData timeSeriesData = new TimeSeriesData();
        public int EpochCount { get; set; }

        private IMLDataSet trainingSet;
        private IMLDataSet validationSet;
        private List<double> trainingError;
        private List<double> validationError;
        private List<double> predictionList;
        private List<double> loopedPredictionList;

        private BasicNetwork network;
        
        public NARXNetwork()
        {
            //TODO: Doplnit konstruktor
            EpochCount = 1;
            trainingError = new List<double>();
            validationError = new List<double>();
            predictionList = new List<double>();
            loopedPredictionList = new List<double>();

            network = CreateNetwork();
   
            trainingSet = GenerateDataSet(timeSeriesData.ReturnSet(SetTypeEnum.TrainingSet));
            validationSet = GenerateDataSet(timeSeriesData.ReturnSet(SetTypeEnum.ValidationSet));

            TrainNetwork();
            PredictData();
            PredictLoopedData();
        }

        public double[] GetTimeSeriesData(SetTypeEnum dataSetType) { return timeSeriesData.ReturnSet(dataSetType); }

        public double[] GetTrainingTestError() { return trainingError.ToArray(); }

        public double[] GetValidationError() { return validationError.ToArray(); }

        public double[] GetPredictedData() { return predictionList.ToArray(); }

        public double[] GetPredictedLoopedData() { return loopedPredictionList.ToArray(); }

        private BasicNetwork CreateNetwork()
        {
            var network = new BasicNetwork();

            //network.AddLayer(new BasicLayer(WindowSize));
            //network.AddLayer(new BasicLayer(100));
            //network.AddLayer(new BasicLayer(1));

            network.AddLayer(new BasicLayer(null, true, WindowSize));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 100));
            network.AddLayer(new BasicLayer(new ActivationLinear(), false, 1));

            //network.AddLayer(new BasicLayer(null, true, WindowSize));
            //network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));
            //network.AddLayer(new BasicLayer(new ActivationTANH(), true, 10));
            ////network.AddLayer(new BasicLayer(17));
            //network.AddLayer(new BasicLayer(new ActivationLinear(), false, 1));
            
            
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
            for (int i = WindowSize; i < data.Length; i++)
            {
                var point = new TemporalPoint(1) { Sequence = i };
                point.Data[0] = data[i];
                result.Points.Add(point);
            }

            result.Generate();

            return result;
        }

        //  (1) page 112, 113
        private void TrainNetwork()
        {
            EarlyStoppingStrategy strategy = new EarlyStoppingStrategy(validationSet, trainingSet);
            //Backpropagation training = new Backpropagation(network, trainingSet);
            //training.AddStrategy(new SmartMomentum());
            //training.AddStrategy(new SmartLearningRate());
            ITrain training = new ResilientPropagation(network, trainingSet);
            training.AddStrategy(strategy);

            while (!strategy.ShouldStop() && EpochCount <= 1000)
            {
                training.Iteration();   // weights are updated here
                double validationErr = network.CalculateError(validationSet);
                System.Diagnostics.Debug.WriteLine(@"Epoch #" + EpochCount + @" Error: " + training.Error
                    + @" Validation Error: " + validationErr);
                trainingError.Add(training.Error);
                validationError.Add(validationErr);
                EpochCount++;
            }
        }

        private void PredictData()
        {
            int testSetLength = timeSeriesData.GetTestSetLength();
            int startPoint = timeSeriesData.GetStartPoint() + timeSeriesData.GetTrainingSetLength()+
                timeSeriesData.GetValidationSetLength();
            var data = timeSeriesData.ReturnSet(SetTypeEnum.AllData);

            for (int i = startPoint; i < startPoint + testSetLength; i++)
            {
                var input = new BasicMLData(WindowSize);
                for (int j = 0; j < WindowSize; j++)
                    input[j] = data[i - WindowSize + j];

                predictionList.Add(network.Compute(input)[0]);
            }
        }

        private void PredictLoopedData()
        {
            int setLength = timeSeriesData.GetClosedLoopSetLength();
            int startPoint = timeSeriesData.GetLoopedStartPoint();
            var data = timeSeriesData.ReturnSet(SetTypeEnum.AllData);

            //  vypocita sa predpoved pre i-tu zlozku na zaklade predchajucich 5-tich zloziek
            //  nova vypocitana zlozka nahradi i-tu zlozku a pouzije sa pre vypocet predpovede
            for (int i = startPoint; i < startPoint + setLength; i++)
            {
                var input = new BasicMLData(WindowSize);
                for (int j = 0; j < WindowSize; j++)
                    input[j] = data[i - WindowSize + j];

                IMLData output = network.Compute(input);
                data[i] = output[0];

                // calculate "closed loop", based on predicted data
                for (int j = 0; j < WindowSize; j++)
                    input[j] = data[i - WindowSize + j];

                loopedPredictionList.Add(network.Compute(input)[0]);
            }
        }
    }
}
