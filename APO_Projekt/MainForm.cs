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
        private LogWindow logWindow;

        public MainWindow()
        {
            InitializeComponent();
            logWindow = new LogWindow();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            
            // flitry obrazu
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png)|*jpg; *.jpeg; *.gif; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // stwórz Picture window
                PictureWindow pictureWindow = new PictureWindow();

                // wyświetl obraz w picture box
                pictureWindow.SetPicture(open);

                // wyświetl okno
                pictureWindow.Show();

                // for testing
                logWindow.addLog("Opened Picture isGrey:" + (pictureWindow.getIsGrey()).ToString() + Environment.NewLine);
            }
        }

        private void MenuClone_Click(object sender, EventArgs e)
        {
            // weź ostatnie aktywne PictureWindow
            PictureWindow pw = PictureWindow.getLastActiveWindow();
            
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
            // Weź aktywne okno. Jeśli nie jest to PictureWindow to zakończ.
            PictureWindow pw = PictureWindow.getLastActiveWindow();

            // Czy jest na czym wykonywać operacje
            if (pw == null) return;

            Operations.negation(pw.getBitmap(), pw.getIsGrey());
            pw.resetLutTables();
            
            pw.resetBitmap();
            //pictureBox.Image = bitmap;
            //if (histogramWindow != null) histogramWindow.setChartValues();
        }
    }
}
