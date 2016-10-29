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

            //TimeSeriesData sd = new TimeSeriesData();
            display.DataSources.Add(new DataSource());
            display.DataSources[0].Name = "Pokusny graf";
            display.DataSources[0].GraphColor = Color.Green;
            //display.DataSources[0].AutoScaleX = true;
            display.DataSources[0].AutoScaleY = true;
            display.DataSources[0].Length = 500;

            for (int i = 0; i < display.DataSources[0].Length; i++)
            {
                display.DataSources[0].Samples[i].x = i;
                display.DataSources[0].Samples[i].y = (float)Math.Sin(i);
            }

            display.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
