using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSeriesPrediction.Forms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();

            display.SetDisplayRangeX(0, 100);
            display.SetGridDistanceX(100);
            display.BackgroundColorTop = Color.White;
            display.BackgroundColorBot = Color.LightGray;
            display.SolidGridColor = Color.LightGray;
            display.DashedGridColor = Color.LightGray;
        }
    }
}
