
namespace Velox
{
    partial class VLXTimestampInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimespan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnDeleteTS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(205, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recorded Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(23, 81);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(106, 21);
            this.lblStartTime.TabIndex = 3;
            this.lblStartTime.Text = "-- StartTime --";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(23, 123);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(101, 21);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "-- EndTime --";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "End:";
            // 
            // lblTimespan
            // 
            this.lblTimespan.AutoSize = true;
            this.lblTimespan.Location = new System.Drawing.Point(23, 174);
            this.lblTimespan.Name = "lblTimespan";
            this.lblTimespan.Size = new System.Drawing.Size(108, 21);
            this.lblTimespan.TabIndex = 7;
            this.lblTimespan.Text = "-- Timespan --";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Timespan:";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.Location = new System.Drawing.Point(3, 12);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(163, 21);
            this.lblCategoryName.TabIndex = 8;
            this.lblCategoryName.Text = "-- CategoryName --";
            // 
            // btnDeleteTS
            // 
            this.btnDeleteTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTS.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteTS.Location = new System.Drawing.Point(5, 203);
            this.btnDeleteTS.Name = "btnDeleteTS";
            this.btnDeleteTS.Size = new System.Drawing.Size(74, 33);
            this.btnDeleteTS.TabIndex = 9;
            this.btnDeleteTS.Text = "Delete";
            this.btnDeleteTS.UseVisualStyleBackColor = true;
            this.btnDeleteTS.Click += new System.EventHandler(this.btnDeleteTS_Click);
            // 
            // VLXTimestampInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.btnDeleteTS);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.lblTimespan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VLXTimestampInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Timestamp Info";
            this.Load += new System.EventHandler(this.VLXTimestampInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimespan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Button btnDeleteTS;
    }
}