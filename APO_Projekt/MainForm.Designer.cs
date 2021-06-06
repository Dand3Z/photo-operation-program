
namespace APO_Projekt
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClone = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToGrayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.lab1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowHistogram = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowLUT = new System.Windows.Forms.ToolStripMenuItem();
            this.lab2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNegation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLinearStretching = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEqualization = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThresholding = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGrayLevelsThresholding = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPosterize = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdjustableStretching = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDirectionalEdgeDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLinearSmoothing = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGaussianBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEdgeDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLinearSharpening = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDirectionalEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCustomMask = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMedianBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBinaryPointOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.lab4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMathematicalMorphology = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSkeletonize = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConvolution = new System.Windows.Forms.ToolStripMenuItem();
            this.lab5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThreMan = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThreAdaptive = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOtsu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWatershed = new System.Windows.Forms.ToolStripMenuItem();
            this.lab6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMetrics = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.lab1ToolStripMenuItem,
            this.lab2ToolStripMenuItem,
            this.MenuDirectionalEdgeDetection,
            this.lab4ToolStripMenuItem,
            this.lab5ToolStripMenuItem,
            this.lab6ToolStripMenuItem,
            this.btnProject,
            this.MenuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuClone,
            this.MenuSave,
            this.MenuToGrayscale});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(139, 22);
            this.MenuOpen.Text = "Open";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuClone
            // 
            this.MenuClone.Name = "MenuClone";
            this.MenuClone.Size = new System.Drawing.Size(139, 22);
            this.MenuClone.Text = "Clone";
            this.MenuClone.Click += new System.EventHandler(this.MenuClone_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(139, 22);
            this.MenuSave.Text = "Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuToGrayscale
            // 
            this.MenuToGrayscale.Name = "MenuToGrayscale";
            this.MenuToGrayscale.Size = new System.Drawing.Size(139, 22);
            this.MenuToGrayscale.Text = "To Grayscale";
            this.MenuToGrayscale.Click += new System.EventHandler(this.MenuToGrayscale_Click);
            // 
            // lab1ToolStripMenuItem
            // 
            this.lab1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowHistogram,
            this.MenuShowLUT});
            this.lab1ToolStripMenuItem.Name = "lab1ToolStripMenuItem";
            this.lab1ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lab1ToolStripMenuItem.Text = "Lab1";
            // 
            // MenuShowHistogram
            // 
            this.MenuShowHistogram.Name = "MenuShowHistogram";
            this.MenuShowHistogram.Size = new System.Drawing.Size(162, 22);
            this.MenuShowHistogram.Text = "Show Histogram";
            this.MenuShowHistogram.Click += new System.EventHandler(this.MenuShowHistogram_Click);
            // 
            // MenuShowLUT
            // 
            this.MenuShowLUT.Name = "MenuShowLUT";
            this.MenuShowLUT.Size = new System.Drawing.Size(162, 22);
            this.MenuShowLUT.Text = "Show LUT";
            this.MenuShowLUT.Click += new System.EventHandler(this.MenuShowLUT_Click);
            // 
            // lab2ToolStripMenuItem
            // 
            this.lab2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNegation,
            this.MenuLinearStretching,
            this.MenuEqualization,
            this.MenuThresholding,
            this.MenuGrayLevelsThresholding,
            this.MenuPosterize,
            this.MenuAdjustableStretching});
            this.lab2ToolStripMenuItem.Name = "lab2ToolStripMenuItem";
            this.lab2ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lab2ToolStripMenuItem.Text = "Lab2";
            // 
            // MenuNegation
            // 
            this.MenuNegation.Name = "MenuNegation";
            this.MenuNegation.Size = new System.Drawing.Size(231, 22);
            this.MenuNegation.Text = "Negation";
            this.MenuNegation.Click += new System.EventHandler(this.MenuNegation_Click);
            // 
            // MenuLinearStretching
            // 
            this.MenuLinearStretching.Name = "MenuLinearStretching";
            this.MenuLinearStretching.Size = new System.Drawing.Size(231, 22);
            this.MenuLinearStretching.Text = "Linear Stretching";
            this.MenuLinearStretching.Click += new System.EventHandler(this.MenuLinearStretching_Click);
            // 
            // MenuEqualization
            // 
            this.MenuEqualization.Name = "MenuEqualization";
            this.MenuEqualization.Size = new System.Drawing.Size(231, 22);
            this.MenuEqualization.Text = "Equalization";
            this.MenuEqualization.Click += new System.EventHandler(this.MenuEqualization_Click);
            // 
            // MenuThresholding
            // 
            this.MenuThresholding.Name = "MenuThresholding";
            this.MenuThresholding.Size = new System.Drawing.Size(231, 22);
            this.MenuThresholding.Text = "Thresholding";
            this.MenuThresholding.Click += new System.EventHandler(this.MenuThresholding_Click);
            // 
            // MenuGrayLevelsThresholding
            // 
            this.MenuGrayLevelsThresholding.Name = "MenuGrayLevelsThresholding";
            this.MenuGrayLevelsThresholding.Size = new System.Drawing.Size(231, 22);
            this.MenuGrayLevelsThresholding.Text = "Thresholding with Gray Levels";
            this.MenuGrayLevelsThresholding.Click += new System.EventHandler(this.MenuGrayLevelsThresholding_Click);
            // 
            // MenuPosterize
            // 
            this.MenuPosterize.Name = "MenuPosterize";
            this.MenuPosterize.Size = new System.Drawing.Size(231, 22);
            this.MenuPosterize.Text = "Posterize";
            this.MenuPosterize.Click += new System.EventHandler(this.MenuPosterize_Click);
            // 
            // MenuAdjustableStretching
            // 
            this.MenuAdjustableStretching.Name = "MenuAdjustableStretching";
            this.MenuAdjustableStretching.Size = new System.Drawing.Size(231, 22);
            this.MenuAdjustableStretching.Text = "Adjustable Stretching";
            this.MenuAdjustableStretching.Click += new System.EventHandler(this.MenuAdjustableStretching_Click);
            // 
            // MenuDirectionalEdgeDetection
            // 
            this.MenuDirectionalEdgeDetection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLinearSmoothing,
            this.MenuEdgeDetection,
            this.MenuLinearSharpening,
            this.MenuDirectionalEdge,
            this.MenuCustomMask,
            this.MenuMedianBlur,
            this.MenuBinaryPointOperations});
            this.MenuDirectionalEdgeDetection.Name = "MenuDirectionalEdgeDetection";
            this.MenuDirectionalEdgeDetection.Size = new System.Drawing.Size(44, 20);
            this.MenuDirectionalEdgeDetection.Text = "Lab3";
            // 
            // MenuLinearSmoothing
            // 
            this.MenuLinearSmoothing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBlur,
            this.MenuGaussianBlur});
            this.MenuLinearSmoothing.Name = "MenuLinearSmoothing";
            this.MenuLinearSmoothing.Size = new System.Drawing.Size(214, 22);
            this.MenuLinearSmoothing.Text = "Linear Smoothing";
            // 
            // MenuBlur
            // 
            this.MenuBlur.Name = "MenuBlur";
            this.MenuBlur.Size = new System.Drawing.Size(145, 22);
            this.MenuBlur.Text = "Blur";
            this.MenuBlur.Click += new System.EventHandler(this.MenuBlur_Click);
            // 
            // MenuGaussianBlur
            // 
            this.MenuGaussianBlur.Name = "MenuGaussianBlur";
            this.MenuGaussianBlur.Size = new System.Drawing.Size(145, 22);
            this.MenuGaussianBlur.Text = "Gaussian Blur";
            this.MenuGaussianBlur.Click += new System.EventHandler(this.MenuGaussianBlur_Click);
            // 
            // MenuEdgeDetection
            // 
            this.MenuEdgeDetection.Name = "MenuEdgeDetection";
            this.MenuEdgeDetection.Size = new System.Drawing.Size(214, 22);
            this.MenuEdgeDetection.Text = "Edge Detection";
            this.MenuEdgeDetection.Click += new System.EventHandler(this.MenuEdgeDetection_Click);
            // 
            // MenuLinearSharpening
            // 
            this.MenuLinearSharpening.Name = "MenuLinearSharpening";
            this.MenuLinearSharpening.Size = new System.Drawing.Size(214, 22);
            this.MenuLinearSharpening.Text = "Linear Sharpening";
            this.MenuLinearSharpening.Click += new System.EventHandler(this.MenuLinearSharpening_Click);
            // 
            // MenuDirectionalEdge
            // 
            this.MenuDirectionalEdge.Name = "MenuDirectionalEdge";
            this.MenuDirectionalEdge.Size = new System.Drawing.Size(214, 22);
            this.MenuDirectionalEdge.Text = "Directional Edge Detection";
            this.MenuDirectionalEdge.Click += new System.EventHandler(this.MenuDirectionalEdge_Click);
            // 
            // MenuCustomMask
            // 
            this.MenuCustomMask.Name = "MenuCustomMask";
            this.MenuCustomMask.Size = new System.Drawing.Size(214, 22);
            this.MenuCustomMask.Text = "Custom Mask";
            this.MenuCustomMask.Click += new System.EventHandler(this.MenuCustomMask_Click);
            // 
            // MenuMedianBlur
            // 
            this.MenuMedianBlur.Name = "MenuMedianBlur";
            this.MenuMedianBlur.Size = new System.Drawing.Size(214, 22);
            this.MenuMedianBlur.Text = "Median Blur";
            this.MenuMedianBlur.Click += new System.EventHandler(this.MenuMedianBlur_Click);
            // 
            // MenuBinaryPointOperations
            // 
            this.MenuBinaryPointOperations.Name = "MenuBinaryPointOperations";
            this.MenuBinaryPointOperations.Size = new System.Drawing.Size(214, 22);
            this.MenuBinaryPointOperations.Text = "Binary Point Operations";
            this.MenuBinaryPointOperations.Click += new System.EventHandler(this.MenuBinaryPointOperations_Click);
            // 
            // lab4ToolStripMenuItem
            // 
            this.lab4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMathematicalMorphology,
            this.MenuSkeletonize,
            this.MenuConvolution});
            this.lab4ToolStripMenuItem.Name = "lab4ToolStripMenuItem";
            this.lab4ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lab4ToolStripMenuItem.Text = "Lab4";
            // 
            // MenuMathematicalMorphology
            // 
            this.MenuMathematicalMorphology.Name = "MenuMathematicalMorphology";
            this.MenuMathematicalMorphology.Size = new System.Drawing.Size(216, 22);
            this.MenuMathematicalMorphology.Text = "Mathematical Morphology";
            this.MenuMathematicalMorphology.Click += new System.EventHandler(this.MenuMathematicalMorphology_Click);
            // 
            // MenuSkeletonize
            // 
            this.MenuSkeletonize.Name = "MenuSkeletonize";
            this.MenuSkeletonize.Size = new System.Drawing.Size(216, 22);
            this.MenuSkeletonize.Text = "Skeletonize";
            this.MenuSkeletonize.Click += new System.EventHandler(this.MenuSkeletonize_Click);
            // 
            // MenuConvolution
            // 
            this.MenuConvolution.Name = "MenuConvolution";
            this.MenuConvolution.Size = new System.Drawing.Size(216, 22);
            this.MenuConvolution.Text = "Convolution";
            this.MenuConvolution.Click += new System.EventHandler(this.MenuConvolution_Click);
            // 
            // lab5ToolStripMenuItem
            // 
            this.lab5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdingToolStripMenuItem,
            this.MenuWatershed});
            this.lab5ToolStripMenuItem.Name = "lab5ToolStripMenuItem";
            this.lab5ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lab5ToolStripMenuItem.Text = "Lab5";
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuThreMan,
            this.MenuThreAdaptive,
            this.MenuOtsu});
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            // 
            // MenuThreMan
            // 
            this.MenuThreMan.Name = "MenuThreMan";
            this.MenuThreMan.Size = new System.Drawing.Size(121, 22);
            this.MenuThreMan.Text = "Manual";
            this.MenuThreMan.Click += new System.EventHandler(this.MenuThreMan_Click);
            // 
            // MenuThreAdaptive
            // 
            this.MenuThreAdaptive.Name = "MenuThreAdaptive";
            this.MenuThreAdaptive.Size = new System.Drawing.Size(121, 22);
            this.MenuThreAdaptive.Text = "Adaptive";
            this.MenuThreAdaptive.Click += new System.EventHandler(this.MenuThreAdaptive_Click);
            // 
            // MenuOtsu
            // 
            this.MenuOtsu.Name = "MenuOtsu";
            this.MenuOtsu.Size = new System.Drawing.Size(121, 22);
            this.MenuOtsu.Text = "Otsu";
            this.MenuOtsu.Click += new System.EventHandler(this.MenuOtsu_Click);
            // 
            // MenuWatershed
            // 
            this.MenuWatershed.Name = "MenuWatershed";
            this.MenuWatershed.Size = new System.Drawing.Size(143, 22);
            this.MenuWatershed.Text = "Watershed";
            this.MenuWatershed.Click += new System.EventHandler(this.MenuWatershed_Click);
            // 
            // lab6ToolStripMenuItem
            // 
            this.lab6ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMetrics});
            this.lab6ToolStripMenuItem.Name = "lab6ToolStripMenuItem";
            this.lab6ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lab6ToolStripMenuItem.Text = "Lab6";
            // 
            // MenuMetrics
            // 
            this.MenuMetrics.Name = "MenuMetrics";
            this.MenuMetrics.Size = new System.Drawing.Size(113, 22);
            this.MenuMetrics.Text = "Metrics";
            this.MenuMetrics.Click += new System.EventHandler(this.MenuFindContours_Click);
            // 
            // btnProject
            // 
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(56, 20);
            this.btnProject.Text = "Project";
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(52, 20);
            this.MenuAbout.Text = "About";
            this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 34);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "APO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem lab1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuClone;
        private System.Windows.Forms.ToolStripMenuItem MenuNegation;
        private System.Windows.Forms.ToolStripMenuItem MenuShowHistogram;
        private System.Windows.Forms.ToolStripMenuItem MenuShowLUT;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuLinearStretching;
        private System.Windows.Forms.ToolStripMenuItem MenuEqualization;
        private System.Windows.Forms.ToolStripMenuItem MenuThresholding;
        private System.Windows.Forms.ToolStripMenuItem MenuPosterize;
        private System.Windows.Forms.ToolStripMenuItem MenuDirectionalEdgeDetection;
        private System.Windows.Forms.ToolStripMenuItem MenuLinearSmoothing;
        private System.Windows.Forms.ToolStripMenuItem MenuBlur;
        private System.Windows.Forms.ToolStripMenuItem MenuGaussianBlur;
        private System.Windows.Forms.ToolStripMenuItem MenuEdgeDetection;
        private System.Windows.Forms.ToolStripMenuItem MenuLinearSharpening;
        private System.Windows.Forms.ToolStripMenuItem MenuDirectionalEdge;
        private System.Windows.Forms.ToolStripMenuItem MenuGrayLevelsThresholding;
        private System.Windows.Forms.ToolStripMenuItem MenuAdjustableStretching;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomMask;
        private System.Windows.Forms.ToolStripMenuItem MenuMedianBlur;
        private System.Windows.Forms.ToolStripMenuItem MenuBinaryPointOperations;
        private System.Windows.Forms.ToolStripMenuItem lab4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMathematicalMorphology;
        private System.Windows.Forms.ToolStripMenuItem MenuSkeletonize;
        private System.Windows.Forms.ToolStripMenuItem MenuConvolution;
        private System.Windows.Forms.ToolStripMenuItem lab5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lab6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnProject;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuThreMan;
        private System.Windows.Forms.ToolStripMenuItem MenuThreAdaptive;
        private System.Windows.Forms.ToolStripMenuItem MenuOtsu;
        private System.Windows.Forms.ToolStripMenuItem MenuWatershed;
        private System.Windows.Forms.ToolStripMenuItem MenuMetrics;
        private System.Windows.Forms.ToolStripMenuItem MenuToGrayscale;
        private System.Windows.Forms.ToolStripMenuItem MenuAbout;
    }
}

