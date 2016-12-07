using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Rectangle : GraphObject
    {
        public Rectangle(int x0, int y0) : base(x0, y0) { }
        public Rectangle() : base() { }

        public override int Who()
        { return 1; }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            if (Selected == true)
            {
                g.DrawRectangle(Pens.Gold, X, Y, w, h);
            }
            else { g.DrawRectangle(Pens.Black, X, Y, w, h); }
        }

        public override bool containPoint(Point p)
        {
            if (p.X >= x && p.X <= (x + w) && p.Y >= y && p.Y <= (y + h))
            {
                return true;
            }
            else { return false; }
        }


    }
}
