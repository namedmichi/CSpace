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
        int b4ersaz = 1;
        public Form1()
        {
            InitializeComponent();
            
        }
        int i = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            button1.Text = "Hallo Welt zum " + i;
            i++;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int faktortemp = 
            i = 1;
            button1.Text = "Hallo Welt zum " + i;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            b3ersaz = b3ersaz * 10;
            button4.Text = b3ersaz.ToString();
            
        }
        private void button5_Click(object sender, EventArgs e)
        {

            b4ersaz = b4ersaz / 10;
            button5.Text = b4ersaz.ToString();


        }
    }
}
