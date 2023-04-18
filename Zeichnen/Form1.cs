using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeichnen
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point start = new Point(0, 0);
        Point end;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            start = end;
            end = new Point(e.X, e.Y);
            g.DrawLine(Pens.Black, start, end);

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
