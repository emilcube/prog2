using System;
using System.Drawing;
namespace WindowsFormsApplication3

{
    internal class GraphObject
    {
        int x, y;
        int w = 100, h = 100;
        Random r = new Random();

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