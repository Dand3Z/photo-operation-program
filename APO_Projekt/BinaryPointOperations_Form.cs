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
    public partial class BinaryPointOperations_Form : Form
    {
        private PictureWindow pw;
        private Mat secondImg = null;
        public BinaryPointOperations_Form(PictureWindow pw)
        {
            InitializeComponent();
            this.pw = pw;

            cbOperations.Items.Add("Add");
            cbOperations.Items.Add("Subtraction");
            cbOperations.Items.Add("Blending");
            cbOperations.Items.Add("AND");
            cbOperations.Items.Add("OR");
            cbOperations.Items.Add("NOT");
            cbOperations.Items.Add("XOR");
            cbOperations.SelectedIndex = 0;
            btnApply.Enabled = false;
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif)|*jpg; *.jpeg; *.gif; *.bmp; *png; *.tif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] filepath = open.FileName.Split(" \\".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                lblLoadedFile.Text = filepath[filepath.Length - 1];
                secondImg = CvInvoke.Imread(open.FileName, ImreadModes.Grayscale);
                btnApply.Enabled = true;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> emguImage = pw.Bitmap.ToImage<Gray, byte>();
            CvInvoke.Resize(secondImg, secondImg, new Size(emguImage.Width, emguImage.Height));

            switch (cbOperations.SelectedItem)
            {
                case "Add":
                    CvInvoke.Add(emguImage, secondImg, emguImage);
                    break;
                case "Subtraction":
                    CvInvoke.Subtract(emguImage, secondImg, emguImage);
                    break;
                case "Blending":
                    CvInvoke.AddWeighted(emguImage, 0.7, secondImg, 0.5, -100 ,emguImage);
                    break;
                case "AND":
                    CvInvoke.BitwiseAnd(emguImage, secondImg, emguImage);
                    break;
                case "OR":
                    CvInvoke.BitwiseOr(emguImage, secondImg, emguImage);
                    break;
                case "NOT":
                    CvInvoke.BitwiseNot(emguImage, secondImg, emguImage);
                    break;
                case "XOR":
                    CvInvoke.BitwiseXor(emguImage, secondImg, emguImage);
                    break;

            }

            Bitmap result = emguImage.ToBitmap();
            pw.Bitmap = result;
            pw.resetLutTables();
            pw.resetBitmap();
            Close();
        }
    }


}
