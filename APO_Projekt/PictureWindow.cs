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
        /**************************************************************
         * Pola
         ************************************************************/

        private static PictureWindow lastActiveWindow = null;

        // Tablice Lut dla każdego z kolorów
        private int[] red = new int[256], green = new int[256], blue = new int[256];
        private int[] yellow = new int[256], pink = new int[256], turquoise = new int[256];
        private int[] allColors = new int[256];

        private bool isGrey = true;  // czy obraz jest monochromatyczny
        private Bitmap bitmap; // obecny stan obrazka
        private HistogramWindow histogramWindow = null;  // histogram tego obrazu
        private LutWindow lutWindow = null; // tablica lut tego obrazu

        /**************************************************************
         * Konstruktory
         ************************************************************/

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
            // klonuj histogram gdy on istnieje
            if (pc.histogramWindow != null) histogramWindow = new HistogramWindow(this);
            pictureBox.Image = bitmap;
            // kopia dokładna
        }

        /**************************************************************
         * Metody
         ************************************************************/

        // Ustaw obraz, używane przy wczytywaniu
        public void setPicture(OpenFileDialog open)
        {
            // inicjalizacja bitmapy
            bitmap = new Bitmap(Image.FromFile(open.FileName));
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

        // zapisz obraz
        public void savePicture(SaveFileDialog save)
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
            if (histogramWindow != null) histogramWindow.printChart(); // aktualzuje histogram
            if (lutWindow != null) lutWindow.resetLutTable(); // aktualizuje wartości w LutWindow
        }

        public void showHistogram()
        {
            // jeśli nie ma histogramu ten obiekt lub ten został zamknięty to go stwórz
            if (histogramWindow == null || histogramWindow.IsClosed) 
            {
                histogramWindow = new HistogramWindow(this);
            }

            // pokaż histogram
            histogramWindow.Show();
        }

        public void showLutTable()
        {
            // jeśli nie ma LutWindow ten obiekt lub ten został zamknięty to go stwórz
            if (lutWindow == null || lutWindow.IsClosed)
            {
                lutWindow = new LutWindow(this);
            }
            // pokaż LutWindow
            lutWindow.Show();
        }   

        /**************************************************************
         * Właściwości
         ************************************************************/

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
        // ostatie aktywne okno PictureWindow
        public static PictureWindow LastActiveWindow { get { return lastActiveWindow; } }


        /************************************************************** 
         * Zdarzenia
         *************************************************************/

        // gdy zamykasz to okno to zamknij też histogram / LutTable
        private void PictureWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // histogram istnieje i jest otwarty
            if (histogramWindow != null && histogramWindow.IsClosed == false) histogramWindow.Close();
            // LutWindow istnieje i jest otwarte
            if (lutWindow != null && lutWindow.IsClosed == false) lutWindow.Close();
        }

        // gdy wybrane okno jest PictureWindow to zmień statyczne lastActiveWindow
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

        // Pokaż szczegóły piksela wskazywanego kursorem
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // bazowe wartości
                // działające dla obraza o wielkości pictureBox.Width, pictureBox.Height
                int x = Cursor.Position.X - this.Left - 20;
                int y = Cursor.Position.Y - this.Top - 42;

                // współczynnik skali
                double scaleX = (double) Bitmap.Width / pictureBox.Width;
                double scaleY = (double) Bitmap.Height / pictureBox.Height;

                // wylicz wskazywany piksel
                Color currentColor = bitmap.GetPixel( (int) (x * scaleX), (int) (y * scaleY));

                // wypisz kolor aktualnie wskazywanego piksela
                labelRed.Text = "Red: " + currentColor.R.ToString();
                labelGreen.Text = "Green: " + currentColor.G.ToString();
                labelBlue.Text = "Blue: " + currentColor.B.ToString();

            }
            catch(Exception ex) {}
        }

    }

    /**
     * Do naprawy
     * Gdy zamykam okno ustaw ostatnie aktywno okno na null
     */
}
