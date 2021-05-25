
namespace APO_Projekt
{
    partial class BinaryPointOperations_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbOperations = new System.Windows.Forms.ComboBox();
            this.lblOperation = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.lblLoadedFile = new System.Windows.Forms.Label();
            this.lbBlendingParams = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.lbAlpha = new System.Windows.Forms.Label();
            this.lbBeta = new System.Windows.Forms.Label();
            this.txtBeta = new System.Windows.Forms.TextBox();
            this.lbGamma = new System.Windows.Forms.Label();
            this.txtGamma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbOperations
            // 
            this.cbOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOperations.FormattingEnabled = true;
            this.cbOperations.Location = new System.Drawing.Point(12, 37);
            this.cbOperations.Name = "cbOperations";
            this.cbOperations.Size = new System.Drawing.Size(121, 21);
            this.cbOperations.TabIndex = 23;
            this.cbOperations.SelectedIndexChanged += new System.EventHandler(this.cbOperations_SelectedIndexChanged);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOperation.Location = new System.Drawing.Point(35, 18);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(67, 16);
            this.lblOperation.TabIndex = 24;
            this.lblOperation.Text = "Operation";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(339, 32);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 52);
            this.btnApply.TabIndex = 25;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Location = new System.Drawing.Point(139, 37);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPicture.TabIndex = 26;
            this.btnLoadPicture.Text = "Load Picture";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.btnLoadPicture_Click);
            // 
            // lblLoadedFile
            // 
            this.lblLoadedFile.AutoSize = true;
            this.lblLoadedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLoadedFile.Location = new System.Drawing.Point(220, 40);
            this.lblLoadedFile.Name = "lblLoadedFile";
            this.lblLoadedFile.Size = new System.Drawing.Size(80, 16);
            this.lblLoadedFile.TabIndex = 27;
            this.lblLoadedFile.Text = "Loaded File";
            // 
            // lbBlendingParams
            // 
            this.lbBlendingParams.AutoSize = true;
            this.lbBlendingParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbBlendingParams.Location = new System.Drawing.Point(12, 77);
            this.lbBlendingParams.Name = "lbBlendingParams";
            this.lbBlendingParams.Size = new System.Drawing.Size(114, 16);
            this.lbBlendingParams.TabIndex = 28;
            this.lbBlendingParams.Text = "Blending Params:";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(75, 99);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(70, 20);
            this.txtAlpha.TabIndex = 29;
            this.txtAlpha.Text = "0,7";
            // 
            // lbAlpha
            // 
            this.lbAlpha.AutoSize = true;
            this.lbAlpha.Location = new System.Drawing.Point(35, 102);
            this.lbAlpha.Name = "lbAlpha";
            this.lbAlpha.Size = new System.Drawing.Size(34, 13);
            this.lbAlpha.TabIndex = 30;
            this.lbAlpha.Text = "Alpha";
            // 
            // lbBeta
            // 
            this.lbBeta.AutoSize = true;
            this.lbBeta.Location = new System.Drawing.Point(170, 102);
            this.lbBeta.Name = "lbBeta";
            this.lbBeta.Size = new System.Drawing.Size(29, 13);
            this.lbBeta.TabIndex = 31;
            this.lbBeta.Text = "Beta";
            // 
            // txtBeta
            // 
            this.txtBeta.Location = new System.Drawing.Point(205, 99);
            this.txtBeta.Name = "txtBeta";
            this.txtBeta.Size = new System.Drawing.Size(70, 20);
            this.txtBeta.TabIndex = 32;
            this.txtBeta.Text = "0,5";
            // 
            // lbGamma
            // 
            this.lbGamma.AutoSize = true;
            this.lbGamma.Location = new System.Drawing.Point(296, 102);
            this.lbGamma.Name = "lbGamma";
            this.lbGamma.Size = new System.Drawing.Size(43, 13);
            this.lbGamma.TabIndex = 33;
            this.lbGamma.Text = "Gamma";
            // 
            // txtGamma
            // 
            this.txtGamma.Location = new System.Drawing.Point(345, 99);
            this.txtGamma.Name = "txtGamma";
            this.txtGamma.Size = new System.Drawing.Size(70, 20);
            this.txtGamma.TabIndex = 34;
            this.txtGamma.Text = "-100";
            // 
            // BinaryPointOperations_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 128);
            this.Controls.Add(this.txtGamma);
            this.Controls.Add(this.lbGamma);
            this.Controls.Add(this.txtBeta);
            this.Controls.Add(this.lbBeta);
            this.Controls.Add(this.lbAlpha);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.lbBlendingParams);
            this.Controls.Add(this.lblLoadedFile);
            this.Controls.Add(this.btnLoadPicture);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblOperation);
            this.Controls.Add(this.cbOperations);
            this.Name = "BinaryPointOperations_Form";
            this.Text = "BinaryPointOperations_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOperations;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.Label lblLoadedFile;
        private System.Windows.Forms.Label lbBlendingParams;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.Label lbAlpha;
        private System.Windows.Forms.Label lbBeta;
        private System.Windows.Forms.TextBox txtBeta;
        private System.Windows.Forms.Label lbGamma;
        private System.Windows.Forms.TextBox txtGamma;
    }
}