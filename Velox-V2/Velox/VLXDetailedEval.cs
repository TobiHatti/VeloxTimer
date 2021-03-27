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
            e.Graphics.ScaleTransform((float)trbScale.Value, 1);
            e.Graphics.TranslateTransform(-trbOffset.Value, 1);

            

            // Get Ticks per Day
            decimal TicksPerDay = DateTime.MinValue.AddDays(1).Ticks - DateTime.MinValue.Ticks;

            decimal TicksPerQuarterHour = TicksPerDay / (24 * 4);

            // Get first timestamp
            long minTSTick = long.MaxValue;
            foreach (VLXCategory category in Categories)
            {
                long tmpMinTick = category.HistoricalFirstTimestamp.StartTime.Ticks;
                if (tmpMinTick < minTSTick)
                    minTSTick = tmpMinTick;
            }

            decimal minTS = (minTSTick / TicksPerQuarterHour);


            for (int i = 0; i < 1000; i++)
            {
                DateTime displayTime = new DateTime(minTSTick);
                // Full Hours:
                if (i % 4 == 0)
                {
                    e.Graphics.DrawLine(Pens.Black, i, 0, i, pbxTimeline.Height);
                }
                // Quarter Hours
                else e.Graphics.DrawLine(Pens.Gray, i, 0, i, pbxTimeline.Height);
            }

            int rowOffset = 0;
            // Cycle through all timestamps
            foreach (VLXCategory category in Categories)
            {
                foreach (VLXTimestamp ts in category.Timestamps)
                {
                    decimal from = (ts.StartTime.Ticks / TicksPerQuarterHour);
                    decimal to = (ts.EndTime.Ticks / TicksPerQuarterHour);

                    decimal fromRef = from - minTS;
                    decimal toRef = to - minTS;

                    RectangleF rect = new RectangleF(
                          (float)fromRef,
                          rowOffset,
                          (float)(toRef - fromRef),
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

        private void trbScale_Scroll(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }

        private void trbOffset_Scroll(object sender, EventArgs e)
        {
            pbxTimeline.Invalidate();
        }
    }
}
