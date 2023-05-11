using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeichnen_2
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        bool mouseRIsDown;
        bool mouseLIsDown;
        int lastx = 0;
        int lasty = 0;
        Pen pen = new Pen(Brushes.Black, 2);
        Bitmap bmp;
        string Filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            //g = this.CreateGraphics();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void save_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseRIsDown = true;
            }
            else
            {
                mouseLIsDown = true;
            }
           
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseRIsDown = false;
                lastx = 0;
                lasty = 0;
            }
            else
            {
                mouseLIsDown = false;
                mouseLIsDown = false;
                lastx = 0;
                lasty = 0;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseRIsDown)
            {
                pictureBox1.Image = bitmap;
                Point point = this.PointToClient(Cursor.Position);
                g.FillRectangle(Brushes.Black, point.X, point.Y, 2, 2);
                if (lastx == 0 && lasty == 0)
                {
                    lastx = point.X;
                    lasty = point.Y;
                    return;
                }
                g.DrawLine(pen, point.X, point.Y, lastx, lasty);
                lastx = point.X;
                lasty = point.Y;

            }
            else if (mouseLIsDown)
            {
                pictureBox1.Image = bitmap;
                Point point = this.PointToClient(Cursor.Position);
                g.FillRectangle(Brushes.White, point.X, point.Y, 6, 6);
                if (lastx == 0 && lasty == 0)
                {
                    lastx = point.X;
                    lasty = point.Y;
                    return;
                }
                Pen temppen = new Pen(Brushes.White, 6);
                g.DrawLine(temppen, point.X, point.Y, lastx, lasty);
                lastx = point.X;
                lasty = point.Y;
            }

        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                var ret = saveFileDialog1.ShowDialog();
                if (ret.ToString() == "cancel") return;
                bitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                
            }
            catch
            {
                
          
              
         
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            var ret = openFileDialog1.ShowDialog();
            if (ret.ToString() == "Cancel") return;
            Filename = openFileDialog1.FileName.ToString();
            bmp = Streaming(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);




        }
        private Bitmap Streaming(string FileName)
        {
            MemoryStream memstream;
            FileStream fs = new FileStream(FileName, FileMode.Open);
            Byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            memstream = new MemoryStream(buffer);
            fs.Dispose();
            return (new Bitmap(memstream));
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }
    }
}
