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
    public partial class MainWindow : Form
    {
        /**************************************************************
         * Pola
         ************************************************************/

        private LogWindow logWindow;

        /**************************************************************
         * Konstruktory
         ************************************************************/

        public MainWindow()
        {
            InitializeComponent();
            logWindow = new LogWindow();
        }

        /**************************************************************
         * Zdarzenia
         ************************************************************/

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            
            // flitry obrazu
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif)|*jpg; *.jpeg; *.gif; *.bmp; *png; *.tif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // stwórz Picture window
                PictureWindow pictureWindow = new PictureWindow();

                // wyświetl obraz w picture box
                pictureWindow.setPicture(open);

                // wyświetl okno
                pictureWindow.Show();

                // for testing
                logWindow.addLog("Opened Picture isGrey:" + (pictureWindow.IsGrey).ToString() + Environment.NewLine);
            }
        }

        // zapisz obraz - do dopracowania
        private void MenuSave_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            // save picture
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                pw.savePicture(save);
            }
        }

        private void MenuClone_Click(object sender, EventArgs e)
        {
            // weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            
            // Czy jest co klonować, jeśli nie zakończ
            if (pw == null) return;

            // stwórz kopie
            new PictureWindow(pw).Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            logWindow.Show();
        }

        private void MenuNegation_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            Operations.negation(pw.Bitmap, pw.IsGrey);
            pw.resetLutTables();
            
            pw.resetBitmap();
        }

        private void MenuShowHistogram_Click(object sender, EventArgs e)
        {
            // tylko jedno okno histogramu dla danego obrazka jest dopuszczalne

            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            pw.showHistogram();

        }

        private void MenuShowLUT_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            pw.showLutTable();
        }

        private void MenuLinearStretching_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            Operations.greyLinearStretching(pw.Bitmap, pw.Red);
            pw.resetLutTables();

            pw.resetBitmap();
        }

        private void MenuEqualization_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            Operations.greyEqualization(pw.Bitmap, pw.Red);
            pw.resetLutTables();

            pw.resetBitmap();
        }

        private void MenuThresholding_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            Threshold_Form slider = new Threshold_Form(pw);
            slider.Show();
        }
    }
}
