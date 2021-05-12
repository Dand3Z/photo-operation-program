
namespace APO_Projekt
{
    partial class MedianBlur_Form
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
            this.lblKernelSize = new System.Windows.Forms.Label();
            this.cbKernelSize = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKernelSize
            // 
            this.lblKernelSize.AutoSize = true;
            this.lblKernelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKernelSize.Location = new System.Drawing.Point(31, 21);
            this.lblKernelSize.Name = "lblKernelSize";
            this.lblKernelSize.Size = new System.Drawing.Size(75, 16);
            this.lblKernelSize.TabIndex = 21;
            this.lblKernelSize.Text = "Kernel Size";
            // 
            // cbKernelSize
            // 
            this.cbKernelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbKernelSize.FormattingEnabled = true;
            this.cbKernelSize.Location = new System.Drawing.Point(12, 50);
            this.cbKernelSize.Name = "cbKernelSize";
            this.cbKernelSize.Size = new System.Drawing.Size(121, 21);
            this.cbKernelSize.TabIndex = 22;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(152, 21);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 52);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // MedianBlur_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 83);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbKernelSize);
            this.Controls.Add(this.lblKernelSize);
            this.Name = "MedianBlur_Form";
            this.Text = "MedianBlur_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKernelSize;
        private System.Windows.Forms.ComboBox cbKernelSize;
        private System.Windows.Forms.Button btnApply;
    }
}