
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
            this.pnlTimeLine = new System.Windows.Forms.Panel();
            this.trbPanelScale = new Syncfusion.Windows.Forms.Tools.TrackBarEx(10, 40);
            this.SuspendLayout();
            // 
            // pnlTimeLine
            // 
            this.pnlTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimeLine.AutoScroll = true;
            this.pnlTimeLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeLine.Location = new System.Drawing.Point(196, 5);
            this.pnlTimeLine.Name = "pnlTimeLine";
            this.pnlTimeLine.Size = new System.Drawing.Size(849, 594);
            this.pnlTimeLine.TabIndex = 4;
            // 
            // trbPanelScale
            // 
            this.trbPanelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPanelScale.BackColor = System.Drawing.Color.White;
            this.trbPanelScale.BeforeTouchSize = new System.Drawing.Size(297, 20);
            this.trbPanelScale.Location = new System.Drawing.Point(748, 605);
            this.trbPanelScale.Name = "trbPanelScale";
            this.trbPanelScale.Size = new System.Drawing.Size(297, 20);
            this.trbPanelScale.SmallChange = 5;
            this.trbPanelScale.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.trbPanelScale.TabIndex = 5;
            this.trbPanelScale.Text = "trackBarEx1";
            this.trbPanelScale.ThemeName = "Metro";
            this.trbPanelScale.TimerInterval = 5;
            this.trbPanelScale.Value = 10;
            this.trbPanelScale.Scroll += new System.EventHandler(this.trbPanelScale_Scroll);
            // 
            // VLXDetailedEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 630);
            this.Controls.Add(this.trbPanelScale);
            this.Controls.Add(this.pnlTimeLine);
            this.Font = new System.Drawing.Font("Leelawadee UI Semilight", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VLXDetailedEval";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Detailed Evaluation";
            this.Load += new System.EventHandler(this.VLXDetailedEval_Load);
            this.ResizeEnd += new System.EventHandler(this.VLXDetailedEval_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTimeLine;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx trbPanelScale;
    }
}