using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Velox
{
    public partial class VLXMain : SfForm
    {
        public VLXMain()
        {
            InitializeComponent();
            this.Style.Border = new Pen(Color.FromKnownColor(KnownColor.Bisque),2);
            this.Style.InactiveBorder = new Pen(Color.FromKnownColor(KnownColor.Linen),2);
        }
    }
}
