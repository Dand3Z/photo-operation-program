
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnToPicWin = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grayImgPanel = new System.Windows.Forms.Panel();
            this.pbGrayImg = new Emgu.CV.UI.ImageBox();
            this.grayHisPanel = new System.Windows.Forms.Panel();
            this.chtGrayHis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colImgPanel = new System.Windows.Forms.Panel();
            this.pbColImg = new Emgu.CV.UI.ImageBox();
            this.colHisPanel = new System.Windows.Forms.Panel();
            this.chtColHis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colValPanel = new System.Windows.Forms.Panel();
            this.lbBlueValue = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.lbGreenValue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.lbRedValue = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.lblValTitle = new System.Windows.Forms.Label();
            this.btnPanel.SuspendLayout();
            this.grayImgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrayImg)).BeginInit();
            this.grayHisPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtGrayHis)).BeginInit();
            this.colImgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColImg)).BeginInit();
            this.colHisPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtColHis)).BeginInit();
            this.colValPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPanel
            // 
            this.btnPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPanel.Controls.Add(this.btnOpen);
            this.btnPanel.Controls.Add(this.btnToPicWin);
            this.btnPanel.Controls.Add(this.btnDefault);
            this.btnPanel.Controls.Add(this.btnSave);
            this.btnPanel.Location = new System.Drawing.Point(15, 620);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(900, 38);
            this.btnPanel.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(802, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(92, 32);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open Picture";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnToPicWin
            // 
            this.btnToPicWin.Location = new System.Drawing.Point(449, 3);
            this.btnToPicWin.Name = "btnToPicWin";
            this.btnToPicWin.Size = new System.Drawing.Size(151, 32);
            this.btnToPicWin.TabIndex = 2;
            this.btnToPicWin.Text = "To PictureWindow";
            this.btnToPicWin.UseVisualStyleBackColor = true;
            this.btnToPicWin.Click += new System.EventHandler(this.btnToPicWin_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(606, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(92, 32);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(704, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grayImgPanel
            // 
            this.grayImgPanel.Controls.Add(this.pbGrayImg);
            this.grayImgPanel.Location = new System.Drawing.Point(12, 12);
            this.grayImgPanel.Name = "grayImgPanel";
            this.grayImgPanel.Size = new System.Drawing.Size(458, 258);
            this.grayImgPanel.TabIndex = 1;
            // 
            // pbGrayImg
            // 
            this.pbGrayImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGrayImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGrayImg.Location = new System.Drawing.Point(0, 0);
            this.pbGrayImg.Name = "pbGrayImg";
            this.pbGrayImg.Size = new System.Drawing.Size(458, 258);
            this.pbGrayImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGrayImg.TabIndex = 2;
            this.pbGrayImg.TabStop = false;
            // 
            // grayHisPanel
            // 
            this.grayHisPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grayHisPanel.Controls.Add(this.chtGrayHis);
            this.grayHisPanel.Location = new System.Drawing.Point(12, 276);
            this.grayHisPanel.Name = "grayHisPanel";
            this.grayHisPanel.Size = new System.Drawing.Size(458, 249);
            this.grayHisPanel.TabIndex = 2;
            // 
            // chtGrayHis
            // 
            chartArea7.Name = "ChartArea1";
            this.chtGrayHis.ChartAreas.Add(chartArea7);
            this.chtGrayHis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chtGrayHis.Legends.Add(legend7);
            this.chtGrayHis.Location = new System.Drawing.Point(0, 0);
            this.chtGrayHis.Name = "chtGrayHis";
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series25.Color = System.Drawing.Color.Gray;
            series25.Legend = "Legend1";
            series25.Name = "gray";
            this.chtGrayHis.Series.Add(series25);
            this.chtGrayHis.Size = new System.Drawing.Size(456, 247);
            this.chtGrayHis.TabIndex = 0;
            this.chtGrayHis.Text = "chart1";
            // 
            // colImgPanel
            // 
            this.colImgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colImgPanel.Controls.Add(this.pbColImg);
            this.colImgPanel.Location = new System.Drawing.Point(583, 12);
            this.colImgPanel.Name = "colImgPanel";
            this.colImgPanel.Size = new System.Drawing.Size(329, 178);
            this.colImgPanel.TabIndex = 3;
            // 
            // pbColImg
            // 
            this.pbColImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbColImg.Location = new System.Drawing.Point(0, 0);
            this.pbColImg.Name = "pbColImg";
            this.pbColImg.Size = new System.Drawing.Size(329, 178);
            this.pbColImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbColImg.TabIndex = 2;
            this.pbColImg.TabStop = false;
            // 
            // colHisPanel
            // 
            this.colHisPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colHisPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colHisPanel.Controls.Add(this.chtColHis);
            this.colHisPanel.Location = new System.Drawing.Point(583, 196);
            this.colHisPanel.Name = "colHisPanel";
            this.colHisPanel.Size = new System.Drawing.Size(329, 173);
            this.colHisPanel.TabIndex = 4;
            // 
            // chtColHis
            // 
            this.chtColHis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea8.Name = "ChartArea1";
            this.chtColHis.ChartAreas.Add(chartArea8);
            this.chtColHis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chtColHis.Legends.Add(legend8);
            this.chtColHis.Location = new System.Drawing.Point(0, 0);
            this.chtColHis.Name = "chtColHis";
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series26.Color = System.Drawing.Color.Red;
            series26.Legend = "Legend1";
            series26.Name = "red";
            series27.ChartArea = "ChartArea1";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series27.Color = System.Drawing.Color.LimeGreen;
            series27.Legend = "Legend1";
            series27.Name = "green";
            series28.ChartArea = "ChartArea1";
            series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series28.Legend = "Legend1";
            series28.Name = "blue";
            series29.ChartArea = "ChartArea1";
            series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series29.Color = System.Drawing.Color.Yellow;
            series29.Legend = "Legend1";
            series29.Name = "red+green";
            series30.ChartArea = "ChartArea1";
            series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series30.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series30.Legend = "Legend1";
            series30.Name = "green+blue";
            series31.ChartArea = "ChartArea1";
            series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series31.Color = System.Drawing.Color.Fuchsia;
            series31.Legend = "Legend1";
            series31.Name = "red+blue";
            series32.ChartArea = "ChartArea1";
            series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series32.Color = System.Drawing.Color.Black;
            series32.Legend = "Legend1";
            series32.Name = "red+green+blue";
            this.chtColHis.Series.Add(series26);
            this.chtColHis.Series.Add(series27);
            this.chtColHis.Series.Add(series28);
            this.chtColHis.Series.Add(series29);
            this.chtColHis.Series.Add(series30);
            this.chtColHis.Series.Add(series31);
            this.chtColHis.Series.Add(series32);
            this.chtColHis.Size = new System.Drawing.Size(327, 171);
            this.chtColHis.TabIndex = 1;
            this.chtColHis.Text = "chart1";
            // 
            // colValPanel
            // 
            this.colValPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.colValPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colValPanel.Controls.Add(this.lbBlueValue);
            this.colValPanel.Controls.Add(this.lblBlue);
            this.colValPanel.Controls.Add(this.tbBlue);
            this.colValPanel.Controls.Add(this.lbGreenValue);
            this.colValPanel.Controls.Add(this.lblGreen);
            this.colValPanel.Controls.Add(this.tbGreen);
            this.colValPanel.Controls.Add(this.lbRedValue);
            this.colValPanel.Controls.Add(this.lblRed);
            this.colValPanel.Controls.Add(this.tbRed);
            this.colValPanel.Controls.Add(this.lblValTitle);
            this.colValPanel.Location = new System.Drawing.Point(476, 375);
            this.colValPanel.Name = "colValPanel";
            this.colValPanel.Size = new System.Drawing.Size(436, 239);
            this.colValPanel.TabIndex = 5;
            // 
            // lbBlueValue
            // 
            this.lbBlueValue.AutoSize = true;
            this.lbBlueValue.Location = new System.Drawing.Point(63, 211);
            this.lbBlueValue.Name = "lbBlueValue";
            this.lbBlueValue.Size = new System.Drawing.Size(67, 13);
            this.lbBlueValue.TabIndex = 9;
            this.lbBlueValue.Text = "Value = 0.11";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBlue.Location = new System.Drawing.Point(21, 179);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(41, 20);
            this.lblBlue.TabIndex = 8;
            this.lblBlue.Text = "Blue";
            // 
            // tbBlue
            // 
            this.tbBlue.Location = new System.Drawing.Point(66, 179);
            this.tbBlue.Maximum = 100;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(367, 45);
            this.tbBlue.TabIndex = 7;
            this.tbBlue.Value = 11;
            this.tbBlue.Scroll += new System.EventHandler(this.tbBlue_Scroll);
            // 
            // lbGreenValue
            // 
            this.lbGreenValue.AutoSize = true;
            this.lbGreenValue.Location = new System.Drawing.Point(63, 142);
            this.lbGreenValue.Name = "lbGreenValue";
            this.lbGreenValue.Size = new System.Drawing.Size(67, 13);
            this.lbGreenValue.TabIndex = 6;
            this.lbGreenValue.Text = "Value = 0.59";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGreen.Location = new System.Drawing.Point(8, 110);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(54, 20);
            this.lblGreen.TabIndex = 5;
            this.lblGreen.Text = "Green";
            // 
            // tbGreen
            // 
            this.tbGreen.Location = new System.Drawing.Point(66, 110);
            this.tbGreen.Maximum = 100;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(367, 45);
            this.tbGreen.TabIndex = 4;
            this.tbGreen.Value = 59;
            this.tbGreen.Scroll += new System.EventHandler(this.tbGreen_Scroll);
            // 
            // lbRedValue
            // 
            this.lbRedValue.AutoSize = true;
            this.lbRedValue.Location = new System.Drawing.Point(63, 82);
            this.lbRedValue.Name = "lbRedValue";
            this.lbRedValue.Size = new System.Drawing.Size(67, 13);
            this.lbRedValue.TabIndex = 3;
            this.lbRedValue.Text = "Value = 0.30";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRed.Location = new System.Drawing.Point(23, 50);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(39, 20);
            this.lblRed.TabIndex = 2;
            this.lblRed.Text = "Red";
            // 
            // tbRed
            // 
            this.tbRed.Location = new System.Drawing.Point(66, 50);
            this.tbRed.Maximum = 100;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(367, 45);
            this.tbRed.TabIndex = 1;
            this.tbRed.Value = 30;
            this.tbRed.Scroll += new System.EventHandler(this.tbRed_Scroll);
            // 
            // lblValTitle
            // 
            this.lblValTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValTitle.AutoSize = true;
            this.lblValTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblValTitle.Location = new System.Drawing.Point(109, 10);
            this.lblValTitle.Name = "lblValTitle";
            this.lblValTitle.Size = new System.Drawing.Size(205, 25);
            this.lblValTitle.TabIndex = 0;
            this.lblValTitle.Text = "Select Color Validity";
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
            this.grayImgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrayImg)).EndInit();
            this.grayHisPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtGrayHis)).EndInit();
            this.colImgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbColImg)).EndInit();
            this.colHisPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtColHis)).EndInit();
            this.colValPanel.ResumeLayout(false);
            this.colValPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
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
        private Emgu.CV.UI.ImageBox pbGrayImg;
        private Emgu.CV.UI.ImageBox pbColImg;
        private System.Windows.Forms.Label lblValTitle;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.TrackBar tbRed;
        private System.Windows.Forms.Label lbRedValue;
        private System.Windows.Forms.Label lbBlueValue;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.TrackBar tbBlue;
        private System.Windows.Forms.Label lbGreenValue;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.TrackBar tbGreen;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtColHis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtGrayHis;
    }
}