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
    public partial class VLXDetailedEval : SfForm
    {
        public WrapSQLite Sql = null;
        public List<VLXCategory> Categories = null;

        public VLXDetailedEval()
        {
            InitializeComponent();

            VLXLib.SetFormStyle(this);
            this.DialogResult = DialogResult.OK;
        }
    }
}
