using System;

using GraphLib;
using ZedGraph;
using TimeSeriesPrediction.Forms;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TimeSeriesPrediction.Classes
{
    static class GenerateGraph
    {

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
            System.Drawing.Color graphColor, double[] data, int xOffset, bool IsVisible = true)
        {
            GraphPane myPane = zgc.GraphPane;

            double x, y1;
            PointPairList list = new PointPairList();

            for (int i = 0; i < data.Length; i++)
            {
                x = i + xOffset;
                y1 = data[i];
                list.Add(x, y1);
            }

            LineItem myCurve = myPane.AddCurve(label,
                  list, graphColor, symbol);
            myCurve.Symbol.Size = 3.0f;
            myCurve.Line.IsVisible = IsVisible;

            zgc.AxisChange();
        }

        public static void AddCurveToZedGraph(ZedGraphControl zgc, string label, SymbolType symbol,
            System.Drawing.Color graphColor, double[] data1, double[] data2, int xOffset, bool IsVisible = true)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            double[] X = new double[data1.Length];
            double[] baseValues = new double[data1.Length];

            for (int i = 0; i < data1.Length; i++)
            {
                X[i] =  i + xOffset;
                //X[i] *= 10;
                if (data1[i] > data2[i])
                {
                    double tmp = data1[i] - data2[i];
                    tmp /= 2.0d;
                    baseValues[i] = data2[i] + tmp;
                }
                else
                {
                    double tmp = data2[i] - data1[i];
                    tmp /= 2.0d;
                    baseValues[i] = data1[i] + tmp;
                }
            }

            ErrorBarItem myBar =  myPane.AddErrorBar("Error", X, data1, baseValues, graphColor);
            myBar.Bar.Symbol.Type = symbol;
            myBar = myPane.AddErrorBar("", X, data2, baseValues, graphColor);
            myBar.Bar.Symbol.Type = symbol;

            zgc.AxisChange();
        }

        public static void AddErrorToZedGraph(ZedGraphControl zgc, string label, SymbolType symbol,
           System.Drawing.Color graphColor, double[] data1, double[] data2, int xOffset, bool IsVisible = true)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            double x, y1;
            PointPairList list = new PointPairList();

            for (int i = 0; i < data1.Length; i++)
            {
                x = i + xOffset;
                y1 = data1[i]-data2[i];
                list.Add(x, y1);
            }
            StickItem myStick = myPane.AddStick("Error", list, graphColor);
            myStick.Symbol.Type = symbol;
            myStick.Symbol.Size = 8.0f;
            myStick.Symbol.Fill = new Fill(System.Drawing.Color.Blue);

            zgc.AxisChange();
        }

        public static void CopyZedPane(GraphPane sourcePane, GraphPane targetPane, BigGraphForm bigForm)
        {
            targetPane.CurveList.Clear();

            targetPane.Title.Text = sourcePane.Title.Text;
            targetPane.XAxis.Title.Text = sourcePane.XAxis.Title.Text;
            targetPane.YAxis.Title.Text = sourcePane.YAxis.Title.Text;
            targetPane.YAxis.Type = targetPane.YAxis.Type;
            targetPane.XAxis.MajorGrid.IsVisible = sourcePane.XAxis.MajorGrid.IsVisible;
            targetPane.YAxis.MajorGrid.IsVisible = sourcePane.YAxis.MajorGrid.IsVisible;
            targetPane.XAxis.MajorGrid.Color = sourcePane.XAxis.MajorGrid.Color;
            targetPane.YAxis.MajorGrid.Color = sourcePane.YAxis.MajorGrid.Color;

            //targetPane.CurveList = sourcePane.CurveList.Clone();

            for (int i = 0; i < sourcePane.CurveList.Count; i++)
            {
                //targetPane.CurveList[i].Color = sourcePane.CurveList[i].Color;
                //targetPane.CurveList[i].IsVisible = sourcePane.CurveList[i].IsVisible;
                var sourceItem = sourcePane.CurveList[i];
    
                if(sourceItem.IsLine)
                {
                    var targetLine = (LineItem)targetPane.AddCurve(sourceItem.Label.Text, sourceItem.Points, sourceItem.Color);
                    var sourceLine = (LineItem)sourceItem;
                    targetLine.Line.IsVisible = sourceLine.Line.IsVisible;
                    targetLine.Symbol = sourceLine.Symbol;
                }
                else
                {
                    var targetBar = (ErrorBarItem)targetPane.AddErrorBar(sourceItem.Label.Text, sourceItem.Points, sourceItem.Color);
                    var sourceBar = (ErrorBarItem)sourceItem;
                    targetBar.IsVisible = sourceBar.IsVisible;
                    targetBar.Bar.Symbol = sourceBar.Bar.Symbol;
                }
            }
            bigForm.zedGraph_main.AxisChange();
        }
    }
}
