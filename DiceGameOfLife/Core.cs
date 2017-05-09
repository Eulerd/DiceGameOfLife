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
        int x, y;

        public int X
        {
            get { return x; }
            set { x = (value <= 0) ? 1 : value; }
        }

        public int Y
        {
            get { return y; }
            set { y = (value <= 0) ? 1 : value; }
        }

        public double Grid { get { return Math.Min(X, Y) / GridCount; } }
        
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

        public Core(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
