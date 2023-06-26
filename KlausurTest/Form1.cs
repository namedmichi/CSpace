using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlausurTest
{
    public partial class Form1 : Form
    {

        bool circle = true;
        bool firstX = true;
        Graphics g;
        Pen pen = new Pen( Color.Black, 1 );
        Point startPo = new Point();
        int fixX;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(circle)
            {
                startPo = new Point(e.X, e.Y);
                g.DrawEllipse(pen, e.X - 5, e.Y - 5, 10, 10);
                circle = false;
                return;
            }
            if( firstX )
            {
                g.DrawLine(pen, startPo, new Point(e.X, e.Y));
                fixX = e.X;
                firstX = false;
                return;
            }
            g.DrawLine(pen, startPo, new Point(fixX, e.Y)); 

        }
    }
}
