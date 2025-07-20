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
    public partial class EdgeDetection_Form : Form
    {
        private PictureWindow pw;
        private int xOrder = 1, yOrder = 0;
        private double threshold1 = 100, threshold2 = 200;
        int ksize = 5;

        public EdgeDetection_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;

            cbBorderType.Items.Add("Replicate");
            cbBorderType.Items.Add("Isolated");
            cbBorderType.Items.Add("Reflect");
            cbBorderType.SelectedIndex = 0;

            cbEdgeDetection.Items.Add("Laplacian");
            cbEdgeDetection.Items.Add("Sobel");
            cbEdgeDetection.Items.Add("Canny");
            cbEdgeDetection.SelectedIndex = 0;

            cbKernelSize.Items.Add("3");
            cbKernelSize.Items.Add("5");
            cbKernelSize.Items.Add("7");
            cbKernelSize.Items.Add("9");
            cbKernelSize.Items.Add("11");
            cbKernelSize.Items.Add("13");
            cbKernelSize.Items.Add("15");
            cbKernelSize.SelectedIndex = 1;

            txtXOrder.Enabled = txtYOrder.Enabled = txtThreshold1.Enabled =
                txtThreshold2.Enabled = false;
        }

        private void cbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEdgeDetection.Text.ToString().Equals("Sobel")) {
                txtXOrder.Enabled = txtYOrder.Enabled = true;
                txtThreshold1.Enabled = txtThreshold2.Enabled = false;
            } else if (cbEdgeDetection.Text.ToString().Equals("Canny")) {
                txtXOrder.Enabled = txtYOrder.Enabled = false;
                txtThreshold1.Enabled = txtThreshold2.Enabled = true;
            } else {
                txtXOrder.Enabled = txtYOrder.Enabled = txtThreshold1.Enabled =
                txtThreshold2.Enabled = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BorderType borderType = getBorderType();
            if (cbEdgeDetection.SelectedItem.ToString().Equals("Laplacian"))
            {
                Console.WriteLine("Laplacian"); //
                Operations.laplacian(pw, ksize, borderType);
            }
            else if (cbEdgeDetection.SelectedItem.ToString().Equals("Sobel"))
            {
                Console.WriteLine("Sobel"); //
                Operations.sobel(pw, ksize, xOrder, yOrder, borderType);
            }
            else
            {
                Console.WriteLine("Canny"); //
                Operations.canny(pw, threshold1, threshold2);
            }
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
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

        private void txtXOrder_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = int.TryParse(txtXOrder.Text.Trim().ToString(), out xOrder);
        }

        private void txtYOrder_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = int.TryParse(txtYOrder.Text.Trim().ToString(), out yOrder);
        }

        private void txtThreshold1_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = double.TryParse(txtThreshold1.Text.Trim().ToString(), out threshold1);
        }

        private void txtThreshold2_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = double.TryParse(txtThreshold2.Text.Trim().ToString(), out threshold2);
        }

        private void cbKernelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cbKernelSize.SelectedItem.ToString(), out ksize);
        }
    }
}
