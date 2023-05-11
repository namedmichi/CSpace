﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRID
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        
            pictureBox1.Width = this.Width - 20;
            pictureBox1.Height = this.Height - 70 ;
            

            g.Clear(Color.White);
            g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            var x = int.Parse(textBox1.Text);
            var y = int.Parse(textBox2.Text);
            var width = pictureBox1.Width;
            var height = pictureBox1.Height;
            var xpos = (width / x);
            var ypos = height / y;
            var xposfix = xpos;
            var yposfix = ypos;
            g.DrawLine(pen, new Point(1, 1), new Point(width, 1));
            for (int i = 0; i < x; i++)
            {

                g.DrawLine(pen, new Point(xpos, 1), new Point(xpos, height));
                xpos = xpos + xposfix;
            }
            for (int i = 0; i < y; i++)
            {

                g.DrawLine(pen, new Point(1, ypos), new Point(width, ypos));
                ypos = ypos + yposfix;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            var x =  int.Parse( textBox1.Text);
            var y = int.Parse(textBox2.Text);
            var width = pictureBox1.Width;
            var height = pictureBox1.Height;
            var xpos = (width/x);
            var ypos = height / y;
            var xposfix = xpos;
            var yposfix = ypos;
            g.DrawLine(pen, new Point(1, 1), new Point(width, 1));
            for (int i = 0; i < x; i++)
            {

                g.DrawLine(pen, new Point(xpos, 1), new Point(xpos, height) );
                xpos = xpos + xposfix;
            }
            for (int i = 0; i < y; i++)
            {

                g.DrawLine(pen, new Point(1, ypos), new Point(width, ypos));
                ypos = ypos + yposfix;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
