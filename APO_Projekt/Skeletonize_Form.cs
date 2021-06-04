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
    public partial class Skeletonize_Form : Form
    {
        private PictureWindow pw;
        private Mat structuringElement;
        private BorderType border;
        public Skeletonize_Form(PictureWindow pw)
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


        private void initFields()
        {
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!pw.IsGrey) { return; }
            getBorderType();
            getStructuringElement(getSize());
            skeletonize();
            Close();
        }

        public void skeletonize()
        {
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            Image<Gray, byte> newImage = (new Image<Gray, byte>(emguImage.Width, emguImage.Height, new Gray(255))).Sub(emguImage).Not();
            Image<Gray, byte> eroded = new Image<Gray, byte>(newImage.Size);
            Image<Gray, byte> temp = new Image<Gray, byte>(newImage.Size);
            Image<Gray, byte> skel = new Image<Gray, byte>(newImage.Size);

            skel.SetValue(0);
            CvInvoke.Threshold(newImage, newImage, 127, 256, 0);
            bool finished = false;

            while (!finished)
            {
                CvInvoke.Erode(newImage, eroded, structuringElement, new Point(-1, -1), 1, border, default(MCvScalar));
                CvInvoke.Dilate(eroded, temp, structuringElement, new Point(-1, -1), 1, border, default(MCvScalar));
                CvInvoke.Subtract(newImage, temp, temp);
                CvInvoke.BitwiseOr(skel, temp, skel);
                eroded.CopyTo(newImage);
                if (CvInvoke.CountNonZero(newImage) == 0) finished = true;
            }

            pw.Bitmap = skel.Mat.ToImage<Rgb,byte>().ToBitmap();
            pw.resetBitmap();
            pw.resetLutTables();
        }
    }
}
