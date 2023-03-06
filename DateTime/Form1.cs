using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTime
{
    public partial class Form1 : Form
    {


        int c = 0;
        string newLine = Environment.NewLine;

        String[] zeit = new String[13];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == 13 ) 
            {
                MessageBox.Show("Liste voll");
                return;
             }
            zeit[c]= System.DateTime.Now.ToString();
            textBox1.Text = textBox1.Text + newLine + zeit[c].ToString();
            
            c++;
        }
    }
}
