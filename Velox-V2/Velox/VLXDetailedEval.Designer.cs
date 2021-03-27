
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
            this.sfDateTimeEdit1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.SuspendLayout();
            // 
            // sfDateTimeEdit1
            // 
            this.sfDateTimeEdit1.Location = new System.Drawing.Point(401, 135);
            this.sfDateTimeEdit1.Name = "sfDateTimeEdit1";
            this.sfDateTimeEdit1.Size = new System.Drawing.Size(232, 31);
            this.sfDateTimeEdit1.TabIndex = 0;
            // 
            // VLXDetailedEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sfDateTimeEdit1);
            this.Name = "VLXDetailedEval";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Detailed Evaluation";
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Input.SfDateTimeEdit sfDateTimeEdit1;
    }
}