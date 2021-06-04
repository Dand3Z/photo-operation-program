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
    public partial class MathematicalMorphology_Form : Form
    {
        private PictureWindow pw;
        private Mat structuringElement;
        private BorderType border;
        private int iterations = 2;
        private MorphOp operation;
        public MathematicalMorphology_Form(PictureWindow pw)
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

        private void getStructuringElement(int size)
        {
            String kind = cbShape.Text.ToString();
            Console.WriteLine(kind);
            switch (kind)
            {
                case "CROSS":
                    structuringElement = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(size, size), new Point(-1, -1));
                    break;
                case "SQUARE":
                    structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(size, size), new Point(-1, -1));
                    break;
                default:
                    throw new Exception("getStructuringElement() error");
            }
        }

        private int getSize()
        {
            return int.Parse(cbSize.Text);
        }

        private void getOperation()
        {
            string kind = cbOperation.Text.ToString();
            Console.WriteLine(kind);
            switch (kind)
            {
                case "Erode":
                    operation = MorphOp.Erode;
                    break;
                case "Dilate":
                    operation = MorphOp.Dilate;
                    break;
                case "Open":
                    operation = MorphOp.Open;
                    break;
                case "Close":
                    operation = MorphOp.Close;
                    break;
                default:
                    throw new Exception("getOperation() error");
            }
        }

        private void initFields()
        {
            cbOperation.Items.Add("Erode");
            cbOperation.Items.Add("Dilate");
            cbOperation.Items.Add("Open");
            cbOperation.Items.Add("Close");
            cbOperation.SelectedIndex = 0;

            cbBorderType.Items.Add("BORDER_REPLICATE");
            cbBorderType.Items.Add("BORDER_ISOLATED");
            cbBorderType.Items.Add("BORDER_REFLECT");
            cbBorderType.SelectedIndex = 0;

            cbShape.Items.Add("CROSS");
            cbShape.Items.Add("SQUARE");
            cbShape.SelectedIndex = 0;

            cbSize.Items.Add("3");
            cbSize.Items.Add("5");
            cbSize.Items.Add("7");
            cbSize.Items.Add("9");
            cbSize.Items.Add("11");
            cbSize.Items.Add("13");
            cbSize.Items.Add("15");
            cbSize.Items.Add("17");
            cbSize.Items.Add("19");
            cbSize.Items.Add("21");
            cbSize.SelectedIndex = 0;
        }
/*
        private bool isBinary()
        {
            if (pw.IsGrey)
            {
                Operations.thresholding(pw.Bitmap, 127);
                return true;
            }
            return false;
        }
*/
        private void txtIterations_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtIterations.Text.Trim(), out iterations);
            btnApply.Enabled = iterations > 0 ? true : false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!pw.IsGrey) { return;  }
            getBorderType();
            getOperation();
            getStructuringElement(getSize());
            Image<Rgb, byte> emguImage = pw.Bitmap.ToImage<Rgb, byte>();
            CvInvoke.Threshold(emguImage, emguImage, 128, 256, 0);
            CvInvoke.MorphologyEx(emguImage, emguImage, operation, structuringElement, new Point(-1, -1), iterations, border, new MCvScalar());
            pw.Bitmap = emguImage.ToBitmap();
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }
    }
}
