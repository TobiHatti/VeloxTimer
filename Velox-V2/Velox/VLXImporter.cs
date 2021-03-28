using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WrapSQL;

namespace Velox
{
    public partial class VLXImporter : Form
    {
        public VLXImporter()
        {
            InitializeComponent();
            this.Hide();
        }

        private void VLXImporter_Load(object sender, EventArgs e)
        {
            if(ofdVeloxImport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open file
                    using (WrapSQLite sql = new WrapSQLite(ofdVeloxImport.FileName))
                    {
                        // Validate
                        sql.Open();
                        sql.ExecuteScalar($"SELECT {VLXDB.Timestamps.CategoryID} FROM {VLXDB.Timestamps.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Timestamps.StartTime} FROM {VLXDB.Timestamps.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Timestamps.EndTime} FROM {VLXDB.Timestamps.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Timestamps.ID} FROM {VLXDB.Timestamps.Self}");

                        sql.ExecuteScalar($"SELECT {VLXDB.Category.Color} FROM {VLXDB.Category.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Category.Description} FROM {VLXDB.Category.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Category.Name} FROM {VLXDB.Category.Self}");
                        sql.ExecuteScalar($"SELECT {VLXDB.Category.ID} FROM {VLXDB.Category.Self}");
                        sql.Close();
                    }

                    // Import
                    File.Copy(ofdVeloxImport.FileName, VLXLib.ConfigFileName, true);

                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    this.DialogResult = DialogResult.Abort;
                }

                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }

            this.Close();
        }
    }
}
