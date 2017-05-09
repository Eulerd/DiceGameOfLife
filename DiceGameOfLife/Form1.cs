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
        
        private void Form1_Load(object sender, EventArgs e)
        {
            core = new Core();
            drawer = new Drawer(mainPictureBox.Width, mainPictureBox.Height);
            cells = new Cells();

            timer = new System.Timers.Timer(core.Interval);
            timer.Elapsed += Update;
            timer.Start();
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            mainPictureBox.Image = drawer.Update(core, cells);
            mainPictureBox.Refresh();
        }

        static Drawer drawer;
        static System.Timers.Timer timer;
        static Core core;
        static Cells cells;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
            
            if (e.KeyData == Keys.OemMinus)
                core.GridCount++;

            if (e.KeyData == Keys.Oemplus)
                core.GridCount--;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            drawer.X = mainPictureBox.Width;
            drawer.Y = mainPictureBox.Height;
        }
    }
}
