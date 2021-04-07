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
            
            //image filters
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png)|*jpg; *.jpeg; *.gif; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // create Picture window
                PictureWindow pictureWindow = new PictureWindow();

                // display image in picture box
                pictureWindow.SetPicture(open);

                // image file path
                pictureWindow.Show();

                // for testing
                logWindow.addLog("Opened Picture isGrey:" + (pictureWindow.getIsGrey()).ToString() + Environment.NewLine);
            }
        }

        private void MenuClone_Click(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            logWindow.Show();
        }
    }
}
