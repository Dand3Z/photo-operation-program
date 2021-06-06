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
    public partial class Convolution_Form : Form
    {
        private PictureWindow pw;
        private BorderType border;
        private double[] mat0 = new double[9], mat1 = new double[9];
        private double[,] bigMat = new double[5,5];
        private bool[] validMat0 = new bool[9], validMat1 = new bool[9];
        private bool use5x5Mask = false;
        public Convolution_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            initFields();
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

            txtFirst0.Text = txtFirst1.Text = txtFirst2.Text = txtFirst3.Text = txtFirst4.Text = txtFirst5.Text = txtFirst6.Text = txtFirst7.Text = txtFirst8.Text = "1";
            mat0[0] = mat0[1] = mat0[2] = mat0[3] = mat0[4] = mat0[5] = mat0[6] = mat0[7] = mat0[8] = 1;
            validMat0[0] = validMat0[1] = validMat0[2] = validMat0[3] = validMat0[4] = validMat0[5] = validMat0[6] = validMat0[7] = validMat0[8] = true;

            txtSecond0.Text = txtSecond2.Text = txtSecond6.Text = txtSecond8.Text = "1";
            mat1[0] = mat1[2] = mat1[6] = mat1[8] = 1;
            txtSecond1.Text = txtSecond3.Text = txtSecond5.Text = txtSecond7.Text = "-2";
            mat1[1] = mat1[3] = mat1[5] = mat1[7] = -2;
            txtSecond4.Text = "5";
            mat1[4] = 5;
            validMat1[0] = validMat1[1] = validMat1[2] = validMat1[3] = validMat1[4] = validMat1[5] = validMat1[6] = validMat1[7] = validMat1[8] = true;
            btnApply.Enabled = bothMatAreValid();
           
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            getBorderType();
            normalizeMat(mat0);
            normalizeMat(mat1);
            if (use5x5Mask) oneStep();
            else twoStep();

            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private void oneStep()
        {
            Matrix<double> matrix = generate5x5Mask();
            Mat inputMat = pw.Bitmap.ToImage<Rgb, byte>().Mat;
            Mat outMat = inputMat.Clone();
            CvInvoke.Filter2D(inputMat, outMat, matrix, new Point(-1, -1), 0, border);
            pw.Bitmap = outMat.ToImage<Rgb, byte>().ToBitmap();
        }

        private void twoStep()
        {
            Mat inputMat = pw.Bitmap.ToImage<Rgb, byte>().Mat;
            Mat tempMap = inputMat.Clone();
            Mat outputMat = inputMat.Clone();

            applyMask(mat0, inputMat, tempMap);
            applyMask(mat1, tempMap, outputMat);
            pw.Bitmap = outputMat.ToImage<Rgb, byte>().ToBitmap();
        }

        private void normalizeMat(double[] mat)
        {
            double sum = mat.ToList().Sum();
            if (sum <= 0) sum = 1;
            for (int i = 0; i < mat.Length; ++i)
            {
                mat[i] /= sum;
            }
        }

        private void applyMask(double[] mat, Mat src, Mat dst)
        {
            Matrix<double> mask = new Matrix<double>(new double[3, 3]
                { { mat[0] , mat[1], mat[2] },
                { mat[3], mat[4], mat[5] },
                { mat[6], mat[7], mat[8] } });

            CvInvoke.Filter2D(src, dst, mask, new Point(-1, -1), 0, border);
        }

        private Matrix<double> generate5x5Mask()
        {
            Matrix<double> bigMatrix = new Matrix<double>(new double[5, 5]);
            for (int i = 0; i < bigMatrix.Cols; ++i)
            {
                for (int j = 0; j < bigMatrix.Rows; ++j)
                {
                    bigMat[i, j] = 0;
                    for (int f = -1; f < 2; ++f)
                    {
                        for (int g = -1; g < 2; ++g)
                        {
                            if (i + f - 1 >= 0 && i + f -1 < 3 && j + g - 1 >= 0 && j + g - 1 < 3)
                            {
                                bigMat[i, j] += mat0[(i + f - 1) * 3 + j + g - 1] * mat1[(1 + f) * 3 + 1 + g];
                            }
                        }
                    }
                }
            }

            double div0 = mat0.ToList().Sum();
            div0 = div0 == 0 ? 1 : div0;
            double div1 = mat1.ToList().Sum();
            div1 = div1 == 0 ? 1 : div1;

            double div = 0;
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    div += bigMat[i, j];
                }
            }
            div = div0*div1;

            for(int i = 0; i < bigMatrix.Cols; i++)
            {
                for(int j = 0; j < bigMatrix.Rows; j++)
                {
                    bigMatrix[i, j] = bigMat[i, j];
                }
            }
            return bigMatrix;
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
