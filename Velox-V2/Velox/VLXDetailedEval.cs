using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            pbxTimeline.Invalidate();
        }

        private void pbxTimeline_Paint(object sender, PaintEventArgs e)
        {
            long minTSTick = long.MaxValue;
            long maxTSTick = int.MinValue;

            e.Graphics.ScaleTransform(1/(float)trView.Value, 1);
            e.Graphics.TranslateTransform(trbOffset.Value, 1);

            foreach (VLXCategory category in Categories)
            {
                long tmpMinTick = category.HistoricalFirstTimestamp.StartTime.Ticks;
                long tmpMaxTick = category.HistoricalLastTimestamp.EndTime.Ticks;

                if (tmpMinTick < minTSTick)
                    minTSTick = tmpMinTick;

                if (tmpMaxTick > maxTSTick)
                    maxTSTick = tmpMaxTick;
            }

            Debug.WriteLine("Min-Tick: " + new DateTime(minTSTick).ToString());
            Debug.WriteLine("Max-Tick: " + new DateTime(maxTSTick).ToString());

            int rowOffset = 1;
            foreach (VLXCategory category in Categories)
            {
                foreach(VLXTimestamp ts in category.Timestamps)
                {
                    float from = (ts.StartTime.Ticks - minTSTick) / 1000000000;
                    float to = (ts.EndTime.Ticks - minTSTick) / 1000000000;

                    RectangleF rect = new RectangleF(
                          from,
                          rowOffset,
                          to - from,
                          15
                    );

                    e.Graphics.FillRectangle(Brushes.Red, rect);
                }

                rowOffset += 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }

        private void trScale_Scroll(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }

        private void trView_Scroll(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }

        private void trbOffset_Scroll(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }
    }
}
