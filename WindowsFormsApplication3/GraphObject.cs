using System;
using System.Drawing;
namespace WindowsFormsApplication3

{
    abstract class GraphObject
    {
        protected Color c;
        protected int x, y;
        protected int w, h;
        protected Brush brush;
        protected Random rand = new Random();
 
        public GraphObject(int x, int y)
        {
            Color[] cols = { Color.Blue, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan };
            c = cols[rand.Next(cols.Length)];
            X = x;
            Y = y;
            w = 40;
            h = 40;
            brush = new SolidBrush(c);

        }


        public GraphObject()
        {
            Color[] cols = { Color.Blue, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan };
            c = cols[rand.Next(cols.Length)];
            x = rand.Next(w, MaxCoords.Width - w);
            y = rand.Next(h, MaxCoords.Height - h);
            w = 40;
            h = 40;
            brush = new SolidBrush(c);

        }

        public static Size MaxCoords { get; set; }

        public Point Location { get { return new Point(x, y); } set { x = value.X; y = value.Y; } }

        public int X
        {
            get { return x; }
            set
            {
                if (value > 350 - w) { throw new ArgumentException("Big x"); }
                x = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value > 250 - h) { throw new ArgumentException("Big y"); }
                y = value;
            }
        }

        abstract public void Draw(Graphics g);

        abstract public bool containPoint(Point p);

        public bool Selected { get; set; }

        abstract public int Who();

    }
}