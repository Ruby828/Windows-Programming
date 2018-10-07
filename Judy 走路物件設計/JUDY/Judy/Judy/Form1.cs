using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Judy
{
    public partial class Form1 : Form
    {
        static int[,] Map = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,1,1,1,0,0,0,1,1,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,1,1,0,0,0,1,1},
            {1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1},
            {1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        int step, head, x, y,t,tt;
        int hhhh;


        judy myjudy = new judy();
        Enemy01 myenemy01 = new Enemy01();
        Enemy02 myenemy02 = new Enemy02();
        Random ccc = new Random();
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = 1;tt = 1;
            DoubleBuffered = true;
            timer1.Enabled = true;
            myenemy01.PersonX(); myenemy02.PersonX();
            step = 0; head = 0;
            myenemy01.pictureBox1.Left = 300;
            myenemy01.pictureBox1.Top = 250;
            myenemy02.pictureBox1.Left = 250;
            myenemy02.pictureBox1.Top = 250;
            myjudy.pictureBox1.Left = 150;
            myjudy.pictureBox1.Top = 250;
            this.Controls.Add(myjudy.pictureBox1);
            this.Controls.Add(myenemy01.pictureBox1);
            this.Controls.Add(myenemy02.pictureBox1);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            x = myjudy.pictureBox1.Left / 32 + 1;
            y = myjudy.pictureBox1.Top / 32 + 1;
            if (e.KeyCode == Keys.Left)
            {
                if (step == 0 && Map[y, x - 1] == 0)
                {
                    head = 1; step = 1;
                }

            }
            if (e.KeyCode == Keys.Right)
            {
                if (step == 0 && Map[y, x + 1] == 0)
                {
                    head = 2; step = 1;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (step == 0 && Map[y - 1, x] == 0)
                {
                    head = 3; step = 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (step == 0 && Map[y + 1, x] == 0)
                {
                    head = 0; step = 1;
                }
            }
            myjudy.draw(step, head);
            step = 0;
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            hhhh = ccc.Next(4);
            step = 1;
            myenemy01.draw(step, hhhh);
            step = 0;
            hhhh = ccc.Next(4);
            step = 1;
            myenemy02.draw(step, hhhh);
            step = 0;
            if (myjudy.pictureBox1.Bounds.IntersectsWith(myenemy01.pictureBox1.Bounds))
            {
                tt = 0;
                
               

            }
            if (myjudy.pictureBox1.Bounds.IntersectsWith(myenemy02.pictureBox1.Bounds))
            {
                t = 0;
                 
            }
            if (!myjudy.pictureBox1.Bounds.IntersectsWith(myenemy01.pictureBox1.Bounds))
            {
                tt = 1;



            }
            if (!myjudy.pictureBox1.Bounds.IntersectsWith(myenemy02.pictureBox1.Bounds))
            {
                t = 1;

            }
            if (tt == 0)
            {
                label1.Visible = true;
                label1.Top = myjudy.pictureBox1.Top - 20;
                label1.Left = myjudy.pictureBox1.Left - 20;
               // tt = 1;
            }

            if (t == 0)
            {
                label2.Visible = true;
                label2.Top = myjudy.pictureBox1.Top - 20;
                label2.Left = myjudy.pictureBox1.Left - 20;
               // t = 1;
            }
            if(t==1) label2.Visible = false;
            if(tt==1) label1.Visible = false;
        }
    }
}
