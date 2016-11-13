using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMnetwork.Classes
{
    class LinearMapping
    {
        private double k;
        private double q;

        //Maps range[x1,x2] on [h1,h2]
        public LinearMapping(double x1, double x2, double h1, double h2)
        {
            k = (h2 - h1) / (x2 - x1);
            q = h1 - x1 * k;
        }

        public double Value(double x)
        {
            return k * x + q;
        }
    }
}
