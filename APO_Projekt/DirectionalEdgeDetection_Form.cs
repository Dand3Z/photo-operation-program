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
    public partial class DirectionalEdgeDetection_Form : Form
    {
        private PictureWindow pw;
        private int selected = 1;
        public DirectionalEdgeDetection_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;
            cbE.Checked = true;
            cbBorderType.Items.Add("Replicate");
            cbBorderType.Items.Add("Isolated");
            cbBorderType.Items.Add("Reflect");
            cbBorderType.SelectedIndex = 0;
        }

        private static Dictionary<int, Matrix<double>> mats = new Dictionary<int, Matrix<double>>
        {// maski
            {1,  new Matrix<double> (new double[3, 3] { { -1,0,1 },{ -1, 0, 1 },{ -1, 0, 1 } })},
            {2,  new Matrix<double> (new double[3, 3] {{ -1,-1,0 },{ -1, 0, 1 },{ 0, 1, 1 } })},
            {3,  new Matrix<double> (new double[3, 3] { { -1, -1, -1 },{ 0,0,0 },{ 1, 1, 1 } })},
            {4,  new Matrix<double> (new double[3, 3] { { 0, -1, -1 },{ 1,0,-1 },{ 1, 1, 0 } })},
            {5,  new Matrix<double> (new double[3, 3] { { 1, 0, -1 },{ 1, 0, -1 },{ 1, 0, -1 } })},
            {6,  new Matrix<double> (new double[3, 3] { { 1,1,0 },{ 1,0,-1},{ 0,-1,-1 } })},
            {7,  new Matrix<double> (new double[3, 3] { { 1,1,1 },{0,0,0},{ -1,-1,-1 } })},
            {8,  new Matrix<double> (new double[3, 3] { { 0,1,1 },{ -1,0,1 },{-1,-1,0 } })},
        };

        private void cbE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbE.Checked)
            {
                cbSE.Checked = cbS.Checked = cbSW.Checked = cbW.Checked = cbNW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 1;
            }
        }

        private void cbSE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSE.Checked)
            {
                cbE.Checked = cbS.Checked = cbSW.Checked = cbW.Checked = cbNW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 2;
            }
        }

        private void cbS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbS.Checked)
            {
                cbE.Checked = cbSE.Checked = cbSW.Checked = cbW.Checked = cbNW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 3;
            }
        }

        private void cbSW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSW.Checked)
            {
                cbE.Checked = cbSE.Checked = cbS.Checked = cbW.Checked = cbNW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 4;
            }
        }

        private void cbW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbW.Checked)
            {
                cbE.Checked = cbSE.Checked = cbS.Checked = cbSW.Checked = cbNW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 5;
            }
        }

        private void cbNW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNW.Checked)
            {
                cbE.Checked = cbSE.Checked = cbS.Checked = cbSW.Checked = cbW.Checked
                    = cbN.Checked = cbNE.Checked = false;
                selected = 6;
            }
        }

        private void cbN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbN.Checked)
            {
                cbE.Checked = cbSE.Checked = cbS.Checked = cbSW.Checked = cbW.Checked
                    = cbNW.Checked = cbNE.Checked = false;
                selected = 7;
            }
        }

        private void cbNE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNE.Checked)
            {
                cbE.Checked = cbSE.Checked = cbS.Checked = cbSW.Checked = cbW.Checked
                    = cbNW.Checked = cbN.Checked = false;
                selected = 8;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Operations.directionalEdgeDetection(pw, getMatrix(), getBorderType());
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
