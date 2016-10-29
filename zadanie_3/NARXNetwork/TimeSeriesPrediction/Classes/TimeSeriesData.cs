using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeSeriesPrediction.Classes
{
    class TimeSeriesData
    {
        private const int trainingSetLength = 900;
        private const int validationSetLength = 100;
        private const int testSetLength = 500;
        private double min;
        private double max;
        private int startPoint;
        private double[] allData;
        private double[] trainigSet = new double[trainingSetLength];
        private double[] validationSet = new double[validationSetLength];
        private double[] testSet = new double[testSetLength];
        private double[] closedLoopTestSet = new double[testSetLength];

        public TimeSeriesData()
        {
            GetDataFromResource();
            FillSets();
            NormalizeArrays();
        }

        public double[] ReturnSet(string dataSet)
        {
            switch (dataSet)
            {
                case "TrainingSet":
                    return trainigSet;
                case "ValidationSet":
                    return validationSet;
                case "TestSet":
                    return testSet;
                default:
                    return null;
            }
        }

        private void GetDataFromResource()
        {
            var listOfNumbers = new List<double>();
            foreach (var number in TimeSeriesPrediction.Properties.Resources.trace.Split('\n'))
            {
                listOfNumbers.Add(Convert.ToDouble(number));
            }
            allData = listOfNumbers.ToArray();
            min = allData.Min();
            max = allData.Max();
        }

        /// <summary>
        /// V metode sa vygeneruje nahodne cislo z intervalu [0, 199255-1500] a naplnia sa jednotlive dataSety.
        /// Data sety budu na seba plynulo nadvazovat (bez prienikov)
        /// </summary>
        private void FillSets()
        {
            startPoint = new Random().Next(0, allData.Length -
                (trainingSetLength + validationSetLength + testSetLength));

            for (int i = 0; i < trainingSetLength; i++)
                trainigSet[i] = allData[startPoint + i];

            for (int i = 0; i < validationSetLength; i++)
                validationSet[i] = allData[startPoint + trainingSetLength + i];

            for (int i = 0; i < testSetLength; i++)
                testSet[i] = allData[startPoint + trainingSetLength + validationSetLength + i];
        }

        private void NormalizeArray(double[] data)
        {
            double a = 1.0d / (double)(max - min);
            double b = -a * min;

            for (int i = 0; i < data.Length; i++)
                data[i] = a * data[i] + b;
        }

        private void NormalizeArrays()
        {
            NormalizeArray(trainigSet);
            NormalizeArray(validationSet);
            NormalizeArray(testSet);
        }
    }
}
