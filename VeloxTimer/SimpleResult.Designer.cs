namespace TaskTimer
{
    partial class SimpleResult
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
            this.btnCloseDialog = new System.Windows.Forms.Button();
            this.btnCreateLogFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCumulatedToday = new System.Windows.Forms.Label();
            this.lblCumulatedThisWeek = new System.Windows.Forms.Label();
            this.lblCumulatedLastMonth = new System.Windows.Forms.Label();
            this.lblCumulatedTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCumulatedLastWeek = new System.Windows.Forms.Label();
            this.lblCumulatedThisMonth = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDifDay = new System.Windows.Forms.Label();
            this.lblDifWeek = new System.Windows.Forms.Label();
            this.lblCumulatedYesterday = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDifMonth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseDialog.Location = new System.Drawing.Point(236, 248);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(97, 28);
            this.btnCloseDialog.TabIndex = 0;
            this.btnCloseDialog.Text = "Schließen";
            this.btnCloseDialog.UseVisualStyleBackColor = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // btnCreateLogFile
            // 
            this.btnCreateLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLogFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateLogFile.Location = new System.Drawing.Point(12, 248);
            this.btnCreateLogFile.Name = "btnCreateLogFile";
            this.btnCreateLogFile.Size = new System.Drawing.Size(200, 28);
            this.btnCreateLogFile.TabIndex = 0;
            this.btnCreateLogFile.Text = "Auswertung Exportieren";
            this.btnCreateLogFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Heute:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultTitle.Location = new System.Drawing.Point(0, 9);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(345, 23);
            this.lblResultTitle.TabIndex = 1;
            this.lblResultTitle.Text = "Auswertung für Kategorie \"Sample\"";
            this.lblResultTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Diese Woche:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Letzten Monat:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Gesamt:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCumulatedToday
            // 
            this.lblCumulatedToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedToday.Location = new System.Drawing.Point(139, 66);
            this.lblCumulatedToday.Name = "lblCumulatedToday";
            this.lblCumulatedToday.Size = new System.Drawing.Size(99, 23);
            this.lblCumulatedToday.TabIndex = 1;
            this.lblCumulatedToday.Text = "00:00:00";
            this.lblCumulatedToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCumulatedThisWeek
            // 
            this.lblCumulatedThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedThisWeek.Location = new System.Drawing.Point(139, 113);
            this.lblCumulatedThisWeek.Name = "lblCumulatedThisWeek";
            this.lblCumulatedThisWeek.Size = new System.Drawing.Size(99, 23);
            this.lblCumulatedThisWeek.TabIndex = 1;
            this.lblCumulatedThisWeek.Text = "00:00:00";
            this.lblCumulatedThisWeek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCumulatedLastMonth
            // 
            this.lblCumulatedLastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedLastMonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCumulatedLastMonth.Location = new System.Drawing.Point(139, 183);
            this.lblCumulatedLastMonth.Name = "lblCumulatedLastMonth";
            this.lblCumulatedLastMonth.Size = new System.Drawing.Size(99, 16);
            this.lblCumulatedLastMonth.TabIndex = 1;
            this.lblCumulatedLastMonth.Text = "00:00:00";
            this.lblCumulatedLastMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCumulatedTotal
            // 
            this.lblCumulatedTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedTotal.Location = new System.Drawing.Point(138, 210);
            this.lblCumulatedTotal.Name = "lblCumulatedTotal";
            this.lblCumulatedTotal.Size = new System.Drawing.Size(99, 23);
            this.lblCumulatedTotal.TabIndex = 1;
            this.lblCumulatedTotal.Text = "00:00:00";
            this.lblCumulatedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Letzte Woche:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Diesen Monat:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCumulatedLastWeek
            // 
            this.lblCumulatedLastWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedLastWeek.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCumulatedLastWeek.Location = new System.Drawing.Point(139, 136);
            this.lblCumulatedLastWeek.Name = "lblCumulatedLastWeek";
            this.lblCumulatedLastWeek.Size = new System.Drawing.Size(99, 16);
            this.lblCumulatedLastWeek.TabIndex = 1;
            this.lblCumulatedLastWeek.Text = "00:00:00";
            this.lblCumulatedLastWeek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCumulatedThisMonth
            // 
            this.lblCumulatedThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedThisMonth.Location = new System.Drawing.Point(139, 160);
            this.lblCumulatedThisMonth.Name = "lblCumulatedThisMonth";
            this.lblCumulatedThisMonth.Size = new System.Drawing.Size(99, 23);
            this.lblCumulatedThisMonth.TabIndex = 1;
            this.lblCumulatedThisMonth.Text = "00:00:00";
            this.lblCumulatedThisMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(212, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Differenz:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifDay
            // 
            this.lblDifDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifDay.Location = new System.Drawing.Point(234, 66);
            this.lblDifDay.Name = "lblDifDay";
            this.lblDifDay.Size = new System.Drawing.Size(99, 23);
            this.lblDifDay.TabIndex = 1;
            this.lblDifDay.Text = "00:00:00";
            this.lblDifDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifWeek
            // 
            this.lblDifWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifWeek.Location = new System.Drawing.Point(234, 113);
            this.lblDifWeek.Name = "lblDifWeek";
            this.lblDifWeek.Size = new System.Drawing.Size(99, 23);
            this.lblDifWeek.TabIndex = 1;
            this.lblDifWeek.Text = "00:00:00";
            this.lblDifWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCumulatedYesterday
            // 
            this.lblCumulatedYesterday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumulatedYesterday.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCumulatedYesterday.Location = new System.Drawing.Point(140, 89);
            this.lblCumulatedYesterday.Name = "lblCumulatedYesterday";
            this.lblCumulatedYesterday.Size = new System.Drawing.Size(99, 16);
            this.lblCumulatedYesterday.TabIndex = 1;
            this.lblCumulatedYesterday.Text = "00:00:00";
            this.lblCumulatedYesterday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(12, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Gestern:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifMonth
            // 
            this.lblDifMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifMonth.Location = new System.Drawing.Point(234, 160);
            this.lblDifMonth.Name = "lblDifMonth";
            this.lblDifMonth.Size = new System.Drawing.Size(99, 23);
            this.lblDifMonth.TabIndex = 1;
            this.lblDifMonth.Text = "00:00:00";
            this.lblDifMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SimpleResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 288);
            this.Controls.Add(this.lblResultTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCumulatedTotal);
            this.Controls.Add(this.lblCumulatedThisMonth);
            this.Controls.Add(this.lblCumulatedLastWeek);
            this.Controls.Add(this.lblCumulatedLastMonth);
            this.Controls.Add(this.lblDifMonth);
            this.Controls.Add(this.lblDifWeek);
            this.Controls.Add(this.lblDifDay);
            this.Controls.Add(this.lblCumulatedThisWeek);
            this.Controls.Add(this.lblCumulatedYesterday);
            this.Controls.Add(this.lblCumulatedToday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateLogFile);
            this.Controls.Add(this.btnCloseDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auswertung";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCloseDialog;
        private System.Windows.Forms.Button btnCreateLogFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCumulatedToday;
        private System.Windows.Forms.Label lblCumulatedThisWeek;
        private System.Windows.Forms.Label lblCumulatedLastMonth;
        private System.Windows.Forms.Label lblCumulatedTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCumulatedLastWeek;
        private System.Windows.Forms.Label lblCumulatedThisMonth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDifDay;
        private System.Windows.Forms.Label lblDifWeek;
        private System.Windows.Forms.Label lblCumulatedYesterday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDifMonth;
    }
}