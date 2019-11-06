using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StickmanShankSimulator.Physics;

namespace StickmanShankSimulator
{
    public partial class Form1 : Form
    {
        StickMan stick = new StickMan(500, 300, 0.75f);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            stick.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stick.Update(0.01f);
            this.Refresh();
        }
    }
}
