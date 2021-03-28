
namespace Velox
{
    partial class VLXImporter
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
            this.ofdVeloxImport = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ofdVeloxImport
            // 
            this.ofdVeloxImport.FileName = "VeloxConfig.vlx";
            this.ofdVeloxImport.Filter = "Velox Config-Files|*.vlx|All Files|*.*";
            this.ofdVeloxImport.Title = "Import Velox Config";
            // 
            // VLXImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 116);
            this.Name = "VLXImporter";
            this.Text = "VLXImporter";
            this.Load += new System.EventHandler(this.VLXImporter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdVeloxImport;
    }
}