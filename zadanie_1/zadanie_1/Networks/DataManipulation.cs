//https://github.com/encog/encog-dotnet-core/blob/master/encog-core-cs/Util/NetworkUtil/TrainerHelper.cs

using System;
using System.Linq;

using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.Data.Basic;
using Encog.Neural.NeuralData;

using zadanie_1.Enums;

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

        public static IMLDataSet GetBasicDataSetFromOneDimensionalArrays(byte[] input, byte[] ideal, bool normalizeData = true)
        {
            var result = new BasicMLDataSet();
            var minInput = 0;
            var maxInput = 255;
            var minIdeal = 0;
            var maxIdeal = 255;

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

        /// <summary>
        /// Metoda prebere sirku a vysku vstupneho obrazku a 1D pole bajtov reprezentujuce obrazok 
        /// a vrati i 2D poli (3D pole) reprezentujuce obrazok rozdeleny na 8x8 polia
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[][][] DividePicture(byte[] arr, int width, int height)
        {
            byte[][][] dividedPicture;
            int cx = width / 8;
            int cy = height / 8;
            int countInSquare = 64;
            int countInRow = 8;

            //alokacia potrebnej pamate
            dividedPicture = new byte[cx * cy][][];
            for (int i = 0; i < dividedPicture.Length; i++)
            {
                dividedPicture[i] = new byte[countInRow][];
                for (int j = 0; j < countInRow; j++)
                    dividedPicture[i][j] = new byte[countInRow];
            }

            // rozdelenie 1D pola na 2D pole s 8x8 polickami
            for (int i = 0; i < cx * cy; i++)
            {
                int start = (i - (i % cx)) * countInSquare + (i % cx) * countInRow;
                for (int y = 0; y < countInRow; y++)
                    for (int x = 0; x < countInRow; x++)
                        dividedPicture[i][x][y] = arr[start + x + y * width];
            }

            return dividedPicture;
        }

        /// <summary>
        /// Metoda preberie obrazok rozdeleny na x-2D poli (3D pole) a vrati obrazok ulozeny vo forme 1D pola.
        /// </summary>
        /// <param name="dividedPicture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] GetPictureArrayFrom3D(byte[][][] dividedPicture, int width, int height)
        {
            int cx = width / 8;
            int cy = height / 8;
            int countInRow = 8;
            byte[] result = new byte[width * height];

            int index = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int i = x / countInRow + (y / countInRow) * cx;
                    result[index++] = dividedPicture[i][x % countInRow][y % countInRow];
                }

            return result;
        }

        public static byte[] Get1DArrayFrom2DArray(byte[][] array2D, int width, int height)
        {
            byte[] result = new byte[width * height];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    result[x + y * width] = array2D[x][y];

            return result;
        }

        public static ActivationFunctionEnum GetActivationFunctionEnum(string functionName)
        {
            switch (functionName)
            {
                case ActivationFunctionStrings.ActivationSigmoid:
                    return ActivationFunctionEnum.ActivationSigmoid;
                case ActivationFunctionStrings.ActivationTanh:
                    return ActivationFunctionEnum.ActivationTanh;
                case ActivationFunctionStrings.ActivationSin:
                    return ActivationFunctionEnum.ActivationSin;
                case ActivationFunctionStrings.ActivationRamp:
                    return ActivationFunctionEnum.ActivationRamp;
                default:
                    return ActivationFunctionEnum.ActivationSigmoid;
            }
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
