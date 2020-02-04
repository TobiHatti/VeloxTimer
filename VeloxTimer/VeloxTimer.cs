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

namespace VeloxTimer
{

    public partial class VeloxTimer : Form
    {
        public static readonly string CategoryFile = @"Categories.txt";
        private readonly Dictionary<int, TimerElement> timers = new Dictionary<int, TimerElement>();
        public VeloxTimer()
        {
            InitializeComponent();
        }

        private void LoadCategories(bool pInitialLoad)
        {
            // If the timer gets loaded the first time, check if a category-file exists. 
            // If not, create one with the default categories
            if(!File.Exists(CategoryFile))
            {
                StreamWriter sw = new StreamWriter(CategoryFile);
                sw.WriteLine("Coding");
                sw.WriteLine("Reviews");
                sw.WriteLine("Support");
                sw.WriteLine("Meeting");
                sw.Close();
            }

            // If the timer gets loaded the first time, check if a log-file exists. 
            // If not, create one
            if (!File.Exists(TimerElement.LogFile))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(TimerElement.LogFile));
                using(StreamWriter sw = new StreamWriter(TimerElement.LogFile))
                {
                    sw.Close();
                }
            }

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
                            && this.Controls[i] != btnResults)
                        this.Controls.Remove(this.Controls[i]);
                }


                StreamReader sr = new StreamReader(CategoryFile);
                string category = null;
                int offset = 35;
                int ctr = 0;
                while ((category = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(category)) continue;
                    // Create Title Label
                    Label lblTitle = new Label
                    {
                        Name = $"lblTitle{ctr}",
                        Text = category,
                        Left = 12,
                        Top = 55 + ctr * offset,
                        Width = 125,
                        AutoSize = false,
                        Font = new Font("Microsoft Sans Serif", 12),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    //lblTitle.BackColor = Color.Red;
                    this.Controls.Add(lblTitle);

                    // Create CurrentTime Label
                    Label lblCurrentTime = new Label
                    {
                        Name = $"lblCurrentTime{ctr}",
                        Text = "00:00:00",
                        Left = 250,
                        Top = 55 + ctr * offset,
                        Width = 90,
                        AutoSize = false,
                        Font = new Font("Microsoft Sans Serif", 12),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    //lblCurrentTime.BackColor = Color.Red;
                    this.Controls.Add(lblCurrentTime);

                    // Create TotalTime Label
                    Label lblTotalTime = new Label
                    {
                        Name = $"lblTotalTime{ctr}",
                        Text = "00:00:00:00",
                        Left = 350,
                        Top = 55 + ctr * offset,
                        Width = 125,
                        AutoSize = false,
                        Font = new Font("Microsoft Sans Serif", 12),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    //lblTotalTime.BackColor = Color.Red;
                    this.Controls.Add(lblTotalTime);

                    // Create StartStop-Button
                    Button btnStartStop = new Button
                    {
                        Name = $"btnStartStop{ctr}",
                        Text = "Start",
                        Left = 140,
                        Top = 50 + ctr * offset,
                        Width = 95,
                        Height = 29,
                        Font = new Font("Microsoft Sans Serif", 12),
                        BackColor = Color.Gainsboro
                    };
                    btnStartStop.Click += BtnStartStop_Click;
                    this.Controls.Add(btnStartStop);

                    // Create Options-Button
                    Button btnSimpResults = new Button
                    {
                        Name = $"btnSimpleResults{ctr}",
                        Text = "...",
                        Left = 490,
                        Top = 50 + ctr * offset,
                        Width = 31,
                        Height = 29,
                        Font = new Font("Microsoft Sans Serif", 12),
                        BackColor = Color.Gainsboro
                    };
                    btnSimpResults.Click += BtnSimpResults_Click;
                    this.Controls.Add(btnSimpResults);

                    // Create Indicator-Light
                    PictureBox pbxIndicate = new PictureBox
                    {
                        Name = $"pbxIndicate{ctr}",
                        BackColor = Color.Red,
                        Left = 228,
                        Top = 51 + ctr * offset,
                        Width = 17,
                        Height = 27
                    };
                    this.Controls.Add(pbxIndicate);

                    timers.Add(ctr, new TimerElement(category));

                    ctr++;
                }

                this.Height =130 + ctr * offset + 20;

                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured whilst trying to load the categories", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case "Today":
                        (this.Controls.Find($"lblTotalTime{timer.Key}",false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.Today).ToString(@"hh\:mm\:ss");
                        break;
                    case "Yesterday":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.Yesterday).ToString(@"hh\:mm\:ss");
                        break;
                    case "This Week":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.ThisWeek).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Last Week":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.LastWeek).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "This Month":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.ThisMonth).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Last Month":
                        (this.Controls.Find($"lblTotalTime{timer.Key}", false)[0] as Label).Text =
                            timer.Value.GetCumulated(CumulateRange.LastMonth).ToString(@"d\:hh\:mm\:ss");
                        break;
                    case "Total":
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
            Process.Start("notepad.exe", CategoryFile);
        }

        private void btnReloadCategories_Click(object sender, EventArgs e)
        {
            bool timerActive = false;
            var dt = DateTime.Now;
            var dtNoMils = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

            foreach (KeyValuePair<int, TimerElement> timer in timers)
                if (timer.Value.IsRunning) timerActive = true;

            if (!timerActive || (timerActive && MessageBox.Show("At least 1 timer is still running. Do you want to stop all running timers and refresh?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
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
                var result = MessageBox.Show("At least 1 timer is still running. Do you want to stop all running timers and save?", "Timer still running", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

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

        private void btnResults_Click(object sender, EventArgs e)
        {
            FullResult fullResultForm = new FullResult();
            fullResultForm.Timers = timers;
            fullResultForm.ShowDialog();
        }
    }
}
