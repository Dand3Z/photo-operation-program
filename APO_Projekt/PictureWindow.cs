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
        private int[] red = new int[256], green = new int[256], blue = new int[256];
        private int[] yellow = new int[256], pink = new int[256], turquoise = new int[256];
        private int[] allColors = new int[256];

        private bool isGrey { get; set; } = true;
        private Bitmap bitmap; // current state of picture
        private HistogramWindow histogramWindow = null;

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
            histogramWindow = new HistogramWindow(this);
            histogramWindow.Show();
        }
        private void fillColorTables()
        {
            Array.Clear(red, 0, red.Length);
            Array.Clear(green, 0, green.Length);
            Array.Clear(blue, 0, blue.Length);
            Array.Clear(yellow, 0, yellow.Length);
            Array.Clear(pink, 0, pink.Length);
            Array.Clear(turquoise, 0, turquoise.Length);
            Array.Clear(allColors, 0, allColors.Length);

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

        // use it to reset lutTables after changes
        private void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Operations.negation(bitmap, isGrey);
            resetLutTables();
            pictureBox.Image = bitmap;
            if (histogramWindow != null) histogramWindow.setChartValues();
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
