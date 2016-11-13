using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Encog.MathUtil;
using Encog.MathUtil.Randomize;
using Encog.MathUtil.RBF;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.SOM;
using Encog.Neural.SOM.Training.Neighborhood;

namespace SOMnetwork.Classes
{
    class KohonensMap
    {
        private double hexRadius = 10;
        private int gridWidth;
        private int gridHeight;
        private int iterationCount;
        private int numberOfChars;
        private bool jetScale;

        private readonly INeighborhoodFunction gaussian;
        private readonly Encog.Neural.SOM.SOMNetwork network;
        private readonly IList<IMLData> samples;
        private readonly BasicTrainSOM train;
        private int iteration;
        private HexGrid hexGrid;
        DataLoader dataLoader;

        public KohonensMap(int gridWidth, int gridHeight, int iterationCount, int numberOfChars,
            int windowWidth, int windowHeight, bool jetScale)
        {
            var dx = windowWidth / ((double)gridWidth * 4);
            hexRadius = dx / Math.Cos(Math.PI / 6.0d);

            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            this.iterationCount = iterationCount;
            this.numberOfChars = numberOfChars;
            this.jetScale = jetScale;

            dataLoader = new DataLoader();
            network = CreateNetwork();
            gaussian = new NeighborhoodRBF(RBFEnum.Gaussian, gridWidth, gridHeight);
            train = new BasicTrainSOM(network, 0.01, null, gaussian);
            samples = new List<IMLData>();

            train.ForceWinner = false;

            for (int wantedCharacter = 1; wantedCharacter <= numberOfChars; wantedCharacter++)
            {
                for (int j = 0; j < 15; j++)
                {
                    var dataRow = dataLoader.ReturnDataRow(wantedCharacter);
                    var data = new BasicMLData(dataRow.Length);
                    for (int k = 0; k < dataRow.Length; k++)
                    {
                        data.Data[k] = dataRow[k];
                    }
                    samples.Add(data);
                }
            }

            train.SetAutoDecay(iterationCount, 0.8, 0.003, gridWidth/2.0d, 1.0d);
        }

        private Encog.Neural.SOM.SOMNetwork CreateNetwork()
        {
            var result = new Encog.Neural.SOM.SOMNetwork(327, gridWidth * gridHeight);
            result.Reset();
            return result;
        }

        public void TrainNetwork()
        {
            for (int i = 0; i < iterationCount; i++)
            {
                var tmp = ThreadSafeRandom.NextDouble();
                var idx = (int)(tmp * samples.Count);
                IMLData c = samples[idx];

                train.TrainPattern(c);
                train.AutoDecay();
                if (i % 50 == 0)
                    System.Diagnostics.Debug.WriteLine("Iteration n.{0}: " + train.ToString(), i);
            }
        }

        public void TrainNetwork(Graphics g, System.Windows.Forms.Timer updateTimer, int frameRate)
        {
            iteration++;
            if (iteration > iterationCount)
                updateTimer.Enabled = false;

            var tmp = ThreadSafeRandom.NextDouble();
            var idx = (int)(tmp * samples.Count);
            IMLData c = samples[idx];

            train.TrainPattern(c);
            train.AutoDecay();
            if(iteration % frameRate == 0)
            {
                Color.FromName("Control");
                GenerateHexGrid();
                VisualizeUMatrix(g);
            }
            
            if (iteration % 50 == 0)
            {
                System.Diagnostics.Debug.WriteLine("Iteration n.{0}:" + iteration);
            }
        }

        public void GenerateHexGrid()
        {
            hexGrid = new HexGrid();
            hexGrid.GenerateGrid(new PointF((float)hexRadius, (float)hexRadius), gridWidth, gridHeight,
                hexRadius, network.Weights.Data, jetScale);
        }

        public void VisualizeUMatrix(Graphics g)
        {
            hexGrid.DrawGrid(g);
        }
    }
}
