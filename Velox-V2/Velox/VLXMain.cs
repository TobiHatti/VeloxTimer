using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WrapSQL;

namespace Velox
{
    public partial class VLXMain : SfForm
    {
        private WrapSQLite sql;
        private List<VLXCategory> categories = null;

        public VLXMain()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);

            cbxTotalTimespan.SelectedIndex = 0;
        }

        private void VLXMain_Load(object sender, EventArgs e)
        {
            // Check if VLX-DB exists, if not, attempt to create it
            if (!File.Exists(VLXLib.ConfigFileName))
                if (!VLXLib.CreateDBFile()) throw new VLXException("Could not initialize VLX-Database. Please try again later or contact your system administrator");

            // Load categories and existing timestamps
            categories = VLXLib.LoadVLXData();

            if (categories == null) throw new VLXException("Could not load VLX-Database. Please try again later or contact your system administrator");


            // Create category-controls
            VLXLib.UpdateControls(this, pnlContentPanel, categories);
            
            // Initialize sql
            sql = new WrapSQLite(VLXLib.ConfigFileName);


        }
    }
}
