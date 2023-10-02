using FinalProject.Data;
using FinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class SalaryService : ISalaryService
    {
        private ApplicationDbContext db;
        public SalaryService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public List<SalaryViewModel> GetData(int? Year, int? Month)
        {
            var currentyear = Year;
            var currentmonth = Month;
            List<SalaryViewModel> list = new List<SalaryViewModel>();
            var li = db.Departments.Include(w => w.Employees).ToList();
            foreach (var ob in li)
            {
                SalaryViewModel o = new SalaryViewModel();
                o.DepartmentName = ob.Name;
                foreach (var emp in ob.Employees)
                {
                    o.EmployeeName = emp.FirstName + ' ' + emp.LastName;
                    var Attandance = db.Attendances.Where(w => w.EmployeeId == emp.Id).ToList();
                    if (currentyear != null)
                    {
                        Attandance = Attandance.Where(w => w.Date.Year == currentyear).ToList();
                    }
                    if (currentmonth != null)
                    {
                        Attandance = Attandance.Where(w => w.Date.Month == currentmonth).ToList();
                    }
                    o.NumberOfAttandanceDays = Attandance.Where(w => w.IsAbsent == false).ToList().Count;
                    o.NumberOfAbsanceDays = Attandance.Where(w => w.IsAbsent == true).ToList().Count;
                    o.DiscountHours = Attandance.Sum(w => w.DiscountHours);
                    o.ExtraHours = Attandance.Sum(w => w.ExtraHours);
                    o.Salary = emp.Salary;
                    var setting = db.GeneralSetting.Where(w => w.Id == 1).FirstOrDefault();
                    o.DisccountHoursPrice = setting.DiscountHourPrice * o.DiscountHours;
                    o.ExtraHoursPrice = setting.ExtraHourPrice * o.ExtraHours;
                    if (currentmonth != null)
                    {
                        o.TotalSalary = emp.Salary - o.DisccountHoursPrice + o.ExtraHoursPrice;
                    }
                    else if (currentyear != null)
                    {
                        o.TotalSalary = (emp.Salary * 12) - o.DisccountHoursPrice + o.ExtraHoursPrice;
                    }
                    o.empId = emp.Id;
                    list.Add(o);
                }
            }
            return list;
        }
    }
}