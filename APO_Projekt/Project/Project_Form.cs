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
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace APO_Projekt.Project
{
    public partial class Project_Form : Form
    {
        private Image<Bgr, byte> colorImg;
        private Image<Gray, byte> grayImg;

        private double[] colorValidity = { 0.11, 0.59, 0.30 }; // B, G, R


        public Project_Form()
        {
            InitializeComponent();
        }

        // invoke in open button
        private void calculateColorHistogram()
        {
            float[] blue;
            float[] green;
            float[] red;

            DenseHistogram denseHistogram = new DenseHistogram(256, new RangeF(0, 256));

            Image<Gray, Byte> imgBlue = colorImg[0];
            Image<Gray, Byte> imgGreen = colorImg[1];
            Image<Gray, Byte> imgRed = colorImg[2];
            
            denseHistogram.Calculate(new Image<Gray, Byte>[] { imgBlue }, true, null);
            blue = denseHistogram.GetBinValues();  // BLUE
            denseHistogram.Clear();

            denseHistogram.Calculate(new Image<Gray, Byte>[] { imgGreen }, true, null);
            green = denseHistogram.GetBinValues();  // GREEN
            denseHistogram.Clear();

            denseHistogram.Calculate(new Image<Gray, Byte>[] { imgRed }, true, null);
            red = denseHistogram.GetBinValues();  // BLUE
            denseHistogram.Clear();


            ////////// 
            hisBoxColor.ClearHistogram();
            hisBoxColor.GenerateHistograms(colorImg, 256);
            //hisBoxColor.
            hisBoxColor.Refresh();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png; *.tiff)|*jpg; *.jpeg; *.gif; *.bmp; *png; *.tiff";
            if (open.ShowDialog() == DialogResult.OK)
            {
                colorImg = new Image<Bgr, byte>(open.FileName);
                pbColImg.Image = colorImg;
                calculateColorHistogram();
                calcutateGrayImage();
            }
        }

        private void calcutateGrayImage()
        {
            grayImg = new Image<Gray, byte>(colorImg.Width, colorImg.Height);

            for (int r = 0; r < colorImg.Rows; ++r)
            {
                for (int c = 0; c < colorImg.Cols; ++c)
                {
                    grayImg.Data[r, c, 0] = (byte) (colorImg.Data[r, c, 0] * colorValidity[0] + colorImg.Data[r, c, 1] * colorValidity[1] + colorImg.Data[r, c, 2] * colorValidity[2]);
                }
            }

            pbGrayImg.Image = grayImg;
        }


        private void tbRed_Scroll(object sender, EventArgs e)
        {
            colorValidity[2] = tbRed.Value / 100d;
            lbRedValue.Text = "Value = " + colorValidity[2];
        }

        private void tbGreen_Scroll(object sender, EventArgs e)
        {
            colorValidity[1] = tbGreen.Value / 100d;
            lbGreenValue.Text = "Value = " + colorValidity[1];
        }

        private void tbBlue_Scroll(object sender, EventArgs e)
        {
            colorValidity[0] = tbBlue.Value / 100d;
            lbBlueValue.Text = "Value = " + colorValidity[0];
        }
    }
}
