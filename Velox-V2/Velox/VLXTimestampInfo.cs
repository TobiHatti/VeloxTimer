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
    public partial class VLXTimestampInfo : SfForm
    {
        public VLXCategory Category;
        public VLXTimestamp Timestamp;
        public WrapSQLite Sql;

        public VLXTimestampInfo()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VLXTimestampInfo_Load(object sender, EventArgs e)
        {
            lblCategoryName.Text = Category.Name;
            lblStartTime.Text = Timestamp.StartTime.ToLongDateString() + ", " + Timestamp.StartTime.ToShortTimeString();
            lblEndTime.Text = Timestamp.EndTime.ToLongDateString() + ", " + Timestamp.EndTime.ToShortTimeString();
            lblTimespan.Text = (Timestamp.EndTime - Timestamp.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void btnDeleteTS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the selected record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Timestamp.Delete(Sql);
                Category.Timestamps.Remove(Timestamp);

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
