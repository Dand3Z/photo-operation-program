
namespace APO_Projekt.Project
{
    partial class Project_Form
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
            this.btnPanel = new System.Windows.Forms.Panel();
            this.grayImgPanel = new System.Windows.Forms.Panel();
            this.grayHisPanel = new System.Windows.Forms.Panel();
            this.colImgPanel = new System.Windows.Forms.Panel();
            this.colHisPanel = new System.Windows.Forms.Panel();
            this.colValPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnToPicWin = new System.Windows.Forms.Button();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanel
            // 
            this.btnPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPanel.Controls.Add(this.btnToPicWin);
            this.btnPanel.Controls.Add(this.btnDefault);
            this.btnPanel.Controls.Add(this.btnSave);
            this.btnPanel.Location = new System.Drawing.Point(15, 620);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(900, 38);
            this.btnPanel.TabIndex = 0;
            // 
            // grayImgPanel
            // 
            this.grayImgPanel.Location = new System.Drawing.Point(12, 12);
            this.grayImgPanel.Name = "grayImgPanel";
            this.grayImgPanel.Size = new System.Drawing.Size(458, 258);
            this.grayImgPanel.TabIndex = 1;
            // 
            // grayHisPanel
            // 
            this.grayHisPanel.Location = new System.Drawing.Point(12, 276);
            this.grayHisPanel.Name = "grayHisPanel";
            this.grayHisPanel.Size = new System.Drawing.Size(458, 249);
            this.grayHisPanel.TabIndex = 2;
            // 
            // colImgPanel
            // 
            this.colImgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colImgPanel.Location = new System.Drawing.Point(583, 12);
            this.colImgPanel.Name = "colImgPanel";
            this.colImgPanel.Size = new System.Drawing.Size(329, 178);
            this.colImgPanel.TabIndex = 3;
            // 
            // colHisPanel
            // 
            this.colHisPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colHisPanel.Location = new System.Drawing.Point(583, 196);
            this.colHisPanel.Name = "colHisPanel";
            this.colHisPanel.Size = new System.Drawing.Size(329, 173);
            this.colHisPanel.TabIndex = 4;
            // 
            // colValPanel
            // 
            this.colValPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.colValPanel.Location = new System.Drawing.Point(476, 375);
            this.colValPanel.Name = "colValPanel";
            this.colValPanel.Size = new System.Drawing.Size(436, 239);
            this.colValPanel.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(805, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(707, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(92, 32);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnToPicWin
            // 
            this.btnToPicWin.Location = new System.Drawing.Point(550, 3);
            this.btnToPicWin.Name = "btnToPicWin";
            this.btnToPicWin.Size = new System.Drawing.Size(151, 32);
            this.btnToPicWin.TabIndex = 2;
            this.btnToPicWin.Text = "To PictureWindow";
            this.btnToPicWin.UseVisualStyleBackColor = true;
            // 
            // Project_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 670);
            this.Controls.Add(this.colValPanel);
            this.Controls.Add(this.colHisPanel);
            this.Controls.Add(this.colImgPanel);
            this.Controls.Add(this.grayHisPanel);
            this.Controls.Add(this.grayImgPanel);
            this.Controls.Add(this.btnPanel);
            this.Name = "Project_Form";
            this.Text = "Project";
            this.btnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnPanel;
        private System.Windows.Forms.Panel grayImgPanel;
        private System.Windows.Forms.Panel grayHisPanel;
        private System.Windows.Forms.Panel colImgPanel;
        private System.Windows.Forms.Panel colHisPanel;
        private System.Windows.Forms.Panel colValPanel;
        private System.Windows.Forms.Button btnToPicWin;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
    }
}