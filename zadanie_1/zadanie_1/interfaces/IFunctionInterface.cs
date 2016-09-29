using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1.interfaces
{
    interface IFunctionInterface
    {
        void InitFunction();
        void DrawFunction(System.Windows.Forms.PictureBox pictureBox, System.Drawing.Graphics g);
        double Function(double x);
    }
}
