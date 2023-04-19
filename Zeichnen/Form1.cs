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
        Pen pen = Pens.Black;
        bool first = true;
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
            if (first)
            {
                end = new Point(e.X, e.Y);
                start = end;
                first = false;
            }
            if(e.Button == MouseButtons.Left)
            {
            start = end;
            end = new Point(e.X, e.Y);
            g.DrawLine(pen, start, end);

            }
            if(e.Button == MouseButtons.Right)
            {
                first  = true;
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           if( listBox1.SelectedIndex == 0 )
            {
                MessageBox.Show(listBox1.SelectedIndex.ToString());
                pen = Pens.Red;
            } else if ( listBox1.SelectedIndex == 1 )
            {
                pen = Pens.Green;
            }else if ( listBox1.SelectedIndex == 2 )
            {
                pen = Pens.Black;
            }
            else
            {
                pen = Pens.Blue;
            }

        }
    }
}
