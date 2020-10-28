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

namespace Velox
{
    public partial class VLXQuickEval : SfForm
    {
        public VLXCategory Category = null;

        public DateTime CustomRangeStart;
        public DateTime CustomRangeEnd;

        public VLXQuickEval()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);
        }

        private void VLXQuickEval_Load(object sender, EventArgs e)
        {
            lblCategoryEvalTitle.Text = $"Quick evaluation for category \"{Category.Name}\"";
            lblCategoryDescription.Text = Category.Description;


            TimeSpan today = Category.TotalTimeFromSelection(TimeSelection.Today);
            TimeSpan yesterday = Category.TotalTimeFromSelection(TimeSelection.Yesterday);
            TimeSpan thisWeek = Category.TotalTimeFromSelection(TimeSelection.ThisWeek);
            TimeSpan lastWeek = Category.TotalTimeFromSelection(TimeSelection.LastWeek);
            TimeSpan thisMonth = Category.TotalTimeFromSelection(TimeSelection.ThisMonth);
            TimeSpan lastMonth = Category.TotalTimeFromSelection(TimeSelection.LastMonth);

            lblToday.Text = today.ToString(@"hh\:mm\:ss");
            lblYesterday.Text = yesterday.ToString(@"hh\:mm\:ss");
            lblThisWeek.Text = thisWeek.ToString(@"hh\:mm\:ss");
            lblLastWeek.Text = lastWeek.ToString(@"hh\:mm\:ss");
            lblThisMonth.Text = thisMonth.ToString(@"hh\:mm\:ss");
            lblLastMonth.Text = lastMonth.ToString(@"hh\:mm\:ss");

            lblTotal.Text = Category.TotalTime.ToString(@"hh\:mm\:ss");
            lblCustomRange.Text = Category.TotalTimeFromSpan(CustomRangeStart, CustomRangeEnd).ToString(@"hh\:mm\:ss");

            lblDateSpan.Text = CustomRangeStart.ToString("dd.MM.yyyy") + " - " + CustomRangeEnd.ToString("dd.MM.yyyy");

            TimeSpan dayDiff = today - yesterday;
            TimeSpan weekDiff = thisWeek - lastWeek;
            TimeSpan monthDiff = thisMonth - lastMonth;

            lblDayDiff.ForeColor = dayDiff >= TimeSpan.Zero ? Color.Green : Color.Red;
            lblWeekDiff.ForeColor = weekDiff >= TimeSpan.Zero ? Color.Green : Color.Red;
            lblMonthDiff.ForeColor = monthDiff >= TimeSpan.Zero ? Color.Green : Color.Red;

            lblDayDiff.Text = (dayDiff >= TimeSpan.Zero ? '+' : '-') + dayDiff.ToString(@"hh\:mm\:ss");
            lblWeekDiff.Text = (weekDiff >= TimeSpan.Zero ? '+' : '-') + weekDiff.ToString(@"hh\:mm\:ss");
            lblMonthDiff.Text = (monthDiff >= TimeSpan.Zero ? '+' : '-') + monthDiff.ToString(@"hh\:mm\:ss");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}