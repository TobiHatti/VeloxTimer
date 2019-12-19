using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeloxTimer
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

            cbxCategories.Items.Add("Alle");

            StreamReader sr = new StreamReader(VeloxTimer.CategoryFile);
            string category = null;
            while ((category = sr.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(category)) continue;
                cbxCategories.Items.Add(category);
            }

            cbxCategories.SelectedIndex = 0;
        }

        private void UpdateOverviewDGV()
        {
            CreateOverviewDGV();
            FillOverviewDGV();
        }

        private void UpdateDetailDGV()
        {
            CreateDetailDGV();
            FillDetailDGV();
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
                    if (chbShowDif.Checked) dgvTimerResult.Columns.Add("colDifDay", "Differenz");
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

        private void CreateDetailDGV()
        {
            dgvResultDetail.Columns.Clear();

            dgvResultDetail.Columns.Add("colDate", "Datum");
            dgvResultDetail.Columns.Add("colStartdate", "Startzeit");
            dgvResultDetail.Columns.Add("colEnddate", "Endzeit");
            dgvResultDetail.Columns.Add("colDuration", "Dauer");
        }

        private void FillDetailDGV()
        {
            int i = 0;
            foreach(KeyValuePair<int, TimerElement> timer in Timers)
            {
                if (cbxCategories.Text != null && timer.Value.CategoryName == cbxCategories.Text || cbxCategories.Text == "Alle")
                {

                    DataGridViewCellStyle totalStyle = new DataGridViewCellStyle
                    {
                        ForeColor = Color.DarkOrange,
                        Font = new Font(dgvResultDetail.Font, FontStyle.Bold)
                    };

                    if(cbxCategories.Text == "Alle")
                        dgvResultDetail.Rows.Add(
                                timer.Value.CategoryName,
                                "", "Gesamt:",
                                timer.Value.GetCumulated(CumulateRange.Total)
                            );
                    else
                        dgvResultDetail.Rows.Add(
                                "Gesamt:",
                                "", "",
                                timer.Value.GetCumulated(CumulateRange.Total)
                            );

                    dgvResultDetail.Rows[i++].DefaultCellStyle = totalStyle;

                    foreach (Tuple<DateTime, DateTime, TimeSpan> logEntry in timer.Value.GetFullLog())
                    {
                        dgvResultDetail.Rows.Add(
                            logEntry.Item1.ToString("ddd, dd.MM.yyyy"),
                            logEntry.Item1.ToString("hh:mm:ss"),
                            logEntry.Item2.ToString("hh:mm:ss"),
                            logEntry.Item3.ToString()
                        );

                        i++;
                    }
                }
            }
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
            sfdSaveExport.FileName = "TaskOverview.csv";
            sfdSaveExport.Title = "Übersicht Exportieren";
            if(sfdSaveExport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfdSaveExport.FileName);
                    sw.WriteLine($"Kategorie;Heute;Gestern;Differenz;Diese Woche;Letzte Woche;Differenz;Diesen Monat;Letzten Monat;Differenz;Gesammt");
                    foreach (KeyValuePair<int, TimerElement> timer in Timers)
                    {
                        sw.WriteLine(
                            $"{timer.Value.CategoryName};" +
                            $"{timer.Value.GetCumulated(CumulateRange.Today)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.Yesterday)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.Today).Subtract(timer.Value.GetCumulated(CumulateRange.Yesterday))};" +
                            $"{timer.Value.GetCumulated(CumulateRange.ThisWeek)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.LastWeek)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.ThisWeek).Subtract(timer.Value.GetCumulated(CumulateRange.LastWeek))};" +
                            $"{timer.Value.GetCumulated(CumulateRange.ThisMonth)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.LastMonth)};" +
                            $"{timer.Value.GetCumulated(CumulateRange.ThisMonth).Subtract(timer.Value.GetCumulated(CumulateRange.LastMonth))};" +
                            $"{timer.Value.GetCumulated(CumulateRange.Total)}"
                        );
                    }

                    sw.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Datei konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetailDGV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExportDetail_Click(object sender, EventArgs e)
        {
            sfdSaveExport.FileName = "TaskDetail.csv";
            sfdSaveExport.Title = "Detailansicht Exportieren";
            if (sfdSaveExport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfdSaveExport.FileName);
                    int i = 0;
                    foreach (KeyValuePair<int, TimerElement> timer in Timers)
                    {
                        if (cbxCategories.Text != null && timer.Value.CategoryName == cbxCategories.Text || cbxCategories.Text == "Alle")
                        {
                            sw.WriteLine($"Datum;Startzeit;Endzeit;Dauer");
                            sw.WriteLine($"{timer.Value.CategoryName};;Gesamt:;{timer.Value.GetCumulated(CumulateRange.Total)}");

                            foreach (Tuple<DateTime, DateTime, TimeSpan> logEntry in timer.Value.GetFullLog())
                                sw.WriteLine($"{logEntry.Item1.ToString("ddd, dd.MM.yyyy")};{logEntry.Item1.ToString("hh:mm:ss")};{logEntry.Item2.ToString("hh:mm:ss")};{logEntry.Item3.ToString()}");
                        }
                    }

                    sw.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Datei konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
