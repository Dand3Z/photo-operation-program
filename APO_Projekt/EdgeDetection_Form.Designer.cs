
namespace APO_Projekt
{
    partial class EdgeDetection_Form
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
            this.lblBorderType = new System.Windows.Forms.Label();
            this.lblEdgeDetection = new System.Windows.Forms.Label();
            this.cbEdgeDetection = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblKernelSize = new System.Windows.Forms.Label();
            this.cbKernelSize = new System.Windows.Forms.ComboBox();
            this.lblXOrder = new System.Windows.Forms.Label();
            this.lblYOrder = new System.Windows.Forms.Label();
            this.txtXOrder = new System.Windows.Forms.TextBox();
            this.txtYOrder = new System.Windows.Forms.TextBox();
            this.lblSobelDetails = new System.Windows.Forms.Label();
            this.lblCannyDetails = new System.Windows.Forms.Label();
            this.lblThreshold1 = new System.Windows.Forms.Label();
            this.lblThreshold2 = new System.Windows.Forms.Label();
            this.txtThreshold1 = new System.Windows.Forms.TextBox();
            this.txtThreshold2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbBorderType
            // 
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(135, 54);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 0;
            // 
            // lblBorderType
            // 
            this.lblBorderType.AutoSize = true;
            this.lblBorderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBorderType.Location = new System.Drawing.Point(157, 21);
            this.lblBorderType.Name = "lblBorderType";
            this.lblBorderType.Size = new System.Drawing.Size(84, 16);
            this.lblBorderType.TabIndex = 21;
            this.lblBorderType.Text = "Border Type";
            // 
            // lblEdgeDetection
            // 
            this.lblEdgeDetection.AutoSize = true;
            this.lblEdgeDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEdgeDetection.Location = new System.Drawing.Point(28, 21);
            this.lblEdgeDetection.Name = "lblEdgeDetection";
            this.lblEdgeDetection.Size = new System.Drawing.Size(101, 16);
            this.lblEdgeDetection.TabIndex = 22;
            this.lblEdgeDetection.Text = "Edge Detection";
            // 
            // cbEdgeDetection
            // 
            this.cbEdgeDetection.FormattingEnabled = true;
            this.cbEdgeDetection.Location = new System.Drawing.Point(8, 54);
            this.cbEdgeDetection.Name = "cbEdgeDetection";
            this.cbEdgeDetection.Size = new System.Drawing.Size(121, 21);
            this.cbEdgeDetection.TabIndex = 23;
            this.cbEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.cbEdgeDetection_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(315, 267);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 24;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblKernelSize
            // 
            this.lblKernelSize.AutoSize = true;
            this.lblKernelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKernelSize.Location = new System.Drawing.Point(285, 21);
            this.lblKernelSize.Name = "lblKernelSize";
            this.lblKernelSize.Size = new System.Drawing.Size(75, 16);
            this.lblKernelSize.TabIndex = 25;
            this.lblKernelSize.Text = "Kernel Size";
            // 
            // cbKernelSize
            // 
            this.cbKernelSize.FormattingEnabled = true;
            this.cbKernelSize.Location = new System.Drawing.Point(262, 54);
            this.cbKernelSize.Name = "cbKernelSize";
            this.cbKernelSize.Size = new System.Drawing.Size(121, 21);
            this.cbKernelSize.TabIndex = 26;
            this.cbKernelSize.SelectedIndexChanged += new System.EventHandler(this.cbKernelSize_SelectedIndexChanged);
            // 
            // lblXOrder
            // 
            this.lblXOrder.AutoSize = true;
            this.lblXOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblXOrder.Location = new System.Drawing.Point(176, 107);
            this.lblXOrder.Name = "lblXOrder";
            this.lblXOrder.Size = new System.Drawing.Size(54, 16);
            this.lblXOrder.TabIndex = 27;
            this.lblXOrder.Text = "X-Order";
            // 
            // lblYOrder
            // 
            this.lblYOrder.AutoSize = true;
            this.lblYOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblYOrder.Location = new System.Drawing.Point(285, 107);
            this.lblYOrder.Name = "lblYOrder";
            this.lblYOrder.Size = new System.Drawing.Size(55, 16);
            this.lblYOrder.TabIndex = 28;
            this.lblYOrder.Text = "Y-Order";
            // 
            // txtXOrder
            // 
            this.txtXOrder.Location = new System.Drawing.Point(156, 141);
            this.txtXOrder.Name = "txtXOrder";
            this.txtXOrder.Size = new System.Drawing.Size(100, 20);
            this.txtXOrder.TabIndex = 29;
            this.txtXOrder.Text = "1";
            this.txtXOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXOrder.TextChanged += new System.EventHandler(this.txtXOrder_TextChanged);
            // 
            // txtYOrder
            // 
            this.txtYOrder.Location = new System.Drawing.Point(273, 141);
            this.txtYOrder.Name = "txtYOrder";
            this.txtYOrder.Size = new System.Drawing.Size(100, 20);
            this.txtYOrder.TabIndex = 30;
            this.txtYOrder.Text = "0";
            this.txtYOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYOrder.TextChanged += new System.EventHandler(this.txtYOrder_TextChanged);
            // 
            // lblSobelDetails
            // 
            this.lblSobelDetails.AutoSize = true;
            this.lblSobelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSobelDetails.Location = new System.Drawing.Point(28, 141);
            this.lblSobelDetails.Name = "lblSobelDetails";
            this.lblSobelDetails.Size = new System.Drawing.Size(89, 16);
            this.lblSobelDetails.TabIndex = 31;
            this.lblSobelDetails.Text = "Sobel Details";
            // 
            // lblCannyDetails
            // 
            this.lblCannyDetails.AutoSize = true;
            this.lblCannyDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCannyDetails.Location = new System.Drawing.Point(28, 220);
            this.lblCannyDetails.Name = "lblCannyDetails";
            this.lblCannyDetails.Size = new System.Drawing.Size(91, 16);
            this.lblCannyDetails.TabIndex = 32;
            this.lblCannyDetails.Text = "Canny Details";
            // 
            // lblThreshold1
            // 
            this.lblThreshold1.AutoSize = true;
            this.lblThreshold1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblThreshold1.Location = new System.Drawing.Point(162, 193);
            this.lblThreshold1.Name = "lblThreshold1";
            this.lblThreshold1.Size = new System.Drawing.Size(79, 16);
            this.lblThreshold1.TabIndex = 33;
            this.lblThreshold1.Text = "Threshold 1";
            // 
            // lblThreshold2
            // 
            this.lblThreshold2.AutoSize = true;
            this.lblThreshold2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblThreshold2.Location = new System.Drawing.Point(285, 193);
            this.lblThreshold2.Name = "lblThreshold2";
            this.lblThreshold2.Size = new System.Drawing.Size(79, 16);
            this.lblThreshold2.TabIndex = 34;
            this.lblThreshold2.Text = "Threshold 2";
            // 
            // txtThreshold1
            // 
            this.txtThreshold1.Location = new System.Drawing.Point(156, 220);
            this.txtThreshold1.Name = "txtThreshold1";
            this.txtThreshold1.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold1.TabIndex = 35;
            this.txtThreshold1.Text = "100";
            this.txtThreshold1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThreshold1.TextChanged += new System.EventHandler(this.txtThreshold1_TextChanged);
            // 
            // txtThreshold2
            // 
            this.txtThreshold2.Location = new System.Drawing.Point(273, 219);
            this.txtThreshold2.Name = "txtThreshold2";
            this.txtThreshold2.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold2.TabIndex = 36;
            this.txtThreshold2.Text = "200";
            this.txtThreshold2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThreshold2.TextChanged += new System.EventHandler(this.txtThreshold2_TextChanged);
            // 
            // EdgeDetection_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 302);
            this.Controls.Add(this.txtThreshold2);
            this.Controls.Add(this.txtThreshold1);
            this.Controls.Add(this.lblThreshold2);
            this.Controls.Add(this.lblThreshold1);
            this.Controls.Add(this.lblCannyDetails);
            this.Controls.Add(this.lblSobelDetails);
            this.Controls.Add(this.txtYOrder);
            this.Controls.Add(this.txtXOrder);
            this.Controls.Add(this.lblYOrder);
            this.Controls.Add(this.lblXOrder);
            this.Controls.Add(this.cbKernelSize);
            this.Controls.Add(this.lblKernelSize);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbEdgeDetection);
            this.Controls.Add(this.lblEdgeDetection);
            this.Controls.Add(this.lblBorderType);
            this.Controls.Add(this.cbBorderType);
            this.Name = "EdgeDetection_Form";
            this.Text = "EdgeDetection_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.Label lblBorderType;
        private System.Windows.Forms.Label lblEdgeDetection;
        private System.Windows.Forms.ComboBox cbEdgeDetection;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblKernelSize;
        private System.Windows.Forms.ComboBox cbKernelSize;
        private System.Windows.Forms.Label lblXOrder;
        private System.Windows.Forms.Label lblYOrder;
        private System.Windows.Forms.TextBox txtXOrder;
        private System.Windows.Forms.TextBox txtYOrder;
        private System.Windows.Forms.Label lblSobelDetails;
        private System.Windows.Forms.Label lblCannyDetails;
        private System.Windows.Forms.Label lblThreshold1;
        private System.Windows.Forms.Label lblThreshold2;
        private System.Windows.Forms.TextBox txtThreshold1;
        private System.Windows.Forms.TextBox txtThreshold2;
    }
}