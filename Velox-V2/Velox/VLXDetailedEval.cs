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

            pnlTimeLine.VerticalScroll.Value += 1;
            pnlTimeLine.VerticalScroll.Enabled = false;
            pnlTimeLine.VerticalScroll.Visible = false;
        }

        private void VLXDetailedEval_Load(object sender, EventArgs e)
        {
            CreateTimeline();

            int i = 0;
            foreach (VLXCategory category in Categories)
            {
                Label categoryLabel = new Label()
                {
                    Text = category.Name,
                    Top = i * 40 + 65,
                    Left = 5,
                    AutoSize = true
                };

                this.Controls.Add(categoryLabel);
                i++;
            }
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
            int scaleInputValue = trbPanelScale.Value;

            // Set Scale
            if (scaleInputValue <= 10) scale = TimelineScale.Days;
            else if (scaleInputValue <= 20) scale = TimelineScale.SixHours;
            else if (scaleInputValue <= 30) scale = TimelineScale.Hours;

            // Remove all components from the panel
            pnlTimeLine.Controls.Clear();

            decimal sizeScale = (decimal)Math.Pow(scaleInputValue, 2);

            // Get Timescales
            // Timescale / 1 Day
            decimal TimescaleDay = TimeSpan.TicksPerDay / sizeScale;

            // Get Day of first entry from all categories
            DateTime firstDay = GetFirstDay();

            // Get Last Day of all entries
            DateTime lastDay = GetLastDay();

            // Calculate total Days
            int totalDays = (lastDay - firstDay).Days;

            // Calculate the offset-amount of all elements on the timeline to start 
            // at the first day containing a timestamp
            decimal firstDayOffset = firstDay.Ticks / TimescaleDay;

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
                        {
                            CreateTimeStep((int)((int)i * TimeSpan.TicksPerHour / TimescaleDay), Color.Gainsboro, 1);
                            CreateLabel(firstDay.AddHours((i % 24)).ToShortTimeString(), (int)((int)i * TimeSpan.TicksPerHour / TimescaleDay), 30, 6f, Color.Gray);
                        }
                            
                    goto case TimelineScale.SixHours;
                case TimelineScale.SixHours:
                    for (int i = 0; i <= totalDays * 4; i++)
                        if(i % 4 != 0)
                        {
                            CreateTimeStep((int)((int)i * (TimeSpan.TicksPerHour * 6) / TimescaleDay), Color.DimGray, 2);
                            CreateLabel(firstDay.AddHours((i % 4) * 6).ToShortTimeString(), (int)((int)i * (TimeSpan.TicksPerHour * 6) / TimescaleDay), 30, 6f, Color.Gray);
                        }
                    goto case TimelineScale.Days;
                case TimelineScale.Days:
                    for (int i = 0; i <= totalDays; i++)
                    {
                        CreateTimeStep((int)((int)i * TimeSpan.TicksPerDay / TimescaleDay), Color.Orange, 3);
                        CreateLabel(firstDay.AddDays(i).ToShortDateString(), (int)((int)i * TimeSpan.TicksPerDay / TimescaleDay), 10, 8f, Color.DimGray);
                    }
                    goto case TimelineScale.Months;
                case TimelineScale.Months:
                    // Todo: detect first day of month
                    //for (int i = 0; i <= totalDays; i++)
                    //    CreateTimeStep((int)((int)i * TimeSpan.TicksPerDay / TimescaleDay), Color.Orange, 3);
                    break;
            }

            // Create category-seperator lines
            for(int i = 0; i <= Categories.Count; i++)
            {
                PictureBox catSep = new PictureBox
                {
                    Top = i * 40 + 55,
                    Left = 0,
                    Height = 1,
                    Width = (int)((int)(totalDays+1) * TimeSpan.TicksPerDay / TimescaleDay),
                    BackColor = Color.DarkOrange
                };

                pnlTimeLine.Controls.Add(catSep);
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
                Top = row * 40 + 60,
                Left = (int)fromRel,
                Height = 30,
                Width = Math.Max(5,(int)(toRel - fromRel)),
                BackColor = category.CategoryColor,
                Tag = new Tuple<VLXCategory, VLXTimestamp>(category, ts),
                Cursor = Cursors.Hand
            };

            tsElement.MouseEnter += TsElement_MouseEnter;
            tsElement.MouseLeave += TsElement_MouseLeave;
            tsElement.MouseClick += TsElement_MouseClick;

            pnlTimeLine.Controls.Add(tsElement);
        }


        private void TsElement_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
        }

        private void TsElement_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        private void TsElement_MouseClick(object sender, MouseEventArgs e)
        {
            Tuple<VLXCategory, VLXTimestamp> tsData = ((sender as PictureBox).Tag as Tuple<VLXCategory, VLXTimestamp>);

            VLXTimestampInfo tsInfo = new VLXTimestampInfo()
            {
                Category = tsData.Item1,
                Timestamp = tsData.Item2,
                Sql = this.Sql
            };

            if(tsInfo.ShowDialog() == DialogResult.Yes)
            {
                CreateTimeline();
            }
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

        private void CreateLabel(string text, int offsetX, int offsetY, float fontSize, Color fontColor)
        {
            Label dtLabel = new Label
            {
                Text = text,
                Top = offsetY,
                Left = offsetX + 1,
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font(FontFamily.GenericSansSerif, fontSize),
                ForeColor = fontColor
            };

            pnlTimeLine.Controls.Add(dtLabel);
        }

        private void trbPanelScale_Scroll(object sender, EventArgs e)
        {
            CreateTimeline();
        }

        private void VLXDetailedEval_ResizeEnd(object sender, EventArgs e)
        {
            CreateTimeline();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            VLXManualAddSession addSession = new VLXManualAddSession()
            {
                Categories = this.Categories,
                PreselectedCategory = null,
                Sql = this.Sql
            };

            if(addSession.ShowDialog() == DialogResult.OK)
            {
                CreateTimeline();
            }
        }
    }
}
