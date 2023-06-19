using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022AS
{
    public partial class Form1 : Form
    {
        static Graphics g;
        Pen pen = new Pen(Color.Black, 3);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.DrawRectangle(pen, 50, 0 , 100, 500);
            int n = int.Parse(textBox1.Text);
            int x = 50;
            int y = 0;
            int step = 500 / n;
          
            for (int i = 0; i < n; i++) {
                g.DrawEllipse(pen, x, y, 100, step);
                y += step;
            }

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }
    }
}
