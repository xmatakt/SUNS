using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SOMnetwork.Classes;

namespace SOMnetwork.Classes
{
    class Hexagon
    {
        private double sin30 = Math.Sin(Math.PI / 6.0d);
        private double cos30 = Math.Cos(Math.PI / 6.0d);

        private double radius;
        public double distance;
        private bool drawBorder;
        private PointF center;
        private List<PointF> vertices;
        private Color color;

        public Hexagon Left = null;
        public Hexagon UpperLeft = null;
        public Hexagon UpperRight = null;
        public Hexagon Right = null;
        public Hexagon BottomRight = null;
        public Hexagon BottomLeft = null;

        public Hexagon(double radius, PointF center, double distance, bool drawBorder = false)
        {
            vertices = new List<PointF>();
            this.radius = radius;
            this.center = new PointF(center.X, center.Y);
            this.distance = distance;
            this.drawBorder = drawBorder;

            CalculateVertices();
        }

        public Hexagon(double radius, PointF center, double distance, Color color, bool drawBorder = false)
        {
            vertices = new List<PointF>();
            this.radius = radius;
            this.center = new PointF(center.X,center.Y);
            this.distance = distance;
            this.drawBorder = drawBorder;
            this.color = Color.FromArgb((int)(distance * 255), (int)(distance * 255), (int)(distance * 255));
            //this.color = color;

            CalculateVertices();
        }

        public Hexagon(double radius, double X, double Y, double distance, bool drawBorder = false)
        {
            vertices = new List<PointF>();
            this.radius = radius;
            this.center = new PointF((float)X, (float)Y);
            this.distance = distance;
            this.drawBorder = drawBorder;

            CalculateVertices();
        }

        //vypocet farby pre hexagon reprezentujuci neuron
        public void CalculateHexagonColor()
        {
            int count = 0;
            double sumR = 0;
            double sumG = 0;
            double sumB = 0;
            //  Left
            if (this.Left != null)
            {
                count++;
                sumR += this.Left.color.R;
                sumG += this.Left.color.G;
                sumB += this.Left.color.B;
            }
            //  UpperLeft
            if (this.UpperLeft != null)
            {
                count++;
                sumR += this.UpperLeft.color.R;
                sumG += this.UpperLeft.color.G;
                sumB += this.UpperLeft.color.B;
            }
            //  UpperRight
            if (this.UpperRight != null)
            {
                count++;
                sumR += this.UpperRight.color.G;
                sumG += this.UpperRight.color.B;
                sumB += this.UpperRight.color.R;
            }
            //  Right
            if (this.Right != null)
            {
                count++;
                sumR += this.Right.color.R;
                sumG += this.Right.color.G;
                sumB += this.Right.color.B;
            }
            //  BottomRight
            if (this.BottomRight != null)
            {
                count++;
                sumR += this.BottomRight.color.R;
                sumG += this.BottomRight.color.G;
                sumB += this.BottomRight.color.B;
            }
            //  BottomLeft
            if (this.BottomLeft != null)
            {
                count++;
                sumR += this.BottomLeft.color.R;
                sumG += this.BottomLeft.color.G;
                sumB += this.BottomLeft.color.B;
            }
            var distanceR = sumR / (double)count;
            var distanceG = sumG / (double)count;
            var distanceB = sumB / (double)count;
            distanceR = Math.Max(0, distanceR);
            distanceR = Math.Min(255, distanceR);
            distanceG = Math.Max(0, distanceG);
            distanceG = Math.Min(255, distanceG);
            distanceB = Math.Max(0, distanceB);
            distanceB = Math.Min(255, distanceB);
            color = Color.FromArgb((int)(distanceR), (int)(distanceG), (int)(distanceB));
        }

        //vypocet farby pre okolie neuronu
        public void CalculateHexagonColor(double a, double b)
        {
            color = Color.FromArgb((int)(a*distance+b),(int)(a*distance+b),(int)(a*distance+b));
        }

        public void CalculateHexagonColor(ColorScale scale)
        {
            color = scale.CalculateColor(distance);
        }

        private void CalculateVertices()
        {
            double dx = radius * cos30;
            double dy = radius * sin30;

            vertices.Add(new PointF((float)(center.X + dx), (float)(center.Y - dy)));
            vertices.Add(new PointF((float)(center.X), (float)(center.Y - radius)));
            vertices.Add(new PointF((float)(center.X - dx), (float)(center.Y - dy)));
            vertices.Add(new PointF((float)(center.X - dx), (float)(center.Y + dy)));
            vertices.Add(new PointF((float)(center.X), (float)(center.Y + radius)));
            vertices.Add(new PointF((float)(center.X + dx), (float)(center.Y + dy)));
        }

        public void DrawHexagon(Graphics g)
        {
            g.FillPolygon(new SolidBrush(color), vertices.ToArray());
            if (drawBorder)
                g.DrawPolygon(new Pen(new SolidBrush(Color.Black), 2.0f),vertices.ToArray());
        }
    }
}
