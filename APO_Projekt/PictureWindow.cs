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
        // Tablice Tut dla każdego z kolorów
        private int[] red = new int[256], green = new int[256], blue = new int[256];
        private int[] yellow = new int[256], pink = new int[256], turquoise = new int[256];
        private int[] allColors = new int[256];

        
        private bool isGrey { get; set; } = true;  // czy obraz jest monochromatyczny
        private Bitmap bitmap; // obecny stan obrazka
        private HistogramWindow histogramWindow = null;  // 

        public PictureWindow()
        {
            InitializeComponent();
            // Dostosuj rozmiar obrazu do rozmiaru okna
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // konstruktor samokopiujący
        public PictureWindow(PictureWindow pc) : this()
        {
            if (!pc.isGrey)
            {
                // w przypadku obrazu kolorowego kopiujemy wszystkie barwy
                Array.Copy(pc.getGreen(), green, pc.getGreen().Length);
                Array.Copy(pc.getBlue(), blue, pc.getBlue().Length);
                Array.Copy(pc.getYellow(), yellow, pc.getYellow().Length);
                Array.Copy(pc.getPink(), pink, pc.getPink().Length);
                Array.Copy(pc.getTurquoise(), turquoise, pc.getTurquoise().Length);
                Array.Copy(pc.getAllColors(), allColors, pc.getAllColors().Length);
            }
            Array.Copy(pc.getRed(), red, pc.getRed().Length);
            isGrey = pc.isGrey;
            bitmap = (Bitmap) pc.bitmap.Clone();
            histogramWindow = new HistogramWindow(pc.histogramWindow);
            pictureBox.Image = bitmap;
            // kopia dokładna
        }

        // Ustaw obraz
        public void SetPicture(OpenFileDialog open)
        {
            // inicjalizacja bitmapy
            bitmap = new Bitmap(open.FileName);
            // ustawienie isGrey
            isGrey = Operations.isGrayScale(bitmap);
            // przypisanie obrazka do picture boxa
            pictureBox.Image = bitmap;
            // wypełnij tabicę lut
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

        // wyświetl histogram po podwójnym kliku myszy
        private void PictureWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (histogramWindow == null)
            {
                histogramWindow = new HistogramWindow(this);
                histogramWindow.Show();
            }
            else
            {
                histogramWindow.Show();
            }
          
            
        }

        // na nowo wylicza wartości dla obrazka kolorowego
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
        }

        // na nowo wylicza wartości dla obrazka monochromatycznego
        private void fillGreyTables()
        {
            red = new int[256];
            for (Int32 h = 0; h < bitmap.Height; h++)
                for (Int32 w = 0; w < bitmap.Width; w++)
                {
                    Color color = bitmap.GetPixel(w, h);
                    red[color.R]++;
                }
        } 

        // Wylicz na nowo wartości dla obrazka
        private void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        // Test button -> do usunięcia
        private void btnTest_Click(object sender, EventArgs e)
        {
            Operations.negation(bitmap, isGrey);
            resetLutTables();
            pictureBox.Image = bitmap;
            if (histogramWindow != null) histogramWindow.setChartValues();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            new PictureWindow(this).Show();
        }

        /**
         * getery i setery -> przyzwyczajenie z Javy
         */

        public int[] getRed() { return red; }
        public int[] getGreen() { return green; }
        public int[] getBlue() { return blue; }
        public int[] getYellow() { return yellow; }
        public int[] getTurquoise() { return turquoise; }
        public int[] getPink() { return pink; }
        public int[] getAllColors() { return allColors; }
    }

}
