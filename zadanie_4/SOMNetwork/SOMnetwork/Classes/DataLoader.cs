using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SOMnetwork.Classes
{
    class DataLoader
    {
        public double[][] Znaky;
        public int[] Oznacenia;

        public DataLoader()
        {
            try
            {
                string[] znaky = File.ReadAllLines(@"..\..\Data\znaky.dat");
                string[] oznacenia = File.ReadAllLines(@"..\..\Data\znaky-oznacenia.dat");

                Znaky = new double[znaky.Length][];
                Oznacenia = new int[oznacenia.Length];

                for (int i = 0; i < oznacenia.Length; i++)
                {
                    Oznacenia[i] = Convert.ToInt32(oznacenia[i]);
                    string[] splittedLine = znaky[i].Split(',');
                    Znaky[i] = new double[splittedLine.Length];
                    for (int j = 0; j < splittedLine.Length; j++)
                    {
                        Znaky[i][j] = Convert.ToDouble(splittedLine[j], System.Globalization.CultureInfo.InvariantCulture);
                    }
                    NormalizeData(Znaky[i]);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //vrati random riadok s pozadovanym znakom
        public double[] ReturnDataRow(int character)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            var index = rand.Next(0, Oznacenia.Length - 1);
            while (Oznacenia[index] != character)
            {
                index = rand.Next(0, Oznacenia.Length - 1);
            }

            return Znaky[index];
        }

        private void NormalizeData(double[] data)
        {
            var min = data.Min();
            var max = data.Max();
            var a = 2.0d / (double)(max - min);
            var b = -1 - 2.0d * min / (double)(max - min);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = a * data[i] + b;
                if (data[i] < -1.0d)
                    data[i] = -1.0d;
                if (data[i] > 1.0d)
                    data[i] = 1.0d;
            }
        }
    }
}
