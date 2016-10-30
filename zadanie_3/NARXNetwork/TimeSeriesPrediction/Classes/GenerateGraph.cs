using System;

using GraphLib;
using ZedGraph;
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

        public static void SetZedGraph(ZedGraphControl zgc, string graphName, string xAxisLabel, string yAxisLabel,
            bool IsLogAxis = false)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = graphName;
            myPane.XAxis.Title.Text = xAxisLabel;
            myPane.YAxis.Title.Text = yAxisLabel;

            if (IsLogAxis)
                myPane.YAxis.Type = AxisType.Log;

            // Add gridlines to the plot, and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = System.Drawing.Color.Black;
            myPane.YAxis.MajorGrid.Color = System.Drawing.Color.Black;
        }
         
        public static void AddCurveToZedGraph(ZedGraphControl zgc, string label, SymbolType symbol,
            System.Drawing.Color graphColor, double[] data, int xOffset)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            double x, y1;
            PointPairList list = new PointPairList();

            for (int i = 0; i < data.Length; i++)
            {
                x = i + xOffset;
                y1 = data[i];
                list.Add(x, y1);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve(label,
                  list, graphColor, symbol);

            //myCurve.Line.Fill = new Fill(System.Drawing.Color.White, graphColor, 45F);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }
    }
}
