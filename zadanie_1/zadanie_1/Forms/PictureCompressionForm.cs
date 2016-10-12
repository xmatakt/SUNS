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

        public PictureCompressionForm()
        {
            InitializeComponent();
        }

        private void loadTrainData_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trainFile = openFileDialog.FileName;

                Bitmap bitmap = new Bitmap(trainFile);

                Image image = Image.FromFile(trainFile);
                byte[] imgArr = ImageToByteArray(image);
                byte[] newArr = new byte[256 * 256];

                StreamWriter sw = new StreamWriter("output.pgm");

                sw.WriteLine("P2");
                sw.WriteLine(image.Width + " " + image.Height);
                sw.WriteLine("255");
                int tmp = imgArr.Length - image.Width * image.Height;
                int count = 0;

                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        sw.Write(((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).G + bitmap.GetPixel(j, i).B)/3) + " ");
                        count++;
                    }
                    sw.WriteLine("");
                }

                MessageBox.Show(count.ToString());
                sw.Flush();
                sw.Close();
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
