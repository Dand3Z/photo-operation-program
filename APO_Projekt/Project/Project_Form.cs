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
        private static readonly Random random = new Random();

        private Image<Bgr, byte> colorImg;
        private Image<Gray, byte> grayImg;
        private double[] colorValidity = { 0.11, 0.59, 0.30 }; // B, G, R
        private bool[] sliderTurn = { true, true, true }; // B, G, R
        private Mode mode = Mode.Support;

        private int updateCount;
        private Timer timer;

        public Project_Form()
        {
            InitializeComponent();
            CenterToScreen();
            removeChartLegend();

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += this.Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();

            this.updateCount++;
            if (mode != Mode.Restrictive || btnRefresh.Enabled)
            {
                refreshGray();
                
            }
        }

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
            calculateGrayLUT(gray);
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
                    int newValue = (int) (colorImg.Data[r, c, 0] * colorValidity[0] + colorImg.Data[r, c, 1] * colorValidity[1] + colorImg.Data[r, c, 2] * colorValidity[2]);
                    newValue = (newValue > 255 && mode == Mode.Unlimited && !cbUnsafe.Checked) ? 255 : newValue;
                    grayImg.Data[r, c, 0] = (byte) newValue;
                }
            }

            pbGrayImg.Image = grayImg;
        }

        private void calculateGrayLUT(float[] gray)
        {
            lvLUT.Items.Clear();
            for (int i = 0; i < gray.Length; ++i)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(gray[i].ToString());
                lvLUT.Items.Add(item);
            }
        }


        private void tbRed_Scroll(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            if (mode == Mode.Support)
            {
                double prevValue = colorValidity[2] * 100;
                double diff = tbRed.Value - prevValue;
                if (diff == 0) { }
                else if (diff > 0)
                { // new value is bigger
                    while(diff > 0)
                    {
                        if (sliderTurn[2])
                        {
                            _ = tbGreen.Value > 0 ? --tbGreen.Value : --tbBlue.Value;
                        }
                        else
                        {
                            _ = tbBlue.Value > 0 ? --tbBlue.Value : --tbGreen.Value;
                        }
                        sliderTurn[2] = !sliderTurn[2];
                        --diff;
                    }
                }
                else
                {
                    while(diff < 0)
                    {
                        if (sliderTurn[2])
                        {
                            _ = tbGreen.Value < 100 ? ++tbGreen.Value : ++tbBlue.Value;
                        }
                        else
                        {
                            _ = tbBlue.Value < 100 ? ++tbBlue.Value : ++tbGreen.Value;
                        }
                        sliderTurn[2] = !sliderTurn[2];
                        ++diff;
                    }
                }

                if (tbBlue.Value + tbGreen.Value + tbRed.Value != 100)
                {
                    fillValues(tbRed, tbGreen, tbBlue);
                }

            }
            refreshSliders();
        }

        private void tbGreen_Scroll(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            if (mode == Mode.Support)
            {
                double prevValue = colorValidity[1] * 100;
                double diff = tbGreen.Value - prevValue;
                if (diff == 0) { }
                else if (diff > 0)
                { // new value is bigger
                    while(diff > 0)
                    {
                        if (sliderTurn[1])
                        {
                            _ = tbRed.Value > 0 ? --tbRed.Value : --tbBlue.Value;
                        }
                        else
                        {
                            _ = tbBlue.Value > 0 ? --tbBlue.Value : --tbRed.Value;
                        }
                        sliderTurn[1] = !sliderTurn[1];
                        --diff;
                    }
                }
                else
                {
                    while(diff < 0)
                    {
                        if (sliderTurn[1])
                        {
                            _ = tbRed.Value < 100 ? ++tbRed.Value : ++tbBlue.Value;
                        }
                        else
                        {
                            _ = tbBlue.Value < 100 ? ++tbBlue.Value : ++tbRed.Value;
                        }
                        sliderTurn[1] = !sliderTurn[1];
                        ++diff;
                    }
                }

                if (tbBlue.Value + tbGreen.Value + tbRed.Value != 100)
                {
                    fillValues(tbGreen, tbBlue, tbRed);
                }

            }
            refreshSliders();
        }

        private void tbBlue_Scroll(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            if (mode == Mode.Support)
            {
                double prevValue = colorValidity[0] * 100;
                double diff = tbBlue.Value - prevValue;
                if (diff == 0) { }
                else if (diff > 0)
                { // new value is bigger
                    while (diff > 0)
                    {
                        if (sliderTurn[0])
                        {
                            _ = tbRed.Value > 0 ? --tbRed.Value : --tbGreen.Value;
                        }
                        else
                        {
                            _ = tbGreen.Value > 0 ? --tbGreen.Value : --tbRed.Value;
                        }
                        sliderTurn[0] = !sliderTurn[0];
                        --diff;
                    }
                }
                else
                {
                    while (diff < 0)
                    {
                        if (sliderTurn[0])
                        {
                            _ = tbRed.Value < 100 ? ++tbRed.Value : ++tbGreen.Value;
                        }
                        else
                        {
                            _ = tbGreen.Value < 100 ? ++tbGreen.Value : ++tbRed.Value;
                        }
                        sliderTurn[0] = !sliderTurn[0];
                        ++diff;
                    }
                }
                if (tbBlue.Value + tbGreen.Value + tbRed.Value != 100)
                {
                    fillValues(tbBlue, tbRed, tbGreen);
                }
            }
            refreshSliders();
        }

        private void fillValues(TrackBar movedSlider, TrackBar s1, TrackBar s2)
        {
            int diff = 100 - (movedSlider.Value + s1.Value + s2.Value);
            if (diff > 0) // too little
            {
                while (diff > 0)
                {
                    _ = s1.Value < 100 ? ++s1.Value : ++s2.Value;
                    --diff;
                }
            }
            else
            {
                while (diff < 0)
                {
                    _ = s1.Value > 0 ? --s1.Value : --s2.Value;
                    ++diff;
                }
            }
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

        private void btnDefault_Click(object sender, EventArgs e)
        {
            tbBlue.Value = 11; tbGreen.Value = 59; tbRed.Value = 30;
            refreshSliders();
            refreshGray();
        }

        private void refreshSliders()
        {
            colorValidity[0] = tbBlue.Value / 100d;
            lbBlueValue.Text = "Percentages = " + colorValidity[0] * 100 + "%";

            colorValidity[1] = tbGreen.Value / 100d;
            lbGreenValue.Text = "Percentages = " + colorValidity[1] * 100 + "%";

            colorValidity[2] = tbRed.Value / 100d;
            lbRedValue.Text = "Percentages = " + colorValidity[2] * 100 + "%";

            int sum = tbBlue.Value + tbGreen.Value + tbRed.Value;
            if (mode == Mode.Restrictive)
            {
                if (sum > 100) btnToPicWin.Enabled = btnRefresh.Enabled = btnSave.Enabled = btnOpen.Enabled = false;
            }
            if (sum <= 100 || mode == Mode.Unlimited)
            {
                btnToPicWin.Enabled = btnRefresh.Enabled = btnSave.Enabled = btnOpen.Enabled = true;
            }
        }

        private void btnToPicWin_Click(object sender, EventArgs e)
        {
            if (grayImg == null)
            {
                MessageBox.Show("Image has not been opened!", "Not opened image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            PictureWindow pictureWindow = new PictureWindow();
            pictureWindow.setPicture(grayImg.ToBitmap());
            pictureWindow.Show();
            Close();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            tbBlue.Value = random.Next(0, 101);
            int maxGreen = Math.Min(101, 101 - tbBlue.Value);
            tbGreen.Value = tbBlue.Value == 100 ? 0 : random.Next(0, maxGreen);
            tbRed.Value = 100 - tbBlue.Value - tbGreen.Value;

            refreshSliders();
            refreshGray();
        }

        private void refreshGray()
        {
            if (colorImg != null && grayImg != null)
            {
                calcutateGrayImage();
                calculateGrayHistogram();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (grayImg == null)
            {
                MessageBox.Show("Image has not been opened!", "Not opened image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            refreshGray();
        }

        private void cbSupportMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSupportMode.Checked)
            {
                btnDefault_Click(sender, e);
                mode = Mode.Support;
                cbRestrictiveMode.Checked = cbUnlimitedMode.Checked = false;
            }

            if (cbSupportMode.Checked == cbRestrictiveMode.Checked && cbRestrictiveMode.Checked == cbUnlimitedMode.Checked
                && cbUnlimitedMode.Checked == false) cbSupportMode.Checked = true;

            refreshSliders();
            cbUnsafe.Enabled = false;
        }

        private void cbRestrictiveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRestrictiveMode.Checked)
            {
                mode = Mode.Restrictive;
                cbSupportMode.Checked = cbUnlimitedMode.Checked = false;
            }

            if (cbSupportMode.Checked == cbRestrictiveMode.Checked && cbRestrictiveMode.Checked == cbUnlimitedMode.Checked
                && cbUnlimitedMode.Checked == false) cbSupportMode.Checked = true;

            refreshSliders();
            cbUnsafe.Enabled = false;
        }

        private void cbUnlimitedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnlimitedMode.Checked)
            {
                mode = Mode.Unlimited;
                cbSupportMode.Checked = cbRestrictiveMode.Checked = false;
            }

            if (cbSupportMode.Checked == cbRestrictiveMode.Checked && cbRestrictiveMode.Checked == cbUnlimitedMode.Checked
                && cbUnlimitedMode.Checked == false)
            { 
                cbSupportMode.Checked = true;
                cbUnsafe.Enabled = false;
                return;
            }

            refreshSliders();
            refreshGray();
            cbUnsafe.Enabled = true;
        }

        private void cbUnsafe_CheckedChanged(object sender, EventArgs e)
        {
            refreshSliders();
            refreshGray();
        }
    }

    public enum Mode
    {
        Support,
        Restrictive,
        Unlimited
    }
}
