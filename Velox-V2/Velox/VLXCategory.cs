using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using Syncfusion.Windows.Forms.Tools.Win32API;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapSQL;

namespace Velox
{
    public enum TimeSelection
    {
        // Note: Enum-Values are bound to combobox-index
        Today = 0,
        Yesterday = 1,
        ThisWeek = 2,
        LastWeek = 3,
        ThisMonth = 4,
        LastMonth = 5,
        Total = 6,

        // Not for selection!
        CustomRange = 7
    }

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

        public TimeSpan TotalTimeFromSelection(TimeSelection pSelection)
        {
            DateTime DTN = DateTime.Now;
            DateTime DTLM = DateTime.Now.AddMonths(-1);
            DateTime DTLW = DateTime.Now.AddDays(-7);

            switch (pSelection)
            {
                case TimeSelection.Today:
                    return TotalTimeFromSpan(
                        new DateTime(DTN.Year, DTN.Month, DTN.Day, 0, 0, 0), 
                        new DateTime(DTN.Year, DTN.Month, DTN.Day, 23, 59, 59)
                    );
                case TimeSelection.Yesterday:
                    return TotalTimeFromSpan(
                        new DateTime(DTN.Year, DTN.Month, DTN.Day, 0, 0, 0).AddDays(-1),
                        new DateTime(DTN.Year, DTN.Month, DTN.Day, 23, 59, 59).AddDays(-1)
                    );
                case TimeSelection.ThisWeek:
                    return TotalTimeFromIsoWeek(DTN.Year, GetIso8601WeekOfYear(DTN));
                case TimeSelection.LastWeek:
                    return TotalTimeFromIsoWeek(DTLW.Year, GetIso8601WeekOfYear(DTLW));
                case TimeSelection.ThisMonth:
                    return TotalTimeFromSpan(
                        new DateTime(DTN.Year, DTN.Month, 1, 0, 0, 0),
                        new DateTime(DTN.Year, DTN.Month, DateTime.DaysInMonth(DTN.Year, DTN.Month), 23, 59, 59)
                    );
                case TimeSelection.LastMonth:
                    return TotalTimeFromSpan(
                        new DateTime(DTLM.Year, DTLM.Month, 1, 0, 0, 0),
                        new DateTime(DTLM.Year, DTLM.Month, DateTime.DaysInMonth(DTLM.Year, DTLM.Month), 23, 59, 59)
                    );
                default:
                    return TotalTime;
            }
        }

        public TimeSpan TotalTimeFromSpan(DateTime pSelectionStart, DateTime pSelectionEnd)
        {
            TimeSpan cummulated = TimeSpan.Zero;

            foreach(VLXTimestamp ts in Timestamps)
                if (ts.StartTime.Ticks > pSelectionStart.Ticks && ts.EndTime.Ticks < pSelectionEnd.Ticks) cummulated += ts.TimeSpan;
            
            return cummulated;
        }

        public TimeSpan TotalTimeFromIsoWeek(int year, int week)
        {
            DateTime firstDayOfWeek = FirstDateOfWeekISO8601(year, week);
            return TotalTimeFromSpan(firstDayOfWeek, firstDayOfWeek.AddDays(7));
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


        private int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) time = time.AddDays(3);
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;

            if (firstWeek == 1) weekNum -= 1;

            var result = firstThursday.AddDays(weekNum * 7);

            return result.AddDays(-3);
        }
    }
}
