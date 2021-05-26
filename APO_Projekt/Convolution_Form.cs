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
        private int[] mat0 = new int[9], mat1 = new int[9];
        private bool[] validMat0 = new bool[9], validMat1 = new bool[9];
        private bool use5x5Mask;
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

        }

        private void twoStep()
        {
            //CvInvoke.
        }

        private bool isMatValid(bool[] validMat)
        {
            foreach(bool b in validMat) { if (!b) return false; }
            return true;
        }

        private bool bothMatAreValid() { return isMatValid(validMat0) && isMatValid(validMat1); }

        private void txtFirst0_TextChanged(object sender, EventArgs e)
        {
            validMat0[0] = int.TryParse(txtFirst0.Text, out mat0[0]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst1_TextChanged(object sender, EventArgs e)
        {
            validMat0[1] = int.TryParse(txtFirst1.Text, out mat0[1]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst2_TextChanged(object sender, EventArgs e)
        {
            validMat0[2] = int.TryParse(txtFirst2.Text, out mat0[2]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst3_TextChanged(object sender, EventArgs e)
        {
            validMat0[3] = int.TryParse(txtFirst3.Text, out mat0[3]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst4_TextChanged(object sender, EventArgs e)
        {
            validMat0[4] = int.TryParse(txtFirst4.Text, out mat0[4]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst5_TextChanged(object sender, EventArgs e)
        {
            validMat0[5] = int.TryParse(txtFirst5.Text, out mat0[5]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst6_TextChanged(object sender, EventArgs e)
        {
            validMat0[6] = int.TryParse(txtFirst6.Text, out mat0[6]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst7_TextChanged(object sender, EventArgs e)
        {
            validMat0[7] = int.TryParse(txtFirst7.Text, out mat0[7]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtFirst8_TextChanged(object sender, EventArgs e)
        {
            validMat0[8] = int.TryParse(txtFirst8.Text, out mat0[8]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond0_TextChanged(object sender, EventArgs e)
        {
            validMat1[0] = int.TryParse(txtSecond0.Text, out mat1[0]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond1_TextChanged(object sender, EventArgs e)
        {
            validMat1[1] = int.TryParse(txtSecond1.Text, out mat1[1]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond2_TextChanged(object sender, EventArgs e)
        {
            validMat1[2] = int.TryParse(txtSecond2.Text, out mat1[2]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond3_TextChanged(object sender, EventArgs e)
        {
            validMat1[3] = int.TryParse(txtSecond3.Text, out mat1[3]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond4_TextChanged(object sender, EventArgs e)
        {
            validMat1[4] = int.TryParse(txtSecond4.Text, out mat1[4]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond5_TextChanged(object sender, EventArgs e)
        {
            validMat1[5] = int.TryParse(txtSecond5.Text, out mat1[5]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond6_TextChanged(object sender, EventArgs e)
        {
            validMat1[6] = int.TryParse(txtSecond6.Text, out mat1[6]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond7_TextChanged(object sender, EventArgs e)
        {
            validMat1[7] = int.TryParse(txtSecond7.Text, out mat1[7]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void txtSecond8_TextChanged(object sender, EventArgs e)
        {
            validMat1[8] = int.TryParse(txtSecond8.Text, out mat1[8]);
            btnApply.Enabled = bothMatAreValid();
        }

        private void cbMask5x5_CheckedChanged(object sender, EventArgs e)
        {
            use5x5Mask = cbMask5x5.Checked;
        }
    }
}
