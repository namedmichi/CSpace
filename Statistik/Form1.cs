using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Statistik
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }
        int fixPos = 527;
        List<int> reverse = new List<int>();
        int heigt = 500;
        string path = @"C:\Users\selbertinger\Desktop\workspaces\CSpace\Statistik\MyTest.csv";
        string ende;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Zahl eingeben");
                return;
            }
            if(heigt + (5 * int.Parse(textBox1.Text)) > 500)
            {
                MessageBox.Show("Maximale Höhe erreicht");
                return;
            }
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (5*int.Parse(textBox1.Text)));
            button1.Height = button1.Height + (5 * int.Parse(textBox1.Text));
            reverse.Add(-(5 * int.Parse(textBox1.Text)));
            heigt += (5 * int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "")
            {
                MessageBox.Show("Zahl eingeben");
                return; 
            }
            if (heigt - (5 * int.Parse(textBox1.Text)) <= 0)
            {
                MessageBox.Show("Minimale Höhe erreicht");
                return;
            }
            button1.Location = new Point(button1.Location.X, button1.Location.Y + (5 *int.Parse(textBox1.Text)));
            button1.Height = button1.Height - (5 * int.Parse(textBox1.Text));
            reverse.Add((5 * int.Parse(textBox1.Text)));
            heigt -= (5 * int.Parse(textBox1.Text));
        }

        private void zurück_Click(object sender, EventArgs e)
        {
            if(reverse.Count== 0)
            {
                MessageBox.Show("Es gibt keine vorherigen werte mehr");
                return;
            }
           int zurück = reverse[reverse.Count - 1];
           button1.Location = new Point(button1.Location.X, button1.Location.Y - zurück);
           button1.Height = button1.Height + zurück;
            heigt = button1.Height;
            reverse.RemoveAt(reverse.Count - 1);
            

        }

        private void set_Click(object sender, EventArgs e)
        {
            if((5 * int.Parse(textBox2.Text)) > 500)
            {
                MessageBox.Show("Zu groß");
                return; 
            }
            if(button1.Height > (5 * int.Parse(textBox2.Text)))
            {
                reverse.Add((button1.Height - (5 * int.Parse(textBox2.Text))));
            }
            else
            {
                reverse.Add( -(5 * int.Parse(textBox2.Text)- button1.Height));
            }
            button1.Height = (5 * int.Parse(textBox2.Text));
              
            int offset = button1.Height;
            heigt = button1.Height;
            button1.Location = new Point(button1.Location.X, fixPos - offset);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (textBox3.Lines.Any())
            {
                ende = textBox3.Lines[textBox3.Lines.Length - 2] + Environment.NewLine;
                MessageBox.Show(textBox3.Lines[textBox3.Lines.Length - 2]);
                MessageBox.Show(ende.GetType().ToString());
            }

            string createText = (button1.Height / 5).ToString() + "%;" + DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss") + "; " + DateTime.Now.Day + Environment.NewLine;
            if (ende.Equals(createText))
            {
                MessageBox.Show("schon vorhanden");
                return;
            }
            File.AppendAllText(path, createText);
            button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = File.ReadAllText(path);
        }
    }
}
