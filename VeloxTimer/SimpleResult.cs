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
    public partial class SimpleResult : Form
    {
        public SimpleResult()
        {
            InitializeComponent();
        }

        public void SetTimerData(TimerElement pTimer)
        {
            lblResultTitle.Text = $"Auswertung für Kategorie \"{pTimer.CategoryName}\"";

            lblCumulatedToday.Text = pTimer.GetCumulated(CumulateRange.Today).ToString(@"hh\:mm\:ss");
            lblCumulatedYesterday.Text = pTimer.GetCumulated(CumulateRange.Yesterday).ToString(@"hh\:mm\:ss");
            lblCumulatedThisWeek.Text = pTimer.GetCumulated(CumulateRange.ThisWeek).ToString(@"d\:hh\:mm\:ss");
            lblCumulatedLastWeek.Text = pTimer.GetCumulated(CumulateRange.LastWeek).ToString(@"d\:hh\:mm\:ss");
            lblCumulatedThisMonth.Text = pTimer.GetCumulated(CumulateRange.ThisMonth).ToString(@"d\:hh\:mm\:ss");
            lblCumulatedLastMonth.Text = pTimer.GetCumulated(CumulateRange.LastMonth).ToString(@"d\:hh\:mm\:ss");
            lblCumulatedTotal.Text = pTimer.GetCumulated(CumulateRange.Total).ToString(@"d\:hh\:mm\:ss");

            char sign = ' ';

            TimeSpan difDay = pTimer.GetCumulated(CumulateRange.Yesterday).Subtract(pTimer.GetCumulated(CumulateRange.Today));
            if (difDay < TimeSpan.Zero)
            {
                lblDifDay.ForeColor = Color.Green;
                sign = '+';
            }
            else if (difDay > TimeSpan.Zero)
            {
                lblDifDay.ForeColor = Color.Red;
                sign = '-';
            }
            lblDifDay.Text = sign + difDay.ToString(@"hh\:mm\:ss");

            TimeSpan difWeek = pTimer.GetCumulated(CumulateRange.LastWeek).Subtract(pTimer.GetCumulated(CumulateRange.ThisWeek));
            if (difWeek < TimeSpan.Zero)
            {
                lblDifWeek.ForeColor = Color.Green;
                sign = '+';
            }
            else if (difWeek > TimeSpan.Zero)
            {
                lblDifWeek.ForeColor = Color.Red;
                sign = '-';
            }
            lblDifWeek.Text = sign + difWeek.ToString(@"d\:hh\:mm\:ss");

            TimeSpan difMonth = pTimer.GetCumulated(CumulateRange.LastMonth).Subtract(pTimer.GetCumulated(CumulateRange.ThisMonth));
            if (difMonth < TimeSpan.Zero)
            {
                lblDifMonth.ForeColor = Color.Green;
                sign = '+';
            }
            else if (difMonth > TimeSpan.Zero)
            {
                lblDifMonth.ForeColor = Color.Red;
                sign = '-';
            }
            lblDifMonth.Text = sign + difMonth.ToString(@"d\:hh\:mm\:ss");
        }

        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCreateLogFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }
    }
}
