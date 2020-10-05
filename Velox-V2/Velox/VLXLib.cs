using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WrapSQL;

namespace Velox
{
    static class VLXLib
    {
        public static string ConfigFileName { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Endev", "Velox", "vlxdata.db");

        public static string GlobalErrorReport { get; set; } = "";

        public static void SetFormStyle(SfForm form)
        {
            form.Style.Border = new Pen(Color.FromKnownColor(KnownColor.Bisque), 2);
            form.Style.InactiveBorder = new Pen(Color.FromKnownColor(KnownColor.Linen), 2);
        }

        public static bool CreateDBFile()
        {
            bool success = true;

            try
            {
                using (WrapSQLite sql = new WrapSQLite(ConfigFileName))
                {
                    sql.Open();

                    sql.TransactionBegin();

                    try
                    {
                        // Creating table "categories"
                        sql.ExecuteNonQuery($@"CREATE TABLE '{VLXDB.Category.Self}' ('{VLXDB.Category.ID}' INTEGER, '{VLXDB.Category.Name}' TEXT, '{VLXDB.Category.Description}' TEXT,PRIMARY KEY('{VLXDB.Category.ID}' AUTOINCREMENT));");

                        // Creating table "timestamps"
                        sql.ExecuteNonQuery($@"CREATE TABLE '{VLXDB.Timestamps.Self}' ('{VLXDB.Timestamps.ID}' INTEGER, '{VLXDB.Timestamps.CategoryID}' INTEGER, '{VLXDB.Timestamps.StartTime}' TEXT, '{VLXDB.Timestamps.EndTime}' TEXT, PRIMARY KEY('{VLXDB.Timestamps.ID}' AUTOINCREMENT));");

                        sql.TransactionCommit();
                    }
                    catch(Exception ex)
                    {
                        GlobalErrorReport = ex.Message;
                        success = false;
                        sql.TransactionRollback();
                    }

                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                GlobalErrorReport = ex.Message;
                success = false;
            }

            return success;
        }
        public static List<VLXCategory> LoadVLXData() => FillVLXTimestamps(LoadVLXCategories());

        public static List<VLXCategory> LoadVLXCategories()
        {
            try
            {
                using (WrapSQLite sql = new WrapSQLite(ConfigFileName))
                {
                    List<VLXCategory> categories = new List<VLXCategory>();

                    sql.Open();

                    using (SQLiteDataReader reader = (SQLiteDataReader)sql.ExecuteQuery($"SELECT * FROM {VLXDB.Category.Self}"))
                    {
                        while (reader.Read())
                        {
                            categories.Add(new VLXCategory(Convert.ToInt32(reader[VLXDB.Category.ID]))
                            {
                                Name = Convert.ToString(reader[VLXDB.Category.Name]),
                                Description = Convert.ToString(reader[VLXDB.Category.Description])
                            });
                        }
                    }

                    sql.Close();

                    return categories;
                }
            }
            catch (Exception ex)
            {
                GlobalErrorReport = ex.Message;
                return null;
            }
        }

        public static List<VLXCategory> FillVLXTimestamps(List<VLXCategory> pUnfilledCategoryList)
        {
            try
            { 
                if(pUnfilledCategoryList != null)
                {
                    using (WrapSQLite sql = new WrapSQLite(ConfigFileName))
                    {
                        sql.Open();

                        for (int i = 0; i < pUnfilledCategoryList.Count; i++)
                        {
                            using (SQLiteDataReader reader = (SQLiteDataReader)sql.ExecuteQuery($"SELECT * FROM {VLXDB.Timestamps.Self} WHERE {VLXDB.Timestamps.CategoryID} = ?", pUnfilledCategoryList[i].ID))
                            {
                                while(reader.Read())
                                {
                                    pUnfilledCategoryList[i].Timestamps.Add(new VLXTimestamp
                                    {
                                        StartTime = Convert.ToDateTime(reader[VLXDB.Timestamps.StartTime]),
                                        EndTime = Convert.ToDateTime(reader[VLXDB.Timestamps.EndTime])
                                    });
                                }
                            }
                        }

                        sql.Close();
                    }

                    return pUnfilledCategoryList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                GlobalErrorReport = ex.Message;
                return null;
            }
        }

        public static void UpdateControls(SfForm pForm, Control pParentControl, List<VLXCategory> pCategories)
        {
            int topOffset = 0;
            int labelExtraOffset = 6;
            int rowHeight = 38;
            int blankContentHeight = 120;
            int minWindowHeight = 220;
            int maxWindowHeight = 800;

            int verticalOffset = -5;

            if (pCategories.Count > 0)
            {
                int i = 0;
                foreach (VLXCategory category in pCategories)
                {
                    // Category Label
                    pParentControl.Controls.Add(new Label()
                    {
                        Text = category.Name,
                        Location = new Point(0 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(206, 21),
                        TextAlign = ContentAlignment.TopRight,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });

                    // Current Session Label
                    pParentControl.Controls.Add(new Label()
                    {
                        Text = "00:00:00",
                        Location = new Point(328 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(106, 21),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });

                    // Total Time Label
                    pParentControl.Controls.Add(new Label()
                    {
                        Text = "00:00:00",
                        Location = new Point(480 + verticalOffset, topOffset + i * rowHeight + labelExtraOffset),
                        AutoSize = false,
                        Size = new Size(163, 21),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                    });

                    // Status Picturebox
                    pParentControl.Controls.Add(new PictureBox()
                    {
                        Location = new Point(293 + verticalOffset, topOffset + i * rowHeight + 1),
                        Size = new Size(14, 30),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = Color.Red
                    });

                    // Start/Stop Button
                    pParentControl.Controls.Add(new Button()
                    {
                        Text = "Start",
                        Location = new Point(212 + verticalOffset, topOffset + i * rowHeight),
                        Size = new Size(83, 32),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = Color.Gainsboro
                    });

                    // Evaluation Button
                    pParentControl.Controls.Add(new Button()
                    {
                        Text = "...",
                        Location = new Point(649 + verticalOffset, topOffset + i * rowHeight),
                        Size = new Size(36, 32),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BackColor = Color.Gainsboro
                    });

                    i++;
                }

                pForm.ClientSize = new Size(pForm.ClientSize.Width, Math.Min(Math.Max(blankContentHeight + i * rowHeight, minWindowHeight), maxWindowHeight));
            }
            else
            {
                pForm.ClientSize = new Size(pForm.ClientSize.Width, 300);

                // No-Categories Label
                pParentControl.Controls.Add(new Label()
                {
                    Font = new Font("Leelawadee UI Semilight", 18),
                    Text = "No categories to display.",
                    Location = new Point(3, 15),
                    AutoSize = false,
                    Size = new Size(679, 36),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left
                });

                // Add-Category Button
                pParentControl.Controls.Add(new Button()
                {
                    Text = "Click here to create a new category!",
                    Location = new Point(265, 60),
                    Size = new Size(158, 61),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    BackColor = Color.Gainsboro
                });
            }
        }
    }
}
