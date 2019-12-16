﻿namespace TaskTimer
{
    partial class TaskTimerMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTimerMain));
            this.lblTitleCurrent = new System.Windows.Forms.Label();
            this.cbxTotalTimeSpanSelect = new System.Windows.Forms.ComboBox();
            this.tmrCurrentUpdater = new System.Windows.Forms.Timer(this.components);
            this.btnCreateResults = new System.Windows.Forms.Button();
            this.btnOpenCategoryFile = new System.Windows.Forms.Button();
            this.btnReloadCategories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitleCurrent
            // 
            this.lblTitleCurrent.AutoSize = true;
            this.lblTitleCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCurrent.Location = new System.Drawing.Point(278, 20);
            this.lblTitleCurrent.Name = "lblTitleCurrent";
            this.lblTitleCurrent.Size = new System.Drawing.Size(57, 20);
            this.lblTitleCurrent.TabIndex = 2;
            this.lblTitleCurrent.Text = "Aktuell";
            this.lblTitleCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxTotalTimeSpanSelect
            // 
            this.cbxTotalTimeSpanSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTotalTimeSpanSelect.FormattingEnabled = true;
            this.cbxTotalTimeSpanSelect.Items.AddRange(new object[] {
            "Heute",
            "Gestern",
            "Diese Woche",
            "Letzte Woche",
            "Diesen Monat",
            "Letzten Monat",
            "Gesamt"});
            this.cbxTotalTimeSpanSelect.Location = new System.Drawing.Point(398, 17);
            this.cbxTotalTimeSpanSelect.Name = "cbxTotalTimeSpanSelect";
            this.cbxTotalTimeSpanSelect.Size = new System.Drawing.Size(123, 28);
            this.cbxTotalTimeSpanSelect.TabIndex = 4;
            this.cbxTotalTimeSpanSelect.Text = "Heute";
            this.cbxTotalTimeSpanSelect.SelectedValueChanged += new System.EventHandler(this.cbxTotalTimeSpanSelect_SelectedValueChanged);
            // 
            // tmrCurrentUpdater
            // 
            this.tmrCurrentUpdater.Enabled = true;
            this.tmrCurrentUpdater.Interval = 1000;
            this.tmrCurrentUpdater.Tick += new System.EventHandler(this.tmrCurrentUpdater_Tick);
            // 
            // btnCreateResults
            // 
            this.btnCreateResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateResults.Location = new System.Drawing.Point(334, 50);
            this.btnCreateResults.Name = "btnCreateResults";
            this.btnCreateResults.Size = new System.Drawing.Size(187, 29);
            this.btnCreateResults.TabIndex = 0;
            this.btnCreateResults.Text = "Auswertung generieren";
            this.btnCreateResults.UseVisualStyleBackColor = true;
            // 
            // btnOpenCategoryFile
            // 
            this.btnOpenCategoryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenCategoryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCategoryFile.Location = new System.Drawing.Point(12, 50);
            this.btnOpenCategoryFile.Name = "btnOpenCategoryFile";
            this.btnOpenCategoryFile.Size = new System.Drawing.Size(101, 29);
            this.btnOpenCategoryFile.TabIndex = 0;
            this.btnOpenCategoryFile.Text = "Kat. bearb.";
            this.btnOpenCategoryFile.UseVisualStyleBackColor = true;
            this.btnOpenCategoryFile.Click += new System.EventHandler(this.btnOpenCategoryFile_Click);
            // 
            // btnReloadCategories
            // 
            this.btnReloadCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadCategories.Location = new System.Drawing.Point(119, 50);
            this.btnReloadCategories.Name = "btnReloadCategories";
            this.btnReloadCategories.Size = new System.Drawing.Size(34, 29);
            this.btnReloadCategories.TabIndex = 0;
            this.btnReloadCategories.Text = "↻";
            this.btnReloadCategories.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReloadCategories.UseVisualStyleBackColor = true;
            this.btnReloadCategories.Click += new System.EventHandler(this.btnReloadCategories_Click);
            // 
            // TaskTimerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 91);
            this.Controls.Add(this.cbxTotalTimeSpanSelect);
            this.Controls.Add(this.lblTitleCurrent);
            this.Controls.Add(this.btnReloadCategories);
            this.Controls.Add(this.btnOpenCategoryFile);
            this.Controls.Add(this.btnCreateResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TaskTimerMain";
            this.Text = "TaskTimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskTimerMain_FormClosing);
            this.Load += new System.EventHandler(this.TaskTimerMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitleCurrent;
        private System.Windows.Forms.ComboBox cbxTotalTimeSpanSelect;
        private System.Windows.Forms.Timer tmrCurrentUpdater;
        private System.Windows.Forms.Button btnCreateResults;
        private System.Windows.Forms.Button btnOpenCategoryFile;
        private System.Windows.Forms.Button btnReloadCategories;
    }
}

