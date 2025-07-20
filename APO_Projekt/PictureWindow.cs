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



namespace APO_Projekt
{
    public partial class PictureWindow : Form
    {
        private static PictureWindow lastActiveWindow = null;

        private int[] red = new int[256], green = new int[256], blue = new int[256];
        private int[] yellow = new int[256], pink = new int[256], turquoise = new int[256];
        private int[] allColors = new int[256];

        private bool isGrey = true; 
        private Bitmap bitmap; 
        private HistogramWindow histogramWindow = null;  
        private LutWindow lutWindow = null; 

        public PictureWindow()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public PictureWindow(PictureWindow pc) : this()
        {
            if (!pc.isGrey)
            {
                Array.Copy(pc.Green, green, pc.Green.Length);
                Array.Copy(pc.Blue, blue, pc.Blue.Length);
                Array.Copy(pc.Yellow, yellow, pc.Yellow.Length);
                Array.Copy(pc.Pink, pink, pc.Pink.Length);
                Array.Copy(pc.Turquoise, turquoise, pc.Turquoise.Length);
                Array.Copy(pc.AllColors, allColors, pc.AllColors.Length);
            }
            Array.Copy(pc.Red, red, pc.Red.Length);
            isGrey = pc.isGrey;
            bitmap = (Bitmap) pc.bitmap.Clone();
            if (pc.histogramWindow != null) histogramWindow = new HistogramWindow(this);
            pictureBox.Image = bitmap;
        }

        public void setPicture(OpenFileDialog open)
        {
            bitmap = new Bitmap(Image.FromFile(open.FileName));
            isGrey = Operations.isGrayScale(bitmap);

            if (isGrey)
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                bitmap = bitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }

            pictureBox.Image = bitmap;
            resetLutTables();
        }

        public void savePicture(SaveFileDialog save)
        {
            string FilePath = save.FileName;
            int index = save.FilterIndex;
            ImageFormat format;
            switch (index)
            {
                case 1:
                    format = ImageFormat.Bmp;
                    break;
                case 2:
                    format = ImageFormat.Gif;
                    break;
                case 3:
                    format = ImageFormat.Jpeg;
                    break;
                case 4:
                    format = ImageFormat.Png;
                    break;
                case 5:
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Png;
                    break;
            }
            pictureBox.Image.Save(FilePath, format);
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
                }

            for (int i = 0; i < yellow.Length; ++i)
            {
                yellow[i] = Math.Min(red[i], green[i]);
                pink[i] = Math.Min(red[i], blue[i]);
                turquoise[i] = Math.Min(green[i], blue[i]);
                allColors[i] = Math.Min(red[i], Math.Min(green[i], blue[i]));
            }
        }

        public void toGrayscale()
        {
            isGrey = true;
            if (histogramWindow != null) histogramWindow.toGrayscale();
            if (lutWindow != null) lutWindow.toGrayscale();

        }

        private void fillGreyTables()
        {
            Array.Clear(red, 0, red.Length);
            for (Int32 h = 0; h < bitmap.Height; h++)
                for (Int32 w = 0; w < bitmap.Width; w++)
                {
                    Color color = bitmap.GetPixel(w, h);
                    red[color.R]++;
                }
        } 

        public void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        public void resetBitmap()
        {
            pictureBox.Image = bitmap;  // aktualizuje wyświetlany obrazek
            if (histogramWindow != null && !histogramWindow.IsClosed) histogramWindow.printChart(); // aktualzuje histogram
            if (lutWindow != null) lutWindow.resetLutTable(); // aktualizuje wartości w LutWindow
        }

        public void showHistogram()
        {
            if (histogramWindow == null || histogramWindow.IsClosed) 
            {
                histogramWindow = new HistogramWindow(this);
            }
            histogramWindow.Show();
        }

        public void showLutTable()
        {
            if (lutWindow == null || lutWindow.IsClosed)
            {
                lutWindow = new LutWindow(this);
            }
            lutWindow.Show();
        }   

        public int[] Red { get { return this.red; } }
        public int[] Green { get { return this.green; } }
        public int[] Blue { get { return this.blue; } }
        public int[] Yellow { get { return this.yellow; } }
        public int[] Turquoise { get { return this.turquoise; } }
        public int[] Pink { get { return this.pink; } }
        public int[] AllColors { get { return this.allColors; } }
        public Bitmap Bitmap { get { return this.bitmap; }
                               set { bitmap = value; }
        }
        public bool IsGrey { get { return this.isGrey; } }
        public static PictureWindow LastActiveWindow { get { return lastActiveWindow; } }


        private void PictureWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (histogramWindow != null && histogramWindow.IsClosed == false) histogramWindow.Close();
            if (lutWindow != null && lutWindow.IsClosed == false) lutWindow.Close();
            lastActiveWindow = null;
        }

        private void PictureWindow_Activated(object sender, EventArgs e)
        {
            PictureWindow activeWindow;
            if (ActiveForm is PictureWindow)
            {
                activeWindow = (PictureWindow)ActiveForm;
            }
            else return;

            lastActiveWindow = activeWindow;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int x = Cursor.Position.X - this.Left - 20;
                int y = Cursor.Position.Y - this.Top - 42;

                double scaleX = (double) Bitmap.Width / pictureBox.Width;
                double scaleY = (double) Bitmap.Height / pictureBox.Height;

                Color currentColor;
                try
                {
                    currentColor = bitmap.GetPixel((int)(x * scaleX), (int)(y * scaleY));
                    labelRed.Text = "Red: " + currentColor.R.ToString();
                    labelGreen.Text = "Green: " + currentColor.G.ToString();
                    labelBlue.Text = "Blue: " + currentColor.B.ToString();
                }
                catch (AccessViolationException) { }
            }
            catch(Exception ex) {}
        }

    }
}
