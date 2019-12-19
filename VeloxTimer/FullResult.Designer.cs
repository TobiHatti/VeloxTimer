namespace VeloxTimer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullResult));
            this.dgvTimerResult = new System.Windows.Forms.DataGridView();
            this.tabControll = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExportOverview = new System.Windows.Forms.Button();
            this.chbShowTotalResults = new System.Windows.Forms.CheckBox();
            this.chbShowMonthResults = new System.Windows.Forms.CheckBox();
            this.chbShowWeekResults = new System.Windows.Forms.CheckBox();
            this.chbShowDayResults = new System.Windows.Forms.CheckBox();
            this.chbShowLastPeriods = new System.Windows.Forms.CheckBox();
            this.chbShowDif = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportDetail = new System.Windows.Forms.Button();
            this.dgvResultDetail = new System.Windows.Forms.DataGridView();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.sfdSaveExport = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimerResult)).BeginInit();
            this.tabControll.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimerResult
            // 
            this.dgvTimerResult.AllowUserToAddRows = false;
            this.dgvTimerResult.AllowUserToDeleteRows = false;
            this.dgvTimerResult.AllowUserToOrderColumns = true;
            this.dgvTimerResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTimerResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimerResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimerResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimerResult.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTimerResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTimerResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTimerResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimerResult.GridColor = System.Drawing.Color.Black;
            this.dgvTimerResult.Location = new System.Drawing.Point(3, 56);
            this.dgvTimerResult.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTimerResult.Name = "dgvTimerResult";
            this.dgvTimerResult.ReadOnly = true;
            this.dgvTimerResult.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.dgvTimerResult.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimerResult.ShowCellErrors = false;
            this.dgvTimerResult.ShowCellToolTips = false;
            this.dgvTimerResult.ShowEditingIcon = false;
            this.dgvTimerResult.ShowRowErrors = false;
            this.dgvTimerResult.Size = new System.Drawing.Size(726, 197);
            this.dgvTimerResult.TabIndex = 0;
            // 
            // tabControll
            // 
            this.tabControll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControll.Controls.Add(this.tabPage1);
            this.tabControll.Controls.Add(this.tabPage2);
            this.tabControll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControll.Location = new System.Drawing.Point(12, 12);
            this.tabControll.Name = "tabControll";
            this.tabControll.SelectedIndex = 0;
            this.tabControll.Size = new System.Drawing.Size(740, 289);
            this.tabControll.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExportOverview);
            this.tabPage1.Controls.Add(this.chbShowTotalResults);
            this.tabPage1.Controls.Add(this.chbShowMonthResults);
            this.tabPage1.Controls.Add(this.chbShowWeekResults);
            this.tabPage1.Controls.Add(this.chbShowDayResults);
            this.tabPage1.Controls.Add(this.chbShowLastPeriods);
            this.tabPage1.Controls.Add(this.chbShowDif);
            this.tabPage1.Controls.Add(this.dgvTimerResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 256);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Übersicht";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExportOverview
            // 
            this.btnExportOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportOverview.Location = new System.Drawing.Point(621, 6);
            this.btnExportOverview.Name = "btnExportOverview";
            this.btnExportOverview.Size = new System.Drawing.Size(108, 29);
            this.btnExportOverview.TabIndex = 2;
            this.btnExportOverview.Text = "Exportieren";
            this.btnExportOverview.UseVisualStyleBackColor = true;
            this.btnExportOverview.Click += new System.EventHandler(this.btnExportOverview_Click);
            // 
            // chbShowTotalResults
            // 
            this.chbShowTotalResults.AutoSize = true;
            this.chbShowTotalResults.Checked = true;
            this.chbShowTotalResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowTotalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowTotalResults.Location = new System.Drawing.Point(139, 29);
            this.chbShowTotalResults.Name = "chbShowTotalResults";
            this.chbShowTotalResults.Size = new System.Drawing.Size(129, 24);
            this.chbShowTotalResults.TabIndex = 1;
            this.chbShowTotalResults.Text = "Gesamtbillanz";
            this.chbShowTotalResults.UseVisualStyleBackColor = true;
            this.chbShowTotalResults.CheckedChanged += new System.EventHandler(this.chbShowTotalResults_CheckedChanged);
            // 
            // chbShowMonthResults
            // 
            this.chbShowMonthResults.AutoSize = true;
            this.chbShowMonthResults.Checked = true;
            this.chbShowMonthResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowMonthResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowMonthResults.Location = new System.Drawing.Point(139, 6);
            this.chbShowMonthResults.Name = "chbShowMonthResults";
            this.chbShowMonthResults.Size = new System.Drawing.Size(125, 24);
            this.chbShowMonthResults.TabIndex = 1;
            this.chbShowMonthResults.Text = "Monatsbillanz";
            this.chbShowMonthResults.UseVisualStyleBackColor = true;
            this.chbShowMonthResults.CheckedChanged += new System.EventHandler(this.chbShowMonthResults_CheckedChanged);
            // 
            // chbShowWeekResults
            // 
            this.chbShowWeekResults.AutoSize = true;
            this.chbShowWeekResults.Checked = true;
            this.chbShowWeekResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowWeekResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowWeekResults.Location = new System.Drawing.Point(6, 29);
            this.chbShowWeekResults.Name = "chbShowWeekResults";
            this.chbShowWeekResults.Size = new System.Drawing.Size(131, 24);
            this.chbShowWeekResults.TabIndex = 1;
            this.chbShowWeekResults.Text = "Wochenbillanz";
            this.chbShowWeekResults.UseVisualStyleBackColor = true;
            this.chbShowWeekResults.CheckedChanged += new System.EventHandler(this.chbShowWeekResults_CheckedChanged);
            // 
            // chbShowDayResults
            // 
            this.chbShowDayResults.AutoSize = true;
            this.chbShowDayResults.Checked = true;
            this.chbShowDayResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowDayResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowDayResults.Location = new System.Drawing.Point(6, 6);
            this.chbShowDayResults.Name = "chbShowDayResults";
            this.chbShowDayResults.Size = new System.Drawing.Size(116, 24);
            this.chbShowDayResults.TabIndex = 1;
            this.chbShowDayResults.Text = "Tagesbillanz";
            this.chbShowDayResults.UseVisualStyleBackColor = true;
            this.chbShowDayResults.CheckedChanged += new System.EventHandler(this.chbShowDayResults_CheckedChanged);
            // 
            // chbShowLastPeriods
            // 
            this.chbShowLastPeriods.AutoSize = true;
            this.chbShowLastPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowLastPeriods.Location = new System.Drawing.Point(283, 6);
            this.chbShowLastPeriods.Name = "chbShowLastPeriods";
            this.chbShowLastPeriods.Size = new System.Drawing.Size(231, 24);
            this.chbShowLastPeriods.TabIndex = 1;
            this.chbShowLastPeriods.Text = "Letztes Zeitfenster anzeigen";
            this.chbShowLastPeriods.UseVisualStyleBackColor = true;
            this.chbShowLastPeriods.CheckedChanged += new System.EventHandler(this.chbShowLastPeriods_CheckedChanged);
            // 
            // chbShowDif
            // 
            this.chbShowDif.AutoSize = true;
            this.chbShowDif.Enabled = false;
            this.chbShowDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowDif.Location = new System.Drawing.Point(283, 29);
            this.chbShowDif.Name = "chbShowDif";
            this.chbShowDif.Size = new System.Drawing.Size(180, 24);
            this.chbShowDif.TabIndex = 1;
            this.chbShowDif.Text = "Differenzen anzeigen";
            this.chbShowDif.UseVisualStyleBackColor = true;
            this.chbShowDif.CheckedChanged += new System.EventHandler(this.chbShowDif_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportDetail);
            this.tabPage2.Controls.Add(this.dgvResultDetail);
            this.tabPage2.Controls.Add(this.cbxCategories);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 256);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detailansicht";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportDetail
            // 
            this.btnExportDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportDetail.Location = new System.Drawing.Point(621, 6);
            this.btnExportDetail.Name = "btnExportDetail";
            this.btnExportDetail.Size = new System.Drawing.Size(108, 29);
            this.btnExportDetail.TabIndex = 3;
            this.btnExportDetail.Text = "Exportieren";
            this.btnExportDetail.UseVisualStyleBackColor = true;
            this.btnExportDetail.Click += new System.EventHandler(this.btnExportDetail_Click);
            // 
            // dgvResultDetail
            // 
            this.dgvResultDetail.AllowUserToAddRows = false;
            this.dgvResultDetail.AllowUserToDeleteRows = false;
            this.dgvResultDetail.AllowUserToOrderColumns = true;
            this.dgvResultDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvResultDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResultDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResultDetail.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvResultDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResultDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultDetail.GridColor = System.Drawing.Color.Black;
            this.dgvResultDetail.Location = new System.Drawing.Point(3, 37);
            this.dgvResultDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dgvResultDetail.Name = "dgvResultDetail";
            this.dgvResultDetail.ReadOnly = true;
            this.dgvResultDetail.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.dgvResultDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResultDetail.ShowCellErrors = false;
            this.dgvResultDetail.ShowCellToolTips = false;
            this.dgvResultDetail.ShowEditingIcon = false;
            this.dgvResultDetail.ShowRowErrors = false;
            this.dgvResultDetail.Size = new System.Drawing.Size(726, 216);
            this.dgvResultDetail.TabIndex = 1;
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(6, 6);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(609, 28);
            this.cbxCategories.TabIndex = 0;
            this.cbxCategories.SelectedIndexChanged += new System.EventHandler(this.cbxCategories_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(644, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // sfdSaveExport
            // 
            this.sfdSaveExport.Filter = "CSV-Dateien|*.csv|Alle Dateien|*.*";
            // 
            // FullResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 347);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullResult";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auswertung";
            this.Load += new System.EventHandler(this.FullResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimerResult)).EndInit();
            this.tabControll.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimerResult;
        private System.Windows.Forms.TabControl tabControll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chbShowTotalResults;
        private System.Windows.Forms.CheckBox chbShowMonthResults;
        private System.Windows.Forms.CheckBox chbShowWeekResults;
        private System.Windows.Forms.CheckBox chbShowDayResults;
        private System.Windows.Forms.CheckBox chbShowLastPeriods;
        private System.Windows.Forms.CheckBox chbShowDif;
        private System.Windows.Forms.Button btnExportOverview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.DataGridView dgvResultDetail;
        private System.Windows.Forms.Button btnExportDetail;
        private System.Windows.Forms.SaveFileDialog sfdSaveExport;
    }
}