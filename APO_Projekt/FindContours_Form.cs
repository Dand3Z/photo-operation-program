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
            CenterToScreen();
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
        
        private void btnApply_Click(object sender, EventArgs e)
        {
            getChainApproxMethod();
            getRetrType();
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            Mat thresh = new Mat();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();

            int width = 0, heigth = 0, pixelAmount = 0;

            for (int i = 0; i < emguImage.Rows; ++i)
            {
                width = 0;
                for (int j = 0; j < emguImage.Cols; ++j)
                {
                    width++;
                    pixelAmount++;
                }
                heigth++;
            }

            CvInvoke.Threshold(emguImage, thresh, 127, 255, ThresholdType.Binary);

            Moments moments = CvInvoke.Moments(thresh, true);

            CvInvoke.Blur(emguImage, emguImage, new Size(3, 3), new Point(-1, -1));
            emguImage = emguImage.Canny(50, 100);
            CvInvoke.FindContours(emguImage, contours, hierarchy, retrType, approxMethod);

            double area, perimeter;
            VectorOfPoint cnt = contours[0];
            area = CvInvoke.ContourArea(cnt);
            perimeter = CvInvoke.ArcLength(cnt, true); 

            Rectangle rect = CvInvoke.BoundingRectangle(cnt);
            double aspectRatio = (double)(rect.Width) / rect.Height; 

            int rectArea = rect.Width * rect.Height;
            double extent = area / rectArea;

            VectorOfPoint hull = new VectorOfPoint();
            CvInvoke.ConvexHull(cnt, hull);
            double hullArea = CvInvoke.ContourArea(hull);
            double soildity = area / hullArea;

            double equiDiameter = Math.Sqrt(4 * area / Math.PI);

            StringBuilder sb = new StringBuilder();

            sb.Append("Picture Metrics:" + Environment.NewLine)
                .Append("Width: " + width + Environment.NewLine)
                .Append("Height: " + heigth + Environment.NewLine)
                .Append("Pixel Amount: " + pixelAmount + Environment.NewLine)
                .Append("Area: " + area + Environment.NewLine)
                .Append("Perimeter: " + perimeter + Environment.NewLine)
                .Append("Aspect Ratio: " + aspectRatio + Environment.NewLine)
                .Append("Extent: " + extent + Environment.NewLine)
                .Append("Solidity: " + soildity + Environment.NewLine)
                .Append("Equivalent Diameter: " + equiDiameter + Environment.NewLine)

                .Append(Environment.NewLine)
                .Append("Moments:" + Environment.NewLine)
                .Append(getMoments(moments))

                .Append(Environment.NewLine)
                .Append("Moments for single objects:" + Environment.NewLine);

            for (int i = 0; i < contours.Size; ++i)
            {
                VectorOfPoint v = contours[i];
                Moments m = CvInvoke.Moments(v, true);
                sb.Append(string.Format("contours[{0}]", i) + Environment.NewLine)
                  .Append(getMoments(m)).Append(Environment.NewLine);
            }
            txtMetrics.Text = sb.ToString();
        }

        private String getMoments(Moments moments)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("m00:" + moments.M00 + Environment.NewLine)
            .Append("m10:" + moments.M10 + Environment.NewLine)
            .Append("m01:" + moments.M01 + Environment.NewLine)
            .Append("m20:" + moments.M20 + Environment.NewLine)
            .Append("m11:" + moments.M11 + Environment.NewLine)
            .Append("m02:" + moments.M02 + Environment.NewLine)
            .Append("m30:" + moments.M30 + Environment.NewLine)
            .Append("m21:" + moments.M21 + Environment.NewLine)
            .Append("m12:" + moments.M12 + Environment.NewLine)
            .Append("m03:" + moments.M03 + Environment.NewLine)
            .Append("mu20:" + moments.Mu20 + Environment.NewLine)
            .Append("mu11:" + moments.Mu11 + Environment.NewLine)
            .Append("mu02:" + moments.Mu02 + Environment.NewLine)
            .Append("mu30:" + moments.Mu30 + Environment.NewLine)
            .Append("mu21:" + moments.Mu21 + Environment.NewLine)
            .Append("mu12:" + moments.Mu12 + Environment.NewLine)
            .Append("mu03:" + moments.Mu03 + Environment.NewLine)
            .Append("nu20:" + moments.Nu20 + Environment.NewLine)
            .Append("nu11:" + moments.Nu11 + Environment.NewLine)
            .Append("nu02:" + moments.Nu02 + Environment.NewLine)
            .Append("nu30:" + moments.Nu30 + Environment.NewLine)
            .Append("nu21:" + moments.Nu21 + Environment.NewLine)
            .Append("nu12:" + moments.Nu12 + Environment.NewLine)
            .Append("nu03:" + moments.Nu03 + Environment.NewLine);

            return sb.ToString();
        }

    }

}
