using FinalProject.Models;
using FinalProject.RepoServices;
using System.ComponentModel;
using System.Globalization;
using System.Web.Mvc;

namespace FinalProject.Helper
{
    public static class HelperShared
    {

        public static async Task <string>  SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
            
            return path;
        }
        public static FileStream DownloadFile(string fileName, string path)
        {

            //string path = @"\\192.168.2.116\Share\Basant\Reports\";
            var file = Path.Combine(Path.Combine(path), fileName);
            return new FileStream(file, FileMode.Open, FileAccess.Read);
        }
        public static FileStream writeStatusInsertInCsvFileAndReturnFile<T>(List<T> list, string dirPath)
        {
            string fileName = "Report" + new Guid() + ".csv";
            string saveToPath = Path.Combine(dirPath, fileName);

            SaveToCsv(list, saveToPath);

            var file = DownloadFile(fileName, dirPath);
            return file;

        }

        public static FileStream DownloadFileAllType(string fileName)
        {
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory + "\\src\\assets";
            var file = Path.Combine(Path.Combine(currentDirectory, "attachments"), fileName);
            return new FileStream(file, FileMode.Open, FileAccess.Read);
        }

        //Helper Method Gets The Number Of Work Days In a specific month
		public static int GetWorkDays(DateTime date)
		{
			int days = DateTime.DaysInMonth(date.Year, date.Month);
			int workDays = 0;
			for (int i = 1; i <= days; i++)
			{
				DateTime day = new DateTime(date.Year, date.Month, i);
				if (day.DayOfWeek != DayOfWeek.Friday && day.DayOfWeek != DayOfWeek.Saturday)
				{
					workDays++;
				}
			}
			return workDays;
		}
		//Helper Method Gets The Number Of Work Days Between Two Days
		public static int GetWorkDays(DateTime startDate, DateTime endDate)
		{
			int days = (int)(endDate - startDate).TotalDays + 1;
			int workDays = 0;
			for (int i = 0; i < days; i++)
			{
				DateTime day = startDate.AddDays(i);
				if (day.DayOfWeek != DayOfWeek.Friday && day.DayOfWeek != DayOfWeek.Saturday)
				{
					workDays++;
				}
			}
			return workDays;
		}
		public static int GetWorkDays(DateTime startDate, DateTime endDate,
			List<string> weeklyHolidays,List<DateTime> OfficialVacations )
		{
			int days = (int)(endDate - startDate).TotalDays + 1;
			int workDays = 0;
			for (int i = 0; i < days; i++)
			{
				DateTime day = startDate.AddDays(i);
				if (!(weeklyHolidays.Contains(day.DayOfWeek.ToString()) || OfficialVacations.Any(o => o.Date == day.Date)))
				{
					workDays += 1;
				}
			}
			return workDays;
		}
		public static int GetWorkDaysLastMonth()
		{
			DateTime today = DateTime.Today;
			DateTime firstDayOfLastMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
			DateTime lastDayOfLastMonth = firstDayOfLastMonth.AddMonths(1).AddDays(-1);
			int workDays = 0;
			for (DateTime date = firstDayOfLastMonth; date <= lastDayOfLastMonth; date = date.AddDays(1))
			{
				if (date.DayOfWeek != DayOfWeek.Friday && date.DayOfWeek != DayOfWeek.Saturday)
				{
					workDays++;
				}
			}
			return workDays;
		}
		public static int GetWorkDaysThisMonth()
		{
			DateTime today = DateTime.Today;
			DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);
			int workDays = 0;
			for (DateTime date = firstDayOfThisMonth; date <= today; date = date.AddDays(1))
			{
				if (date.DayOfWeek != DayOfWeek.Friday && date.DayOfWeek != DayOfWeek.Saturday)
				{
					workDays++;
				}
			}
			return workDays;
		}


       
        public static int Get_Count_Month_Days(int month, int year, DayOfWeek dayName)
        {
            int numOfDays = 0;
            int daysOfMonth = DateTime.DaysInMonth(year, month); // 30 /28 /31

            for (int i = 1; i <= daysOfMonth; i++)
            {
                if (new DateTime(year, month, i).DayOfWeek == dayName)
                {
                    numOfDays++;
                }
            }
            return numOfDays;
        }
        public static int Get_Count_Year_Days(int year, DayOfWeek dayName)
        {
            int numOfDays = 0;
            for (int i = 1; i <= 12; i++)
            {
                numOfDays += Get_Count_Month_Days(i, year, dayName);
            }
            return numOfDays;
        }
        public static DayOfWeek convertStringToDayOfWeek(string Day)
        {
            DayOfWeek dayName = DayOfWeek.Saturday;
            switch (Day)
            {
                case "Saturday":
                    dayName = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    dayName = DayOfWeek.Sunday;
                    break;
                case "Monday":
                    dayName = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    dayName = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    dayName = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    dayName = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    dayName = DayOfWeek.Friday;
                    break;
            }
            return dayName;
        }


        public static int GetDaysInYear(DateTime date)
        {
            if (date.Equals(DateTime.MinValue))
            {
                return -1;
            }

            DateTime thisYear = new DateTime(date.Year, 1, 1);
            DateTime nextYear = new DateTime(date.Year + 1, 1, 1);

            return (nextYear - thisYear).Days;
        }
     
            public static IEnumerable<SelectListItem> Months
            {
                get
                {
                    return DateTimeFormatInfo
                           .InvariantInfo
                           .MonthNames
                           .Select((monthName, index) => new SelectListItem
                           {
                               Value = (index + 1).ToString(),
                               Text = monthName
                           });
                }
            }
        
    }
}
