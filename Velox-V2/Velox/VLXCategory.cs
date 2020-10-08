using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapSQL;

namespace Velox
{
    class VLXCategory
    {
        public int ID { get; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<VLXTimestamp> Timestamps { get; set; } = new List<VLXTimestamp>();

        public bool SessionActive { get; private set; }
        public TimeSpan CurrentSessionTime
        {
            get
            {
                if (sessionStartTime != DateTime.MinValue) return DateTime.Now - sessionStartTime;
                else return TimeSpan.Zero;
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                TimeSpan tsTotal = TimeSpan.Zero;
                foreach (VLXTimestamp ts in Timestamps)
                    tsTotal = tsTotal.Add(ts.TimeSpan);
                return tsTotal;
            }
        }
        
        private DateTime sessionStartTime = DateTime.MinValue;
        private DateTime sessionEndTime = DateTime.MinValue;
        

        public VLXCategory(int ID)
        {
            this.ID = ID;
        }

        public void StartSession()
        {
            SessionActive = true;

            sessionStartTime = DateTime.Now;
        }

        public void StopSession()
        {
            SessionActive = false;

            sessionEndTime = DateTime.Now;
        }

        public bool SaveLastSession(WrapSQLite sql)
        {
            bool success = true;

            if(!SessionActive)
            {
                
                try
                {
                    sql.Open();

                    sql.ExecuteNonQuery($"INSERT INTO {VLXDB.Timestamps.Self} ({VLXDB.Timestamps.CategoryID},{VLXDB.Timestamps.StartTime},{VLXDB.Timestamps.EndTime}) VALUES (?,?,?)",
                        ID,
                        sessionStartTime,
                        sessionEndTime
                    );

                    sql.Close();
                }
                catch(Exception ex)
                {
                    VLXException.GlobalErrorReport = ex.Message;
                    success = false;
                }

                Timestamps.Add(new VLXTimestamp() { 
                    StartTime = sessionStartTime,
                    EndTime = sessionEndTime
                });

                sessionStartTime = DateTime.MinValue;
                sessionEndTime = DateTime.MinValue;
            }

            return success;
        }
    }
}
