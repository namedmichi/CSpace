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

        int teil = 0;
        int c = 0;
        string newLine = Environment.NewLine;

        List<string> zeit = new List<string>();
        List<int> nr = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == teil ) 
            {
                MessageBox.Show("Liste voll");
                return;
             }
            
            if (nr.Contains(int.Parse(textBoxNr.Text)))
            {
                MessageBox.Show("Nr. schon vorhanden");
                return;
            }

            nr.Add(int.Parse(textBoxNr.Text));
            zeit.Add(System.DateTime.Now.TimeOfDay.ToString());
            label3.Text = c+1 + "/" + teil + " Teilnehmern sind schon im Ziel";
            textBox1.Text = textBox1.Text  + "Nr." + nr[c] + "       " + zeit[c].ToString() + newLine;
            label3.Visible= true;
            c++;
        }

        private void Bestaetigen_Click(object sender, EventArgs e)
        {
            if  (textBox2.Text != "" )
            {

                teil = int.Parse(textBox2.Text);
                textBox1.Visible= true; textBoxNr.Visible= true; label1.Visible= true;button1.Visible= true; 
                textBox2.Visible= false;label2.Visible= false;button2.Visible= false;
            }
        }
    }
}
