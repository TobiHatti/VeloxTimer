namespace Velox
{
    partial class VLXCategoryManager
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
            this.lbxCategories = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSafeChanges = new System.Windows.Forms.Button();
            this.colCategoryColor = new Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv();
            this.lblCurrentColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxCategories
            // 
            this.lbxCategories.FormattingEnabled = true;
            this.lbxCategories.ItemHeight = 21;
            this.lbxCategories.Location = new System.Drawing.Point(5, 31);
            this.lbxCategories.Name = "lbxCategories";
            this.lbxCategories.Size = new System.Drawing.Size(248, 235);
            this.lbxCategories.TabIndex = 7;
            this.lbxCategories.Click += new System.EventHandler(this.lbxCategories_Click);
            this.lbxCategories.SelectedIndexChanged += new System.EventHandler(this.lbxCategories_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI Semilight", 14F);
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Category Manager";
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Enabled = false;
            this.txbName.Location = new System.Drawing.Point(259, 55);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(234, 29);
            this.txbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // txbDescription
            // 
            this.txbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescription.Enabled = false;
            this.txbDescription.Location = new System.Drawing.Point(259, 121);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(234, 109);
            this.txbDescription.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Description";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(546, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 31);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(5, 279);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 31);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(80, 279);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 31);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSafeChanges
            // 
            this.btnSafeChanges.Location = new System.Drawing.Point(259, 235);
            this.btnSafeChanges.Name = "btnSafeChanges";
            this.btnSafeChanges.Size = new System.Drawing.Size(145, 31);
            this.btnSafeChanges.TabIndex = 5;
            this.btnSafeChanges.Text = "Save Changes";
            this.btnSafeChanges.UseVisualStyleBackColor = true;
            this.btnSafeChanges.Click += new System.EventHandler(this.btnSafeChanges_Click);
            // 
            // colCategoryColor.RecentGroup
            // 
            this.colCategoryColor.RecentGroup.Name = "Recent Colors";
            this.colCategoryColor.RecentGroup.Visible = false;
            // 
            // colCategoryColor.StandardGroup
            // 
            this.colCategoryColor.StandardGroup.Name = "Standard Colors";
            // 
            // colCategoryColor.ThemeGroup
            // 
            this.colCategoryColor.ThemeGroup.IsSubItemsVisible = true;
            this.colCategoryColor.ThemeGroup.Name = "Theme Colors";
            // 
            // colCategoryColor
            // 
            this.colCategoryColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colCategoryColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colCategoryColor.Enabled = false;
            this.colCategoryColor.HorizontalItemsSpacing = 1;
            this.colCategoryColor.Location = new System.Drawing.Point(499, 31);
            this.colCategoryColor.Name = "colCategoryColor";
            this.colCategoryColor.Size = new System.Drawing.Size(145, 199);
            this.colCategoryColor.Style = Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv.visualstyle.Metro;
            this.colCategoryColor.TabIndex = 19;
            this.colCategoryColor.Text = "colorPickerUIAdv1";
            this.colCategoryColor.ThemeName = "Metro";
            this.colCategoryColor.VerticalItemsSpacing = 1;
            this.colCategoryColor.Picked += new Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv.ColorPickedEventHandler(this.colCategoryColor_Picked);
            // 
            // lblCurrentColor
            // 
            this.lblCurrentColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentColor.BackColor = System.Drawing.Color.LightSalmon;
            this.lblCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentColor.Enabled = false;
            this.lblCurrentColor.Location = new System.Drawing.Point(499, 2);
            this.lblCurrentColor.Name = "lblCurrentColor";
            this.lblCurrentColor.Size = new System.Drawing.Size(145, 25);
            this.lblCurrentColor.TabIndex = 20;
            this.lblCurrentColor.Text = "Current Color";
            this.lblCurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VLXCategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 315);
            this.Controls.Add(this.lblCurrentColor);
            this.Controls.Add(this.colCategoryColor);
            this.Controls.Add(this.btnSafeChanges);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxCategories);
            this.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VLXCategoryManager";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Manage Categories";
            this.Load += new System.EventHandler(this.VLXCategoryManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSafeChanges;
        private Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv colCategoryColor;
        private System.Windows.Forms.Label lblCurrentColor;
    }
}