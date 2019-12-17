namespace TaskTimer
{
    partial class FullResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullResult));
            this.dgvTimerResult = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbShowDif = new System.Windows.Forms.CheckBox();
            this.chbShowLastPeriods = new System.Windows.Forms.CheckBox();
            this.chbShowDayResults = new System.Windows.Forms.CheckBox();
            this.chbShowWeekResults = new System.Windows.Forms.CheckBox();
            this.chbShowMonthResults = new System.Windows.Forms.CheckBox();
            this.chbShowTotalResults = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimerResult)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimerResult
            // 
            this.dgvTimerResult.AllowUserToAddRows = false;
            this.dgvTimerResult.AllowUserToDeleteRows = false;
            this.dgvTimerResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimerResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimerResult.Location = new System.Drawing.Point(0, 49);
            this.dgvTimerResult.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTimerResult.Name = "dgvTimerResult";
            this.dgvTimerResult.ReadOnly = true;
            this.dgvTimerResult.Size = new System.Drawing.Size(732, 396);
            this.dgvTimerResult.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 471);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chbShowTotalResults);
            this.tabPage1.Controls.Add(this.chbShowMonthResults);
            this.tabPage1.Controls.Add(this.chbShowWeekResults);
            this.tabPage1.Controls.Add(this.chbShowDayResults);
            this.tabPage1.Controls.Add(this.chbShowLastPeriods);
            this.tabPage1.Controls.Add(this.chbShowDif);
            this.tabPage1.Controls.Add(this.dgvTimerResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Übersicht";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbShowDif
            // 
            this.chbShowDif.AutoSize = true;
            this.chbShowDif.Enabled = false;
            this.chbShowDif.Location = new System.Drawing.Point(318, 29);
            this.chbShowDif.Name = "chbShowDif";
            this.chbShowDif.Size = new System.Drawing.Size(126, 17);
            this.chbShowDif.TabIndex = 1;
            this.chbShowDif.Text = "Differenzen anzeigen";
            this.chbShowDif.UseVisualStyleBackColor = true;
            this.chbShowDif.CheckedChanged += new System.EventHandler(this.chbShowDif_CheckedChanged);
            // 
            // chbShowLastPeriods
            // 
            this.chbShowLastPeriods.AutoSize = true;
            this.chbShowLastPeriods.Location = new System.Drawing.Point(318, 6);
            this.chbShowLastPeriods.Name = "chbShowLastPeriods";
            this.chbShowLastPeriods.Size = new System.Drawing.Size(159, 17);
            this.chbShowLastPeriods.TabIndex = 1;
            this.chbShowLastPeriods.Text = "Letztes Zeitfenster anzeigen";
            this.chbShowLastPeriods.UseVisualStyleBackColor = true;
            this.chbShowLastPeriods.CheckedChanged += new System.EventHandler(this.chbShowLastPeriods_CheckedChanged);
            // 
            // chbShowDayResults
            // 
            this.chbShowDayResults.AutoSize = true;
            this.chbShowDayResults.Checked = true;
            this.chbShowDayResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowDayResults.Location = new System.Drawing.Point(6, 6);
            this.chbShowDayResults.Name = "chbShowDayResults";
            this.chbShowDayResults.Size = new System.Drawing.Size(85, 17);
            this.chbShowDayResults.TabIndex = 1;
            this.chbShowDayResults.Text = "Tagesbillanz";
            this.chbShowDayResults.UseVisualStyleBackColor = true;
            this.chbShowDayResults.CheckedChanged += new System.EventHandler(this.chbShowDayResults_CheckedChanged);
            // 
            // chbShowWeekResults
            // 
            this.chbShowWeekResults.AutoSize = true;
            this.chbShowWeekResults.Checked = true;
            this.chbShowWeekResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowWeekResults.Location = new System.Drawing.Point(6, 29);
            this.chbShowWeekResults.Name = "chbShowWeekResults";
            this.chbShowWeekResults.Size = new System.Drawing.Size(96, 17);
            this.chbShowWeekResults.TabIndex = 1;
            this.chbShowWeekResults.Text = "Wochenbillanz";
            this.chbShowWeekResults.UseVisualStyleBackColor = true;
            this.chbShowWeekResults.CheckedChanged += new System.EventHandler(this.chbShowWeekResults_CheckedChanged);
            // 
            // chbShowMonthResults
            // 
            this.chbShowMonthResults.AutoSize = true;
            this.chbShowMonthResults.Checked = true;
            this.chbShowMonthResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowMonthResults.Location = new System.Drawing.Point(139, 6);
            this.chbShowMonthResults.Name = "chbShowMonthResults";
            this.chbShowMonthResults.Size = new System.Drawing.Size(90, 17);
            this.chbShowMonthResults.TabIndex = 1;
            this.chbShowMonthResults.Text = "Monatsbillanz";
            this.chbShowMonthResults.UseVisualStyleBackColor = true;
            this.chbShowMonthResults.CheckedChanged += new System.EventHandler(this.chbShowMonthResults_CheckedChanged);
            // 
            // chbShowTotalResults
            // 
            this.chbShowTotalResults.AutoSize = true;
            this.chbShowTotalResults.Checked = true;
            this.chbShowTotalResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowTotalResults.Location = new System.Drawing.Point(139, 29);
            this.chbShowTotalResults.Name = "chbShowTotalResults";
            this.chbShowTotalResults.Size = new System.Drawing.Size(91, 17);
            this.chbShowTotalResults.TabIndex = 1;
            this.chbShowTotalResults.Text = "Gesamtbillanz";
            this.chbShowTotalResults.UseVisualStyleBackColor = true;
            this.chbShowTotalResults.CheckedChanged += new System.EventHandler(this.chbShowTotalResults_CheckedChanged);
            // 
            // FullResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 495);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullResult";
            this.ShowInTaskbar = false;
            this.Text = "Auswertung";
            this.Load += new System.EventHandler(this.FullResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimerResult)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimerResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chbShowTotalResults;
        private System.Windows.Forms.CheckBox chbShowMonthResults;
        private System.Windows.Forms.CheckBox chbShowWeekResults;
        private System.Windows.Forms.CheckBox chbShowDayResults;
        private System.Windows.Forms.CheckBox chbShowLastPeriods;
        private System.Windows.Forms.CheckBox chbShowDif;
    }
}