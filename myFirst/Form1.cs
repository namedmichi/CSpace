using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFirst
{
    public partial class Form1 : Form
    {
        int b3ersaz = 1;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            i = i + b3ersaz;
            
            button1.Text = "Hallo Welt zum " + i;
            

        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Text = "Hallo Welt zum 0";
            b3ersaz= 0;
            i = 0;
            button4.Text = b3ersaz.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                b3ersaz = b3ersaz / 10;
                if (b3ersaz < 1)
                {
                    b3ersaz = 1;
                    
                }
                button4.Text = b3ersaz.ToString();
            }
            else
            {
                b3ersaz = b3ersaz * 10;
                
                if (b3ersaz < 1)
                {
                    b3ersaz = 1;
                }
                button4.Text = b3ersaz.ToString();
            }
        }
    }
}
