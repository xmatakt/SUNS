using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMnetwork.Classes
{
    class HexGrid
    {
        private int width;
        private int height;
        private List<Hexagon> grid;
        private ColorScale jetScale;

        public double Min = Double.MaxValue;
        public double Max = Double.MinValue;

        public HexGrid()
        {
            this.grid = new List<Hexagon>(); ;
        }

        public HexGrid(List<Hexagon> grid)
        {
            this.grid = grid;
        }

        public void AddHexagon(Hexagon hexagon)
        {
            grid.Add(hexagon);
        }

        public void DrawGrid(Graphics graphics, bool calculateCenterColor = false)
        {
            foreach (var hex in grid)
            {
                //hex.CalculateHexagonColor();
                //  hexagon reprezentujuci neuron
                hex.DrawHexagon(graphics);
                //  Left
                if (hex.Left != null)
                    hex.Left.DrawHexagon(graphics);
                //  UpperLeft
                if (hex.UpperLeft != null)
                    hex.UpperLeft.DrawHexagon(graphics);
                //  UpperRight
                if (hex.UpperRight != null)
                    hex.UpperRight.DrawHexagon(graphics);
                //  Right
                //if (hex.Right != null)
                //    hex.Right.DrawHexagon(graphics);
                ////  BottomRight
                //if (hex.BottomRight != null)
                //    hex.BottomRight.DrawHexagon(graphics);
                ////  BottomLeft
                //if (hex.BottomLeft != null)
                //    hex.BottomLeft.DrawHexagon(graphics);
            }
        }

        public void GenerateGrid(PointF startPoint, int width, int height, double radius, double[][] data,
            bool colorScale)
        {
            this.width = width;
            this.height = height;
            double sin30 = Math.Sin(Math.PI / 6.0d);
            double cos30 = Math.Cos(Math.PI / 6.0d);
            double dx = radius * cos30;
            double dy = radius * sin30;
            double actualX = startPoint.X;
            double actualY = startPoint.Y;
            var act = 0;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    act = y + width * x;
                    //prvy vlavo dole nema suseda, posledny v pravo dole ma
                    if (x % 2 == 0)
                    {
                        //zistim poziciu stredu hexagonu s indexom act, tento hexagon bude reprezentovat samotny neuron
                        actualX = startPoint.X + 4 * dx * y;
                        actualY = startPoint.Y + 3 * radius * x;
                        AddHexagon(new Hexagon(radius, new PointF((float)actualX, (float)actualY), 0.0d, false));

                        //ak nie som uplne napravo, neuron ma Right suseda
                        if (y + 1 != width)
                        {
                            grid[act].Right = new Hexagon(radius, new PointF((float)(actualX + 2 * dx), (float)(actualY)),
                               EuclideanDistance(data[act], data[Position(x, y + 1)]), false);
                        }
                        //ak nie som uplne dole, cize existuju bottom susedia
                        if (x + 1 != height)
                        {
                            //BottomRight sused
                            grid[act].BottomRight = new Hexagon(radius, new PointF((float)(actualX + dx), (float)(actualY + radius + dy)),
                                EuclideanDistance(data[act], data[Position(x + 1, y)]), false);
                            //ak nie som uplne nalavo, neuron ma BottomLeft suseda
                            if (y != 0)
                            {
                                grid[act].BottomLeft = new Hexagon(radius, new PointF((float)(actualX - dx), (float)(actualY + radius + dy)),
                                    EuclideanDistance(data[act], data[Position(x + 1, y - 1)]), false);
                            }
                        }
                    }
                    // prvy vlavo dole ma suseda, posledny vpravo dole nema
                    else
                    {
                        //zistim poziciu stredu hexagonu s indexom act, tento hexagon bude reprezentovat samotny neuron
                        actualX = startPoint.X + 2 * dx + 4 * dx * y;
                        actualY = startPoint.Y + 3 * radius * x;
                        AddHexagon(new Hexagon(radius, new PointF((float)actualX, (float)actualY), 1, Color.PowderBlue, false));

                        ////ak nie som uplne napravo, neuron ma Right suseda
                        if (y + 1 < width)
                        {
                            grid[act].Right = new Hexagon(radius, new PointF((float)(actualX + 2 * dx), (float)(actualY)),
                               EuclideanDistance(data[act], data[Position(x, y + 1)]), false);
                        }
                        //ak nie som uplne dole, cize existuju bottom susedia
                        if (x + 1 != height)
                        {
                            //BottomLeft sused
                            grid[act].BottomLeft = new Hexagon(radius, new PointF((float)(actualX - dx), (float)(actualY + radius + dy)),
                                 EuclideanDistance(data[act], data[Position(x + 1, y)]), false);
                            //ak nie som uplne napravo, neuron ma BottomRight suseda
                            if (y + 1 < width)
                            {
                                grid[act].BottomRight = new Hexagon(radius, new PointF((float)(actualX + dx), (float)(actualY + radius + dy)),
                                    EuclideanDistance(data[act], data[Position(x + 1, y + 1)]), false);
                            }
                        }
                    }
                }
            }

            //prepojenia
            jetScale = new ColorScale(Min, Max);
            ConnectGrid(width, height);
            //true = jetScale, false = greyScale;
            SetGridColors(colorScale);
        }

        public void GenerateGrid(PointF startPoint, int width, int height, double radius, double[] data,
            Graphics g = null, System.Windows.Forms.PictureBox p = null)
        {
            this.width = width;
            this.height = height;
            double sin30 = Math.Sin(Math.PI / 6.0d);
            double cos30 = Math.Cos(Math.PI / 6.0d);
            double dx = radius * cos30;
            double dy = radius * sin30;
            double actualX = startPoint.X;
            double actualY = startPoint.Y;
            var act = 0;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    act = y + width * x;
                    //prvy vlavo dole nema suseda, posledny v pravo dole ma
                    if (x % 2 == 0)
                    {
                        //zistim poziciu stredu hexagonu s indexom act, tento hexagon bude reprezentovat samotny neuron
                        actualX = startPoint.X + 4 * dx * y;
                        actualY = startPoint.Y + 3 * radius * x;
                        AddHexagon(new Hexagon(radius, new PointF((float)actualX, (float)actualY), 1, Color.PowderBlue, true));

                        //ak nie som uplne napravo, neuron ma Right suseda
                        if (y + 1 != width)
                        {
                            grid[act].Right = new Hexagon(radius, new PointF((float)(actualX + 2 * dx), (float)(actualY)),
                               Distance(data[act], data[Position(x, y + 1)]), Color.Blue, true);
                        }
                        //ak nie som uplne dole, cize existuju bottom susedia
                        if (x + 1 != height)
                        {
                            //BottomRight sused
                            grid[act].BottomRight = new Hexagon(radius, new PointF((float)(actualX + dx), (float)(actualY + radius + dy)),
                                Distance(data[act], data[Position(x + 1, y)]), Color.Red, true);
                            //ak nie som uplne nalavo, neuron ma BottomLeft suseda
                            if (y != 0)
                            {
                                grid[act].BottomLeft = new Hexagon(radius, new PointF((float)(actualX - dx), (float)(actualY + radius + dy)),
                                    Distance(data[act], data[Position(x + 1, y - 1)]), Color.Green, true);
                            }
                        }
                    }
                    // prvy vlavo dole ma suseda, posledny vpravo dole nema
                    else
                    {
                        //zistim poziciu stredu hexagonu s indexom act, tento hexagon bude reprezentovat samotny neuron
                        actualX = startPoint.X + 2 * dx + 4 * dx * y;
                        actualY = startPoint.Y + 3 * radius * x;
                        AddHexagon(new Hexagon(radius, new PointF((float)actualX, (float)actualY), 1, Color.PowderBlue, true));

                        ////ak nie som uplne napravo, neuron ma Right suseda
                        if (y + 1 < width)
                        {
                            grid[act].Right = new Hexagon(radius, new PointF((float)(actualX + 2 * dx), (float)(actualY)),
                               Distance(data[act], data[Position(x, y + 1)]), Color.Blue, true);
                        }
                        //ak nie som uplne dole, cize existuju bottom susedia
                        if (x + 1 != height)
                        {
                            //BottomLeft sused
                            grid[act].BottomLeft = new Hexagon(radius, new PointF((float)(actualX - dx), (float)(actualY + radius + dy)),
                                 Distance(data[act], data[Position(x + 1, y)]), Color.Green, true);
                            //ak nie som uplne napravo, neuron ma BottomRight suseda
                            if (y + 1 < width)
                            {
                                grid[act].BottomRight = new Hexagon(radius, new PointF((float)(actualX + dx), (float)(actualY + radius + dy)),
                                    Distance(data[act], data[Position(x + 1, y + 1)]), Color.Red, true);
                            }
                        }
                    }
                    //DrawGrid(g);
                    //p.Refresh();
                }
            }

            //prepojenia
            ConnectGrid(width, height);
        }

        private void SetGridColors(bool jetScale = false)
        {
            if(!jetScale)
            {
                double a = 255.0d / (Min - Max);
                double b = -a * Max;
                foreach (var hex in grid)
                {
                    //  Right
                    if (hex.Right != null)
                        hex.Right.CalculateHexagonColor(a, b);
                    //  BottomRight
                    if (hex.BottomRight != null)
                        hex.BottomRight.CalculateHexagonColor(a, b);
                    //  BottomLeft
                    if (hex.BottomLeft != null)
                        hex.BottomLeft.CalculateHexagonColor(a, b);
                }
            }
            else
            {
                foreach (var hex in grid)
                {
                    //  Right
                    if (hex.Right != null)
                        hex.Right.CalculateHexagonColor(this.jetScale);
                    //  BottomRight
                    if (hex.BottomRight != null)
                        hex.BottomRight.CalculateHexagonColor(this.jetScale);
                    //  BottomLeft
                    if (hex.BottomLeft != null)
                        hex.BottomLeft.CalculateHexagonColor(this.jetScale);
                }
            }

            //farba samotneho neuronu (priemer okolitych farieb)
            foreach (var hex in grid)
            {
                hex.CalculateHexagonColor();
            }
        }

        //  kazdy neuron reprezentovany hexagonom ma svojho BottomLeft,BottomRight a Right suseda (ak existuju)
        //  este im potrebujeme pridat UpperLeft, UpperRight a Left susedov (ak existuju)
        private void ConnectGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            var act = 0;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    act = y + height * x;

                    //existencia Left suseda
                    if (y != 0)
                    {
                        grid[act].Left = grid[Position(x, y - 1)].Right;
                    }

                    if ((x > 0) && (x % 2 == 0))
                    {
                        //UpperRight existuje vzdy za danych podmienok vzdy
                        grid[act].UpperRight = grid[Position(x - 1, y)].BottomLeft;
                        //existencia UpperLeft suseda
                        if (y != 0)
                        {
                            grid[act].UpperLeft = grid[Position(x - 1, y - 1)].BottomRight;
                        }
                    }

                    if ((x > 0) && (x % 2 == 1))
                    {
                        //UpperLeft existuje vzdy za danych podmienok vzdy
                        grid[act].UpperLeft = grid[Position(x - 1, y)].BottomRight;
                        //existencia UpperRight suseda
                        if (y != width - 1)
                        {
                            grid[act].UpperRight = grid[Position(x - 1, y + 1)].BottomLeft;
                        }
                    }
                }
            }
        }

        //vrati poziciu v 1D poli pre poziciu v 2D poli
        private int Position(int x, int y)
        {
            return y + height * x;
        }

        private double Distance(double x, double y)
        {
            return Math.Abs(x - y) / 2.0d;
            //return Math.Abs(x - y)/48.0d;
        }

        private double EuclideanDistance(double[] x, double[] y)
        {
            var sum = 0.0d;

            for (int i = 0; i < x.Length; i++)
            {
                sum += Math.Pow(x[i] - y[i], 2.0d);
            }
            //euklidovska norma vahovych vektorov dvoch neuronov
            var result = Math.Sqrt(sum);
            
            //urcim minimum a maximum koli vyfarbovaniu neuronov
            if (result > Max)
                Max = result;
            if (result < Min)
                Min = result;

            return result;
        }
    }
}
