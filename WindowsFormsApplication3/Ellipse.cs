using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Ellipse : GraphObject
    {
        public Ellipse(int x0, int y0) : base(x0, y0) { }
        public Ellipse() : base() { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            if (Selected == true)
            {
                g.DrawEllipse(Pens.Gold, X, Y, w, h);
            }
            else { g.DrawEllipse(Pens.Black, X, Y, w, h); }
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
