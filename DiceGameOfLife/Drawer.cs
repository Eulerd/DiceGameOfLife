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
        public Bitmap Update(Core core, Cells cells)
        {
            int X = core.X;
            int Y = core.Y;
            Bitmap canvas = new Bitmap(X, Y);

            Graphics g = Graphics.FromImage(canvas);

            double grid = core.Grid;

            // セルを描画
            for (int i = 0; i < X; i++)
            {
                Size size = new Size((int)grid, (int)grid);
                for (int j = 0; j < Y; j++)
                {
                    Point p = new Point((int)grid * i, (int)grid * j);
                    Brush b = (cells.alives[i, j]) ? Brushes.Green : Brushes.White;
                    g.FillRectangle(b, new Rectangle(p, size));
                }
            }

            // 格子を描画
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
