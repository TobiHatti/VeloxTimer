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

        }

        private void VLXMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(VLXLib.ConfigFileName))
                if (!VLXLib.CreateDBFile()) VLXLib.ManagedException("*** Could not  ***");

            sql = new WrapSQLite(VLXLib.ConfigFileName);

            
        }
    }
}
