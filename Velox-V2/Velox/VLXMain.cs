using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WrapSQL;

namespace Velox
{
    public partial class VLXMain : SfForm
    {
        private WrapSQLite sql;
        private List<VLXCategory> categories = null;

        private DateTime customStartDate = DateTime.Now;
        private DateTime customEndDate = DateTime.Now.AddDays(5);

        public VLXMain()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);

            cbxTotalTimespan.SelectedIndex = 0;
        }

        private void VLXMain_Load(object sender, EventArgs e)
        {
            // Check if VLX-DB exists, if not, attempt to create it
            if (!File.Exists(VLXLib.ConfigFileName))
                if (!VLXLib.CreateDBFile()) throw new VLXException("Could not initialize VLX-Database. Please try again later or contact your system administrator");

            // Load categories and existing timestamps
            categories = VLXLib.LoadVLXData();

            if (categories == null) throw new VLXException("Could not load VLX-Database. Please try again later or contact your system administrator");


            // Create category-controls
            UpdateControls(categories);

            // Update total timestamps
            UpdateTotalTimespans();

            // Initialize sql
            sql = new WrapSQLite(VLXLib.ConfigFileName);
        }


        private void UpdateControls(List<VLXCategory> pCategories)
        {
            int topOffset = 0;
            int labelExtraOffset = 6;
            int rowHeight = 38;
            int blankContentHeight = 120;
            int minWindowHeight = 220;
            int maxWindowHeight = 800;

            int verticalOffset = -5;

            // Remove every control before adding new ones
            pnlContentPanel.Controls.Clear();


            if (pCategories.Count > 0)
            {
                int i = 0;
                foreach (VLXCategory category in pCategories)
                {
                    // Category Label
                    pnlContentPanel.Controls.Add(new Label()
                    {
                        Name = "lblCategory" + category.ID,
                        Text = category.Name,
                        Location = new Point(0 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(206, 21),
                        TextAlign = ContentAlignment.TopRight,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });;

                    // Current Session Label
                    pnlContentPanel.Controls.Add(new Label()
                    {
                        Name = "lblCurrentSession" + category.ID,
                        Text = "00:00:00",
                        Location = new Point(328 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(106, 21),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });

                    // Total Time Label
                    pnlContentPanel.Controls.Add(new Label()
                    {
                        Name = "lblTotalTime" + category.ID,
                        Text = "00:00:00",
                        Location = new Point(480 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(163, 21),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });

                    // Status Picturebox
                    pnlContentPanel.Controls.Add(new PictureBox()
                    {
                        Name = "pbxStatusIndicator" + category.ID,
                        Location = new Point(293 + verticalOffset, topOffset + i * rowHeight + 1),
                        Size = new Size(14, 30),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = (category.SessionActive ? Color.Lime : Color.Red)
                    });

                    // Start/Stop Button
                    Button startStopButton = new Button()
                    {
                        Name = "btnStartStop" + category.ID,
                        Text = (category.SessionActive ? "Stop" : "Start"),
                        Tag = category,
                        Location = new Point(212 + verticalOffset, topOffset + i * rowHeight),
                        Size = new Size(83, 32),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = Color.Gainsboro,
                    };
                    startStopButton.Click += StartStopButton_Click;
                    pnlContentPanel.Controls.Add(startStopButton);

                    // Evaluation Button
                    Button evaluationButton = new Button()
                    {
                        Name = "btnEvaluation" + category.ID,
                        Text = "...",
                        Tag = category,
                        Location = new Point(649 + verticalOffset, topOffset + i * rowHeight),
                        Size = new Size(36, 32),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = Color.Gainsboro
                    };
                    evaluationButton.Click += EvaluationButton_Click;
                    pnlContentPanel.Controls.Add(evaluationButton);

                    i++;
                }

                this.ClientSize = new Size(this.ClientSize.Width, Math.Min(Math.Max(blankContentHeight + i * rowHeight, minWindowHeight), maxWindowHeight));
            }
            else
            {
                this.ClientSize = new Size(this.ClientSize.Width, 300);

                // No-Categories Label
                pnlContentPanel.Controls.Add(new Label()
                {
                    Name = "lblNoCategory",
                    Font = new Font("Leelawadee UI Semilight", 18),
                    Text = "No categories to display.",
                    Location = new Point(3, 15),
                    AutoSize = false,
                    Size = new Size(679, 36),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left
                });

                // Add-Category Button
                Button addCategoryButton = new Button()
                {
                    Name = "btnAddCategoryNotExist",
                    Text = "Click here to create a new category!",
                    Location = new Point(265, 60),
                    Size = new Size(158, 61),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    BackColor = Color.Gainsboro
                };
                addCategoryButton.Click += btnManageCategories_Click;
                pnlContentPanel.Controls.Add(addCategoryButton);
            }
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            VLXCategory category = ((sender as Button).Tag as VLXCategory);

            if (!category.SessionActive)
            {
                // Update indicator-color
                (pnlContentPanel.Controls.Find("pbxStatusIndicator" + category.ID, false)[0] as PictureBox).BackColor = Color.Lime;

                // Update button-title
                (pnlContentPanel.Controls.Find("btnStartStop" + category.ID, false)[0] as Button).Text = "Stop";

                category.StartSession();
            }
            else
            {
                // Update indicator-color
                (pnlContentPanel.Controls.Find("pbxStatusIndicator" + category.ID, false)[0] as PictureBox).BackColor = Color.Red;

                // Update button-title
                (pnlContentPanel.Controls.Find("btnStartStop" + category.ID, false)[0] as Button).Text = "Start";

                category.StopSession();
                if (!category.SaveLastSession(sql)) throw new VLXException("Could not save last session.");

                UpdateTotalTimespans();
            }

        }

        private void EvaluationButton_Click(object sender, EventArgs e)
        {
            VLXCategory category = ((sender as Button).Tag as VLXCategory);

            OpenQuickEvalWindow(category);
        }


        private void OpenQuickEvalWindow(VLXCategory pCategory)
        {
            VLXQuickEval quickEval = new VLXQuickEval()
            {
                Category = pCategory,
                CustomRangeStart = customStartDate,
                CustomRangeEnd = customEndDate
            };
            DialogResult res = quickEval.ShowDialog();

            // Dialog result is yes, if the user wants to add a session manually
            if (res == DialogResult.Yes)
            {
                VLXManualAddSession addSession = new VLXManualAddSession()
                {
                    Categories = categories,
                    PreselectedCategory = pCategory,
                    Sql = sql
                };

                DialogResult addSessRes = addSession.ShowDialog();

                if (addSessRes == DialogResult.OK)
                    UpdateTotalTimespans();
                
                if (addSessRes == DialogResult.Abort || addSessRes == DialogResult.OK)
                    OpenQuickEvalWindow(pCategory);
            }
        }


        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            VLXCategoryManager manager = new VLXCategoryManager()
            {
                Sql = sql,
                Categories = categories
            };

            manager.ShowDialog();
         
            UpdateControls(categories);
            UpdateTotalTimespans();
        }

        private void btnDetailedEvaluation_Click(object sender, EventArgs e)
        {
            ShowPrereleaseWarning();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ShowPrereleaseWarning();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ShowPrereleaseWarning();
        }

        private void tmrUpdateSessions_Tick(object sender, EventArgs e)
        {
            foreach (VLXCategory category in categories)
            {
                // Try-Catch required, because timers still try to update when adding a new category in the manager
                try
                {
                    // Update indicator-color
                    (pnlContentPanel.Controls.Find("lblCurrentSession" + category.ID, false)[0] as Label).Text = category.CurrentSessionTime.ToString(@"hh\:mm\:ss\:ff"); ;
                }
                catch { }
            }
        }

        private void UpdateTotalTimespans()
        {
            if (categories != null)
            {
                foreach (VLXCategory category in categories)
                {
                    if (cbxTotalTimespan.SelectedIndex != (int)TimeSelection.CustomRange)
                    {
                        TimeSpan ts = category.TotalTimeFromSelection((TimeSelection)cbxTotalTimespan.SelectedIndex);
                        // Update total selected timespan
                        (pnlContentPanel.Controls.Find("lblTotalTime" + category.ID, false)[0] as Label).Text = string.Format("{0:00}:{1:00}:{2:00}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
                    }
                    else
                    {
                        TimeSpan ts = category.TotalTimeFromSpan(customStartDate, customEndDate);
                        // Update total selected timespan
                        (pnlContentPanel.Controls.Find("lblTotalTime" + category.ID, false)[0] as Label).Text = string.Format("{0:00}:{1:00}:{2:00}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
                    }
                }
            }
        }

        private void cbxTotalTimespan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTotalTimespan.SelectedIndex == (int)TimeSelection.CustomRange) 
            {
                VLXDateRangePicker datePicker = new VLXDateRangePicker()
                {
                    StartDate = customStartDate,
                    EndDate = customEndDate
                };


                if(datePicker.ShowDialog() == DialogResult.OK)
                {
                    customStartDate = datePicker.StartDate;
                    customEndDate = datePicker.EndDate;
                }
                else
                {
                    cbxTotalTimespan.SelectedIndex = (int)TimeSelection.Total;
                }
            }

            UpdateTotalTimespans();
        }

        private void ShowPrereleaseWarning()
        {
            MessageBox.Show("This feature has not been added in the current pre-release of Velox.\r\nVisit https://endev.at/p/velox for updates.", "Velox Pre-Release", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
