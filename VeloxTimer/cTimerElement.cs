using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public enum CumulateRange
    {
        Today,
        Yesterday,
        ThisWeek,
        LastWeek,
        ThisMonth,
        LastMonth,
        Total
    }

    public class TimerElement
    {
        public string CategoryName { get; set; } = "";
        public bool IsRunning { get; set; } = false;
        public DateTime SessionStartTime { get; set; } = DateTime.MinValue;
        public DateTime SessionStopTime { get; set; } = DateTime.MinValue;

        private static bool alertShown = false;

        public static string LogFile { get; set; } = @"Logs\TaskTimerLog.csv";

        public TimerElement(string pCategoryName)
        {
            CategoryName = pCategoryName;
        }

        public void SaveLogEntry()
        {
            try
            {
                if (!File.Exists(LogFile))
                {
                    if (!string.IsNullOrEmpty(Path.GetDirectoryName(LogFile))) Directory.CreateDirectory(Path.GetDirectoryName(LogFile));

                    StreamWriter sri = new StreamWriter(LogFile);
                    sri.WriteLine("Category;SessionStart;SessionStop;SessionDuration");
                    sri.Close();
                }

                StreamWriter sr = new StreamWriter(LogFile, true);
                sr.WriteLine($"{CategoryName};{SessionStartTime};{SessionStopTime};{SessionStopTime.Subtract(SessionStartTime)}");
                sr.Close();
            }
            catch(Exception)
            {
                MessageBox.Show($"Der Wert konnte nicht gespeichert werden, da die Datei \"{LogFile}\" nicht geladen werden konnte. Schließen Sie die Datei und versuchen Sie es erneut.", "Datei konnte nicht geladen werden", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }

        
        public TimeSpan GetCumulated(CumulateRange pCumulRange)
        {
            try
            {
                string line;
                TimeSpan cumulated = new TimeSpan(0,0,0,0);
                StreamReader sr = new StreamReader(LogFile);
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] lineSegments = line.Split(';');
                    string category = lineSegments[0];
                    DateTime startTime = DateTime.Parse(lineSegments[1]);
                    TimeSpan timeSpan = TimeSpan.Parse(lineSegments[3]);

                    switch (pCumulRange)
                    {
                        case CumulateRange.Today:
                            if (category == CategoryName
                                && startTime.Year == DateTime.Now.Year
                                && startTime.Month == DateTime.Now.Month
                                && startTime.Day == DateTime.Now.Day)
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.Yesterday:
                            if (category == CategoryName
                                && startTime.Year == DateTime.Now.Year
                                && startTime.Month == DateTime.Now.Month
                                && startTime.Day == DateTime.Now.AddDays(-1).Day)
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.ThisWeek:
                            if (category == CategoryName &&
                                GetIso8601WeekOfYear(startTime) == GetIso8601WeekOfYear(DateTime.Now))
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.LastWeek:
                            if (category == CategoryName &&
                                GetIso8601WeekOfYear(startTime) == GetIso8601WeekOfYear(DateTime.Now.AddDays(-7)))
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.ThisMonth:
                            if (category == CategoryName
                                && startTime.Year == DateTime.Now.Year
                                && startTime.Month == DateTime.Now.Month)
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.LastMonth:
                            if (category == CategoryName
                                && startTime.Year == DateTime.Now.Year
                                && startTime.Month == DateTime.Now.AddMonths(-1).Month)
                                cumulated = cumulated.Add(timeSpan);
                            break;
                        case CumulateRange.Total:
                            if(category == CategoryName)
                                cumulated = cumulated.Add(timeSpan);
                            break;
                    }
                }
                sr.Close();
                return cumulated;
            }
            catch (Exception)
            {
                if (!alertShown)
                    MessageBox.Show($"Die Datei \"{LogFile}\" konnte nicht geladen werden. Schließen Sie die Datei und versuchen Sie es erneut.", "Datei konnte nicht geladen werden", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

                alertShown = true;

                return TimeSpan.Zero;
            }
        }

        public List<Tuple<DateTime, DateTime, TimeSpan>> GetFullLog()
        {
            
            List<Tuple<DateTime, DateTime, TimeSpan>> logEntries = new List<Tuple<DateTime, DateTime, TimeSpan>>();

            try
            {
                string line;
                StreamReader sr = new StreamReader(LogFile);
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    
                    string[] lineSegments = line.Split(';');

                    if (lineSegments[0] != CategoryName) continue;

                    DateTime startTime = DateTime.Parse(lineSegments[1]);
                    DateTime endTime = DateTime.Parse(lineSegments[2]);
                    TimeSpan timeSpan = TimeSpan.Parse(lineSegments[3]);

                    logEntries.Add(new Tuple<DateTime, DateTime, TimeSpan>(startTime, endTime, timeSpan));
                }
                sr.Close();

                return logEntries;
            }
            catch (Exception)
            {
                if (!alertShown)
                    MessageBox.Show($"Die Datei \"{LogFile}\" konnte nicht geladen werden. Schließen Sie die Datei und versuchen Sie es erneut.", "Datei konnte nicht geladen werden", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

                alertShown = true;

                return null;
            }
        }

        private int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) time = time.AddDays(3);
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public void ResetSession()
        {
            SessionStartTime = DateTime.MinValue;
            SessionStopTime = DateTime.MinValue;
        }
    }
}
