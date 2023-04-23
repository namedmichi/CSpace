using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ( listBox2.SelectedIndex == 0)
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
            }else if ( listBox2.SelectedIndex == 1)
            {
                if (first)
                {
                    x = e.X;
                    y = e.Y;
                    clicks++;
                    first = false;
                    return;

                }
                if  (clicks == 1)
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
                if(clicks == 2)
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
            }else if ( listBox2.SelectedIndex == 2)
            {
                if ( clicks == 0)
                {

                    Point1 = new Point(e.X, e.Y);
                    clicks++;
                    return;
                }
                if (clicks == 1)
                {

                    Point2 = new Point(e.X, e.Y);
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

                    // Draw polygon to screen.
                    g.DrawPolygon(pen, curvePoints);
                    clicks = 0;
                }


        

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
                pen = new Pen(Brushes.Red);
                pen.Width = 5;
            } else if ( listBox1.SelectedIndex == 1 )
            {
                pen = new Pen(Brushes.Green);
            }else if ( listBox1.SelectedIndex == 2 )
            {
                pen = new Pen(Brushes.Black);
            }
            else
            {
                pen = new Pen(Brushes.Blue);
            }

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length <= 0)
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
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            
            Thread.Sleep(2000); 
            Form1.ActiveForm.ClientSize = new Size(this.width, this.height);
        }
    }
}
