using FinalProject.Models;
using FinalProject.Helper;
using FinalProject.RepoServices;
using Newtonsoft.Json;
namespace FinalProject.ViewModels
{
	public class EmployeeDashboardVM
	{
		private readonly IVacationRepository vacationRepository;
		private readonly List<OfficialVacation> _officialVacations;
		DateTime FirstDayOfMonth => new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		DateTime LastDayOfMonth => FirstDayOfMonth.AddMonths(1).AddDays(-1);
		DateTime LastMonth => new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
		public EmployeeDashboardVM(List<Attendance> attendances, Employee employee, IVacationRepository VactionRepository, List<OfficialVacation> officialVacations)
		{
			EmployeeAttendances = attendances;
			Employee = employee;
			vacationRepository = VactionRepository;
			_officialVacations = officialVacations;
		}

		public List<Attendance> EmployeeAttendances { get; }
		public Employee Employee { get; }

		public string ChartLabels
		{
			get
			{
				var attendaces = EmployeeAttendances.Where(a => a.Date.Month == DateTime.Now.AddMonths(-1).Month).OrderBy(a => a.Date).Select(a => a.Date.ToString("d MMM")).ToList();
				return JsonConvert.SerializeObject(attendaces);
			}
		}
		public string ChartValues
		{
			get
			{
				List<int> values = new List<int>();
				var attendances = EmployeeAttendances.Where(a => a.Date.Month == DateTime.Now.AddMonths(-1).Month).OrderBy(a => a.Date).ToList();
				foreach (var attendance in attendances)
				{
					int hours = (int)(attendance.DepartureTime - attendance.ArrivalTime).TotalHours;
					values.Add(hours);
				}
				return JsonConvert.SerializeObject(values);
			}
		}

		public List<Vacation> Vacations
		{
			get
			{
				return vacationRepository.GetVacations().Where(v => v.EmployeeId == Employee.Id).Take(4).OrderBy(v => v.StartDate).ToList();
			}
		}
		public int ThisMonthAttendanceCount
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date >= FirstDayOfMonth && a.Date <= DateTime.Now && !a.IsAbsent).Count();
			}
		}
		public int ThisMonthWorkDaysUntilToday
		{
			get
			{
				return HelperShared.GetWorkDaysThisMonth();
			}
		}
		public int ThisMonthWorkDays
		{
			get
			{
				return HelperShared.GetWorkDays(DateTime.Today);
			}
		}
		public int LastMonthAttendanceCount
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date.Month == LastMonth.Month).Count();
			}
		}
		public int LastMonthWorkDays
		{
			get
			{
				return HelperShared.GetWorkDaysLastMonth();
			}
		}

		public int ThisMonthExtraHours
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date >= FirstDayOfMonth && a.Date <= DateTime.Now && !a.IsAbsent).Sum(e => e.ExtraHours);
			}
		}

		public int ThisMonthDiscountHours
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date >= FirstDayOfMonth && a.Date <= DateTime.Now && !a.IsAbsent).Sum(e => e.DiscountHours);
			}
		}
		public int LastMonthExtraHours
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date.Month == LastMonth.Month).Sum(e => e.ExtraHours);
			}
		}

		public int LastMonthDiscountHours
		{
			get
			{
				return EmployeeAttendances.Where(a => a.Date.Month == LastMonth.Month).Sum(e => e.DiscountHours);

			}
		}

		public bool IsYesterdayWork
		{
			get
			{
				return vacationRepository.IsVacation(Employee.Id, DateTime.Today.AddDays(-1));
			}
		}
		public bool IsTodayWork
		{
			get
			{
				return vacationRepository.IsVacation(Employee.Id, DateTime.Today);
			}
		}
		public bool IsTommorowWork { get { return vacationRepository.IsVacation(Employee.Id, DateTime.Today.AddDays(1)); } }

		public bool IsYesterdayOfficialVacation
		{
			get
			{
				return _officialVacations.Any(o => o.Date == DateTime.Today.Date.AddDays(-1));
			}
		}
		public bool IsTodayOfficialVacation
		{
			get
			{
				return _officialVacations.Any(o => o.Date == DateTime.Today.Date);
			}
		}
		public bool IsTommorowOfficialVacation
		{
			get { return _officialVacations.Any(o => o.Date == DateTime.Today.Date.AddDays(1)); }
		}
	}
}
