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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            
            //image filters
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp)|*jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // create Picture window
                PictureWindow pictureWindow = new PictureWindow();

                // display image in picture box
                pictureWindow.SetPicture(open);
                // image file path
                pictureWindow.Show();
            }
        }

        private void MenuClone_Click(object sender, EventArgs e)
        {

        }
    }
}
