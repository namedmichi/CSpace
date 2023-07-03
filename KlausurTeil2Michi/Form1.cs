using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlausurTeil2Michi
{
    public partial class Form1 : Form
    {
        Graphics g;
        int n;
        Point last;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            g.DrawEllipse(Pens.White, last.X, last.Y, 50, 50);
            try
            {
                n = int.Parse(textBox1.Text);
                if(n < 0 || n > 100)
                {
                    return;
                }
                g.DrawLine(Pens.Black, 50, 200, 550, 200);

                g.DrawEllipse(Pens.Black, 50 + 500 * n / 100 - 25, 200 - 25, 50, 50);
                last = new Point(50 + 500 * n / 100 - 25, 200 - 25);
            } catch { 
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.X > 550 || e.X < 50)
            {
                return;
            }
            try
            {
            g.DrawEllipse(Pens.White, last.X, last.Y, 50, 50);

               
                g.DrawLine(Pens.Black, 50, 200, 550, 200);

                g.DrawEllipse(Pens.Black, e.X - 25, 200 - 25, 50, 50);
                last = new Point(e.X - 25, 200 - 25);
                textBox1.Text =   (( e.X - 50) / 5 ).ToString();
            }
            catch
            {
            }
        }
    }
}
