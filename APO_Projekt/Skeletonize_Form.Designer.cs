
namespace APO_Projekt
{
    partial class Skeletonize_Form
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
            this.lbBorderType = new System.Windows.Forms.Label();
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.lbShape = new System.Windows.Forms.Label();
            this.cbShape = new System.Windows.Forms.ComboBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBorderType
            // 
            this.lbBorderType.AutoSize = true;
            this.lbBorderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbBorderType.Location = new System.Drawing.Point(22, 20);
            this.lbBorderType.Name = "lbBorderType";
            this.lbBorderType.Size = new System.Drawing.Size(95, 20);
            this.lbBorderType.TabIndex = 5;
            this.lbBorderType.Text = "Border Type";
            // 
            // cbBorderType
            // 
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(123, 22);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 6;
            // 
            // lbShape
            // 
            this.lbShape.AutoSize = true;
            this.lbShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbShape.Location = new System.Drawing.Point(250, 23);
            this.lbShape.Name = "lbShape";
            this.lbShape.Size = new System.Drawing.Size(56, 20);
            this.lbShape.TabIndex = 7;
            this.lbShape.Text = "Shape";
            // 
            // cbShape
            // 
            this.cbShape.FormattingEnabled = true;
            this.cbShape.Location = new System.Drawing.Point(312, 25);
            this.cbShape.Name = "cbShape";
            this.cbShape.Size = new System.Drawing.Size(121, 21);
            this.cbShape.TabIndex = 8;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSize.Location = new System.Drawing.Point(22, 70);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(40, 20);
            this.lbSize.TabIndex = 9;
            this.lbSize.Text = "Size";
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(123, 69);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(121, 21);
            this.cbSize.TabIndex = 10;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(369, 91);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Skeletonize_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 126);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.cbShape);
            this.Controls.Add(this.lbShape);
            this.Controls.Add(this.cbBorderType);
            this.Controls.Add(this.lbBorderType);
            this.Name = "Skeletonize_Form";
            this.Text = "Skeletonize_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBorderType;
        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.Label lbShape;
        private System.Windows.Forms.ComboBox cbShape;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.Button btnApply;
    }
}