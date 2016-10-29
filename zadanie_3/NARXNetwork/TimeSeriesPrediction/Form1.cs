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
using TimeSeriesPrediction.Forms;
using TimeSeriesPrediction.Enumerations;

namespace TimeSeriesPrediction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ErrorForm errorForm = new ErrorForm();

            display_all.SetDisplayRangeX(0, 100);
            display_all.SetGridOriginX(0.0f);
            display_all.SetGridDistanceX(100);
            display_all.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
            display_all.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;

            NARXNetwork net = new NARXNetwork();

            //  ERROR DISPLAY
            GenerateGraph.AddDisplayDataSource(errorForm.display, "Training error", Color.Red, net.GetTrainingTestError(), 0);
            GenerateGraph.AddDisplayDataSource(errorForm.display, "Validation error", Color.Blue, net.GetValidationError(), 0);
            errorForm.Show();

            //  USED DATA DISPLAY
            GenerateGraph.AddDisplayDataSource(display_all, "Training", Color.Red, net.GetTimeSeriesData(SetTypeEnum.TrainingSet), 0);
            GenerateGraph.AddDisplayDataSource(display_all, "Validation", Color.Green, net.GetTimeSeriesData(SetTypeEnum.ValidationSet), 900);
            GenerateGraph.AddDisplayDataSource(display_all, "Test", Color.Blue, net.GetTimeSeriesData(SetTypeEnum.TestSet), 1000);

            //  SERIES-PARALLEL PREDICTION GRAPH
            GenerateGraph.AddDisplayDataSource(display_prediction, "Original", Color.DarkBlue, net.GetTimeSeriesData(SetTypeEnum.TestSet), 0);
            GenerateGraph.AddDisplayDataSource(display_prediction, "Predicted", Color.DarkRed, net.GetPredictedData(), 0);

            //  PARALLEL (LOOPED) PREDICTION
            GenerateGraph.AddDisplayDataSource(display_loopPrediction, "Original", Color.DarkBlue, net.GetTimeSeriesData(SetTypeEnum.ClosedLoopSet), 0);
            GenerateGraph.AddDisplayDataSource(display_loopPrediction, "Looped", Color.DarkRed, net.GetPredictedLoopedData(), 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
