//https://github.com/encog/encog-dotnet-core/blob/master/encog-core-cs/Util/NetworkUtil/TrainerHelper.cs

using System;
using System.Linq;

using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.Data.Basic;
using Encog.Neural.NeuralData;

namespace zadanie_1.Networks
{
    static class DataManipulation
    {
        /// <summary>
        /// Method returns IMLDataSet from input and ideal double[] arrays.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <param name="ideal">The ideal data.</param>
        /// <param name="normalizeData">Indicates whether the data should be normalized.</param>
        /// <returns></returns>
        public static IMLDataSet GetBasicDataSetFromOneDimensionalArrays(double[] input, double[] ideal, bool normalizeData = true)
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

        public static INeuralDataSet GetNeuralDataSetFromOneDimensionalArrays(double[] input, double[] ideal, bool normalizeData = true)
        {
            var dataInput = GetNormalized2DData(input);
            var dataIdeal = GetNormalized2DData(ideal);

            return new BasicNeuralDataSet(dataInput, dataIdeal);
        }

        #region Data normalization
        public static double[][] GetNormalized2DData(double[] data)
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

        public static double[] GetNormalized1DData(double[] data)
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

        public static double[] GetNormalized1DData(double data, double min, double max, bool normalizeData = true)
        {
            //mapovanie na [-1,1]
            //double a = 2.0d / (double)(max - min);
            //double b = -a * min - 1;

            //mapovanie na [0,1]
            double a = 1.0d, b = 1.0d;
            if (normalizeData)
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
