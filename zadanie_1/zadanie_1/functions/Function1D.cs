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

        public double Function(double x)
        {
            //return x * x;
            //return -Math.Abs(x);
            if (x >= -9 && x <= -3)
                return x * x + 12 * x + 36;
            if (x >= -3 && x <= 3)
                return x * x;
            if (x >= 3 && x <= 9)
                return x * x - 12 * x + 36;
            return 0;
        }

        public double[] GetFInput() { return fInput; }

        public double[] GetFIdeal() { return fIdeal; }

        #region Drawing
        public void DrawFunction(System.Windows.Forms.PictureBox pictureBox, Graphics g)
        {
            Pen pen = new Pen(Brushes.Blue);
            for (int i = 1; i < fInput.Length; i++)
            {
                g.DrawLine(pen, GetXCoord(fInput[i - 1]), GetYCoord(fIdeal[i-1]),
                    GetXCoord(fInput[i]), GetYCoord(fIdeal[i]));    
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
                g.DrawEllipse(pen, GetXCoord(fInput[i]), GetYCoord(result[i]), 2.5f, 2.5f);
                //g.DrawLine(pen, GetXCoord(fInput[i - 1]), GetYCoord(fIdeal[i - 1]),
                //    GetXCoord(fInput[i]), GetYCoord(fIdeal[i]));
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
            for (float i = 0; i <= pictureHeight; i += (float)delY)
                g.DrawLine(pen, 0, i, pictureWidth, i);

            pictureBox.Refresh();
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
