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
        private TimelineScale scale = TimelineScale.Hours;

        public VLXDetailedEval()
        {
            InitializeComponent();

            VLXLib.SetFormStyle(this);
            this.DialogResult = DialogResult.OK;
        }

        private void VLXDetailedEval_Load(object sender, EventArgs e)
        {
            CreateTimeline();
        }

        private enum TimelineScale
        {
            Months,
            Days,
            Hours,
            SixHours
        }

        private void CreateTimeline()
        {
            // Remove all components from the panel
            pnlTimeLine.Controls.Clear();

            decimal sizeScale = (decimal)Math.Pow(trbPanelScale.Value, 2);

            // Get Timescales
            // Timescale / 1 Day
            decimal TimescaleDay = TimeSpan.TicksPerDay / sizeScale;

            // Get Day of first entry from all categories
            long firstDayTS = GetFirstDay().Ticks;

            // Get Last Day of all entries
            DateTime lastDay = GetLastDay();

            // Calculate total Days
            int totalDays = (lastDay - new DateTime(firstDayTS)).Days;

            // Calculate the offset-amount of all elements on the timeline to start 
            // at the first day containing a timestamp
            decimal firstDayOffset = firstDayTS / TimescaleDay;

            // Add Timestamp-elements
            int row = 0;
            foreach (VLXCategory category in Categories)
            {
                foreach (VLXTimestamp ts in category.Timestamps)
                {
                    CreateTimestampElement(category, ts, row, firstDayOffset, TimescaleDay);
                }
                row++;
            }

            // Create Timegrid
            switch (scale)
            {
                case TimelineScale.Hours:
                    for (int i = 0; i <= totalDays * 24; i++)
                        if(i % 6 != 0)
                            CreateTimeStep((int)((int)i * TimeSpan.TicksPerHour / TimescaleDay), Color.Gainsboro, 1);
                    goto case TimelineScale.SixHours;
                case TimelineScale.SixHours:
                    for (int i = 0; i <= totalDays * 4; i++)
                        if(i % 4 != 0)
                            CreateTimeStep((int)((int)i * (TimeSpan.TicksPerHour * 6) / TimescaleDay), Color.DimGray, 2);
                    goto case TimelineScale.Days;
                case TimelineScale.Days:
                    for (int i = 0; i <= totalDays; i++)
                        CreateTimeStep((int)((int)i * TimeSpan.TicksPerDay / TimescaleDay), Color.Orange, 3);
                    goto case TimelineScale.Months;
                case TimelineScale.Months:
                    // Todo: detect first day of month
                    //for (int i = 0; i <= totalDays; i++)
                    //    CreateTimeStep((int)((int)i * TimeSpan.TicksPerDay / TimescaleDay), Color.Orange, 3);
                    break;
            }
        }

        private DateTime GetFirstDay()
        {
            DateTime firstDay = DateTime.MaxValue;
            foreach(VLXCategory category in Categories)
            {
                DateTime firstCategoryTS = category.HistoricalFirstTimestamp.StartTime;

                if (firstCategoryTS < firstDay)
                    firstDay = firstCategoryTS;
            }

            return new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 0, 0, 0);
        }

        private DateTime GetLastDay()
        {
            DateTime lastDay = DateTime.MinValue;
            foreach (VLXCategory category in Categories)
            {
                DateTime lastCategoryTS = category.HistoricalLastTimestamp.EndTime;

                if (lastCategoryTS > lastDay)
                    lastDay = lastCategoryTS;
            }

            return new DateTime(lastDay.Year, lastDay.Month, lastDay.Day, 0, 0, 0).AddDays(1);
        }

        private void CreateTimestampElement(VLXCategory category, VLXTimestamp ts, int row, decimal firstDayOffset, decimal Timescale)
        {
            decimal from = (ts.StartTime.Ticks / Timescale);
            decimal to = (ts.EndTime.Ticks / Timescale);

            decimal fromRel = from - firstDayOffset;
            decimal toRel = to - firstDayOffset;


            PictureBox tsElement = new PictureBox
            {
                Top = row * 40 + 20,
                Left = (int)fromRel,
                Height = 30,
                Width = (int)(toRel - fromRel),
                BackColor = Color.Red
            };

            pnlTimeLine.Controls.Add(tsElement);
        }

        private void CreateTimeStep(int offset, Color color, int width)
        {
            PictureBox timeStep = new PictureBox
            {
                Top = 0,
                Left = offset - width/2,
                Height = pnlTimeLine.Height,
                Width = width,
                BackColor = color
            };

            pnlTimeLine.Controls.Add(timeStep);
        }


        private void trbPanelScale_Scroll(object sender, EventArgs e)
        {
            CreateTimeline();
        }
    }
}
