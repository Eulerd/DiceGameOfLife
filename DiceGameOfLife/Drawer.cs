using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DiceGameOfLife
{
    class Drawer
    {
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
        
        public Drawer(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Bitmap Update(Core core, Cells cells)
        {
            Bitmap canvas = new Bitmap(X, Y);

            Graphics g = Graphics.FromImage(canvas);

            double grid = Math.Min(X, Y) / core.GridCount;

            // 格子を描写
            // y軸方向
            for (int i = 0; i < X;i++)
            {
                float pos = (float)grid * i;
                g.DrawLine(Pens.Black, new PointF(pos, 0), new PointF(pos, Y));
            }

            // x軸方向
            for(int i = 0;i < Y;i++)
            {
                float pos = (float)grid * i;
                g.DrawLine(Pens.Black, new PointF(0, pos), new PointF(X, pos));
            }

            g.Dispose();

            return canvas;
        }
    }
}
