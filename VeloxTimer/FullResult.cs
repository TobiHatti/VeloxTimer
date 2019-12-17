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
        public FullResult()
        {
            InitializeComponent();

            dgvTimerResult.Columns.Add("colCategory", "Kategorie");
            dgvTimerResult.Columns.Add("colToday", "Heute");
            dgvTimerResult.Columns.Add("colYesterday", "Gestern");
            dgvTimerResult.Columns.Add("colDifDay", "Differenz");
            dgvTimerResult.Columns.Add("colThisWeek", "Diese Woche");
            dgvTimerResult.Columns.Add("colLastWeek", "Letzte Woche");
            dgvTimerResult.Columns.Add("colDifWeek", "Differenz");
            dgvTimerResult.Columns.Add("colThisMonth", "Diesen Monat");
            dgvTimerResult.Columns.Add("colLastMonth", "Letzten Monat");
            dgvTimerResult.Columns.Add("colDifMonth", "Differenz");
            dgvTimerResult.Columns.Add("colTotal", "Gesamt");
            dgvTimerResult.Rows.Add();

        }
    }
}
