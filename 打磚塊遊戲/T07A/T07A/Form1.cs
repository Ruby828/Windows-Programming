using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T07A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Label[] block = new Label[50];
        int x = 5,y=5;
        int rest = 50;
        int count=0;
        int score = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            pictureBox1.Top=260;
            pictureBox1.Left = 246;
            button1.Top = 331;
            button1.Left = 223;
            button1.Enabled = true;
            button1.Text = "start";

            for (int a = 0; a < 50; a++)
            { 
                block[a] = new Label();
		        block[a].Width = 40;
		        block[a].Height = 20;
                block[a].BorderStyle = BorderStyle.FixedSingle;
                if ((a / 10) == 0)
                {
                    block[a].BackColor = Color.Purple;
                    block[a].Location = new Point(100 + (a % 10) * 40, 50);
                }
                else if ((a / 10) == 1)
                {
                    block[a].BackColor = Color.Red;
                    block[a].Location = new Point(100 + (a % 10) * 40, 70);
                }
                else if ((a / 10) == 2)
                {
                    block[a].BackColor = Color.Blue;
                    block[a].Location = new Point(100 + (a % 10) * 40,90);
                }
                else if ((a / 10) == 3)
                {
                    block[a].BackColor = Color.Green;
                    block[a].Location = new Point(100 + (a % 10) * 40,110);
                }
                else if ((a / 10) == 4)
                {
                    block[a].BackColor = Color.Yellow;
                    block[a].Location = new Point(100 + (a % 10) * 40, 130);
                }
                Controls.Add(block[a]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (Convert.ToString(rest));
            label3.Text = (Convert.ToString(score));
            pictureBox1.Left += x;
            for (int a = 0; a <50; a++)
            {
                if (block[a].BackColor!=Color.White&&block[a].Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    block[a].BackColor = Color.White;
                    x = (-1) * x;
             
                    while (block[a].Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        pictureBox1.Left+=x;
                        
                    }
                    goto ass;
                }

            }
            
                pictureBox1.Top += y;
            for (int a = 0; a < 50; a++)
            {
                if (block[a].BackColor != Color.White && block[a].Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    block[a].BackColor = Color.White;
                    y = (-1) * y;
                    while (block[a].Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        pictureBox1.Top += y;
                    }
                    rest--;
                    if ((a / 10) == 0) score = score + 100;
                    else if ((a / 10) == 1) score = score + 40;
                    else if ((a / 10) == 2) score = score + 30;
                    else if ((a / 10) == 3) score = score + 20;
                    else if ((a / 10) == 4) score = score + 10;
                    break;
                }
            }
            ass:
            if (pictureBox1.Bounds.IntersectsWith(button1.Bounds))
            {
                y = (-1) * y;
                while(pictureBox1.Bounds.IntersectsWith(button1.Bounds))
                {
                    pictureBox1.Top+=y;
                }
            }
            if (pictureBox1.Left < (-2))
            {
                pictureBox1.Left = -2;
                x = (-1) * x;
            }
            if (pictureBox1.Left > 614)
            {
                pictureBox1.Left = 614;
                x = (-1) * x;
            }
            if (pictureBox1.Top <0)
            {
                pictureBox1.Top = 0;
                y = (-1) * y;
            }
            if (pictureBox1.Top > 373)
            {
                count++;
                pictureBox1.Top = 260;
                pictureBox1.Left = 246;

                if (count==3)
                {
                    timer1.Enabled = false;
                    button1.BackColor = Color.White;
                    Form1_Load(sender, e);
                    for (int a = 0; a < 50; a++)
                    {
                        block[a].Dispose();
                    }
                    count = 0;
                }
 
            }
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "";
            timer1.Enabled = true;
            button1.Enabled = false;
            button1.BackColor = Color.Black;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button1.Left=button1.Left-10;
                if (button1.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    x=x-2;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                button1.Left=button1.Left+10;
                if (button1.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    x=x+2;
                }
            }
            if (button1.Left > 540)
            {
                button1.Left = 540;
            }
            else if (button1.Left < 0)
            {
                button1.Left = 0;
            }
        }

        

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Left))
            {
                button1.Left = button1.Left - 10;
                if (button1.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    x = x - 2;
                }
            }
            if (e.KeyChar == Convert.ToChar(Keys.Right))
            {
                button1.Left = button1.Left + 10;
                if (button1.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    x = x + 2;
                }
            }
            if (button1.Left > 540)
            {
                button1.Left = 540;
            }
            else if (button1.Left < 0)
            {
                button1.Left = 0;
            }
        }

       
    }
}
