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

namespace APO_Projekt
{
    public partial class CustomMask_Form : Form
    {
        private PictureWindow pw;
        private double[] maskValues = new double[9];
        private bool[] validValues = new bool[9];
        public CustomMask_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            cbBorderType.Items.Add("Replicate");
            cbBorderType.Items.Add("Isolated");
            cbBorderType.Items.Add("Reflect");
            cbBorderType.SelectedIndex = 0;
            btnApply.Enabled = false;
        }

        private void areAllFieldsValid()
        {
            foreach (bool b in validValues)
            {
                if (b != true)
                {
                    btnApply.Enabled = false;
                    return;
                }
            }
            btnApply.Enabled = true;
            return;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            double sum = maskValues.ToList().Sum();

            BorderType border = getBorderType();

            for (int i = 0; i < maskValues.Length; ++i)
            {
                maskValues[i] /= sum;
            }

            Matrix<double> mask = new Matrix<double>(new double[3, 3]
            { {maskValues[0] , maskValues[1], maskValues[2] },
            { maskValues[3], maskValues[4], maskValues[5] },
            { maskValues[6], maskValues[7], maskValues[8] } });

            Operations.linearSharpening(pw, mask, border);

            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            validValues[0] = double.TryParse(txt1.Text.Trim().ToString(), out maskValues[0]);
            areAllFieldsValid();
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            validValues[1] = double.TryParse(txt2.Text.Trim().ToString(), out maskValues[1]);
            areAllFieldsValid();
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            validValues[2] = double.TryParse(txt3.Text.Trim().ToString(), out maskValues[2]);
            areAllFieldsValid();
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            validValues[3] = double.TryParse(txt4.Text.Trim().ToString(), out maskValues[3]);
            areAllFieldsValid();
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            validValues[4] = double.TryParse(txt5.Text.Trim().ToString(), out maskValues[4]);
            areAllFieldsValid();
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            validValues[5] = double.TryParse(txt6.Text.Trim().ToString(), out maskValues[5]);
            areAllFieldsValid();
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            validValues[6] = double.TryParse(txt7.Text.Trim().ToString(), out maskValues[6]);
            areAllFieldsValid();
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            validValues[7] = double.TryParse(txt8.Text.Trim().ToString(), out maskValues[7]);
            areAllFieldsValid();
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            validValues[8] = double.TryParse(txt9.Text.Trim().ToString(), out maskValues[8]);
            areAllFieldsValid();
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
    }
}
