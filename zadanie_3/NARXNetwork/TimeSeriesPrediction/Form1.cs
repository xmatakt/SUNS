using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GraphLib;

using TimeSeriesPrediction.Classes;

namespace TimeSeriesPrediction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //NARXNetwork net = new NARXNetwork();
            display.DataSources.Add(new DataSource());
            display.DataSources[0].Name = "Pokusny graf1";
            display.DataSources[0].GraphColor = Color.Green;
            //display.DataSources[0].AutoScaleX = true;
            display.DataSources[0].AutoScaleY = true;
            display.DataSources[0].Length = 500;

            for (int i = 0; i < display.DataSources[0].Length; i++)
            {
                display.DataSources[0].Samples[i].x = i;
                display.DataSources[0].Samples[i].y = (float)Math.Sin(i);
            }

            display.DataSources.Add(new DataSource());
            display.DataSources[1].Name = "Pokusny graf2";
            display.DataSources[1].GraphColor = Color.Red;
            //display.DataSources[0].AutoScaleX = true;
            display.DataSources[1].AutoScaleY = true;
            display.DataSources[1].Length = 500;

            for (int i = 0; i < display.DataSources[1].Length; i++)
            {
                display.DataSources[1].Samples[i].x = i;
                display.DataSources[1].Samples[i].y = (float)Math.Cos(i);
            }

            display.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
