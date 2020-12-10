using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DMHelper
{
    public partial class Form1 : Form
    {
        bool startPaint;
        Point mousePos;
        Bitmap bmp;


        public Form1()
        {
            InitializeComponent();
            try
            {
                Bitmap newBitmap = new Bitmap(@"..\..\test.bmp");
                bmp = new Bitmap(newBitmap);
                newBitmap.Dispose();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("test.bmp file not found, creating new");
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseButtons.HasFlag(MouseButtons.Left)) startPaint = false;
            if (startPaint)
            {
                Pen p = new Pen(Color.Black, 5);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawLine(p, mousePos, e.Location);
                }
                pictureBox1.Image = bmp;
                mousePos = e.Location;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            mousePos = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = bmp;

            bmp.Save(@"..\..\test.bmp");

        }
    }
}
