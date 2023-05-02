using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeichnen_2
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool mouseIsDown;
        int lastx = 0;
        int lasty = 0;
        Pen pen = new Pen(Brushes.Black, 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                Point point = this.PointToClient(Cursor.Position);
                g.FillRectangle(Brushes.Black, point.X, point.Y, 2, 2);
                if(lastx == 0 && lasty == 0)
                {
                    lastx = point.X;
                    lasty = point.Y;
                    return;
                }
                g.DrawLine(pen, point.X, point.Y, lastx, lasty);
                lastx = point.X;
                lasty = point.Y;
               
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left)
            {
             mouseIsDown = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseIsDown = false;
                lastx = 0;
                lasty = 0;
            }
        }
    }
}
