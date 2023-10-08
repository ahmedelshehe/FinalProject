using FinalProject.Models;
using System.ComponentModel;

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
	}
}
