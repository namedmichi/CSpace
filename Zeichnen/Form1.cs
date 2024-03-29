﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeichnen
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point start = new Point(0, 0);
        Point end;
        Pen pen = new Pen(Brushes.Black);
        bool first = true;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        int x;
        int y;
        int width;
        int height;
        int clicks;
        Point Point1;
        Point Point2;
        Point Point3;
        Point[] last = new Point[2];

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
            {
                if (first)
                {
                    end = new Point(e.X, e.Y);
                    start = end;
                    first = false;
                }
                if (e.Button == MouseButtons.Left)
                {
                    start = end;
                    end = new Point(e.X, e.Y);
                    last[0] = start;
                    last[1] = end;
                    g.DrawLine(pen, start, end);

                }
                if (e.Button == MouseButtons.Right)
                {
                    first = true;
                }
            }
            else if (listBox2.SelectedIndex == 1)
            {
                if (first)
                {
                    x = e.X;
                    y = e.Y;
                    clicks++;
                    first = false;
                    return;

                }
                if (clicks == 1)
                {
                    width = e.X - x;
                    if (width < 0)
                    {
                        width = width * -1;
                        x -= width;
                    }
                    clicks++;
                    return;
                }
                if (clicks == 2)
                {
                    height = e.Y - y;
                    if (height < 0)
                    {
                        height = height * -1;
                        y -= height;
                    }
                    g.DrawRectangle(pen, x, y, width, height);
                    first = true;
                    clicks = 0;
                }
            }
            else if (listBox2.SelectedIndex == 2)
            {
                Point last1 = new Point(0, 0);
                Point last2 = new Point(0, 0);
                if (clicks == 0)
                {

                    Point1 = new Point(e.X, e.Y);
                    g.DrawEllipse(Pens.Black, e.X, e.Y, 5, 5);
                  
                    clicks++;
                    return;
                }
                if (clicks == 1)
                {

                    Point2 = new Point(e.X, e.Y);
                    g.DrawEllipse(Pens.Black, e.X, e.Y, 5, 5);
                   
                    clicks++;
                    return;
                }
                if (clicks == 2)
                {

                    Point3 = new Point(e.X, e.Y);
                    Point[] curvePoints =
                                     {
                                 Point1,
                                 Point2,
                                 Point3


                    };
                    g.DrawEllipse(Pens.White, Point1.X, Point1.Y, 5, 5);
                    g.DrawEllipse(Pens.White, Point2.X, Point2.Y, 5, 5);
                    g.DrawPolygon(pen, curvePoints);
                    clicks = 0;
                }




            }


        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                return;
            }
            try
            {
                pen.Width = int.Parse(textBox1.Text);

            }
            catch
            {
                MessageBox.Show("Nur Zahlen!!!");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            first = true;
            clicks = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            g.DrawLine(Pens.White, start, end);
            end = start;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;

        }
    }
}
