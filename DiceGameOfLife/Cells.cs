using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameOfLife
{
    class Cells
    {
        /// <summary>
        /// x方向の最大値
        /// </summary>
        public int MaxX { get; private set; }

        /// <summary>
        /// y方向の最大値委
        /// </summary>
        public int MaxY { get; private set; }

        /// <summary>
        /// 最大値
        /// </summary>
        private const int MaxValue = 1000;

        /// <summary>
        /// 各セルの生死
        /// </summary>
        public static bool[,] alives;

        public Cells()
        {
            MaxX = MaxValue;
            MaxY = MaxValue;
            alives = new bool[MaxX, MaxY];

            Clear();
        }

        public Cells(int x, int y)
        {
            MaxX = x;
            MaxY = y;
            alives = new bool[MaxX, MaxY];

            Clear();
        }

        public void Update()
        {
            for (int i = 0; i < MaxX; i++)
                for (int j = 0; j < MaxY; j++)
                    alives[i, j] = IsAlive(i, j);
        }

        /// <summary>
        /// そのセルが次に生きているのか
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns>セルの生死</returns>
        bool IsAlive(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i < x + 3; i++)
            {
                if (x == 0 || x == MaxX - 1)
                    continue;

                for (int j = y - 1; j < y + 3; j++)
                {
                    if (y == 0 || y == MaxY - 1)
                        continue;

                    if (alives[i, j])
                        count++;
                }
            }

            if (count == 2 || count == 3)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        void Clear()
        {
            for (int i = 0; i < MaxX; i++)
                for (int j = 0; j < MaxY; j++)
                    alives[i, j] = false;
        }
    }
}
