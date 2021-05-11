
namespace APO_Projekt
{
    partial class GaussianBlur_Form
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
            this.btnApply = new System.Windows.Forms.Button();
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.lblBorderType = new System.Windows.Forms.Label();
            this.lblKernelSize = new System.Windows.Forms.Label();
            this.cbKernelSize = new System.Windows.Forms.ComboBox();
            this.lblSigmaX = new System.Windows.Forms.Label();
            this.txtSigmaX = new System.Windows.Forms.TextBox();
            this.txtSigmaY = new System.Windows.Forms.TextBox();
            this.lblSigmaY = new System.Windows.Forms.Label();
            this.cbXeqY = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(487, 52);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbBorderType
            // 
            this.cbBorderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(12, 52);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 19;
            // 
            // lblBorderType
            // 
            this.lblBorderType.AutoSize = true;
            this.lblBorderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBorderType.Location = new System.Drawing.Point(31, 19);
            this.lblBorderType.Name = "lblBorderType";
            this.lblBorderType.Size = new System.Drawing.Size(84, 16);
            this.lblBorderType.TabIndex = 20;
            this.lblBorderType.Text = "Border Type";
            // 
            // lblKernelSize
            // 
            this.lblKernelSize.AutoSize = true;
            this.lblKernelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKernelSize.Location = new System.Drawing.Point(162, 19);
            this.lblKernelSize.Name = "lblKernelSize";
            this.lblKernelSize.Size = new System.Drawing.Size(75, 16);
            this.lblKernelSize.TabIndex = 21;
            this.lblKernelSize.Text = "Kernel Size";
            // 
            // cbKernelSize
            // 
            this.cbKernelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbKernelSize.FormattingEnabled = true;
            this.cbKernelSize.Location = new System.Drawing.Point(139, 52);
            this.cbKernelSize.Name = "cbKernelSize";
            this.cbKernelSize.Size = new System.Drawing.Size(121, 21);
            this.cbKernelSize.TabIndex = 22;
            // 
            // lblSigmaX
            // 
            this.lblSigmaX.AutoSize = true;
            this.lblSigmaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSigmaX.Location = new System.Drawing.Point(280, 19);
            this.lblSigmaX.Name = "lblSigmaX";
            this.lblSigmaX.Size = new System.Drawing.Size(55, 16);
            this.lblSigmaX.TabIndex = 23;
            this.lblSigmaX.Text = "SigmaX";
            // 
            // txtSigmaX
            // 
            this.txtSigmaX.Location = new System.Drawing.Point(266, 52);
            this.txtSigmaX.Name = "txtSigmaX";
            this.txtSigmaX.Size = new System.Drawing.Size(84, 20);
            this.txtSigmaX.TabIndex = 24;
            this.txtSigmaX.Text = "1";
            this.txtSigmaX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSigmaX.TextChanged += new System.EventHandler(this.txtSigmaX_TextChanged);
            // 
            // txtSigmaY
            // 
            this.txtSigmaY.Location = new System.Drawing.Point(356, 52);
            this.txtSigmaY.Name = "txtSigmaY";
            this.txtSigmaY.Size = new System.Drawing.Size(84, 20);
            this.txtSigmaY.TabIndex = 25;
            this.txtSigmaY.Text = "0";
            this.txtSigmaY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSigmaY.TextChanged += new System.EventHandler(this.txtSigmaY_TextChanged);
            // 
            // lblSigmaY
            // 
            this.lblSigmaY.AutoSize = true;
            this.lblSigmaY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSigmaY.Location = new System.Drawing.Point(370, 19);
            this.lblSigmaY.Name = "lblSigmaY";
            this.lblSigmaY.Size = new System.Drawing.Size(56, 16);
            this.lblSigmaY.TabIndex = 26;
            this.lblSigmaY.Text = "SigmaY";
            // 
            // cbXeqY
            // 
            this.cbXeqY.AutoSize = true;
            this.cbXeqY.Location = new System.Drawing.Point(458, 18);
            this.cbXeqY.Name = "cbXeqY";
            this.cbXeqY.Size = new System.Drawing.Size(104, 17);
            this.cbXeqY.TabIndex = 27;
            this.cbXeqY.Text = "SigmaX=SigmaY";
            this.cbXeqY.UseVisualStyleBackColor = true;
            this.cbXeqY.CheckedChanged += new System.EventHandler(this.cbXeqY_CheckedChanged);
            // 
            // GaussianBlur_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 87);
            this.Controls.Add(this.cbXeqY);
            this.Controls.Add(this.lblSigmaY);
            this.Controls.Add(this.txtSigmaY);
            this.Controls.Add(this.txtSigmaX);
            this.Controls.Add(this.lblSigmaX);
            this.Controls.Add(this.cbKernelSize);
            this.Controls.Add(this.lblKernelSize);
            this.Controls.Add(this.lblBorderType);
            this.Controls.Add(this.cbBorderType);
            this.Controls.Add(this.btnApply);
            this.Name = "GaussianBlur_Form";
            this.Text = "GaussianBlur_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.Label lblBorderType;
        private System.Windows.Forms.Label lblKernelSize;
        private System.Windows.Forms.ComboBox cbKernelSize;
        private System.Windows.Forms.Label lblSigmaX;
        private System.Windows.Forms.TextBox txtSigmaX;
        private System.Windows.Forms.TextBox txtSigmaY;
        private System.Windows.Forms.Label lblSigmaY;
        private System.Windows.Forms.CheckBox cbXeqY;
    }
}