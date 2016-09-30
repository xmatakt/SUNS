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
        private double[] fInput;
        private double[] fIdeal;
        private double delX = -1;
        private double delY = -1;

        //private PointF[] curvePoints;

        public Function1D(double left, double right, int count, int width, int height)
        {
            leftBorder = left;
            rightBorder = right;
            nodesCount = count;
            pictureWidth = width;
            pictureHeight = height;

            InitFunction();
        }

        public void InitFunction()
        {
            fInput = new double[nodesCount+1];
            fIdeal = new double[nodesCount+1];
            
            SwitchBorders();
            double delimeter = (rightBorder - leftBorder) / (double)nodesCount;
            
            for (int i = 0; i <= nodesCount; i++)
            {
                fInput[i] = leftBorder + i * delimeter;
                fIdeal[i] = Function(fInput[i]);
            }

            delX = pictureWidth/(double)(2d * Math.Max(Math.Abs(leftBorder), Math.Abs(rightBorder)));
            delY = pictureHeight/(double)(2d * Math.Max(Math.Abs(fIdeal.Min()), Math.Abs(fIdeal.Max())));
        }

        public void DrawFunction(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            Pen pen = new Pen(Brushes.Black);
            for (int i = 1; i < fInput.Length; i++)
            {
                g.DrawLine(pen, GetXCoord(fInput[i - 1]), GetYCoord(fIdeal[i-1]),
                    GetXCoord(fInput[i]), GetYCoord(fIdeal[i]));    
            }

            pictureBox.Refresh();
        }

        public double Function(double x)
        {
            //return Math.Sin(x);
            return -Math.Abs(x);
        }

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
            return (float)(-delX * y + pictureHeight / 2d);
        }
    }
}
