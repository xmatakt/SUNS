using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOMnetwork.Classes
{
    //Jet color scale
    class ColorScale
    {
        private double left;
        private double right;
        private double min;
        private double max;
        private LinearMapping mapping;

        public ColorScale(double min, double max)
        {
            this.min = min;
            this.max = max;
            mapping = new LinearMapping(min, max, 0.0d, 1.0d);
        }

        public Color CalculateColor(double value)
        {
            var x = mapping.Value(value);
            var x1 = 0.0d;
            var x2 = 0.1d;
            var x3 = 0.35d;
            var x4 = 0.65d;
            var x5 = 0.9d;
            var x6 = 1.0d;
            //if (x >= 0.0d && x < 0.1d)
            //    return Color.FromArgb((int)(new LinearMapping(0.0d, 0.1d, 128, 255).Value(x)), 0, 0);
            //if (x >= 0.1d && x < 0.35d)
            //    return Color.FromArgb(1, (int)(new LinearMapping(0.1d, 0.35d, 0, 255).Value(x)), 0);
            //if (x >= 0.35d && x < 0.65d)
            //    return Color.FromArgb((int)(new LinearMapping(0.35d, 0.65d, 255, 0).Value(x)), 255,
            //        (int)(new LinearMapping(0.35d, 0.65d, 0, 255).Value(x)));
            //if (x >= 0.65d && x < 0.9)
            //    return Color.FromArgb(0, (int)(new LinearMapping(0.65d, 0.9d, 255, 0).Value(x)), 255);
            //if (x >= 0.9 && x <= 1.0d)
            //    return Color.FromArgb(0, 0, (int)(new LinearMapping(0.9d, 1.0d, 255, 128).Value(x)));

            //modre
            if (x >= x1 && x < x2)
                return Color.FromArgb(0, 0, (int)(new LinearMapping(x1, x2, 128, 255).Value(x)));
            if (x >= x2 && x < x3)
                return Color.FromArgb(0, (int)(new LinearMapping(x2, x3, 0, 255).Value(x)), 255);
            if (x >= x3 && x < x4)
                return Color.FromArgb((int)(new LinearMapping(x3, x4, 0, 255).Value(x)), 255,
                    (int)(new LinearMapping(x3, x4, 255, 0).Value(x)));
            if (x >= x4 && x < x5)
                return Color.FromArgb(255, (int)(new LinearMapping(x4, x5, 255, 0).Value(x)), 0);
            if (x >= x5 && x <= x6)
                return Color.FromArgb((int)(new LinearMapping(x5, x6, 255, 128).Value(x)), 0, 0);

            //cervene
            //if (x >= x1 && x < x2)
            //    return Color.FromArgb((int)(new LinearMapping(x1, x2, 128, 255).Value(x)), 0, 0);
            //if (x >= x2 && x < x3)
            //    return Color.FromArgb(255, (int)(new LinearMapping(x2, x3, 0, 255).Value(x)), 0);
            //if (x >= x3 && x < x4)
            //    return Color.FromArgb((int)(new LinearMapping(x3, x4, 255, 0).Value(x)), 255,
            //        (int)(new LinearMapping(x3, x4, 0, 255).Value(x)));
            //if (x >= x4 && x < x5)
            //    return Color.FromArgb(0, (int)(new LinearMapping(x4, x5, 255, 0).Value(x)), 255);
            //if (x >= x5 && x <= x6)
            //    return Color.FromArgb(0, 0, (int)(new LinearMapping(x5, x6, 255, 128).Value(x)));

            return Color.Pink;
        }
    }
}