using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHelper
{
    public partial class Form2 : Form
    {
        PictureBox[,] grid;
        int xDiff, yDiff;
        string baseDir = @"..\..\Images\";

        public Form2()
        {
            InitializeComponent();
            GetArraySize();
            LoadGrid();
        }

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
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y] = new PictureBox();
                    grid[x, y].Image = LoadImage(x + xDiff, y + yDiff);

                }
            }
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
                if (x > lowestX) lowestX = x;
                if (y > highestY) highestY = y;
                if (y > lowestY) lowestY = y;
            }

            grid = new PictureBox[highestX - lowestX + 1, highestY - lowestY + 1];
            xDiff = lowestX;
            yDiff = lowestY;
        }
    }
}
