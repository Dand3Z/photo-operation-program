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

namespace APO_Projekt
{
    public partial class GaussianBlur_Form : Form
    {
        private PictureWindow pw;
        private double sigmaX;
        private double sigmaY;
        public GaussianBlur_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            sigmaX = 1;
            sigmaY = 0;

            cbBorderType.Items.Add("Replicate");
            cbBorderType.Items.Add("Isolated");
            cbBorderType.Items.Add("Reflect");
            cbBorderType.SelectedIndex = 0;

            cbKernelSize.Items.Add("3x3");
            cbKernelSize.Items.Add("5x5");
            cbKernelSize.Items.Add("7x7");
            cbKernelSize.Items.Add("9x9");
            cbKernelSize.Items.Add("11x11");
            cbKernelSize.Items.Add("13x13");
            cbKernelSize.Items.Add("15x15");
            cbKernelSize.SelectedIndex = 0;
        }

        private int getKernelSize()
        {
            string kernel = cbKernelSize.SelectedItem.ToString();
            int choice = 3;
            switch (kernel)
            {
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
        private BorderType getBorderType()
        {
            if (cbBorderType.SelectedItem.Equals("Replicate"))
            {
                return BorderType.Replicate;
            }
            else if (cbBorderType.SelectedItem.Equals("Isolated"))
            {
                return BorderType.Isolated;
            }
            else
            {
                return BorderType.Reflect;
            }
        }

        private void txtSigmaX_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = double.TryParse(txtSigmaX.Text, out sigmaX);
        }

        private void txtSigmaY_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = double.TryParse(txtSigmaY.Text, out sigmaY);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int kernelSize = getKernelSize();
            BorderType borderType = getBorderType();
            Size size = new Size(kernelSize, kernelSize);
            Operations.gaussianBlur(pw, size, borderType, sigmaX, sigmaY);
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private void cbXeqY_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXeqY.Checked)
            {
                txtSigmaY.Enabled = false;
                txtSigmaY.Text = txtSigmaX.Text;
                sigmaY = sigmaX;
            }
            else
            {
                txtSigmaY.Enabled = true;
            }
        }
    }
}
