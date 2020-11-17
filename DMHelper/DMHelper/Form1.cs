using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        Point mousePos;


        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseButtons.HasFlag(MouseButtons.Left)) startPaint = false;
            if (startPaint)
            {
                Pen p = new Pen(Color.Black, 5);
                g.DrawLine(p, mousePos, e.Location);
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
            g.Save();

        }
    }
}
