using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHelper
{
    public partial class Form1 : Form
    {
        bool startPaint;
        Graphics g;
        int? initX = null;
        int? initY = null;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint)
            {
                //Setting the Pen BackColor and line Width
                Pen p = new Pen(Color.Black, 5);
                //Drawing the line.
                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Hello World!");
            startPaint = true;
        }
    }
}
