using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesPrediction.Enumerations
{
    enum SetTypeEnum
    {
        TrainingSet = 0,
        ValidationSet = 1,
        TestSet = 3,
        ClosedLoopSet = 4,
        AllData = 5
    }
}
