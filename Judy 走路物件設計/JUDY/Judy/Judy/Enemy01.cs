using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judy
{
    class Enemy01 : Person
    {
        public override void PersonX()
        {
            person.Image = Judy.Properties.Resources._001;
            pictureBox1.Image = person.Image;
        }
    }
}
