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
        public int X { get; private set; }
        public int Y { get; private set; }
        
        public Drawer(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Bitmap Update(Core core, Cells cells)
        {
            Bitmap canvas = new Bitmap(X, Y);

            Graphics g = Graphics.FromImage(canvas);

            // 格子を描写
            double grid = X / core.GridCount;
            // y軸方向
            for(int i = 1; i < X;i++)
            {
                float pos = (float)grid * i;
                g.DrawLine(Pens.Black, new PointF(pos, 0), new PointF(pos, Y));
            }

            // x軸方向
            for(int i = 1;i < Y;i++)
            {
                float pos = (float)grid * i;
                g.DrawLine(Pens.Black, new PointF(0, pos), new PointF(X, pos));
            }

            g.Dispose();

            return canvas;
        }
    }
}
