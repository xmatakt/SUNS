using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using zadanie_1.interfaces;

namespace zadanie_1.functions
{
    class Function1D : IFunctionInterface
    {
        private int pictureWidth;
        private int pictureHeight;
        private double leftBorder;
        private double rightBorder;
        private int nodesCount;
        private int trainNodesCount;
        private int testNodesCount;
        private double[] trainInput;
        private double[] trainIdeal;
        private double[] testInput;
        private double[] testIdeal;
        private double delX = -1;
        private double delY = -1;

        //private PointF[] curvePoints;

        public Function1D(double left, double right, int count, int width, int height)
        {
            leftBorder = left;
            rightBorder = right;
            pictureWidth = width;
            pictureHeight = height;

            int tmp = count % 100;
            if (tmp < 50 && count > 100)
                count -= tmp;
            else
                count += tmp;

            nodesCount = count;
            trainNodesCount = (int)(nodesCount * 0.8);
            testNodesCount = nodesCount - trainNodesCount;

            InitFunction();
        }

        public void InitFunction()
        {
            trainInput = new double[trainNodesCount + 2];
            trainIdeal = new double[trainNodesCount + 2];
            testInput = new double[testNodesCount + 1];
            testIdeal = new double[testNodesCount + 1];
            
            SwitchBorders();
            double delimeter = (rightBorder - leftBorder) / (double)nodesCount;

            int testIndex = 0;
            int trainIndex = 0;
            for (int i = 0; i <= nodesCount; i++)
            {
                if(i == 0 || i == nodesCount)
                {
                    trainInput[trainIndex] = leftBorder + i * delimeter;
                    trainIdeal[trainIndex] = Function(trainInput[trainIndex++]);
                    testInput[testIndex] = leftBorder + i * delimeter;
                    testIdeal[testIndex] = Function(testInput[testIndex++]);
                }
                else
                {
                    if (i % 5 == 0)
                    {
                        testInput[testIndex] = leftBorder + i * delimeter;
                        testIdeal[testIndex] = Function(testInput[testIndex++]);
                    }
                    else
                    {
                        trainInput[trainIndex] = leftBorder + i * delimeter;
                        trainIdeal[trainIndex] = Function(trainInput[trainIndex++]);
                    }
                }
            }

            delX = pictureWidth/(double)(2d * Math.Max(Math.Abs(leftBorder), Math.Abs(rightBorder)));
            delY = pictureHeight / (double)(2d * Math.Max(Math.Abs(trainIdeal.Min()), Math.Abs(trainIdeal.Max())));
        }

        public double Function(double x)
        {
            if (x >= -9 && x <= -3)
                return x * x + 12 * x + 36;
            if (x >= -3 && x <= 3)
                return x * x;
            if (x >= 3 && x <= 9)
                return x * x - 12 * x + 36;
            return 0;
        }

        public double[] GetTrainInput() { return trainInput; }

        public double[] GetTrainIdeal() { return trainIdeal; }

        public double[] GetTestInput() { return testInput; }

        public double[] GetTestIdeal() { return testIdeal; }

        #region Drawing
        public void DrawFunction(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            Pen pen = new Pen(Brushes.Blue);
            for (int i = 1; i < trainInput.Length; i++)
            {
                g.DrawLine(pen, GetXCoord(trainInput[i - 1]), GetYCoord(trainIdeal[i - 1]),
                    GetXCoord(trainInput[i]), GetYCoord(trainIdeal[i]));    
            }

            pictureBox.Refresh();
        }

        /// <summary>
        /// Vykresli vystup z neuronovej siete ako diskretne body
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="g"></param>
        /// <param name="result">Vysledok z neuronovej siete.</param>
        public void DrawResultAsPoints(System.Windows.Forms.PictureBox pictureBox, Graphics g, double[] result)
        {
            Pen pen = new Pen(Brushes.Red);
            for (int i = 0; i < result.Length; i++)
            {
                g.DrawEllipse(pen, GetXCoord(trainInput[i]), GetYCoord(result[i]), 2.5f, 2.5f);
                //g.DrawLine(pen, GetXCoord(fInput[i - 1]), GetYCoord(fIdeal[i - 1]),
                //    GetXCoord(fInput[i]), GetYCoord(fIdeal[i]));
            }

            pictureBox.Refresh();
        }

        public void DrawResultAsCurve(System.Windows.Forms.PictureBox pictureBox, Graphics g, double[] result)
        {
            Pen pen = new Pen(Brushes.Red);
            for (int i = 1; i < result.Length; i++)
            {
                g.DrawLine(pen, GetXCoord(testInput[i - 1]), GetYCoord(result[i - 1]),
                    GetXCoord(testInput[i]), GetYCoord(result[i]));
            }

            pictureBox.Refresh();
        }

        public void DrawMesh(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            g.DrawLine(new Pen(Brushes.Black), pictureWidth / 2.0f, 0, pictureWidth / 2.0f, pictureHeight);
            g.DrawLine(new Pen(Brushes.Black), 0, pictureHeight / 2.0f, pictureWidth, pictureHeight / 2.0f);

            Pen pen = new Pen(Color.FromArgb(39,0,0,0));
            //zvisel ciary
            for (float i = 0; i <= pictureWidth; i += (float)delX)
            {
                g.DrawLine(pen, i, 0, i, pictureHeight);
                //g.DrawString(i.ToString(),new Font(FontFamily.GenericSansSerif, 10.0f),Brushes.Black,i,pictureHeight/2);
            }
            //vodorovne ciary
            for (float i = 0; i <= pictureHeight; i += (float)delX)
                g.DrawLine(pen, 0, i, pictureWidth, i);

            pictureBox.Refresh();
        }

        public void DrawLegend(System.Windows.Forms.PictureBox pictureBox, Graphics g, int epochCount, string text)
        {
            g.DrawLine(new Pen(Brushes.Blue, 3), pictureWidth - 130, pictureHeight - 70, pictureWidth - 110, pictureHeight - 70);
            g.DrawString("F(x)", new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Bold), Brushes.Black, pictureWidth - 100, pictureHeight - 75);
            g.DrawLine(new Pen(Brushes.Red, 3), pictureWidth - 130, pictureHeight - 50, pictureWidth - 110, pictureHeight - 50);
            g.DrawString("F(x) approximation", new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Bold), Brushes.Black, pictureWidth - 100, pictureHeight - 55);
            g.DrawString(text + (epochCount + 1), new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Bold), Brushes.Black, pictureWidth - 100, pictureHeight - 35);
        }

        public void ClearMesh(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            g.Clear(Color.White);
            DrawFunction(pictureBox, g);
        }
#endregion

        #region Help functions
        private void SwitchBorders()
        {
            if (rightBorder < leftBorder)
            {
                double tmp = leftBorder;
                leftBorder = rightBorder;
                rightBorder = tmp;
            }
        }

        private float GetXCoord(double x)
        {
            return (float)(delX * x + pictureWidth / 2d);
        }

        private float GetYCoord(double y)
        {
            return (float)(-delY * y + pictureHeight / 2d);
        }
        #endregion
    }
}
