using System;
using System.Windows.Forms;

namespace arrays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] zahlen = new int[6];

            zahlen[0] = 0;
            zahlen[1] = 39;
            zahlen[2] = 22;
            zahlen[3] = 32;
            zahlen[4] = 6;
            zahlen[5] = 11;
        }

        //function that iteratas over the array zahlen and prints out every element in a messagebox
  

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
