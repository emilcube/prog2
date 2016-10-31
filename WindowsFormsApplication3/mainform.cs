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
            panel1.BackColor = Color.Aqua;
        }

        private void Delete(object sender, EventArgs e)
        {
            panel1.BackColor = this.BackColor;
        }

        private void p(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Green, 0, 0, 200, 200);
        }
    }
}
