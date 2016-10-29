using System;

using GraphLib;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeSeriesPrediction.Classes
{
    static class GenerateGraph
    {
        public static void AddDisplayDataSource(PlotterDisplayEx display, string graphName,
            System.Drawing.Color graphColor, double[] data)
        {
            int sourcesCount = display.DataSources.Count;
            display.DataSources.Add(new DataSource());
            display.DataSources[sourcesCount].Name = graphName;
            display.DataSources[sourcesCount].GraphColor = graphColor;
            //display.DataSources[0].AutoScaleX = true;
            display.DataSources[sourcesCount].AutoScaleY = true;
            display.DataSources[sourcesCount].Length = data.Length;

            for (int i = 0; i < display.DataSources[sourcesCount].Length; i++)
            {
                display.DataSources[sourcesCount].Samples[i].x = i;
                display.DataSources[sourcesCount].Samples[i].y = (float)data[i];
            }

            display.Refresh();
        }
    }
}
