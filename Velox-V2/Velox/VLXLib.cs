using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
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
        public static string ConfigFileName { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Endev", "Velox", "timestamps.db");

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
                        sql.ExecuteNonQuery(@"CREATE TABLE 'categories' ('ID' INTEGER,'CategoryName' TEXT,'CategoryDescription' TEXT,PRIMARY KEY('ID' AUTOINCREMENT));");

                        // Creating table "timestamps"
                        sql.ExecuteNonQuery("@CREATE TABLE 'timestamps' ('ID' INTEGER, 'CategoryID' INTEGER, 'StartTime' TEXT, 'EndTime' TEXT, PRIMARY KEY('ID' AUTOINCREMENT));");

                        sql.TransactionCommit();
                    }
                    catch
                    {
                        success = false;
                        sql.TransactionRollback();
                    }

                    sql.Close();
                }
            }
            catch
            {
                success = false;
            }

            return success;
        }
    }


}
