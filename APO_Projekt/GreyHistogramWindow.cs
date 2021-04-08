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
    public partial class GreyHistogramWindow : Form
    {
        private int[] LutTable;
        private PictureWindow pictureWindow;
        public GreyHistogramWindow(PictureWindow pictureWindow)
        {
            InitializeComponent();
            this.pictureWindow = pictureWindow;
        }

        private void fillLutTable()
        {
            LutTable = new int[256];
            Bitmap img = pictureWindow.GetBitmap();
            for (Int32 h = 0; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
                    LutTable[color.R]++;
                }
        } // make new LutTable and fill it




    }
}
