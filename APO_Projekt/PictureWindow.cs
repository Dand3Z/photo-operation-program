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

        // Tablice Lut dla każdego z kolorów
        private int[] red = new int[256], green = new int[256], blue = new int[256];
        private int[] yellow = new int[256], pink = new int[256], turquoise = new int[256];
        private int[] allColors = new int[256];

        private bool isGrey { get; set; } = true;  // czy obraz jest monochromatyczny
        private Bitmap bitmap; // obecny stan obrazka
        private HistogramWindow histogramWindow = null;  // histogram tego obrazu
        private LutWindow lutWindow = null;

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

            // dla czarnobiałego obrazu zmień jego format
            if (isGrey)
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                bitmap = bitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                /**************************************************************************************
                 * Zmieniamy format. Jeśli coś będzie nie tak to z formatem to na etapie zapisu
                 * zmień ponownie format.
                 *************************************************************************************/
            }

            // przypisanie obrazka do picture boxa
            pictureBox.Image = bitmap;
            // wypełnij tabicę lut
            resetLutTables();
        }

        // save picture
        public void SavePicture(SaveFileDialog save)
        {
            string FilePath = save.FileName;
            pictureBox.Image.Save(FilePath, ImageFormat.Png);
            // dodaj różne formaty później !!!
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

            // wypełnienie tablicy Lut podstawowych barw
            for (Int32 h = 0; h < bitmap.Height; h++)
                for (Int32 w = 0; w < bitmap.Width; w++)
                {
                    Color color = bitmap.GetPixel(w, h);
                    red[color.R]++;
                    green[color.G]++;
                    blue[color.B]++;

                    //if (color.R == color.G) yellow[color.R]++;
                    //if (color.R == color.B) pink[color.R]++;
                    //if (color.G == color.B) turquoise[color.G]++;

                    //if ((color.R == color.G) && (color.G == color.B)) allColors[color.G]++;
                }

            // wyliczenie tablic kombinacyjnych
            for (int i = 0; i < yellow.Length; ++i)
            {
                yellow[i] = Math.Min(red[i], green[i]);
                pink[i] = Math.Min(red[i], blue[i]);
                turquoise[i] = Math.Min(green[i], blue[i]);
                allColors[i] = Math.Min(red[i], Math.Min(green[i], blue[i]));
            }

        }

        // na nowo wylicza wartości dla obrazka monochromatycznego
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

        // Wylicz na nowo wartości dla obrazka
        public void resetLutTables()
        {
            if (isGrey) fillGreyTables();
            else fillColorTables();
        }

        // zresetuj wyświelaną bitmapę i ewentualnie histogram / LutWindow
        // do użycia po każdej operacji na obrazie
        public void resetBitmap()
        {
            pictureBox.Image = bitmap;  // aktualizuje wyświetlany obrazek
            if (histogramWindow != null) histogramWindow.setChartValues(); // aktualzuje histogram
            if (lutWindow != null) lutWindow.resetLutTable(); // aktualizuje wartości w LutWindow
        }

        public void showHistogram()
        {
            // jeśli nie ma histogramu ten obiekt lub ten został zamknięty to go stwórz
            if (histogramWindow == null || histogramWindow.getIsClosed()) 
            {
                histogramWindow = new HistogramWindow(this);
            }

            // pokaż histogram
            histogramWindow.Show();
        }

        public void showLutTable()
        {
            // jeśli nie ma LutWindow ten obiekt lub ten został zamknięty to go stwórz
            if (lutWindow == null || lutWindow.getIsClosed())
            {
                lutWindow = new LutWindow(this);
            }
            // pokaż LutWindow
            lutWindow.Show();
        }

        public void deleteHistogramWindow()
        {
            // this.histogramWindow = null;
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
            // histogram istnieje i jest otwarty
            if (histogramWindow != null && histogramWindow.getIsClosed() == false) histogramWindow.Close();
            // LutWindow istnieje i jest otwarte
            if (lutWindow != null && lutWindow.getIsClosed() == false) histogramWindow.Close();
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

    }
}
