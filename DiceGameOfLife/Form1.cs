using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace DiceGameOfLife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            core = new Core(mainPictureBox.Width, mainPictureBox.Height);
            drawer = new Drawer();
            cells = new Cells();

            cells.alives[1, 1] = true;
            cells.alives[2, 1] = true;
            cells.alives[2, 2] = true;

            timer = new System.Timers.Timer(core.Interval);
            timer.Elapsed += Update;
            timer.Start();

            while(true)
            {
                await Task.Run(() =>
                {
                    mainPictureBox.Image = drawer.Update(core, cells);
                    mainPictureBox.Refresh();
                });
            }
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            cells.Update();
        }

        static Drawer drawer;
        static System.Timers.Timer timer;
        static Core core;
        static Cells cells;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.OemMinus:
                    core.GridCount++;
                    break;
                case Keys.Oemplus:
                    core.GridCount--;
                    break;
                case Keys.Space:
                    if (timer.Enabled)
                        timer.Stop();
                    else
                        timer.Start();
                    break;
            }
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            core.X = mainPictureBox.Width;
            core.Y = mainPictureBox.Height;
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point mp = PointToClient(Cursor.Position);
            Point wp = mainPictureBox.Location;
            Point p = new Point(mp.X - wp.X, mp.Y - wp.Y);

            cells.ChangeSell((int)(p.X / core.Grid), (int)(p.Y / core.Grid));
        }
    }
}
