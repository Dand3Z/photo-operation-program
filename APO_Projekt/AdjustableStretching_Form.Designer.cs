
namespace APO_Projekt
{
    partial class AdjustableStretching_Form
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
            this.tbP1 = new System.Windows.Forms.TrackBar();
            this.tbQ3 = new System.Windows.Forms.TrackBar();
            this.tbP2 = new System.Windows.Forms.TrackBar();
            this.tbQ4 = new System.Windows.Forms.TrackBar();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblSrcFrom = new System.Windows.Forms.Label();
            this.lblTrgFrom = new System.Windows.Forms.Label();
            this.lblSrcTo = new System.Windows.Forms.Label();
            this.lblTrgTo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQ3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQ4)).BeginInit();
            this.SuspendLayout();
            // 
            // tbP1
            // 
            this.tbP1.Location = new System.Drawing.Point(32, 61);
            this.tbP1.Maximum = 255;
            this.tbP1.Name = "tbP1";
            this.tbP1.Size = new System.Drawing.Size(238, 45);
            this.tbP1.TabIndex = 0;
            this.tbP1.Scroll += new System.EventHandler(this.tbP1_Scroll);
            // 
            // tbQ3
            // 
            this.tbQ3.Location = new System.Drawing.Point(319, 61);
            this.tbQ3.Maximum = 255;
            this.tbQ3.Name = "tbQ3";
            this.tbQ3.Size = new System.Drawing.Size(238, 45);
            this.tbQ3.TabIndex = 1;
            this.tbQ3.Scroll += new System.EventHandler(this.tbQ3_Scroll);
            // 
            // tbP2
            // 
            this.tbP2.Location = new System.Drawing.Point(32, 153);
            this.tbP2.Maximum = 255;
            this.tbP2.Name = "tbP2";
            this.tbP2.Size = new System.Drawing.Size(238, 45);
            this.tbP2.TabIndex = 2;
            this.tbP2.Value = 255;
            this.tbP2.Scroll += new System.EventHandler(this.tbP2_Scroll);
            // 
            // tbQ4
            // 
            this.tbQ4.Location = new System.Drawing.Point(319, 153);
            this.tbQ4.Maximum = 255;
            this.tbQ4.Name = "tbQ4";
            this.tbQ4.Size = new System.Drawing.Size(238, 45);
            this.tbQ4.TabIndex = 3;
            this.tbQ4.Value = 255;
            this.tbQ4.Scroll += new System.EventHandler(this.tbQ4_Scroll);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(513, 222);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblSrcFrom
            // 
            this.lblSrcFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSrcFrom.AutoSize = true;
            this.lblSrcFrom.Location = new System.Drawing.Point(29, 93);
            this.lblSrcFrom.Name = "lblSrcFrom";
            this.lblSrcFrom.Size = new System.Drawing.Size(46, 13);
            this.lblSrcFrom.TabIndex = 5;
            this.lblSrcFrom.Text = "Value: 0";
            // 
            // lblTrgFrom
            // 
            this.lblTrgFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrgFrom.AutoSize = true;
            this.lblTrgFrom.Location = new System.Drawing.Point(316, 93);
            this.lblTrgFrom.Name = "lblTrgFrom";
            this.lblTrgFrom.Size = new System.Drawing.Size(46, 13);
            this.lblTrgFrom.TabIndex = 6;
            this.lblTrgFrom.Text = "Value: 0";
            // 
            // lblSrcTo
            // 
            this.lblSrcTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSrcTo.AutoSize = true;
            this.lblSrcTo.Location = new System.Drawing.Point(29, 185);
            this.lblSrcTo.Name = "lblSrcTo";
            this.lblSrcTo.Size = new System.Drawing.Size(58, 13);
            this.lblSrcTo.TabIndex = 7;
            this.lblSrcTo.Text = "Value: 255";
            // 
            // lblTrgTo
            // 
            this.lblTrgTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrgTo.AutoSize = true;
            this.lblTrgTo.Location = new System.Drawing.Point(316, 185);
            this.lblTrgTo.Name = "lblTrgTo";
            this.lblTrgTo.Size = new System.Drawing.Size(58, 13);
            this.lblTrgTo.TabIndex = 8;
            this.lblTrgTo.Text = "Value: 255";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(221, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 20);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Enter the thresholds";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(112, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(408, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "To";
            // 
            // AdjustableStretching_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 257);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTrgTo);
            this.Controls.Add(this.lblSrcTo);
            this.Controls.Add(this.lblTrgFrom);
            this.Controls.Add(this.lblSrcFrom);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbQ4);
            this.Controls.Add(this.tbP2);
            this.Controls.Add(this.tbQ3);
            this.Controls.Add(this.tbP1);
            this.Name = "AdjustableStretching_Form";
            this.Text = "AdjustableStretching_Form";
            ((System.ComponentModel.ISupportInitialize)(this.tbP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQ3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQ4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbP1;
        private System.Windows.Forms.TrackBar tbQ3;
        private System.Windows.Forms.TrackBar tbP2;
        private System.Windows.Forms.TrackBar tbQ4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblSrcFrom;
        private System.Windows.Forms.Label lblTrgFrom;
        private System.Windows.Forms.Label lblSrcTo;
        private System.Windows.Forms.Label lblTrgTo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}