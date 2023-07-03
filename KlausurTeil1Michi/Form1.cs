using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlausurTeil1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.DrawRectangle(Pens.Black, 10, 10, 300, 400);

            int n = int.Parse(textBox1.Text);
            if(n > 12)
            {
                n = 12;
            }
            int x = 1;
            int y = 1;
            for (int i = 1; i <= n; i++) 
            {
             g.DrawEllipse(Pens.Black, -90 + (100 * x), 400 - (100 * y) +10 , 100, 100);
                x++;
                if(x % 4 == 0)
                {
                    x= 1;
                    y++;
                }
            }
        }
    }
}
