using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022AS4
{
    public partial class Form1 : Form
    {
        Point first;
        Point last;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            first = e.Location;
            g = this.CreateGraphics();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            last = e.Location;
            Point topRight= new Point(last.X, first.Y);
            Point topLeft = new Point(first.X, first.Y);
            Point bottomLeft = new Point(first.X, last.Y);
            Point bottomRight = new Point(last.X, last.Y);
            g.DrawLine(Pens.Black, topRight, topLeft);
            g.DrawLine(Pens.Black, topLeft, bottomLeft);
            g.DrawLine(Pens.Black, bottomLeft, bottomRight);
            g.DrawLine(Pens.Black, bottomRight, topRight);




        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
