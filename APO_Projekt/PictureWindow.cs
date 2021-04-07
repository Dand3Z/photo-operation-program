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
        public PictureWindow()
        {
            InitializeComponent();
        }

        public PictureWindow(PictureWindow pc)
        {
            InitializeComponent();
            // ...
        }

        public void SetPicture(OpenFileDialog open)
        {
            // Adjust image to window size
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // display picture in picture box
            pictureBox.Image = new Bitmap(open.FileName);
        }
    }
}
