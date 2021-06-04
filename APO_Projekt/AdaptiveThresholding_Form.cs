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

namespace APO_Projekt
{
    public partial class AdaptiveThresholding_Form : Form
    {
        private PictureWindow pw;
        private byte value = (byte)5;
        private AdaptiveThresholdType adaptiveType;
        private ThresholdType thresholdType;
        public AdaptiveThresholding_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            init();
        }

        private void init()
        {
            cbAdaptiveMethod.Items.Add("ADAPTIVE_THRESH_MEAN_C");
            cbAdaptiveMethod.Items.Add("ADAPTIVE_THRESH_GAUSSIAN_C");
            cbAdaptiveMethod.SelectedIndex = 0;

            cbThresholdType.Items.Add("THRESH_BINARY");
            cbThresholdType.Items.Add("THRESH_BINARY_INV");
            cbThresholdType.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            getAdaptiveType();
            getThresholdType();
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            CvInvoke.AdaptiveThreshold(emguImage, emguImage, 255, adaptiveType, thresholdType, value, 5);
            //CvInvoke.MorphologyEx(emguImage, emguImage, operation, structuringElement, new Point(-1, -1), iterations, border, new MCvScalar());
            pw.Bitmap = emguImage.Mat.ToImage<Rgb,byte>().ToBitmap();
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private void getAdaptiveType()
        {
            String kind = cbAdaptiveMethod.Text.ToString();
            switch (kind)
            {
                case "ADAPTIVE_THRESH_MEAN_C":
                    adaptiveType = AdaptiveThresholdType.MeanC;
                    break;
                case "ADAPTIVE_THRESH_GAUSSIAN_C":
                    adaptiveType = AdaptiveThresholdType.GaussianC;
                    break;
                default:
                    throw new Exception("getAdaptiveType() error");
            }
        }

        private void getThresholdType()
        {
            String kind = cbThresholdType.Text.ToString();
            switch (kind)
            {
                case "THRESH_BINARY":
                    thresholdType = ThresholdType.Binary;
                    break;
                case "THRESH_BINARY_INV":
                    thresholdType = ThresholdType.BinaryInv;
                    break;
                default:
                    throw new Exception("getThresholdType() error");
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (trackBar.Value % 2 == 0)
                if (value < trackBar.Value) ++trackBar.Value;
                else if (value > trackBar.Value) --trackBar.Value;

            value = (byte)trackBar.Value;
            lbTbValue.Text = "Value: " + value.ToString();
        }
    }
}
