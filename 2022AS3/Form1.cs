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
        Point fistlast;
        Point secondlast;
        Pen pen = new Pen(Color.Black, 2);
        Boolean drawing = false;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            first = e.Location;
            fistlast = e.Location;
            drawing = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            second = e.Location;
            g.DrawLine(pen, first, second);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing)
            {

                second = e.Location;
                g.DrawLine(pen, first, second);

                secondlast = e.Location;
                Pen backpen = new Pen(this.BackColor, 2);
                g.DrawLine(backpen, fistlast, secondlast);
                
            }
        }
    }
}
