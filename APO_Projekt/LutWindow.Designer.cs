
namespace APO_Projekt
{
    partial class LutWindow
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.LutList = new System.Windows.Forms.ListView();
            this.Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Red = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Green = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Blue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureWindowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LutList
            // 
            this.LutList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LutList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Level,
            this.Red,
            this.Green,
            this.Blue});
            this.LutList.FullRowSelect = true;
            this.LutList.GridLines = true;
            this.LutList.HideSelection = false;
            this.LutList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.LutList.Location = new System.Drawing.Point(12, 12);
            this.LutList.Name = "LutList";
            this.LutList.Size = new System.Drawing.Size(258, 453);
            this.LutList.TabIndex = 0;
            this.LutList.UseCompatibleStateImageBehavior = false;
            this.LutList.View = System.Windows.Forms.View.Details;
            // 
            // Level
            // 
            this.Level.Text = "Level";
            this.Level.Width = 50;
            // 
            // Red
            // 
            this.Red.Text = "Red";
            // 
            // Green
            // 
            this.Green.Text = "Green";
            // 
            // Blue
            // 
            this.Blue.Text = "Blue";
            // 
            // pictureWindowBindingSource
            // 
            this.pictureWindowBindingSource.DataSource = typeof(APO_Projekt.PictureWindow);
            // 
            // LutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 477);
            this.Controls.Add(this.LutList);
            this.Name = "LutWindow";
            this.Text = "LutWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LutWindow_FormClosed);
            this.Load += new System.EventHandler(this.LutWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureWindowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource pictureWindowBindingSource;
        private System.Windows.Forms.ListView LutList;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ColumnHeader Red;
        private System.Windows.Forms.ColumnHeader Green;
        private System.Windows.Forms.ColumnHeader Blue;
    }
}