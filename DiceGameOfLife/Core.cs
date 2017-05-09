using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameOfLife
{
    class Core
    {
        private const int MinCount = 30;
        private const double MinInterval = 0.000001;

        double interval = MinInterval;

        int gridCount = MinCount;
        
        public double Interval
        {
            get { return interval; }
            set
            {
                if (interval < 0)
                    interval = MinInterval;
                else if (interval > int.MaxValue)
                    interval = int.MaxValue;
                else
                    interval = value;
            }
        }

        public int GridCount
        {
            get { return gridCount; }
            set { gridCount = (value <= 0) ? MinCount : value; }
        }
    }
}
