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

        private PointF[] curvePoints;

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
        }

        public void DrawFunction(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            g.DrawLine(new Pen(Brushes.Black),0,0,100,100);
            pictureBox.Refresh();
        }

        public double Function(double x)
        {
            return Math.Sin(x);
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
    }
}
