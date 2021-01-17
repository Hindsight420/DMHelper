using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DMHelper
{
    public partial class Form2 : Form
    {
        Bitmap[,] grid; //from 0 to 10
        Bitmap fullMap;
        int xDiff, yDiff; //from -5 to 5
        string baseDir = @"..\..\Images\";
        const int imageSize = 300;

        public Form2()
        {
            InitializeComponent();
            GetArraySize();
            LoadGrid();
        }

        //Load all images and draw them in the pictureBox
        Bitmap LoadImage(int x, int y)
        {
            Bitmap bmp;
            try
            {
                Console.WriteLine(baseDir + x + "_" + y + ".bmp");
                Bitmap newBitmap = new Bitmap(baseDir + x + "_" + y + ".bmp");
                bmp = new Bitmap(newBitmap);
                newBitmap.Dispose();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("test.bmp file not found, creating new");
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            return bmp;
        }

        void LoadGrid()
        {
            using (Graphics g = Graphics.FromImage(fullMap))
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        //grid[x, y] = new Bitmap();
                        grid[x, y] = LoadImage(x + xDiff, y + yDiff);
                        g.DrawImage(grid[x, y], x * imageSize + 1, y * imageSize + 1);
                    }
                }
            }
            pictureBox1.Image = fullMap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void GetArraySize()
        {
            int highestX = 0;
            int lowestX = 0;
            int highestY = 0;
            int lowestY = 0;

            var filenames = from fullFilename
                            in Directory.EnumerateFiles(baseDir)
                            select Path.GetFileNameWithoutExtension(fullFilename);
            foreach (string filename in filenames)
            {
                string[] split = filename.Split('_');
                int x = Convert.ToInt32(split[0]);
                int y = Convert.ToInt32(split[1]);

                if (x > highestX) highestX = x;
                if (x < lowestX) lowestX = x;
                if (y > highestY) highestY = y;
                if (y < lowestY) lowestY = y;
            }

            int xResolution = highestX - lowestX + 1;
            int yResolution = highestY - lowestY + 1;

            grid = new Bitmap[xResolution, yResolution];
            xDiff = lowestX;
            yDiff = lowestY;
            fullMap = new Bitmap(imageSize * xResolution + xResolution + 1, imageSize * yResolution + yResolution + 1);
        }
    }
}
