using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Projekt
{
    public partial class PictureWindow : Form
    {
        private int[] red = null, green = null, blue = null;
        private int[] yellow = null, pink = null, turquoise = null;
        private int[] allColors = null;

        private bool isGrey { get; set; } = true;
        private Bitmap bitmap;

        public PictureWindow()
        {
            InitializeComponent();


        }

        public PictureWindow(PictureWindow pc)
        {
            InitializeComponent();
            // ...
        }

        public void SetPicture(OpenFileDialog open)
        {
            // Adjust image to window size
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // initalize bitmap
            bitmap = new Bitmap(open.FileName);
            // set isGrey
            isGrey = Operations.isGrayScale(bitmap);
            // display picture in picture box
            pictureBox.Image = bitmap;
            // fillLutTable
            resetLutTables();
        }

        public bool getIsGrey()
        {
            return this.isGrey;
        }

        public Bitmap GetBitmap()
        {
            return this.bitmap;
        }

        private void PictureWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new HistogramWindow(this).Show();
        }
        private void fillColorTables()
        {
            red = new int[256];
            green = new int[256];
            blue = new int[256];
            yellow = new int[256];
            pink = new int[256];
            turquoise = new int[256];
            allColors = new int[256];

            for (Int32 h = 0; h < bitmap.Height; h++)
                for (Int32 w = 0; w < bitmap.Width; w++)
                {
                    Color color = bitmap.GetPixel(w, h);
                    red[color.R]++;
                    green[color.G]++;
                    blue[color.B]++;

                    if (color.R == color.G) yellow[color.R]++;
                    if (color.R == color.B) pink[color.R]++;
                    if (color.G == color.B) turquoise[color.G]++;

                    if ((color.R == color.G) && (color.G == color.B)) allColors[color.G]++;
                }
        } // make new tables and fill it

        private void fillGreyTables()
        {
            red = new int[256];
            for (Int32 h = 0; h < bitmap.Height; h++)
                for (Int32 w = 0; w < bitmap.Width; w++)
                {
                    Color color = bitmap.GetPixel(w, h);
                    red[color.R]++;
                }
        } // make new tables and fill it

        private void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        public int[] getRed() { return red; }
        public int[] getGreen() { return green; }
        public int[] getBlue() { return blue; }
        public int[] getYellow() { return yellow; }
        public int[] getTurquoise() { return turquoise; }
        public int[] getPink() { return pink; }
        public int[] getAllColors() { return allColors; }
    }

}
