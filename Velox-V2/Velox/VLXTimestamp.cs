using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapSQL;

namespace Velox
{
    public class VLXTimestamp
    {
        public string ID;
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public TimeSpan TimeSpan 
        {
            get => EndTime - StartTime;
        }

        public VLXTimestamp()
        {
            ID = Guid.NewGuid().ToString();
        }

        public void Delete(WrapSQLite sql)
        {
            sql.Open();
            sql.ExecuteNonQuery($"DELETE FROM {VLXDB.Timestamps.Self} WHERE {VLXDB.Timestamps.ID} = ?", ID);
            sql.Close();
        }
    }
}
