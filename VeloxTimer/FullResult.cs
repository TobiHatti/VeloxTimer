using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public partial class FullResult : Form
    {
        public Dictionary<int, TimerElement> Timers { get; set; } = null;


        public FullResult()
        {
            InitializeComponent();
        }

        private void FullResult_Load(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void UpdateOverviewDGV()
        {
            CreateOverviewDGV();
            FillOverviewDGV();
        }

        private void FillOverviewDGV()
        {
            List<object> param;

            foreach (KeyValuePair<int, TimerElement> timer in Timers)
            {
                param = new List<object>();

                param.Add(timer.Value.CategoryName);

                if (chbShowDayResults.Checked)
                {
                    param.Add(timer.Value.GetCumulated(CumulateRange.Today));
                    if (chbShowLastPeriods.Checked)
                    {
                        param.Add(timer.Value.GetCumulated(CumulateRange.Yesterday));
                        if (chbShowDif.Checked)  param.Add(timer.Value.GetCumulated(CumulateRange.Today).Subtract(timer.Value.GetCumulated(CumulateRange.Yesterday)));
                    }
                }

                if (chbShowWeekResults.Checked)
                {
                    param.Add(timer.Value.GetCumulated(CumulateRange.ThisWeek));
                    if (chbShowLastPeriods.Checked)
                    {
                        param.Add(timer.Value.GetCumulated(CumulateRange.LastWeek));
                        if (chbShowDif.Checked) param.Add(timer.Value.GetCumulated(CumulateRange.ThisWeek).Subtract(timer.Value.GetCumulated(CumulateRange.LastWeek)));
                    }
                }

                if (chbShowMonthResults.Checked)
                {
                    param.Add(timer.Value.GetCumulated(CumulateRange.ThisMonth));
                    if (chbShowLastPeriods.Checked)
                    {
                        param.Add(timer.Value.GetCumulated(CumulateRange.LastMonth));
                        if (chbShowDif.Checked) param.Add(timer.Value.GetCumulated(CumulateRange.ThisMonth).Subtract(timer.Value.GetCumulated(CumulateRange.LastMonth)));
                    }
                }

                if (chbShowTotalResults.Checked) param.Add(timer.Value.GetCumulated(CumulateRange.Total));

                dgvTimerResult.Rows.Add(param.ToArray());
            }

            DataGridViewCellStyle positiveDif = new DataGridViewCellStyle { ForeColor = Color.Green };
            DataGridViewCellStyle negativeDif = new DataGridViewCellStyle { ForeColor = Color.Red };
            int checkedSegments = 0;

            if (chbShowDayResults.Checked) checkedSegments++;
            if (chbShowWeekResults.Checked) checkedSegments++;
            if (chbShowMonthResults.Checked) checkedSegments++;

            foreach (DataGridViewRow row in dgvTimerResult.Rows)
            {
                if (chbShowLastPeriods.Checked && chbShowDif.Checked)
                {
                    if (checkedSegments >= 3)
                    {
                        if(TimeSpan.Parse(row.Cells[9].Value.ToString()) < TimeSpan.Zero) row.Cells[9].Style = negativeDif;
                        if(TimeSpan.Parse(row.Cells[9].Value.ToString()) > TimeSpan.Zero) row.Cells[9].Style = positiveDif;
                    }
                    if (checkedSegments  >= 2)
                    {
                        if (TimeSpan.Parse(row.Cells[6].Value.ToString()) < TimeSpan.Zero) row.Cells[6].Style = negativeDif;
                        if (TimeSpan.Parse(row.Cells[6].Value.ToString()) > TimeSpan.Zero) row.Cells[6].Style = positiveDif;
                    }
                    if (checkedSegments  >= 1)
                    {
                        if (TimeSpan.Parse(row.Cells[3].Value.ToString()) < TimeSpan.Zero) row.Cells[3].Style = negativeDif;
                        if (TimeSpan.Parse(row.Cells[3].Value.ToString()) > TimeSpan.Zero) row.Cells[3].Style = positiveDif;
                    }
                }
            }
        }

        private void CreateOverviewDGV()
        {
            dgvTimerResult.Columns.Clear();

            dgvTimerResult.Columns.Add("colCategory", "Kategorie");

            if (chbShowDayResults.Checked)
            {
                dgvTimerResult.Columns.Add("colToday", "Heute");
                if (chbShowLastPeriods.Checked)
                {
                    dgvTimerResult.Columns.Add("colYesterday", "Gestern");
                    if(chbShowDif.Checked) dgvTimerResult.Columns.Add("colDifDay", "Differenz");
                }
            }

            if (chbShowWeekResults.Checked)
            {
                dgvTimerResult.Columns.Add("colThisWeek", "Diese Woche");
                if (chbShowLastPeriods.Checked)
                {
                    dgvTimerResult.Columns.Add("colLastWeek", "Letzte Woche");
                    if (chbShowDif.Checked) dgvTimerResult.Columns.Add("colDifWeek", "Differenz");
                }
            }

            if (chbShowMonthResults.Checked)
            {
                dgvTimerResult.Columns.Add("colThisMonth", "Diesen Monat");
                if (chbShowLastPeriods.Checked)
                {
                    dgvTimerResult.Columns.Add("colLastMonth", "Letzten Monat");
                    if (chbShowDif.Checked) dgvTimerResult.Columns.Add("colDifMonth", "Differenz");
                }
            }

            if (chbShowTotalResults.Checked) dgvTimerResult.Columns.Add("colTotal", "Gesamt");

        }

        private void chbShowDayResults_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void chbShowMonthResults_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void chbShowDif_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void chbShowWeekResults_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void chbShowTotalResults_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();
        }

        private void chbShowLastPeriods_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverviewDGV();

            if (!(sender as CheckBox).Checked) chbShowDif.Enabled = false;
            else chbShowDif.Enabled = true;
        }

        private void btnExportOverview_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
