using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jumpfloor
{
    public partial class Form1 : Form
    {
        PictureBox[] squareArray = new PictureBox[7];
        int[] squareXArray = { 3, 325, 0, 323, 121, 325, 449 }; //x 座標位置
        int[] squareYArray = { 560, 495, 384, 305, 230, 150, 80  };
        int[] squareWArray = { 327, 327, 245, 164, 164, 164,204 }; //平台寬度
       
        int click_x, step, walk_x, walk_y, ay;
        bool left, right, jump, isOnGround;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            for (int i = 0; i < 7; i++)  //產生平台
            {
                PictureBox ss = new PictureBox();
                ss.Image = jumpfloor.Properties.Resources.square1;
                squareArray[i] = ss;
                squareArray[i].Left = squareXArray[i];
                squareArray[i].Top = squareYArray[i];
                squareArray[i].Width = squareWArray[i];
                
            }
            pictureBox1.Height = 70;
            pictureBox1.Width = 55;
            pictureBox2.Left = pictureBox1.Left + pictureBox1.Width / 2;
            pictureBox2.Top = pictureBox1.Top - pictureBox1.Height;
            jump = false;
            isOnGround = true;
            timer1.Enabled = false;
            walk_x = 5; walk_y = 0;ay = 2;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //jump = true;
            //jumpMode();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            jump = true;
            jumpMode();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click_x = e.X;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(right)
            {
                if (step == 1) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_72; }
                if (step == 2) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_73; }
                if (step == 3) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_74; }
                if (step == 4) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_72; }
                if (step == 5) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_73; }
                if (step == 6) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_74; }
                pictureBox1.Left += walk_x;
                pictureBox2.Left = pictureBox1.Left + pictureBox1.Width / 2;
                step++;
                if (step == 7) { step = 0; };
            }

            if (left)
            {
                if (step == 1) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_69; }
                if (step == 2) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_70; }
                if (step == 3) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_71; }
                if (step == 4) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_69; }
                if (step == 5) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_70; }
                if (step == 6) { pictureBox1.Image = jumpfloor.Properties.Resources.shape_71; }
                pictureBox1.Left -= walk_x;
                pictureBox2.Left = pictureBox1.Left + pictureBox1.Width / 2;
                step++;
                if (step == 7) { step = 0; }
            }


            if (pictureBox1.Left >= 640) { pictureBox1.Left = 0; pictureBox2.Left = pictureBox1.Left + pictureBox1.Width / 2; }
            if (pictureBox1.Left <= 0) { pictureBox1.Left = 640; pictureBox2.Left = pictureBox1.Left + pictureBox1.Width / 2; }

            if (click_x >= pictureBox1.Left + pictureBox1.Width)
            {
                right = true;
                left = false;
            }
            if (click_x <= pictureBox1.Left)
            {
                right = false;
                left = true;
            }
            if (isOnGround) { isOnGroundTrue(); }
            if (!isOnGround) { isOnGroundFalse(); }

            OnGroundSet();
        }

        public void isOnGroundTrue()   // 平面
        {
            jumpMode();//判定是否有跳躍
            fallMode(); //判定是否還在平台
        }

        public void jumpMode()
        {
            if (jump)
            {
                walk_y -= 25;  //跳躍初始速度 –負值代表往上  
                isOnGround = false;
                jump = false;
            }
        }
        public void fallMode()
        {
            for (int i = 0; i < 7; i++)
            {
                if (pictureBox2.Top == squareArray[i].Top)
                {
                    if (!(squareArray[i].Bounds.IntersectsWith(pictureBox2.Bounds)))
                    {
                        isOnGround = false;
                    }
                }
            }
        }

        public void isOnGroundFalse()   //人物在跳躍處理 
        {
            pictureBox1.Image = jumpfloor.Properties.Resources.shape_95;
            walk_y += ay;  //地心引力往下拉的力量(減速)
            pictureBox1.Top += walk_y;
            pictureBox2.Top = pictureBox1.Top + pictureBox1.Height;
            if (walk_y >= 16) { walk_y = 16; }
        }


        public void OnGroundSet()
        {
            if (pictureBox1.Top >= 480) //判定是否已經在地板或超過地板
            {
                pictureBox1.Top = 480; pictureBox2.Top = pictureBox1.Top + pictureBox1.Height;
                walk_y = 0;
                isOnGround = true;
            }

            if (walk_y > 0) ////判定人物是否往下移動 walk_y > 0 處理是否接觸平台  walk_y < 0 代表往上移動
            {
                for (int i = 0; i < 7; i++)
                {
                    if (squareArray[i].Bounds.IntersectsWith(pictureBox2.Bounds))
                    {
                        if (pictureBox2.Top >= squareArray[i].Top)
                        {
                            pictureBox1.Top = squareArray[i].Top - pictureBox1.Height;
                            pictureBox2.Top = pictureBox1.Top + pictureBox1.Height;
                            walk_y = 0; isOnGround = true;
                        }
                    }
                }
            }

        }


    }
}
