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
                        categories.Add(new VLXCategory(Convert.ToInt32(reader[VLXDB.Category.ID])) { 
                            Name = Convert.ToString(reader[VLXDB.Category.Name]),
                            Description = Convert.ToString(reader[VLXDB.Category.Description])
                        });
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
    }
}
