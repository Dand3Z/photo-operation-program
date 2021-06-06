
namespace APO_Projekt
{
    partial class FindContours_Form
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
            this.lbRetrType = new System.Windows.Forms.Label();
            this.cbRetrType = new System.Windows.Forms.ComboBox();
            this.lbApproxMethod = new System.Windows.Forms.Label();
            this.cbApproxMethod = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtMetrics = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbRetrType
            // 
            this.lbRetrType.AutoSize = true;
            this.lbRetrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbRetrType.Location = new System.Drawing.Point(37, 31);
            this.lbRetrType.Name = "lbRetrType";
            this.lbRetrType.Size = new System.Drawing.Size(74, 20);
            this.lbRetrType.TabIndex = 0;
            this.lbRetrType.Text = "RetrType";
            // 
            // cbRetrType
            // 
            this.cbRetrType.FormattingEnabled = true;
            this.cbRetrType.Location = new System.Drawing.Point(12, 69);
            this.cbRetrType.Name = "cbRetrType";
            this.cbRetrType.Size = new System.Drawing.Size(121, 21);
            this.cbRetrType.TabIndex = 1;
            // 
            // lbApproxMethod
            // 
            this.lbApproxMethod.AutoSize = true;
            this.lbApproxMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbApproxMethod.Location = new System.Drawing.Point(180, 31);
            this.lbApproxMethod.Name = "lbApproxMethod";
            this.lbApproxMethod.Size = new System.Drawing.Size(154, 20);
            this.lbApproxMethod.TabIndex = 2;
            this.lbApproxMethod.Text = "ChainApproxMethod";
            // 
            // cbApproxMethod
            // 
            this.cbApproxMethod.FormattingEnabled = true;
            this.cbApproxMethod.Location = new System.Drawing.Point(184, 69);
            this.cbApproxMethod.Name = "cbApproxMethod";
            this.cbApproxMethod.Size = new System.Drawing.Size(150, 21);
            this.cbApproxMethod.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(364, 12);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(111, 78);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtMetrics
            // 
            this.txtMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetrics.Location = new System.Drawing.Point(11, 116);
            this.txtMetrics.Multiline = true;
            this.txtMetrics.Name = "txtMetrics";
            this.txtMetrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMetrics.Size = new System.Drawing.Size(464, 337);
            this.txtMetrics.TabIndex = 5;
            // 
            // FindContours_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 465);
            this.Controls.Add(this.txtMetrics);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbApproxMethod);
            this.Controls.Add(this.lbApproxMethod);
            this.Controls.Add(this.cbRetrType);
            this.Controls.Add(this.lbRetrType);
            this.Name = "FindContours_Form";
            this.Text = "FindContours_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRetrType;
        private System.Windows.Forms.ComboBox cbRetrType;
        private System.Windows.Forms.Label lbApproxMethod;
        private System.Windows.Forms.ComboBox cbApproxMethod;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtMetrics;
    }
}