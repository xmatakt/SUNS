using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Random rand = new Random();
            g.FillPolygon(new SolidBrush(color), vertices.ToArray());
            if (drawBorder)
                g.DrawPolygon(new Pen(new SolidBrush(Color.Black), 2.0f),vertices.ToArray());
        }

        public void CalculateHexagonColor()
        {
            int count = 0;
            double sum = 0;
            //  hexagon reprezentujuci neuron
            //  Left
            if (this.Left != null)
            {
                count++;
                sum += this.Left.distance;
            }
            //  UpperLeft
            if (this.UpperLeft != null)
            {
                count++;
                sum += this.UpperLeft.distance;
            }
            //  UpperRight
            if (this.UpperRight != null)
            {
                count++;
                sum += this.UpperRight.distance;
            }
            //  Right
            if (this.Right != null)
            {
                count++;
                sum += this.Right.distance;
            }
            //  BottomRight
            if (this.BottomRight != null)
            {
                count++;
                sum += this.BottomRight.distance;
            }
            //  BottomLeft
            if (this.BottomLeft != null)
            {
                count++;
                sum += this.BottomLeft.distance;
            }
            distance = sum / (double)count;
            color = Color.FromArgb((int)(distance * 255), (int)(distance * 255), (int)(distance * 255));
        }
    }
}
