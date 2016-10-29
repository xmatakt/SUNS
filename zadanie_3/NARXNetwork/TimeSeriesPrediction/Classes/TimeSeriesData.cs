#region Zdroje
//  https://github.com/encog/encog-dotnet-core/blob/master/ConsoleExamples/Examples/Predict/PredictSunspot.cs
//  Programming Neural Networks with Encog3 in C# (Jeff Heaton)
#endregion

using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeSeriesPrediction.Classes
{
    class TimeSeriesData
    {
        private const int trainingSetLength = 900;
        private const int validationSetLength = 100;
        private const int testSetLength = 500;
        private int startPoint;
        private int[] allData;
        private double[] trainigSet = new double[trainingSetLength];
        private double[] validationSet = new double[validationSetLength];
        private double[] testSet = new double[testSetLength];
        private double[] closedLoopTestSet = new double[testSetLength];

        public TimeSeriesData()
        {
            GetDataFromResourceFile();
            FillSets();
        }

        private void GetDataFromResourceFile()
        {
            var listOfNumbers = new List<int>();
            foreach (var number in TimeSeriesPrediction.Properties.Resources.trace.Split('\n'))
            {
                listOfNumbers.Add(Convert.ToInt32(number));
            }
            allData = listOfNumbers.ToArray();
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
    }
}
