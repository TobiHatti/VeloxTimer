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

        public VLXMain()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);
            MessageBox.Show($"{VLXDB.Category.Self}");
        }

        private void VLXMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(VLXLib.ConfigFileName))
                if (!VLXLib.CreateDBFile()) throw new VLXException("Could not initialize VLX-Database. Please try again later or contact your system administrator");

            sql = new WrapSQLite(VLXLib.ConfigFileName);

            
        }
    }
}
