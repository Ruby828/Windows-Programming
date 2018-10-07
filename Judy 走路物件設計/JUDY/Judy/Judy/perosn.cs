using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Judy
{
    class Person
    {
        public PictureBox person = new PictureBox();
        public PictureBox pictureBox1 = new PictureBox();
        System.Windows.Forms.Timer personT = new System.Windows.Forms.Timer();
        int s, h;
        int destX = 0, destY = 0;

        public Person()
        {
            //person.Image = Judy.Properties.Resources._001;
            person.SizeMode = PictureBoxSizeMode.Normal;
            person.BringToFront();
            person.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Size = new System.Drawing.Size(32, 48);
            pictureBox1.BringToFront();
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            //pictureBox1.Image = person.Image;
            personT.Enabled = false;
            personT.Interval = 40;
            personT.Tick += new EventHandler(theout);
        }

        public virtual void PersonX()
        {

        }

        public void location(int x, int y)
        {
            pictureBox1.Location = new Point(x, y);
        }

        // public void theout(object sender, EventArgs args)
        private void theout(object sender, EventArgs args)
        {
            Bitmap targetbitmap = new Bitmap(32, 48, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(targetbitmap);
            s++;
            if (h == 0) { pictureBox1.Top += 4; }
            if (h == 1) { pictureBox1.Left -= 4; }
            if (h == 2) { pictureBox1.Left += 4; }
            if (h == 3) { pictureBox1.Top -= 4; }
            g.DrawImage(person.Image, new Rectangle(0, 0, 32, 48), new Rectangle((s % 4) * 32, h * 48, 32, 48), GraphicsUnit.Pixel);
            pictureBox1.Image = targetbitmap;

            if (s == 8)
            {
                s = 0;
                //位置微調成32的倍數+1
                if (h == 0) pictureBox1.Top += 1;
                if (h == 1) pictureBox1.Left -= 1;
                if (h == 2) pictureBox1.Left += 1;
                if (h == 3) pictureBox1.Top -= 1;
                personT.Stop();

            }
        }

        public void draw(int sss, int hhh)
        {
            s = sss;
            h = hhh;
            if (s > 0) { personT.Start(); }

        }

        public void removeIt()
        {
            person.Parent.Controls.Remove(person);
        }

        public void move()
        {
            pictureBox1.Left += destX;
            pictureBox1.Top += destY;
        }



    }
}
