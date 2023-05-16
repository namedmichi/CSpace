using System;
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
        int x;
        int y;
        int height;
        int width;
        int sectorx;
        int sectory;
        Point lastPoint;
        int counter = 0;
        new List<Point> points = new List<Point>();
        int[,] array;
        private void Form1_Resize(object sender, EventArgs e)
        {
        
            pictureBox1.Width = this.Width - 20;
            pictureBox1.Height = this.Height - 70 ;
            

            g.Clear(Color.White);
            g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
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
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            var xpos = (width / x);
            var ypos = height / y;
            var xposfix = xpos;
            var yposfix = ypos;
            array = new int[x, y];
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
           for (int i = 0; i < y; i++)
            {

                g.DrawLine(pen, new Point(1, ypos), new Point(width, ypos));
                ypos = ypos + yposfix;
            }
            for(int i = 0; i < y; i++)
            {
                for(int c = 0; c< x; c++)
                {
                    array[i,c] = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            var xpos = (width / x);
            var ypos = height / y;
            sectorx = mouseX / xpos;
            sectory = mouseY / ypos;
            lastPoint = new Point(sectorx * xpos, sectory * ypos);
            points.Add(lastPoint);
            array[sectorx,sectory]++;
            g.FillRectangle(Brushes.Black, sectorx * xpos, sectory * ypos, xpos, ypos);
            g.DrawString(array[sectorx,sectory].ToString(), new Font("Arial", 12), Brushes.White, new Point((sectorx * xpos)- 10+ xpos/2, (sectory * ypos)- 10 + ypos/2));
            counter++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xpos = (width / x);
            var ypos = height / y;
            var Pointx = points[counter - 1].X / xpos;
            var Pointy = points[counter - 1].Y / ypos;
            var xposfix = xpos;
            var yposfix = ypos;
            array[Pointx, Pointy]--;
            if (array[Pointx,Pointy] > 0)
            {
                g.FillRectangle(Brushes.Black, Pointx * xpos, Pointy * ypos, xpos, ypos);
                g.DrawString(array[Pointx, Pointy].ToString(), new Font("Arial", 12), Brushes.White, new Point((Pointx * xpos) - 10 + xpos / 2, (Pointy * ypos) - 10 + ypos / 2));
                counter--;
                return;
            }
            counter--;
            g.FillRectangle(Brushes.White, Pointx * xpos, Pointy * ypos, xpos, ypos);
            points.RemoveAt(counter);
            for (int i = 0; i < x; i++)
            {

                g.DrawLine(new Pen(Color.Black, 5), new Point(xpos, 1), new Point(xpos, height));
                xpos = xpos + xposfix;
            }
            for (int i = 0; i < y; i++)
            {

                g.DrawLine(new Pen(Color.Black, 5), new Point(1, ypos), new Point(width, ypos));
                ypos = ypos + yposfix;
            }
        }
    }
}
