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
    public partial class LinearSharpening_Form : Form
    {
        private int selected = 2;
        PictureWindow pw;

        private static Dictionary<int, Matrix<double>> mats = new Dictionary<int, Matrix<double>>
        {
            {1,  new Matrix<double> (new double[3, 3] { { 0, -1, 0 },{ -1, 5, -1 },{ 0, -1, 0 } })},
            {2,  new Matrix<double> (new double[3, 3] {{ -1,-1,-1 },{ -1, 9, -1 },{ -1, -1, -1 } })},
            {3,  new Matrix<double> (new double[3, 3] { { 1, -2, 1 },{ -2,5,-2 },{ 1, -2, 1 } })},
        };
        public LinearSharpening_Form(PictureWindow pw)
        {
            InitializeComponent();
            cb2.Checked = true;
            this.pw = pw;
            cbBorderType.Items.Add("Replicate");
            cbBorderType.Items.Add("Isolated");
            cbBorderType.Items.Add("Reflect");
            cbBorderType.SelectedIndex = 0;
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked)
            {
                cb2.Checked = cb3.Checked = false;
                selected = 1;
            }
        }

        private void cb2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2.Checked)
            {
                cb1.Checked = cb3.Checked = false;
                selected = 2;
            }
        }

        private void cb3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3.Checked)
            {
                cb2.Checked = cb1.Checked = false;
                selected = 3;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Operations.linearSharpening(pw, getMatrix(), getBorderType());
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }

        private Matrix<double> getMatrix()
        {
            return mats[selected];
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
