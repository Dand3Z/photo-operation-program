
namespace APO_Projekt
{
    partial class AdaptiveThresholding_Form
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
            this.cbAdaptiveMethod = new System.Windows.Forms.ComboBox();
            this.cbThresholdType = new System.Windows.Forms.ComboBox();
            this.lblAdaptiveMethod = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lbTbValue = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblThresholdType = new System.Windows.Forms.Label();
            this.lbBlockSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAdaptiveMethod
            // 
            this.cbAdaptiveMethod.FormattingEnabled = true;
            this.cbAdaptiveMethod.Location = new System.Drawing.Point(33, 68);
            this.cbAdaptiveMethod.Name = "cbAdaptiveMethod";
            this.cbAdaptiveMethod.Size = new System.Drawing.Size(200, 21);
            this.cbAdaptiveMethod.TabIndex = 1;
            // 
            // cbThresholdType
            // 
            this.cbThresholdType.FormattingEnabled = true;
            this.cbThresholdType.Location = new System.Drawing.Point(262, 68);
            this.cbThresholdType.Name = "cbThresholdType";
            this.cbThresholdType.Size = new System.Drawing.Size(150, 21);
            this.cbThresholdType.TabIndex = 2;
            // 
            // lblAdaptiveMethod
            // 
            this.lblAdaptiveMethod.AutoSize = true;
            this.lblAdaptiveMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAdaptiveMethod.Location = new System.Drawing.Point(80, 29);
            this.lblAdaptiveMethod.Name = "lblAdaptiveMethod";
            this.lblAdaptiveMethod.Size = new System.Drawing.Size(110, 16);
            this.lblAdaptiveMethod.TabIndex = 20;
            this.lblAdaptiveMethod.Text = "Adaptive Method";
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 2;
            this.trackBar.Location = new System.Drawing.Point(33, 142);
            this.trackBar.Maximum = 255;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(407, 45);
            this.trackBar.SmallChange = 2;
            this.trackBar.TabIndex = 21;
            this.trackBar.TickFrequency = 2;
            this.trackBar.Value = 5;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // lbTbValue
            // 
            this.lbTbValue.AutoSize = true;
            this.lbTbValue.Location = new System.Drawing.Point(30, 197);
            this.lbTbValue.Name = "lbTbValue";
            this.lbTbValue.Size = new System.Drawing.Size(46, 13);
            this.lbTbValue.TabIndex = 22;
            this.lbTbValue.Text = "Value: 5";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(367, 192);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblThresholdType
            // 
            this.lblThresholdType.AutoSize = true;
            this.lblThresholdType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblThresholdType.Location = new System.Drawing.Point(297, 29);
            this.lblThresholdType.Name = "lblThresholdType";
            this.lblThresholdType.Size = new System.Drawing.Size(84, 16);
            this.lblThresholdType.TabIndex = 24;
            this.lblThresholdType.Text = "Border Type";
            // 
            // lbBlockSize
            // 
            this.lbBlockSize.AutoSize = true;
            this.lbBlockSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbBlockSize.Location = new System.Drawing.Point(195, 123);
            this.lbBlockSize.Name = "lbBlockSize";
            this.lbBlockSize.Size = new System.Drawing.Size(71, 16);
            this.lbBlockSize.TabIndex = 25;
            this.lbBlockSize.Text = "Block Size";
            // 
            // AdaptiveThresholding_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 232);
            this.Controls.Add(this.lbBlockSize);
            this.Controls.Add(this.lblThresholdType);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lbTbValue);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.lblAdaptiveMethod);
            this.Controls.Add(this.cbThresholdType);
            this.Controls.Add(this.cbAdaptiveMethod);
            this.Name = "AdaptiveThresholding_Form";
            this.Text = "AdaptiveThresholding_Form";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAdaptiveMethod;
        private System.Windows.Forms.ComboBox cbThresholdType;
        private System.Windows.Forms.Label lblAdaptiveMethod;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lbTbValue;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblThresholdType;
        private System.Windows.Forms.Label lbBlockSize;
    }
}