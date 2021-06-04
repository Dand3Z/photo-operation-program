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
using Emgu.CV.Util;

namespace APO_Projekt
{
    public partial class FindContours_Form : Form
    {
        private PictureWindow pw;
        private RetrType retrType;
        private ChainApproxMethod approxMethod;
        public FindContours_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            init();
        }


        private void getRetrType()
        {
            String kind = cbRetrType.Text.ToString();
            switch (kind)
            {
                case "External":
                    retrType = RetrType.External;
                    break;
                case "Ccomp":
                    retrType = RetrType.Ccomp;
                    break;
                case "List":
                    retrType = RetrType.List;
                    break;
                case "Tree":
                    retrType = RetrType.Tree;
                    break;
                default:
                    throw new Exception("getRetrType() error");
            }
        }

        private void getChainApproxMethod()
        {
            String kind = cbApproxMethod.Text.ToString();
            switch (kind)
            {
                case "ChainApproxNone":
                    approxMethod = ChainApproxMethod.ChainApproxNone;
                    break;
                case "ChainApproxSimple":
                    approxMethod = ChainApproxMethod.ChainApproxSimple;
                    break;
                case "ChainApproxTc89Kcos":
                    approxMethod = ChainApproxMethod.ChainApproxTc89Kcos;
                    break;
                case "ChainApproxTc89L1":
                    approxMethod = ChainApproxMethod.ChainApproxTc89L1;
                    break;
                case "ChainCode":
                    approxMethod = ChainApproxMethod.ChainCode;
                    break;
                case "LinkRuns":
                    approxMethod = ChainApproxMethod.LinkRuns;
                    break;
                default:
                    throw new Exception("getChainApproxMethod() error");
            }
        }

        private void init()
        {
            cbRetrType.Items.Add("External");
            cbRetrType.Items.Add("Ccomp");
            cbRetrType.Items.Add("List");
            cbRetrType.Items.Add("Tree");
            cbRetrType.SelectedIndex = 0;

            cbApproxMethod.Items.Add("ChainApproxNone");
            cbApproxMethod.Items.Add("ChainApproxSimple");
            cbApproxMethod.Items.Add("ChainApproxTc89Kcos");
            cbApproxMethod.Items.Add("ChainApproxTc89L1");
            cbApproxMethod.Items.Add("ChainCode");
            cbApproxMethod.Items.Add("LinkRuns");
            cbApproxMethod.SelectedIndex = 0;
        }
        // do poprawy
        private void btnApply_Click(object sender, EventArgs e)
        {
            getChainApproxMethod();
            getRetrType();
            Image<Rgb, byte> emguImage = pw.Bitmap.ToImage<Rgb, byte>();
            Mat img = emguImage.Mat;
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.Threshold(img, img, 127, 255, ThresholdType.Binary);
            CvInvoke.FindContours(img, contours, hierarchy, retrType, approxMethod);
            Mat img2 = img.Clone();
            CvInvoke.CvtColor(img, img2, ColorConversion.Gray2Rgb);
            CvInvoke.DrawContours(img2, contours, 0, new MCvScalar(255, 0, 0), 3);
            pw.Bitmap = img2.ToBitmap();
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

    }

}
