
namespace APO_Projekt
{
    partial class BinsThresholdingForm
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
            this.txtBins = new System.Windows.Forms.TextBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBins
            // 
            this.txtBins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBins.Location = new System.Drawing.Point(12, 12);
            this.txtBins.MaxLength = 3;
            this.txtBins.Multiline = true;
            this.txtBins.Name = "txtBins";
            this.txtBins.Size = new System.Drawing.Size(96, 57);
            this.txtBins.TabIndex = 0;
            this.txtBins.Text = "8";
            this.txtBins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBins.TextChanged += new System.EventHandler(this.txtBins_TextChanged);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(35, 75);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(54, 23);
            this.btnDo.TabIndex = 2;
            this.btnDo.Text = "Do";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // BinsThresholdingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 109);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.txtBins);
            this.Name = "BinsThresholdingForm";
            this.Text = "BinsThresholdingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBins;
        private System.Windows.Forms.Button btnDo;
    }
}