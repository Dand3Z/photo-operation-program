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
        private bool isGrey { get; set; } = true;
        private Bitmap bitmap;

        public PictureWindow()
        {
            InitializeComponent();
            // temp
            new WzorHistogramuTEMP().Show();

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
            // initalize bitmap
            bitmap = new Bitmap(open.FileName);
            // set isGrey
            isGrey = Operations.isGrayScale(bitmap);
            // display picture in picture box
            pictureBox.Image = bitmap;
           
        }

        public bool getIsGrey()
        {
            return this.isGrey;
        }

        public Bitmap GetBitmap()
        {
            return this.bitmap;
        }
    }
}
