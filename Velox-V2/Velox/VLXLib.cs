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

        public static void SetFormStyle(SfForm form)
        {
            form.Style.Border = new Pen(Color.FromKnownColor(KnownColor.Bisque), 2);
            form.Style.InactiveBorder = new Pen(Color.FromKnownColor(KnownColor.Linen), 2);

            form.Style.ShadowOpacity = 50;
            form.Style.InactiveShadowOpacity = 30;

            form.Style.TitleBar.BackColor = Color.FromKnownColor(KnownColor.Bisque);
            form.Style.TitleBar.BottomBorderColor = Color.FromKnownColor(KnownColor.Bisque);

            form.Icon = Properties.Resources.VeloxIcon;
            form.IconSize = new Size(32, 32);
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
                        sql.ExecuteNonQuery($@"CREATE TABLE '{VLXDB.Category.Self}' ('{VLXDB.Category.ID}' TEXT, '{VLXDB.Category.Name}' TEXT, '{VLXDB.Category.Description}' TEXT,PRIMARY KEY('{VLXDB.Category.ID}'));");

                        // Creating table "timestamps"
                        sql.ExecuteNonQuery($@"CREATE TABLE '{VLXDB.Timestamps.Self}' ('{VLXDB.Timestamps.ID}' INTEGER, '{VLXDB.Timestamps.CategoryID}' TEXT, '{VLXDB.Timestamps.StartTime}' TEXT, '{VLXDB.Timestamps.EndTime}' TEXT, PRIMARY KEY('{VLXDB.Timestamps.ID}' AUTOINCREMENT));");

                        sql.TransactionCommit();
                    }
                    catch(Exception ex)
                    {
                        VLXException.GlobalErrorReport = ex.Message;
                        success = false;
                        sql.TransactionRollback();
                    }

                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                VLXException.GlobalErrorReport = ex.Message;
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
                            categories.Add(new VLXCategory(new Guid(Convert.ToString(reader[VLXDB.Category.ID])))
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
                VLXException.GlobalErrorReport = ex.Message;
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
                VLXException.GlobalErrorReport = ex.Message;
                return null;
            }
        }
    }
}
