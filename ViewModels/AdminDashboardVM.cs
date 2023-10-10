using FinalProject.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FinalProject.ViewModels
{
    public class AdminDashboardVM
    {
         List<string> colors = new List<string>() {
            "rgb(255, 99, 132)",
            "rgb(54, 162, 235)",
            "rgb(255, 205, 86)",
            "rgb(75, 192, 192)",
            "rgb(153, 102, 255)",
            "rgb(255, 159, 64)",
            "rgb(255, 0, 0)",
            "rgb(0, 255, 0)",
            "rgb(0, 0, 255)",
            "rgb(128, 128, 128)"
        };

        public Employee adminEmployee;
        private readonly List<Vacation> vacations;
        private readonly List<Employee> employees;
        private readonly List<Department> departments;
        private readonly List<Attendance> thisMonthAttendances;
        private readonly List<Attendance> lastMonthAttendances;
        private readonly List<OfficialVacation> officialVacations;
        public AdminDashboardVM(Employee AdminEmployee, List<Employee> Employees,
            List<Department> Departments,List<Vacation> Vacations,List<Attendance> ThisMonthAttendances,
            List<Attendance> LastMonthAttendances,List<OfficialVacation> OfficialVacations
            )
        {
            adminEmployee = AdminEmployee;
            vacations = Vacations;
            employees = Employees;
            departments = Departments;
            thisMonthAttendances = ThisMonthAttendances;
            lastMonthAttendances = LastMonthAttendances;
            officialVacations = OfficialVacations;

        }

        public int EmployeesCount { get { 
             return employees.Count;
            } }
        public double EmployeesAgeAverage
        {
            get
            {
                return employees != null ? Math.Round(employees.Average(e => e.Age), 1) : 0;
            }
        }
        public string DepartmentNames { get
            {
                var departmentsNames = departments.OrderBy(d => d.Id).Select(e => e.Name).ToList();
                return JsonConvert.SerializeObject(departmentsNames);
            } }
        public List<Employee> LatestContractedEmployees { 
            get { return employees.OrderByDescending(o=>o.ContractDate.Date).Take(4).ToList(); }
        }
        public string DepartmentEmployeesCount
        {
            get
            {
                List<int> result = new List<int>();
                foreach (Department department in departments.OrderBy(d => d.Id))
                {
                    result.Add(department.Employees.Count());
                }
            return JsonConvert.SerializeObject(result);
            }
        }
        public int DepartmentsCount
        { get {
                return departments.Count();
            }
        }
        public string BiggestDepartment { get
            {
                return departments.OrderByDescending(d => d.Employees.Count()).Take(1).Select(d => d.Name).First();
            } }
        public string DeptChartColors { get
            {
                var count = departments.Count;
                var chosenColors = colors.Take(count).ToList();
                return JsonConvert.SerializeObject(chosenColors);
            }
        }

        public int ThisMonthExtraHours => thisMonthAttendances.Count != 0  ? thisMonthAttendances.Sum(e => e.ExtraHours) : 0;
        public int LastMonthExtraHours =>  lastMonthAttendances.Count != 0 ? lastMonthAttendances.Sum(e => e.ExtraHours) : 0;
        public int ThisMonthDiscountHours =>thisMonthAttendances.Count != 0 ? thisMonthAttendances.Sum(e => e.DiscountHours) : 0;
        public int LastMonthDiscountHours => lastMonthAttendances.Count != 0 ? lastMonthAttendances.Sum(e => e.DiscountHours) : 0;
        public double ThisMonthAverageHours => thisMonthAttendances.Count != 0  ? Math.Round(thisMonthAttendances.Average(e => (e.DepartureTime - e.ArrivalTime).TotalHours), 2) : 0;
        public double LastMonthAverageHours => lastMonthAttendances.Count != 0 ? Math.Round(lastMonthAttendances.Average(e => (e.DepartureTime - e.ArrivalTime).TotalHours), 2) : 0;
        public int AcceptedVacations => vacations.Where(v =>v.Status == VacationStatus.Approved).Count();
        public int PendingVacations => vacations.Where(v =>v.Status == VacationStatus.Pending).Count();

        public int OfficialVactionsCount => officialVacations.Where(o => o.Date.Month == DateTime.Now.Month).Count();
    }
}
