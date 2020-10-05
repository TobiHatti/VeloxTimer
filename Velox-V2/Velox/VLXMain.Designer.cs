namespace Velox
{
    partial class VLXMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLXMain));
            this.pbxTopShade = new System.Windows.Forms.PictureBox();
            this.cbxTotalTimespan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnDetailedEvaluation = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxTopShade
            // 
            this.pbxTopShade.BackColor = System.Drawing.Color.Linen;
            this.pbxTopShade.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxTopShade.Location = new System.Drawing.Point(0, 0);
            this.pbxTopShade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxTopShade.Name = "pbxTopShade";
            this.pbxTopShade.Size = new System.Drawing.Size(685, 48);
            this.pbxTopShade.TabIndex = 0;
            this.pbxTopShade.TabStop = false;
            // 
            // cbxTotalTimespan
            // 
            this.cbxTotalTimespan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTotalTimespan.FormattingEnabled = true;
            this.cbxTotalTimespan.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This Week",
            "Last Week",
            "This Month ",
            "Last Month",
            "Total",
            "Custom Range"});
            this.cbxTotalTimespan.Location = new System.Drawing.Point(549, 9);
            this.cbxTotalTimespan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxTotalTimespan.Name = "cbxTotalTimespan";
            this.cbxTotalTimespan.Size = new System.Drawing.Size(125, 29);
            this.cbxTotalTimespan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Location = new System.Drawing.Point(480, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total of";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Linen;
            this.label2.Location = new System.Drawing.Point(328, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.Location = new System.Drawing.Point(95, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Category";
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManageCategories.Location = new System.Drawing.Point(12, 205);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(155, 32);
            this.btnManageCategories.TabIndex = 3;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            // 
            // btnDetailedEvaluation
            // 
            this.btnDetailedEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetailedEvaluation.Location = new System.Drawing.Point(173, 205);
            this.btnDetailedEvaluation.Name = "btnDetailedEvaluation";
            this.btnDetailedEvaluation.Size = new System.Drawing.Size(155, 32);
            this.btnDetailedEvaluation.TabIndex = 3;
            this.btnDetailedEvaluation.Text = "Detailed Evaluation";
            this.btnDetailedEvaluation.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Location = new System.Drawing.Point(583, 205);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(90, 32);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(332, 205);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 32);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Bisque;
            this.pictureBox1.Location = new System.Drawing.Point(0, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 3);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlContentPanel
            // 
            this.pnlContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContentPanel.AutoScroll = true;
            this.pnlContentPanel.Location = new System.Drawing.Point(0, 56);
            this.pnlContentPanel.Name = "pnlContentPanel";
            this.pnlContentPanel.Size = new System.Drawing.Size(685, 134);
            this.pnlContentPanel.TabIndex = 6;
            // 
            // VLXMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 249);
            this.Controls.Add(this.pnlContentPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnDetailedEvaluation);
            this.Controls.Add(this.btnManageCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTotalTimespan);
            this.Controls.Add(this.pbxTopShade);
            this.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(32, 32);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "VLXMain";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Style.InactiveShadowOpacity = ((byte)(20));
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Style.ShadowOpacity = ((byte)(30));
            this.Style.TitleBar.BackColor = System.Drawing.Color.Bisque;
            this.Style.TitleBar.BottomBorderColor = System.Drawing.Color.Bisque;
            this.Text = "Velox Timer ";
            this.Load += new System.EventHandler(this.VLXMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTopShade;
        private System.Windows.Forms.ComboBox cbxTotalTimespan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnDetailedEvaluation;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlContentPanel;
    }
}

