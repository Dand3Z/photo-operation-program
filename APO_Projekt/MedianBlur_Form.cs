using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace APO_Projekt
{
    public partial class MedianBlur_Form : Form
    {
        private PictureWindow pw;
        public MedianBlur_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;

            cbKernelSize.Items.Add("1x1");
            cbKernelSize.Items.Add("3x3");
            cbKernelSize.Items.Add("5x5");
            cbKernelSize.Items.Add("7x7");
            cbKernelSize.Items.Add("9x9");
            cbKernelSize.Items.Add("11x11");
            cbKernelSize.Items.Add("13x13");
            cbKernelSize.Items.Add("15x15");
            cbKernelSize.SelectedIndex = 1;
        }

        private int getKernelSize()
        {
            string kernel = cbKernelSize.SelectedItem.ToString();
            int choice = 3;
            switch (kernel)
            {
                case "1x1":
                    choice = 1;
                    break;
                case "3x3":
                    choice = 3;
                    break;
                case "5x5":
                    choice = 5;
                    break;
                case "7x7":
                    choice = 7;
                    break;
                case "9x9":
                    choice = 9;
                    break;
                case "11x11":
                    choice = 11;
                    break;
                case "13x13":
                    choice = 13;
                    break;
                case "15x15":
                    choice = 15;
                    break;
            }
            return choice;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            CvInvoke.MedianBlur(emguImage, emguImage, getKernelSize());
            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }
    }
}
