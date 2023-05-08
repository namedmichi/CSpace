using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

            bitmap.Save("C:\\Users\\selbertinger\\Desktop\\workspaces\\CSpace\\Zeichnen\\test.jpg", ImageFormat.Jpeg);
                
            }
            catch
            {
                bitmap.Dispose();
                bitmap.Save("C:\\Users\\selbertinger\\Desktop\\workspaces\\CSpace\\Zeichnen\\test.jpg", ImageFormat.Jpeg);
         
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap("C:\\Users\\selbertinger\\Desktop\\workspaces\\CSpace\\Zeichnen\\test.jpg");
            pictureBox1.Image = bitmap;
            g = Graphics.FromImage(bitmap);
        }
    }
}
