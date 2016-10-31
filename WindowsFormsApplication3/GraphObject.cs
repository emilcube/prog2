using System;
using System.Drawing;
namespace WindowsFormsApplication3

{
    internal class GraphObject
    {
        int x,y;
        int w = 100, h = 100;
        Random r = new Random();

        public static Size MaxCoords { get; set; }

        public int X
        {
            get { return x; }
            set
            {
                if (value > MaxCoords.Width) { throw new ArgumentException("Big x"); }
                x = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value > MaxCoords.Width) { throw new ArgumentException("big y"); }
                y = value;
            }
        }

        public bool Selected { get; set; }

        public GraphObject()
        {
            x = r.Next(200);
            y = r.Next(200);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Red, x, y, w, h);
        }
    }
}