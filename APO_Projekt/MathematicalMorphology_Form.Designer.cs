
namespace APO_Projekt
{
    partial class MathematicalMorphology_Form
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
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.lbOperation = new System.Windows.Forms.Label();
            this.lbShape = new System.Windows.Forms.Label();
            this.cbShape = new System.Windows.Forms.ComboBox();
            this.lbBorderType = new System.Windows.Forms.Label();
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lbIterations = new System.Windows.Forms.Label();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbOperation
            // 
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Location = new System.Drawing.Point(122, 28);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(121, 21);
            this.cbOperation.TabIndex = 0;
            // 
            // lbOperation
            // 
            this.lbOperation.AutoSize = true;
            this.lbOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbOperation.Location = new System.Drawing.Point(12, 26);
            this.lbOperation.Name = "lbOperation";
            this.lbOperation.Size = new System.Drawing.Size(79, 20);
            this.lbOperation.TabIndex = 1;
            this.lbOperation.Text = "Operation";
            // 
            // lbShape
            // 
            this.lbShape.AutoSize = true;
            this.lbShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbShape.Location = new System.Drawing.Point(249, 26);
            this.lbShape.Name = "lbShape";
            this.lbShape.Size = new System.Drawing.Size(56, 20);
            this.lbShape.TabIndex = 2;
            this.lbShape.Text = "Shape";
            // 
            // cbShape
            // 
            this.cbShape.FormattingEnabled = true;
            this.cbShape.Location = new System.Drawing.Point(311, 28);
            this.cbShape.Name = "cbShape";
            this.cbShape.Size = new System.Drawing.Size(121, 21);
            this.cbShape.TabIndex = 3;
            // 
            // lbBorderType
            // 
            this.lbBorderType.AutoSize = true;
            this.lbBorderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbBorderType.Location = new System.Drawing.Point(12, 81);
            this.lbBorderType.Name = "lbBorderType";
            this.lbBorderType.Size = new System.Drawing.Size(95, 20);
            this.lbBorderType.TabIndex = 4;
            this.lbBorderType.Text = "Border Type";
            // 
            // cbBorderType
            // 
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(122, 83);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 5;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSize.Location = new System.Drawing.Point(249, 81);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(40, 20);
            this.lbSize.TabIndex = 6;
            this.lbSize.Text = "Size";
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(311, 83);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(121, 21);
            this.cbSize.TabIndex = 7;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(367, 142);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lbIterations
            // 
            this.lbIterations.AutoSize = true;
            this.lbIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbIterations.Location = new System.Drawing.Point(12, 132);
            this.lbIterations.Name = "lbIterations";
            this.lbIterations.Size = new System.Drawing.Size(76, 20);
            this.lbIterations.TabIndex = 9;
            this.lbIterations.Text = "Iterations";
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(122, 132);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(41, 20);
            this.txtIterations.TabIndex = 10;
            this.txtIterations.TextChanged += new System.EventHandler(this.txtIterations_TextChanged);
            // 
            // MathematicalMorphology_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 177);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.lbIterations);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.cbBorderType);
            this.Controls.Add(this.lbBorderType);
            this.Controls.Add(this.cbShape);
            this.Controls.Add(this.lbShape);
            this.Controls.Add(this.lbOperation);
            this.Controls.Add(this.cbOperation);
            this.Name = "MathematicalMorphology_Form";
            this.Text = "MathematicalMorphology_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.Label lbOperation;
        private System.Windows.Forms.Label lbShape;
        private System.Windows.Forms.ComboBox cbShape;
        private System.Windows.Forms.Label lbBorderType;
        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lbIterations;
        private System.Windows.Forms.TextBox txtIterations;
    }
}