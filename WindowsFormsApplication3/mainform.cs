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
        List<GraphObject> elements = new List<GraphObject>();
        public MainForm()
        {
            InitializeComponent();
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
            //panel1.BackColor = Color.Aqua;
            GraphObject r = new GraphObject();
            elements.Add(r);
            panel1.Invalidate();
        }

        private void Delete(object sender, EventArgs e)
        {
            //panel1.BackColor = this.BackColor;
            elements.RemoveAt(elements.Count - 1);
            panel1.Invalidate();
        }

        private void p(object sender, PaintEventArgs e)
        {
            foreach(GraphObject r in elements)
            { 
               r.Draw(e.Graphics);
            }

            }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {
            
        }
    }
}
