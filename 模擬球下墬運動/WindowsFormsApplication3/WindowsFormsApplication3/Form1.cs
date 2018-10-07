using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int y = 15;
        int x = 545;
        int up = 0;
        int n = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Top >= 400 && up == 0)
            {
                y *= -1;
                n++;
                up = 1;
            }
            if (pictureBox1.Top <= 400-400/n && up == 1)
            {
                y *= -1;
                up = 0;
            }
            if (400 - 400 / n > 350) timer1.Enabled = false;

            pictureBox1.Top += y;

        }
    }
}
