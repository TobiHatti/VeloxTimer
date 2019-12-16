using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{

    public partial class TaskTimerMain : Form
    {
        private string categoryFile = @"Categories.txt";
        private Dictionary<int, TimerElement> timers = new Dictionary<int, TimerElement>();
        public TaskTimerMain()
        {
            InitializeComponent();
        }

        private void LoadCategories(bool pInitialLoad)
        {
            try
            {
                // When reloading, remove every control except the main, fixed controls
                if(!pInitialLoad)
                {
                    timers.Clear();
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                        if(this.Controls[i] != cbxTotalTimeSpanSelect
                            && this.Controls[i] != lblTitleCurrent
                            && this.Controls[i] != btnOpenCategoryFile
                            && this.Controls[i] != btnReloadCategories
                            && this.Controls[i] != btnCreateResults)
                        this.Controls.Remove(this.Controls[i]);
                }


                StreamReader sr = new StreamReader(categoryFile);
                string category = null;
                int offset = 35;
                int ctr = 0;
                while ((category = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(category)) continue;
                    // Create Title Label
                    Label lblTitle = new Label();
                    lblTitle.Name = $"lblTitle{ctr}";
                    lblTitle.Text = category;
                    lblTitle.Left = 12;
                    lblTitle.Top = 55 + ctr * offset;
                    lblTitle.Width = 125;
                    lblTitle.AutoSize = false;
                    lblTitle.Font = new Font("Microsoft Sans Serif", 12);
                    lblTitle.TextAlign = ContentAlignment.MiddleRight;
                    //lblTitle.BackColor = Color.Red;
                    this.Controls.Add(lblTitle);

                    // Create CurrentTime Label
                    Label lblCurrentTime = new Label();
                    lblCurrentTime.Name = $"lblCurrentTime{ctr}";
                    lblCurrentTime.Text = "00:00:00";
                    lblCurrentTime.Left = 250;
                    lblCurrentTime.Top = 55 + ctr * offset;
                    lblCurrentTime.Width = 90;
                    lblCurrentTime.AutoSize = false;
                    lblCurrentTime.Font = new Font("Microsoft Sans Serif", 12);
                    lblCurrentTime.TextAlign = ContentAlignment.MiddleRight;
                    //lblCurrentTime.BackColor = Color.Red;
                    this.Controls.Add(lblCurrentTime);

                    // Create TotalTime Label
                    Label lblTotalTime = new Label();
                    lblTotalTime.Name = $"lblTotalTime{ctr}";
                    lblTotalTime.Text = "00:00:00:00";
                    lblTotalTime.Left = 350;
                    lblTotalTime.Top = 55 + ctr * offset;
                    lblTotalTime.Width = 125;
                    lblTotalTime.AutoSize = false;
                    lblTotalTime.Font = new Font("Microsoft Sans Serif", 12);
                    lblTotalTime.TextAlign = ContentAlignment.MiddleRight;
                    //lblTotalTime.BackColor = Color.Red;
                    this.Controls.Add(lblTotalTime);

                    // Create StartStop-Button
                    Button btnStartStop = new Button();
                    btnStartStop.Name = $"btnStartStop{ctr}";
                    btnStartStop.Text = "Start";
                    btnStartStop.Left = 140;
                    btnStartStop.Top = 50 + ctr * offset;
                    btnStartStop.Width = 95;
                    btnStartStop.Height = 29;
                    btnStartStop.Font = new Font("Microsoft Sans Serif", 12);
                    btnStartStop.BackColor = Color.Gainsboro;
                    btnStartStop.Click += BtnStartStop_Click;
                    this.Controls.Add(btnStartStop);

                    // Create Options-Button
                    Button btnSimpResults = new Button();
                    btnSimpResults.Name = $"btnSimpleResults{ctr}";
                    btnSimpResults.Text = "...";
                    btnSimpResults.Left = 490;
                    btnSimpResults.Top = 50 + ctr * offset;
                    btnSimpResults.Width = 31;
                    btnSimpResults.Height = 29;
                    btnSimpResults.Font = new Font("Microsoft Sans Serif", 12);
                    btnSimpResults.BackColor = Color.Gainsboro;
                    btnSimpResults.Click += BtnSimpResults_Click;
                    this.Controls.Add(btnSimpResults);

                    // Create Indicator-Light
                    PictureBox pbxIndicate = new PictureBox();
                    pbxIndicate.Name = $"pbxIndicate{ctr}";
                    pbxIndicate.BackColor = Color.Red;
                    pbxIndicate.Left = 228;
                    pbxIndicate.Top = 51 + ctr * offset;
                    pbxIndicate.Width = 17;
                    pbxIndicate.Height = 27;
                    this.Controls.Add(pbxIndicate);

                    timers.Add(ctr, new TimerElement(category));

                    ctr++;
                }

                this.Height =130 + ctr * offset + 20;

                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ein Fehler ist beim Laden der Kategorien aufgetreten.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSimpResults_Click(object sender, EventArgs e)
        {
            int objIndex = Convert.ToInt32((sender as Button).Name.Replace("btnSimpleResults", ""));

            SimpleResult simpleResultForm = new SimpleResult();

            simpleResultForm.SetTimerData(timers[objIndex]);

            simpleResultForm.ShowDialog();
        }

        private void UpdateCumulated()
        {
            foreach (KeyValuePair<int, TimerElement> timer in timers)
            {
                switch (cbxTotalTimeSpanSelect.SelectedItem.ToString())
                {
                    case "Heute":
                        (this.Controls.Find($"lblTotalTime{timer.Key}",false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.Today).ToString(@"hh\:mm\:ss");
                        break;
                    case "Gestern":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.Yesterday).ToString(@"hh\:mm\:ss");
                        break;
                    case "Diese Woche":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.ThisWeek).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Letzte Woche":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.LastWeek).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Diesen Monat":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.ThisMonth).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Letzten Monat":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.LastMonth).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Gesamt":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.Total).ToString(@"d\:hh\:mm\:ss");
                        break;
                }
            }
        }

        private void TaskTimerMain_Load(object sender, EventArgs e)
        {
            LoadCategories(true);
            UpdateCumulated();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            int objIndex = Convert.ToInt32((sender as Button).Name.Replace("btnStartStop", ""));

            var dt = DateTime.Now;
            var dtNoMils = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            if ((sender as Button).Text == "Start")
            {
                (sender as Button).Text = "Stop";
                (this.Controls.Find($"pbxIndicate{objIndex}", false)[0] as PictureBox).BackColor = Color.Lime;

                
                timers[objIndex].IsRunning = true;
                timers[objIndex].SessionStartTime = dtNoMils;
            }
            else
            {
                (sender as Button).Text = "Start";
                (this.Controls.Find($"pbxIndicate{objIndex}", false)[0] as PictureBox).BackColor = Color.Red;

                timers[objIndex].IsRunning = false;
                timers[objIndex].SessionStopTime = dtNoMils;

                timers[objIndex].SaveLogEntry();
                timers[objIndex].ResetSession();

                UpdateCumulated();

                (this.Controls.Find($"lblCurrentTime{objIndex}", false)[0] as Label).Text = "00:00:00";
            }
           
        }

        private void tmrCurrentUpdater_Tick(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            var checkDT = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            foreach (KeyValuePair<int, TimerElement> timer in timers)
            {
                if (timer.Value.IsRunning)
                {
                    (this.Controls.Find($"lblCurrentTime{timer.Key}", false)[0] as Label).Text =
                        (checkDT.Subtract(timer.Value.SessionStartTime)).ToString("T");
                }
            }
        }


       
        private void btnOpenCategoryFile_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", categoryFile);
        }

        private void btnReloadCategories_Click(object sender, EventArgs e)
        {
            bool timerActive = false;
            var dt = DateTime.Now;
            var dtNoMils = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            foreach (KeyValuePair<int, TimerElement> timer in timers)
                if (timer.Value.IsRunning) timerActive = true;

            if (!timerActive || (timerActive && MessageBox.Show("Mindestens 1 Timer läuft gerade. Sollen alle laufenden Timer gestoppt werden um zu aktualisieren?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if(timerActive)
                {
                    foreach (KeyValuePair<int, TimerElement> timer in timers)
                        if (timer.Value.IsRunning)
                        {
                            timer.Value.IsRunning = false;
                            timer.Value.SessionStopTime = dtNoMils;

                            timer.Value.SaveLogEntry();
                            timer.Value.ResetSession();
                        }   
                }

                LoadCategories(false);
                UpdateCumulated();
            }

            
        }

        private void cbxTotalTimeSpanSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateCumulated();
        }

        private void TaskTimerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool timerActive = false;
            var dt = DateTime.Now;
            var dtNoMils = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            foreach (KeyValuePair<int, TimerElement> timer in timers)
                if (timer.Value.IsRunning) timerActive = true;

            if(timerActive)
            {
                var result = MessageBox.Show("Es läuft noch mindestens 1 Timer. Wollen Sie alle noch laufenden Timer stoppen und speichern?", "Timer laufen noch", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel) e.Cancel = true;

                if(result == DialogResult.Yes)
                {
                    foreach (KeyValuePair<int, TimerElement> timer in timers)
                        if (timer.Value.IsRunning)
                        {
                            timer.Value.IsRunning = false;
                            timer.Value.SessionStopTime = dtNoMils;

                            timer.Value.SaveLogEntry();
                            timer.Value.ResetSession();
                        }
                }

                if(result == DialogResult.No) e.Cancel = false;
            }
        }
    }
}
