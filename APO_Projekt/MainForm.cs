using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APO_Projekt
{
    public partial class MainWindow : Form
    {
        private LogWindow logWindow;

        public MainWindow()
        {
            InitializeComponent();
            logWindow = new LogWindow();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp; *.png; *.tiff)|*jpg; *.jpeg; *.gif; *.bmp; *png; *.tiff";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PictureWindow pictureWindow = new PictureWindow();
                pictureWindow.setPicture(open);
                pictureWindow.Show();
                logWindow.addLog("Opened Picture isGrey:" + (pictureWindow.IsGrey).ToString() + Environment.NewLine);
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;

            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff";
            if (save.ShowDialog() == DialogResult.OK)
            {
                pw.savePicture(save);
            }
        }

        private void MenuClone_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            new PictureWindow(pw).Show();
        }

        private void MenuNegation_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;

            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            Operations.negation(pw.Bitmap, pw.IsGrey);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuShowHistogram_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            pw.showHistogram();
        }

        private void MenuShowLUT_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            pw.showLutTable();
        }

        private void MenuLinearStretching_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Operations.greyLinearStretching(pw.Bitmap, pw.Red);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuEqualization_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;

            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Operations.greyEqualization(pw.Bitmap, pw.Red);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuThresholding_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;

            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Threshold_Form slider = new Threshold_Form(pw);
            slider.Show();
        }

        private void MenuPosterize_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            PosterizeForm form = new PosterizeForm(pw);
            form.Show();
        }

        private void MenuBlur_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Blur_Form blur_Form = new Blur_Form(pw);
            blur_Form.Show();
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuGaussianBlur_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            GaussianBlur_Form gaussianBlur_Form = new GaussianBlur_Form(pw);
            gaussianBlur_Form.Show();
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuLinearSharpening_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            LinearSharpening_Form form = new LinearSharpening_Form(pw);
            form.Show();
        }

        private void MenuDirectionalEdge_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            DirectionalEdgeDetection_Form form = new DirectionalEdgeDetection_Form(pw);
            form.Show();
        }

        private void MenuGrayLevelsThresholding_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            GrayLevelsThresholding_Form slider = new GrayLevelsThresholding_Form(pw);
            slider.Show();
        }

        private void MenuAdjustableStretching_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            AdjustableStretching_Form slider = new AdjustableStretching_Form(pw);
            slider.Show();
        }

        private void MenuEdgeDetection_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            EdgeDetection_Form form = new EdgeDetection_Form(pw);
            form.Show();
        }

        private void MenuCustomMask_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            CustomMask_Form form = new CustomMask_Form(pw);
            form.Show();
        }

        private void MenuMedianBlur_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            MedianBlur_Form form = new MedianBlur_Form(pw);
            form.Show();
        }

        private void MenuBinaryPointOperations_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            BinaryPointOperations_Form form = new BinaryPointOperations_Form(pw);
            form.Show();
        }

        private void MenuMathematicalMorphology_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            MathematicalMorphology_Form form = new MathematicalMorphology_Form(pw);
            form.Show();
        }

        private void MenuSkeletonize_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Skeletonize_Form form = new Skeletonize_Form(pw);
            form.Show();
        }

        private void MenuConvolution_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Convolution_Form form = new Convolution_Form(pw);
            form.Show();
        }

        private void MenuThreMan_Click(object sender, EventArgs e)
        {
            MenuThresholding_Click(sender, e);
        }

        private void MenuThreAdaptive_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            AdaptiveThresholding_Form form = new AdaptiveThresholding_Form(pw);
            form.Show();
        }

        private void MenuOtsu_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Operations.otsu(pw);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuWatershed_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            Operations.watershed(pw);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuFindContours_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!pw.IsGrey)
            {
                MessageBox.Show("Image should be grayscale!", "Not grayscale image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            var form = new FindContours_Form(pw);
            form.Show();
        }

        private void MenuToGrayscale_Click(object sender, EventArgs e)
        {
            PictureWindow pw = PictureWindow.LastActiveWindow;
            if (pw == null)
            {
                MessageBox.Show("Image should be selected!", "Not selected image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            Operations.toGrayscale(pw);
            pw.resetLutTables();
            pw.resetBitmap();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            new AboutMe_Form().Show();
        }
    }
}
