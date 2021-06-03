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
    // do poprawy
    public partial class Convolution_Form : Form
    {
        private PictureWindow pw;
        private BorderType border;
        private double[] mat0 = new double[9], mat1 = new double[9];
        private bool[] validMat0 = new bool[9], validMat1 = new bool[9];
        private bool use5x5Mask = false;
        public Convolution_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            initFields();
            btnApply.Enabled = false;
        }


        private void getBorderType()
        {
            String kind = cbBorderType.Text.ToString();
            Console.WriteLine(kind);
            switch (kind)
            {
                case "BORDER_REPLICATE":
                    border = BorderType.Replicate;
                    break;
                case "BORDER_ISOLATED":
                    border = BorderType.Isolated;
                    break;
                case "BORDER_REFLECT":
                    border = BorderType.Reflect;
                    break;
                default:
                    throw new Exception("getBorderType() error");
            }
        }

        private void initFields()
        {
            cbBorderType.Items.Add("BORDER_REPLICATE");
            cbBorderType.Items.Add("BORDER_ISOLATED");
            cbBorderType.Items.Add("BORDER_REFLECT");
            cbBorderType.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            getBorderType();
            if (use5x5Mask) oneStep();
            else twoStep();

            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private void oneStep()
        {
            // merge 2 masks
        }

        private void twoStep()
        {
            Bitmap source = pw.Bitmap;
            Mat inputMat = source.ToImage<Gray, byte>().Mat;
            Mat tempMap = new Mat();
            Mat outputMat = new Mat();
            tempMap = inputMat.Clone();
            outputMat = inputMat.Clone();

            applyMask(mat0, inputMat, tempMap);
            applyMask(mat1, tempMap, outputMat);
            pw.Bitmap = outputMat.ToImage<Gray, byte>().ToBitmap();
        }

        private void applyMask(double[] mat, Mat src, Mat dst)
        {
            double sum = mat.ToList().Sum();
            if (sum <= 0) sum = 1;
            for (int i = 0; i < mat.Length; ++i)
            {
                mat[i] /= sum;
            }

            foreach (double i in mat) Console.WriteLine(i); // testing

            Matrix<double> mask = new Matrix<double>(new double[3, 3]
                { { mat[0] , mat[1], mat[2] },
                { mat[3], mat[4], mat[5] },
                { mat[6], mat[7], mat[8] } });

            for (int i = 0; i < mask.Width; ++i)
            {
                for (int j = 0; j < mask.Height; ++j) Console.WriteLine(mask[i, j]);
            } // testing

            // wykonaj operację detekcji krawędzi
            CvInvoke.Filter2D(src, dst, mask, new Point(-1, -1), 0, border);

            //Operations.linearSharpening(pw, mask, border);
            // wywala się bo dzieli przez 0 !!!!
        }

        private bool isMatValid(bool[] validMat)
        {
            foreach(bool b in validMat) { if (!b) return false; }
            return true;
        }

        private bool bothMatAreValid() { return isMatValid(validMat0) && isMatValid(validMat1); }

        private void txtFirst0_TextChanged(object sender, EventArgs e)
        {
            validMat0[0] = double.TryParse(txtFirst0.Text, out mat0[0]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst1_TextChanged(object sender, EventArgs e)
        {
            validMat0[1] = double.TryParse(txtFirst1.Text, out mat0[1]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst2_TextChanged(object sender, EventArgs e)
        {
            validMat0[2] = double.TryParse(txtFirst2.Text, out mat0[2]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst3_TextChanged(object sender, EventArgs e)
        {
            validMat0[3] = double.TryParse(txtFirst3.Text, out mat0[3]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst4_TextChanged(object sender, EventArgs e)
        {
            validMat0[4] = double.TryParse(txtFirst4.Text, out mat0[4]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst5_TextChanged(object sender, EventArgs e)
        {
            validMat0[5] = double.TryParse(txtFirst5.Text, out mat0[5]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst6_TextChanged(object sender, EventArgs e)
        {
            validMat0[6] = double.TryParse(txtFirst6.Text, out mat0[6]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst7_TextChanged(object sender, EventArgs e)
        {
            validMat0[7] = double.TryParse(txtFirst7.Text, out mat0[7]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst8_TextChanged(object sender, EventArgs e)
        {
            validMat0[8] = double.TryParse(txtFirst8.Text, out mat0[8]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond0_TextChanged(object sender, EventArgs e)
        {
            validMat1[0] = double.TryParse(txtSecond0.Text, out mat1[0]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond1_TextChanged(object sender, EventArgs e)
        {
            validMat1[1] = double.TryParse(txtSecond1.Text, out mat1[1]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond2_TextChanged(object sender, EventArgs e)
        {
            validMat1[2] = double.TryParse(txtSecond2.Text, out mat1[2]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond3_TextChanged(object sender, EventArgs e)
        {
            validMat1[3] = double.TryParse(txtSecond3.Text, out mat1[3]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond4_TextChanged(object sender, EventArgs e)
        {
            validMat1[4] = double.TryParse(txtSecond4.Text, out mat1[4]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond5_TextChanged(object sender, EventArgs e)
        {
            validMat1[5] = double.TryParse(txtSecond5.Text, out mat1[5]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond6_TextChanged(object sender, EventArgs e)
        {
            validMat1[6] = double.TryParse(txtSecond6.Text, out mat1[6]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond7_TextChanged(object sender, EventArgs e)
        {
            validMat1[7] = double.TryParse(txtSecond7.Text, out mat1[7]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond8_TextChanged(object sender, EventArgs e)
        {
            validMat1[8] = double.TryParse(txtSecond8.Text, out mat1[8]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void cbMask5x5_CheckedChanged(object sender, EventArgs e)
        {
            use5x5Mask = cbMask5x5.Checked;
        }
    }
}
