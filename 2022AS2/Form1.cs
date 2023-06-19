using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022AS2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point last;
        int lastrad;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int rad;
            int col;

            if(e.Button == MouseButtons.Right)
            {
                Pen penn = new Pen(Color.White, 2);
                g.DrawEllipse(penn, last.X, last.Y, lastrad, lastrad);
                return;
            }

            try
            {
                rad = int.Parse(textBox2.Text);
                col = int.Parse(textBox1.Text);


            }
            catch(Exception ex)
            {
                MessageBox.Show("Bitte gebe eine Zahl richtige Zahl ein!! Standartwerte verwendet");
                textBox1.Text = "1";
                textBox2.Text = "20";

            }
            rad = int.Parse(textBox2.Text);
            col = int.Parse(textBox1.Text);
            Color color;
            if (col == 1)
            {
                color = Color.Red;
            }
            else if (col == 2)
            {
                color = Color.Blue;
            }
            else
            {
                color = Color.Green;
            }
            Pen pen = new Pen(color, 2);
            g.DrawEllipse(pen, e.X - rad / 2, e.Y - rad / 2, rad, rad);
            last = new Point(e.X - rad / 2, e.Y - rad / 2);
            lastrad = rad;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.White, 2);
            g.DrawEllipse(pen, last.X, last.Y, lastrad, lastrad);
        }


    }
}
