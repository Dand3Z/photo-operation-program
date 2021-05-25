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

            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

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
            
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

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

            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

            Threshold_Form slider = new Threshold_Form(pw);
            slider.Show();
        }

        private void MenuPosterize_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

            PosterizeForm form = new PosterizeForm(pw);
            form.Show();
        }

        private void MenuBlur_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

            Blur_Form blur_Form = new Blur_Form(pw);
            blur_Form.Show();
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuGaussianBlur_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;

            GaussianBlur_Form gaussianBlur_Form = new GaussianBlur_Form(pw);
            gaussianBlur_Form.Show();
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuLinearSharpening_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            LinearSharpening_Form form = new LinearSharpening_Form(pw);
            form.Show();
        }

        private void MenuDirectionalEdge_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            DirectionalEdgeDetection_Form form = new DirectionalEdgeDetection_Form(pw);
            form.Show();
        }

        private void MenuGrayLevelsThresholding_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            GrayLevelsThresholding_Form slider = new GrayLevelsThresholding_Form(pw);
            slider.Show();
        }

        private void MenuAdjustableStretching_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            AdjustableStretching_Form slider = new AdjustableStretching_Form(pw);
            slider.Show();
        }

        private void MenuEdgeDetection_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            EdgeDetection_Form form = new EdgeDetection_Form(pw);
            form.Show();
        }

        private void MenuCustomMask_Click(object sender, EventArgs e)
        {
            // Weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.LastActiveWindow;
            // Czy jest na czym wykonywać operacje
            if (pw == null) return;
            // sprawdź czy obraz jest szaroodcieniowy
            if (!pw.IsGrey) return;
            CustomMask_Form form = new CustomMask_Form(pw);
            form.Show();
        }

        private void MenuMedianBlur_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null) return;
            if (!pw.IsGrey) return;
            MedianBlur_Form form = new MedianBlur_Form(pw);
            form.Show();
        }

        private void MenuBinaryPointOperations_Click(object sender, EventArgs e)
        {// isGrey do zmiany
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null) return;
            if (!pw.IsGrey) return;
            BinaryPointOperations_Form form = new BinaryPointOperations_Form(pw);
            form.Show();
        }

        private void MenuMathematicalMorphology_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null) return;
            if (!pw.IsGrey) return;
            MathematicalMorphology_Form form = new MathematicalMorphology_Form(pw);
            form.Show();
        }
    }
}
