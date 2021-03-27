
namespace Velox
{
    partial class VLXDetailedEval
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
            this.pbxTimeline = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trbScale = new System.Windows.Forms.TrackBar();
            this.trbOffset = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTimeline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxTimeline
            // 
            this.pbxTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxTimeline.Location = new System.Drawing.Point(173, 6);
            this.pbxTimeline.Name = "pbxTimeline";
            this.pbxTimeline.Size = new System.Drawing.Size(871, 618);
            this.pbxTimeline.TabIndex = 0;
            this.pbxTimeline.TabStop = false;
            this.pbxTimeline.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxTimeline_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trbScale
            // 
            this.trbScale.Location = new System.Drawing.Point(6, 55);
            this.trbScale.Maximum = 50;
            this.trbScale.Minimum = 1;
            this.trbScale.Name = "trbScale";
            this.trbScale.Size = new System.Drawing.Size(161, 45);
            this.trbScale.TabIndex = 2;
            this.trbScale.Value = 25;
            this.trbScale.Scroll += new System.EventHandler(this.trbScale_Scroll);
            // 
            // trbOffset
            // 
            this.trbOffset.Location = new System.Drawing.Point(6, 106);
            this.trbOffset.Maximum = 500;
            this.trbOffset.Name = "trbOffset";
            this.trbOffset.Size = new System.Drawing.Size(161, 45);
            this.trbOffset.TabIndex = 3;
            this.trbOffset.Value = 1;
            this.trbOffset.Scroll += new System.EventHandler(this.trbOffset_Scroll);
            // 
            // VLXDetailedEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 630);
            this.Controls.Add(this.trbOffset);
            this.Controls.Add(this.trbScale);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbxTimeline);
            this.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VLXDetailedEval";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Detailed Evaluation";
            ((System.ComponentModel.ISupportInitialize)(this.pbxTimeline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTimeline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trbScale;
        private System.Windows.Forms.TrackBar trbOffset;
    }
}