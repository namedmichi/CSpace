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

            i = 1;
            button1.Text = "Hallo Welt zum " + i;
        }
    }
}
