using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace zadanie_1.Forms
{
    public partial class PictureCompressionForm : Form
    {
        private string trainFile = "";
        private string testFile = "";
        private byte[][][] dividedTrainPicture; 

        public PictureCompressionForm()
        {
            InitializeComponent();
            //Tmp();
        }

        private void DividePicture(byte[] arr, int width, int height)
        {
            StreamWriter sw = new StreamWriter("output2D.pgm");
            sw.WriteLine("P2");
            sw.WriteLine(width + " " + height);
            sw.WriteLine("255");

            int cx = width / 8;
            int cy = height / 8;
            int countInSquare = 64;
            int countInRow = 8;

            //alokacia potrebnej pamate
            dividedTrainPicture = new byte[cx * cy][][];
            for (int i = 0; i < dividedTrainPicture.Length; i++)
            {
                dividedTrainPicture[i] = new byte[countInRow][];
                for (int j = 0; j < countInRow; j++)
                    dividedTrainPicture[i][j] = new byte[countInRow];
            }

            // rozdelenie 1D pola na 2D pole s 8x8 polickami
            for (int i = 0; i < cx * cy; i++) 
            {
                int start = (i - (i % cx)) * countInSquare + (i % cx) * countInRow;
                for (int y = 0; y < countInRow; y++)
                    for (int x = 0; x < countInRow; x++)
                        dividedTrainPicture[i][x][y] = arr[start + x + y * width];
            }

            //z mnoho 2D na jeden 1D
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int i = x / countInRow + (y / countInRow) * cx;
                    sw.WriteLine(dividedTrainPicture[i][x % countInRow][y % countInRow]);
                }
            }    

            sw.Flush();
            sw.Close();
        }

        private void loadTrainData_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trainFile = openFileDialog.FileName;
                Bitmap bitmap = new Bitmap(trainFile);
                byte[] arr = new byte[bitmap.Width * bitmap.Height];

                StreamWriter sw = new StreamWriter("output.pgm");

                sw.WriteLine("P2");
                sw.WriteLine(bitmap.Width + " " + bitmap.Height);
                sw.WriteLine("255");
                int index = 0;

                for (int i = 0; i < bitmap.Height; i++)
                    for (int j = 0; j < bitmap.Width; j++)
                        arr[index++] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).G + bitmap.GetPixel(j, i).B) / 3);

                for (int i = 0; i < arr.Length; i++)
                {
                    sw.Write("{0} ", arr[i]);
                    if (i != 0 && i % bitmap.Width == 0)
                        sw.WriteLine("");
                }

                sw.Flush();
                sw.Close();

                DividePicture(arr, bitmap.Width, bitmap.Height);
            }
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            //return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
