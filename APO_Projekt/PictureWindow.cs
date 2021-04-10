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
        private static PictureWindow lastActiveWindow = null;

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
            // klonuj histogram gdy on istnieje
            if (pc.histogramWindow != null) histogramWindow = new HistogramWindow(this);
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
        public void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        // zresetuj wyświelaną bitmapę i ewentualnie histogram
        // do użycia po każdej operacji na obrazie
        public void resetBitmap()
        {
            pictureBox.Image = bitmap;
            if (histogramWindow != null) histogramWindow.setChartValues();
        }

        public void showHistogram()
        {
            // jeśli nie ma histogramu ten obiekt to go stwórz
            if (histogramWindow == null)
            {
                histogramWindow = new HistogramWindow(this);
            }

            // pokaż histogram
            histogramWindow.Show();
        }

        /*
        // Test button -> do usunięcia DELETE IT
        private void btnTest_Click(object sender, EventArgs e)
        {
            Operations.negation(bitmap, isGrey);
            resetLutTables();
            pictureBox.Image = bitmap;
            if (histogramWindow != null) histogramWindow.setChartValues();
        }
        
        // tworzenie kopii -> do usunięcia DELETE IT
        private void btnCopy_Click(object sender, EventArgs e)
        {
            new PictureWindow(this).Show();
        }
        */


        /************************************************************** 
         * Events
         *************************************************************/


        // gdy zamykasz to okno to zamknij też histogram
        private void PictureWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (histogramWindow != null) histogramWindow.Close();
        }
        // gdy wybrane okno jest PictureWindow to zmień statyczne lastActiveWindow
        private void PictureWindow_Activated(object sender, EventArgs e)
        {
            PictureWindow activeWindow;
            if (ActiveForm is PictureWindow)
            {
                activeWindow = (PictureWindow)ActiveForm;
            } else return;

            lastActiveWindow = activeWindow;
        }

        /*
        // wyświetl histogram po podwójnym kliku myszy
        private void PictureWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // tylko jedno okno histogramu dla danego obrazka jest dopuszczalne

            // jeśli nie ma to stwórz i pokaż
            if (histogramWindow == null)
            {
                histogramWindow = new HistogramWindow(this);
            }

            // pokaż histogram
            histogramWindow.Show();

        }
        */

        /**************************************************************
         * getery i setery -> przyzwyczajenie z Javy
         ************************************************************/

        public int[] getRed() { return red; }
        public int[] getGreen() { return green; }
        public int[] getBlue() { return blue; }
        public int[] getYellow() { return yellow; }
        public int[] getTurquoise() { return turquoise; }
        public int[] getPink() { return pink; }
        public int[] getAllColors() { return allColors; }
        public Bitmap getBitmap() { return bitmap; }
        public bool getIsGrey() { return this.isGrey; }
        public static PictureWindow getLastActiveWindow() { return lastActiveWindow; }
        public HistogramWindow getHistogramWindow() { return histogramWindow; }
        public void setHistogramWindow(HistogramWindow hw) { this.histogramWindow = hw; }

        public void deleteHistogramWindow()
        {
            this.histogramWindow = null;
        }


    }

}
