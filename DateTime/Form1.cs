using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<TimeSpan> timespan = new List<TimeSpan>();
        List<int> nr = new List<int>();
        Stopwatch stopWatch = new Stopwatch();
        
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

    
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            zeit.Add(elapsedTime);
            timespan.Add(ts);
            TimeSpan firstT = timespan[0];  
            TimeSpan curT = timespan[c];
            TimeSpan dif = curT - firstT;
            string diff = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            dif.Hours, dif.Minutes, dif.Seconds,
            dif.Milliseconds / 10);

            nr.Add(int.Parse(textBoxNr.Text));
            label3.Text = c+1 + "/" + teil + " Teilnehmern sind schon im Ziel";
            listBox1.Items.Add("Nr." + String.Format("{0:000}", nr[c]) + "       " + zeit[c]+ "  +" + diff );
            label3.Visible= true;
            c++;
        }

        private void Bestaetigen_Click(object sender, EventArgs e)
        {
            if  (textBox2.Text != "" )
            {

                teil = int.Parse(textBox2.Text);
                textBox2.Visible= false;label2.Visible= false;button2.Visible= false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {        
                if (nr.Contains(int.Parse(textBoxNr.Text)))
                {
                    MessageBox.Show("Nr. schon vorhanden");
                    return;
                }
                nr[index] = int.Parse(textBoxNr.Text);

                listBox1.Items[index] = "Nr." + nr[index].ToString("000") + "       " + zeit[index].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                listBox1.Visible= true; textBoxNr.Visible= true; label1.Visible= true;button1.Visible= true; button4.Visible = true; btnEdit.Visible=true;
                stopWatch.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                nr.RemoveAt(index);
                zeit.RemoveAt(index);
                timespan.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
                c -= 1;
            }
        }
    }
}
