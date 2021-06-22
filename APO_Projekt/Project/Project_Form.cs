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
using System.Drawing.Imaging;

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
            CenterToScreen();
            removeChartLegend();
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

            printColorHistogram(blue,green,red);
        }

        private void printColorHistogram(float[] blue, float[] green, float[] red)
        {
            float[] yellow = new float[256], pink = new float[256], turquoise = new float[256], allColors = new float[256];

            chtColHis.Series["red"].Points.Clear();
            chtColHis.Series["green"].Points.Clear();
            chtColHis.Series["blue"].Points.Clear();
            chtColHis.Series["red+green"].Points.Clear();
            chtColHis.Series["green+blue"].Points.Clear();
            chtColHis.Series["red+blue"].Points.Clear();
            chtColHis.Series["red+green+blue"].Points.Clear();

            for (int i = 0; i < blue.Length; ++i)
            {
                yellow[i] = Math.Min(red[i], green[i]);
                pink[i] = Math.Min(red[i], blue[i]);
                turquoise[i] = Math.Min(green[i], blue[i]);
                allColors[i] = Math.Min(red[i], Math.Min(green[i], blue[i]));
            }

            for (int i = 0; i < 256; ++i)
            {
                chtColHis.Series["red"].Points.AddXY(i, red[i]);
                chtColHis.Series["green"].Points.AddXY(i, green[i]);
                chtColHis.Series["blue"].Points.AddXY(i, blue[i]);
                chtColHis.Series["red+green"].Points.AddXY(i, yellow[i]);
                chtColHis.Series["green+blue"].Points.AddXY(i, turquoise[i]);
                chtColHis.Series["red+blue"].Points.AddXY(i, pink[i]);
                chtColHis.Series["red+green+blue"].Points.AddXY(i, allColors[i]);

            }
            chtColHis.Invalidate();
        }

        private void calculateGrayHistogram()
        {
            float[] gray;

            DenseHistogram denseHistogram = new DenseHistogram(256, new RangeF(0, 256));

            Image<Gray, Byte> imgGray = grayImg[0];

            denseHistogram.Calculate(new Image<Gray, Byte>[] { imgGray }, true, null);
            gray = denseHistogram.GetBinValues();  // GRAY
            denseHistogram.Clear();

            printGrayHistogram(gray);
        }
        
        private void printGrayHistogram(float[] gray)
        {
            chtGrayHis.Series["gray"].Points.Clear();

            for (int i = 0; i < 256; ++i)
            {
                chtGrayHis.Series["gray"].Points.AddXY(i, gray[i]);

            }
            chtColHis.Invalidate();
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
                calculateGrayHistogram();
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

        private void removeChartLegend()
        {
            chtColHis.Series[0].IsVisibleInLegend = false;
            chtColHis.Series[1].IsVisibleInLegend = false;
            chtColHis.Series[2].IsVisibleInLegend = false;
            chtColHis.Series[3].IsVisibleInLegend = false;
            chtColHis.Series[4].IsVisibleInLegend = false;
            chtColHis.Series[5].IsVisibleInLegend = false;
            chtColHis.Series[6].IsVisibleInLegend = false;

            chtGrayHis.Series[0].IsVisibleInLegend = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grayImg == null)
            {
                MessageBox.Show("Image has not been opened!", "Not opened image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff";
            if (save.ShowDialog() == DialogResult.OK)
            {
                savePicture(save);
            }
        }

        private void savePicture(SaveFileDialog save)
        {
            string FilePath = save.FileName;
            int index = save.FilterIndex;
            ImageFormat format;
            switch (index)
            {
                case 1:
                    format = ImageFormat.Bmp;
                    break;
                case 2:
                    format = ImageFormat.Gif;
                    break;
                case 3:
                    format = ImageFormat.Jpeg;
                    break;
                case 4:
                    format = ImageFormat.Png;
                    break;
                case 5:
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Png;
                    break;
            }
            grayImg.ToBitmap().Save(FilePath, format);
        }
    }
}
