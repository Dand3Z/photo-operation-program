
namespace APO_Projekt
{
    partial class Blur_Form
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
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbKernelSize = new System.Windows.Forms.ComboBox();
            this.lblBorderType = new System.Windows.Forms.Label();
            this.lblKernelSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbBorderType
            // 
            this.cbBorderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(12, 55);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(285, 53);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbKernelSize
            // 
            this.cbKernelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbKernelSize.FormattingEnabled = true;
            this.cbKernelSize.Location = new System.Drawing.Point(139, 55);
            this.cbKernelSize.Name = "cbKernelSize";
            this.cbKernelSize.Size = new System.Drawing.Size(121, 21);
            this.cbKernelSize.TabIndex = 18;
            // 
            // lblBorderType
            // 
            this.lblBorderType.AutoSize = true;
            this.lblBorderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBorderType.Location = new System.Drawing.Point(36, 20);
            this.lblBorderType.Name = "lblBorderType";
            this.lblBorderType.Size = new System.Drawing.Size(84, 16);
            this.lblBorderType.TabIndex = 19;
            this.lblBorderType.Text = "Border Type";
            // 
            // lblKernelSize
            // 
            this.lblKernelSize.AutoSize = true;
            this.lblKernelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKernelSize.Location = new System.Drawing.Point(163, 20);
            this.lblKernelSize.Name = "lblKernelSize";
            this.lblKernelSize.Size = new System.Drawing.Size(75, 16);
            this.lblKernelSize.TabIndex = 20;
            this.lblKernelSize.Text = "Kernel Size";
            // 
            // Blur_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 88);
            this.Controls.Add(this.lblKernelSize);
            this.Controls.Add(this.lblBorderType);
            this.Controls.Add(this.cbKernelSize);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbBorderType);
            this.Name = "Blur_Form";
            this.Text = "Blur_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbKernelSize;
        private System.Windows.Forms.Label lblBorderType;
        private System.Windows.Forms.Label lblKernelSize;
    }
}