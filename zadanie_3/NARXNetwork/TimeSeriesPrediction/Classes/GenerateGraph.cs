using System;

using GraphLib;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeSeriesPrediction.Classes
{
    static class GenerateGraph
    {
        public static void AddDisplayDataSource(PlotterDisplayEx display, string graphName,
            System.Drawing.Color graphColor, double[] data, int xOffset, bool ClearDataSources = false)
        {
            if (ClearDataSources)
                display.DataSources.Clear();

            int sourcesCount = display.DataSources.Count;
            display.DataSources.Add(new DataSource());
            display.DataSources[sourcesCount].Name = graphName;
            //display.DataSources[sourcesCount].OnRenderXAxisLabel += RenderXLabel;
            display.DataSources[sourcesCount].GraphColor = graphColor;
            display.DataSources[sourcesCount].AutoScaleY = false;
            display.DataSources[sourcesCount].SetGridDistanceY(1);
            display.DataSources[sourcesCount].SetGridOriginY(0.0f);
            display.DataSources[sourcesCount].SetDisplayRangeY((float)data.Min(), (float)data.Max());
            //display.DataSources[sourcesCount].SetDisplayRangeY(0.0f, 0.5f);
            //display.DataSources[0].AutoScaleX = true;
            //display.DataSources[sourcesCount].AutoScaleY = true;
            display.DataSources[sourcesCount].Length = data.Length;

            for (int i = 0; i < display.DataSources[sourcesCount].Length; i++)
            {
                display.DataSources[sourcesCount].Samples[i].x = i + xOffset;
                display.DataSources[sourcesCount].Samples[i].y = (float)data[i];
            }

            display.Refresh();
        }

        private static String RenderXLabel(DataSource s, int idx)
        {
            if (s.AutoScaleX)
            {
                //if (idx % 2 == 0)
                {
                    int Value = (int)(s.Samples[idx].x);
                    return "" + Value;
                }
            }
            else
            {
                int Value = (int)(s.Samples[idx].x / 200);
                String Label = "" + Value + "\"";
                return Label;
            }
        }
    }
}
