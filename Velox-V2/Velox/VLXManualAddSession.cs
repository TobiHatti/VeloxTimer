using Syncfusion.Windows.Forms.Tools;
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
using WrapSQL;

namespace Velox
{
    public partial class VLXManualAddSession : SfForm
    {
        public VLXCategory PreselectedCategory = null;
        public List<VLXCategory> Categories = null;
        public WrapSQLite Sql = null;

        private DateTime selectedStartTime, selectedEndTime;

        public VLXManualAddSession()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);

            this.DialogResult = DialogResult.Cancel;

            dtpDate.Value = DateTime.Today;
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now.AddHours(1);
        }

        private void VLXManualAddSession_Load(object sender, EventArgs e)
        {
            cbxCategories.Items.AddRange(Categories.ToArray());

            for (int i = 0; i < cbxCategories.Items.Count; i++)
            {
                if (cbxCategories.Items[i] == PreselectedCategory) cbxCategories.SelectedIndex = i;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            selectedStartTime = new DateTime(
                dtpDate.Value.Value.Year,
                dtpDate.Value.Value.Month,
                dtpDate.Value.Value.Day,
                dtpStartTime.Value.Hour,
                dtpStartTime.Value.Minute,
                dtpStartTime.Value.Second
            );

            selectedEndTime = new DateTime(
                dtpDate.Value.Value.Year,
                dtpDate.Value.Value.Month,
                dtpDate.Value.Value.Day,
                dtpEndTime.Value.Hour,
                dtpEndTime.Value.Minute,
                dtpEndTime.Value.Second
            );

            if(selectedEndTime < selectedStartTime)
            {
                MessageBox.Show("End-Time cannot be before the Start-Time!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (cbxCategories.SelectedItem as VLXCategory).SaveManualSession(Sql, selectedStartTime, selectedEndTime);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
