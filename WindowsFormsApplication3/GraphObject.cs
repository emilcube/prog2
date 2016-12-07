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
            x = rand.Next(w / 2, MaxCoords.Width - w / 2);
            y = rand.Next(h / 2, MaxCoords.Height - h / 2);
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
                if (value > MaxCoords.Width-w/2) { throw new ArgumentException("Big x"); }
                x = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value > MaxCoords.Height - h / 2) { throw new ArgumentException("Big y"); }
                y = value;
            }
        }

        abstract public void Draw(Graphics g);

        abstract public bool containPoint(Point p);

        public bool Selected { get; set; }
    }
}