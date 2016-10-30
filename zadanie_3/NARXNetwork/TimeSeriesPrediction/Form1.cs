//  http://www.codeproject.com/Articles/5431/A-flexible-charting-library-for-NET

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
using ZedGraph;

using TimeSeriesPrediction.Classes;
using TimeSeriesPrediction.Forms;
using TimeSeriesPrediction.Enumerations;

namespace TimeSeriesPrediction
{
    public partial class Form1 : Form
    {
        ErrorForm errorForm;
        BigGraphForm bigForm;
        NARXNetwork net;

        public Form1()
        {
            InitializeComponent();

            errorForm = new ErrorForm();
            bigForm = new BigGraphForm();
            net = new NARXNetwork();

            //  ERROR DISPLAY
            GenerateGraph.SetZedGraph(errorForm.zedGraph_error, "TRAINING ERRORS", --net.EpochCount + " Epochs", "Mean Squared Error (mse)", true);
            GenerateGraph.AddCurveToZedGraph(errorForm.zedGraph_error, "Training MSE", SymbolType.None, Color.Red, net.GetTrainingTestError(), 0);
            GenerateGraph.AddCurveToZedGraph(errorForm.zedGraph_error, "Validation MSE", SymbolType.None, Color.Blue, net.GetValidationError(), 0);

            //  USED DATA DISPLAY
            GenerateGraph.SetZedGraph(zedGraph_all, "USED DATA", "X AXIS", "Y AXIS");

            GenerateGraph.AddCurveToZedGraph(zedGraph_all, "Training set", SymbolType.None,
                Color.Red, net.GetTimeSeriesData(SetTypeEnum.TrainingSet), 0);
            GenerateGraph.AddCurveToZedGraph(zedGraph_all, "Validation set", SymbolType.None,
               Color.Green, net.GetTimeSeriesData(SetTypeEnum.ValidationSet), 900);
            GenerateGraph.AddCurveToZedGraph(zedGraph_all, "Test set", SymbolType.None,
             Color.Blue, net.GetTimeSeriesData(SetTypeEnum.TestSet), 1000);

            //  SERIES-PARALLEL PREDICTION GRAPH
            GenerateGraph.SetZedGraph(zedGraph_serial, "SERIES-PARALLEL PREDICTION GRAPH", "X AXIS","Y AXIS");

            GenerateGraph.AddCurveToZedGraph(zedGraph_serial, "Original", SymbolType.None, 
                Color.LightBlue, net.GetTimeSeriesData(SetTypeEnum.TestSet), 0);
            GenerateGraph.AddCurveToZedGraph(zedGraph_serial, "Predicted", SymbolType.None,
                Color.DarkRed, net.GetPredictedData(), 0);
            //GenerateGraph.AddCurveToZedGraph(zedGraph_serial, "Error", SymbolType.None,
            //    Color.OrangeRed, net.GetPredictedData(), net.GetTimeSeriesData(SetTypeEnum.TestSet), 0);

            //  PARALLEL (LOOPED) PREDICTION
            GenerateGraph.SetZedGraph(zedGraph_looped, "PARALLEL (LOOPED) PREDICTION", "X AXIS", "Y AXIS");

            GenerateGraph.AddCurveToZedGraph(zedGraph_looped, "Original", SymbolType.None,
                Color.LightBlue, net.GetTimeSeriesData(SetTypeEnum.ClosedLoopSet), 0);
            GenerateGraph.AddCurveToZedGraph(zedGraph_looped, "Predicted", SymbolType.None,
            Color.DarkRed, net.GetPredictedLoopedData(), 0);
            //GenerateGraph.AddCurveToZedGraph(zedGraph_looped, "Error", SymbolType.None,
            //    Color.OrangeRed, net.GetTimeSeriesData(SetTypeEnum.ClosedLoopSet), net.GetPredictedLoopedData(), 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void zedGraph_all_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                if (errorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };
            if (e.KeyCode == Keys.F2)
            {
                bigForm.zedGraph_error.GraphPane.CurveList.Clear();
                GenerateGraph.CopyZedPane(zedGraph_all.GraphPane, bigForm.zedGraph_main.GraphPane, bigForm);
                if (bigForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };
            }
        }

        private void zedGraph_serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                if (errorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };
            if (e.KeyCode == Keys.F2)
            {
                GenerateGraph.CopyZedPane(zedGraph_serial.GraphPane, bigForm.zedGraph_main.GraphPane, bigForm);

                bigForm.zedGraph_error.GraphPane.CurveList.Clear();
                GenerateGraph.SetZedGraph(bigForm.zedGraph_error, "", "Time", "Error");
                GenerateGraph.AddErrorToZedGraph(bigForm.zedGraph_error, "Error", SymbolType.Circle, Color.OrangeRed,
                    net.GetTimeSeriesData(SetTypeEnum.TestSet), net.GetPredictedData(), 0);
                if (bigForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };
            }
        }

        private void zedGraph_looped_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                if (errorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };

            if(e.KeyCode == Keys.F2)
            {
                GenerateGraph.CopyZedPane(zedGraph_looped.GraphPane, bigForm.zedGraph_main.GraphPane, bigForm);

                bigForm.zedGraph_error.GraphPane.CurveList.Clear();
                GenerateGraph.SetZedGraph(bigForm.zedGraph_error, "", "Time", "Error");
                GenerateGraph.AddErrorToZedGraph(bigForm.zedGraph_error, "Error", SymbolType.Circle, Color.OrangeRed,
                    net.GetTimeSeriesData(SetTypeEnum.ClosedLoopSet), net.GetPredictedLoopedData(), 0);
                if (bigForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { };
            }
        }
    }
}
