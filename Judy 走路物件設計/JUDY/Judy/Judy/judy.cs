using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace Judy
{
    class judy
    {
        public PictureBox judyA = new PictureBox();
        public PictureBox pictureBox1 = new PictureBox();
        static System.Windows.Forms.Timer judyT = new System.Windows.Forms.Timer();
        static int s, h;

        public judy()
        {
            judyA.Image = Judy.Properties.Resources.Judy;
            judyA.SizeMode = PictureBoxSizeMode.Normal;
            judyA.BringToFront();
            judyA.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Size = new System.Drawing.Size(32, 48);
            pictureBox1.BringToFront();
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = Judy.Properties.Resources.Judy;
            judyT.Enabled = false;
            judyT.Interval = 40;
            judyT.Tick += new EventHandler(theout);
        }

        public void location(int x, int y)
        {
            pictureBox1.Location = new Point(x, y);
        }

        public void theout(object sender, EventArgs args)
        {
            Bitmap targetbitmap = new Bitmap(32, 48, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(targetbitmap);
            s++;
            if (h == 0) { pictureBox1.Top += 4; }
            if (h == 1) { pictureBox1.Left -= 4; }
            if (h == 2) { pictureBox1.Left += 4; }
            if (h == 3) { pictureBox1.Top -= 4; }
            g.DrawImage(judyA.Image, new Rectangle(0, 0, 32, 48), new Rectangle((s % 4) * 32, h * 48, 32, 48), GraphicsUnit.Pixel);
            pictureBox1.Image = targetbitmap;

            if (s == 8)
            {
                s = 0;
                //位置微調成32的倍數+1
                if (h == 0) pictureBox1.Top += 1;
                if (h == 1) pictureBox1.Left -= 1;
                if (h == 2) pictureBox1.Left += 1;
                if (h == 3) pictureBox1.Top -= 1;
                judyT.Stop();

            }
        }

        public void draw(int sss, int hhh)
        {
            s = sss;
            h = hhh;
            if (s > 0) { judyT.Start(); }

        }

        public void removeIt()
        {
            judyA.Parent.Controls.Remove(judyA);
        }
    }
}
