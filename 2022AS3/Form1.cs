using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022AS3
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point first;
        Point second;
        Pen pen = new Pen(Color.Black, 2);
        Boolean drawing;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            first = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            second = e.Location;
            g.DrawLine(pen, first, second);
        }
    }
}
