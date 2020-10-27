using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Velox
{
    public partial class VLXDateRangePicker : SfForm
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public VLXDateRangePicker()
        {
            InitializeComponent();

            VLXLib.SetFormStyle(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(dtpStartTime.Value < dtpEndTime.Value)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("End-Date cannot be after the Start-Date!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void VLXDateRangePicker_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = StartDate;
            dtpEndTime.Value = EndDate;
        }
    }
}
