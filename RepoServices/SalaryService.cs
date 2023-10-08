using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class SalaryService : ISalaryService
    {
        private ApplicationDbContext db;
        private readonly IOfficialVacationRepository officialVacationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWeeklyHolidayRepository weeklyHolidayRepository;
        private readonly IVacationRepository vacationRepository;

        public SalaryService(ApplicationDbContext _db, IVacationRepository vacationRepository, IWeeklyHolidayRepository weeklyHolidayRepository, IEmployeeRepository employeeRepository, IOfficialVacationRepository officialVacationRepository)
        {
            db = _db;
            this.officialVacationRepository = officialVacationRepository;
            this.employeeRepository = employeeRepository;
            this.weeklyHolidayRepository = weeklyHolidayRepository;
            this.vacationRepository = vacationRepository;
        }
        public (List<SalaryViewModel> result, string alertMessage) GetData(int? Year, int? Month)
        {

            var currentyear = Year;
            var currentmonth = Month;
            var officialVacation = 0;
            //  var annualVacation = 0;
            string alertMessage = null;

            var OffVacations = officialVacationRepository.GetOfficialVacations();
            foreach (var item in OffVacations)
            {
                if (currentmonth == null)
                {
                    for (var i = 0; i < 12; i++)
                    {
                        if (currentyear == Convert.ToDateTime(item.Date).Year)
                        {
                            if (i + 1 == Convert.ToDateTime(item.Date).Month)
                                officialVacation++;
                        }
                    }
                }
                else
                {
                    if (currentmonth == Convert.ToDateTime(item.Date).Month &&
                        currentyear == Convert.ToDateTime(item.Date).Year)
                        officialVacation++;
                }


            }

            int WeeklyAndOffHolidaysPerMonth = (weeklyHolidayRepository.GetAllHolidays().Select(x => x.Holiday).Count()) * 4 + (officialVacation);
            int WeeklyAndOffHolidaysPerYear = (weeklyHolidayRepository.GetAllHolidays().Select(x => x.Holiday).Count()) * 4 * 12 + (officialVacation);

            List<SalaryViewModel> list = new List<SalaryViewModel>();
            if (currentyear == null)
            {
                alertMessage = "";
                return (list, alertMessage);
            }
            var li = db.Departments.Include(w => w.Employees).ToList();
            foreach (var ob in li)
            {

                foreach (var emp in ob.Employees)
                {

                    //var annVacations = vacationRepository.GetVacationByEmployee(emp.Id);
                    //foreach (var item in annVacations)
                    //{

                    //    if(item.StartDate.Value.Year == currentyear)
                    //    {
                    //        while (item.StartDate <= item.EndDate)
                    //        {
                    //            if (item.Status == VacationStatus.Approved)
                    //            {
                    //                if(annualVacation<21)
                    //                {
                    //                    annualVacation++;

                    //                }

                    //            }
                    //            item.StartDate.Value.AddDays(1);

                    //        }

                    //    }

                    //}





                    SalaryViewModel o = new SalaryViewModel();

                    //var employee = employeeRepository.GetEmployee(emp.Id);

                    DateTime? hireDate = emp.ContractDate;

                    if (currentyear != null && currentyear < hireDate.Value.Year)
                    {
                        alertMessage = "Please Select a Year After Hire Date.";
                        return (list, alertMessage);

                    }
                    if (currentyear == DateTime.Now.Year)
                    {
                        if (currentmonth == null)
                        {
                            alertMessage = "Please Select a Year Before Current Year.";
                            return (list, alertMessage);
                        }
                        else
                        {
                            if (currentmonth >= DateTime.Now.Month)
                            {
                                alertMessage = "Please Select a Month Before Current Month.";
                                return (list, alertMessage);
                            }
                        }
                    }



                    o.DepartmentName = ob.Name;
                    o.EmployeeName = emp.FirstName + ' ' + emp.LastName;
                    double SalaryPerDay = emp.Salary / 30;
                    var Attandance = db.Attendances.Where(w => w.EmployeeId == emp.Id).ToList();
                    if (currentyear != null)
                    {
                        Attandance = Attandance.Where(w => w.Date.Year == currentyear).ToList();
                    }
                    if (currentmonth != null)
                    {
                        Attandance = Attandance.Where(w => w.Date.Month == currentmonth).ToList();
                    }
                    //o.NumberOfAttandanceDays = Attandance.Where(w => w.IsAbsent == false).ToList().Count;
                    //o.NumberOfAbsanceDays = Attandance.Where(w => w.IsAbsent == true).ToList().Count;

                    var AttendanceDay = Attandance.Where(w => w.IsAbsent == false).ToList().Count;
                    var absanceDayPerYear = 0;
                    var AbsanceDayPerMonth = 0;
                    //if (annualVacation > 21)
                    //{
                    //     absanceDayPerYear = 365 - (WeeklyAndOffHolidaysPerYear + AttendanceDay);
                    //     AbsanceDayPerMonth = 30 - (WeeklyAndOffHolidaysPerMonth + AttendanceDay);

                    //}
                    //else
                    //{
                    absanceDayPerYear = 365 - (WeeklyAndOffHolidaysPerYear + AttendanceDay);//-annualVacation;
                    AbsanceDayPerMonth = 30 - (WeeklyAndOffHolidaysPerMonth + AttendanceDay);// -annualVacation;

                    //}

                    if (currentyear != null)
                    {
                        o.NumberOfAbsanceDays = absanceDayPerYear;

                    }
                    if (currentmonth != null)
                    {
                        o.NumberOfAbsanceDays = AbsanceDayPerMonth;
                    }

                    o.NumberOfAttandanceDays = AttendanceDay;
                    o.DiscountHours = Attandance.Sum(w => w.DiscountHours);
                    o.ExtraHours = Attandance.Sum(w => w.ExtraHours);
                    o.Salary = emp.Salary;

                    var setting = db.GeneralSetting.Where(w => w.Id == 1).FirstOrDefault();
                    o.DisccountHoursPrice = setting.DiscountHourPrice * o.DiscountHours;
                    o.ExtraHoursPrice = setting.ExtraHourPrice * o.ExtraHours;
                    if (currentmonth != null)
                    {
                        o.TotalSalary = emp.Salary - o.DisccountHoursPrice + o.ExtraHoursPrice - (AbsanceDayPerMonth * SalaryPerDay);
                    }
                    else if (currentyear != null)
                    {
                        o.TotalSalary = (emp.Salary * 12) - o.DisccountHoursPrice + o.ExtraHoursPrice - (absanceDayPerYear * SalaryPerDay);
                    }
                    o.empId = emp.Id;
                    list.Add(o);
                }
            }
            return (list, alertMessage);
        }
    }
}