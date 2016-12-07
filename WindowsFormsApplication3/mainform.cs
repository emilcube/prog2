using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication3
{
    public partial class MainForm : Form
    {
        private List<GraphObject> elements = new List<GraphObject>();
        bool dragging;
        int dx = 0, dy = 0;
        bool elli;
        int chElli;
        Random rand = new Random();

        public MainForm()
        {
            InitializeComponent();
            GraphObject.MaxCoords = panel1.ClientSize;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Add(object sender, EventArgs e)
        {
            //GraphObject r = new GraphObject();
            //elements.Add(r);
            //panel1.Invalidate();

            chElli = rand.Next(10);
            if (chElli < 5) elli = true;
            else elli = false;
            if (elli) elements.Add(new Ellipse());//elements.Add(new Ellipse(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            else elements.Add(new Rectangle());//elements.Add(new Rectangle(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            label.Text = String.Format("создан {0} объект", elements.Count);
            panel1.Invalidate();

        }

        private void Delete(object sender, EventArgs e)
        {
            //elements.RemoveAt(elements.Count - 1);
            //panel1.Invalidate();

            panel1.BackColor = this.BackColor;
            if (elements.Count > 0)
            {
                elements.RemoveAt(elements.Count - 1);
                panel1.Invalidate();
                label.Text = String.Format("Удален {0} объект", elements.Count + 1);
            }
            else
            {
                label.Text = "Удалять нечего, объектов нет";
            }
        }

        private void p(object sender, PaintEventArgs e)
        {
            foreach (GraphObject r in elements)
            {
                r.Draw(e.Graphics);
            }

        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {
            //elements.Clear();
            //panel1.Invalidate();

            if (elements.Count > 0)
            {
                label.Text = String.Format("Удалено {0} объектов", elements.Count);
                elements.Clear();
            }
            else
            {
                label.Text = "Удалять нечего, объектов нет";
            }
            panel1.Invalidate();


        }


        private void MouseDoubleClick11(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)

        {
            try
            {
            chElli = rand.Next(10);
            if (chElli < 5) elli = true;
            else elli = false;
            if (elli) elements.Add(new Ellipse(e.X, e.Y));
            else elements.Add(new Rectangle(e.X, e.Y));
            label.Text = String.Format("создан {0} объект", elements.Count);
            }
            catch (ArgumentException ex)
            {
                label.Text = ex.Message;
            }
            panel1.Refresh();

            //try
            //{
            //    //
            //    GraphObject r = new GraphObject();
            //    r.X = e.X;
            //    r.Y = e.Y;
            //    elements.Add(r);
            //    panel1.Refresh();
            //    label.Text = "New Rectangle!";
            //}
            //catch (ArgumentException ex)
            //{
            //   label.Text = ex.Message;
            //}
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
          GraphObject.MaxCoords = panel1.ClientSize;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            /*foreach (GraphObject r in elements)
{
    r.containPoint(e.Location);
    if (r.Selected) { dragging = true; dx = e.Location.X - e.Location.X; dy = e.Location.Y - e.Location.Y; }
}*/

            int v = -1;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].containPoint(e.Location)) v = i;
            }
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Selected = (i == v);
            }

            if (v != -1)
            {
                dragging = true;

                int x = e.X;
                int y = e.Y;
                /*
                                bool i = true;
                                bool j = true;

                                while (i)
                                {
                                    dx = x - 50;
                                    x = x - 50;
                                    if (dx <= 50) { i = false; }
                                }
                                while (j)
                                {
                                    dy = y - 50;
                                    y = y - 50;
                                    if (dy <= 50) { j = false; }
                                }
                                */
                dx = e.X - elements[v].X; dy = e.Y - elements[v].Y;
                panel1.Invalidate(); return;
            }

            panel1.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!dragging) return;
                Point m = new Point(e.X - dx, e.Y - dy);
                foreach (GraphObject r in elements) if (r.Selected) r.Location = m;
                
            }
            catch (Exception ex)
            {
                label.Text = ex.Message;
            }
            panel1.Invalidate();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (dragging) dragging = false;
                else return;
            }
            
            catch (Exception ex)
            {
                label.Text = ex.Message;
            }

            panel1.Invalidate();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (GraphObject r in elements)
            {
                r.containPoint(e.Location);
                if (r.Selected) return;
            }
            panel1.Invalidate();
        }

        private void RemoveSelected(object sender, EventArgs e)
        {
            List<GraphObject> elements1 = new List<GraphObject>();
            foreach (GraphObject r in elements)
            {
                if (!r.Selected) { elements1.Add(r); }
            }
            elements = elements1;
            /* foreach (GraphObject r in elements)
             {
                 if (r.Selected) { elements.Remove(r); } 
             }       */
            label.Text = String.Format("выбранный объект удален");
            panel1.Invalidate();

        }

        private void MoveSelected(object sender, EventArgs e)
        {
            try
            {
                foreach (GraphObject r in elements)
                {
                    if (r.Selected) { Point m = new Point(rand.Next(panel1.Width - r.X), rand.Next(panel1.Height - r.Y)); r.Location = m; }
                }
                label.Text = String.Format("выбранный объект перемещен");
            }
            catch (Exception ex)
            {

                label.Text = ex.Message;
            }
            

            panel1.Invalidate();
        }


        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }



    }
}
