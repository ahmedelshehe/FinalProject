using FinalProject.Data;
using FinalProject.Helper;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Web.Mvc;

namespace FinalProject.RepoServices
{
    public class SalaryService : ISalaryService
    {
        private ApplicationDbContext db;
        private readonly IOfficialVacationRepository officialVacationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWeeklyHolidayRepository weeklyHolidayRepository;
        private readonly IVacationRepository vacationRepository;
        private readonly IGeneralSettingRepository generalSettingRepository;

      
     
        public SalaryService(ApplicationDbContext _db, IGeneralSettingRepository generalSettingRepository, IVacationRepository vacationRepository, IWeeklyHolidayRepository weeklyHolidayRepository, IEmployeeRepository employeeRepository, IOfficialVacationRepository officialVacationRepository)
        {
            db = _db;
            this.officialVacationRepository = officialVacationRepository;
            this.employeeRepository = employeeRepository;
            this.weeklyHolidayRepository = weeklyHolidayRepository;
            this.vacationRepository = vacationRepository;
            this.generalSettingRepository = generalSettingRepository;
        }
       
        public int calcWeeklyHolidayPerMonth(int year, int month)
        {
            int numberOfDays = 0;
          if(month != -1)
            {
                List<WeeklyHoliday> WeeklyHolidays = weeklyHolidayRepository.GetAllHolidays();
                foreach (var Day in WeeklyHolidays)
                {
                    numberOfDays += HelperShared.Get_Count_Month_Days(month, year, HelperShared.convertStringToDayOfWeek(Day.Holiday));
                }
            }
                
            return numberOfDays;
        }
        public int calcWeeklyHolidayPerYear(int year)
        {
            int numberOfDays = 0;
            List<WeeklyHoliday> WeeklyHolidays = weeklyHolidayRepository.GetAllHolidays();
            foreach (var Day in WeeklyHolidays)
            {
                numberOfDays += HelperShared.Get_Count_Year_Days(year, HelperShared.convertStringToDayOfWeek(Day.Holiday));
            }
            return numberOfDays;
        }
        public int calcOfficialPerMonth(int year, int month)
        {
            var  numOffVacations = officialVacationRepository.GetOfficialVacations().
                Where(d => d.Date.Year == year && d.Date.Month == month).Count();
            return numOffVacations;
        }
        public int calcOfficialPerYear(int year)
        {
           var numOffVacations = officialVacationRepository.GetOfficialVacations().Where(d => d.Date.Year == year).Count();
            return numOffVacations;
        }
        public (List<SalaryViewModel> result, string alertMessage) getDataPerMonth(int Year, int Month)
        {
            var currentyear = Year;
            var currentmonth = Month;
            string alertMessage = null;
            List<SalaryViewModel> list = new List<SalaryViewModel>();
            var listOfDepartment = db.Departments.Include(w => w.Employees).ToList();
            foreach (var dept in listOfDepartment)
            {
                foreach (var emp in dept.Employees)
                {
                    var empOfViewModel = new SalaryViewModel();
                    int numberOfVacations = 0;
                    int absanceDayPerYear = 0;
                    int absanceDayPerMonth = 0;
                    int weeklyHolidayPerYear = 0;
                    int weeklyHolidayPerMonth = 0;
                    int atttendanceDay = 0;
                    double discountHourPrice = 0;
                    double ExtraHourPrice = 0;
                    double discountHoursPercentage = 0;
                    double ExtraHoursPercentage = 0;
                    var discountHors = 0;
                    var extraHors = 0;
                    double SalaryPerDay = emp.Salary / 30;

                    DateTime? hireDate = emp.ContractDate;
                    if (currentyear < hireDate.Value.Year)
                    {
                       // alertMessage = "Please Select a Year After Hire Date.";
                        continue;
                        //return (list, alertMessage);
                    }
                    if (currentyear == DateTime.Now.Year)
                    {
                        if (currentmonth >= DateTime.Now.Month)
                        {
                            alertMessage = "Please Select a Month Before Current Month.";
                            continue;
                            //return (list, alertMessage);
                        }
                    }

                    var annVacations = vacationRepository.GetVacationById(emp.Id).
                        Where(w => w.StartDate.Year == currentyear && w.EndDate.Year == currentyear &&
                          w.StartDate.Month == currentmonth && w.EndDate.Month == currentmonth);
                    foreach (var vac in annVacations)
                    {
                        numberOfVacations += vacationRepository.GetVacationDays(emp.Id, vac.StartDate);
                    }
                    var attandance = db.Attendances.Where(w => w.EmployeeId == emp.Id).ToList();
                    attandance = attandance.Where(w => w.Date.Month == currentmonth && w.Date.Year == currentyear).ToList();
                    atttendanceDay = attandance.Where(w => w.IsAbsent == false).ToList().Count;

                    var officialDay = calcOfficialPerMonth(currentyear, currentmonth);

                    weeklyHolidayPerMonth = calcWeeklyHolidayPerMonth(currentyear, currentmonth);
                    absanceDayPerMonth = DateTime.DaysInMonth(currentyear, currentmonth) -
                        (atttendanceDay + weeklyHolidayPerMonth + officialDay);

                    discountHoursPercentage = generalSettingRepository.DiscountTimePricePerHour();
                    ExtraHoursPercentage = generalSettingRepository.OverTimePricePerHour();
                    discountHourPrice = (discountHoursPercentage / 100) * emp.Salary;
                    ExtraHourPrice = (ExtraHoursPercentage / 100) * emp.Salary;
                    discountHors= attandance.Sum(w => w.DiscountHours);
                    extraHors= attandance.Sum(w => w.ExtraHours);
                    empOfViewModel.empId = emp.Id;
                    empOfViewModel.NumberOfAbsanceDays = absanceDayPerMonth;
                    empOfViewModel.Salary = emp.Salary;
                    empOfViewModel.DepartmentName = dept.Name;
                    empOfViewModel.EmployeeName = emp.FirstName + ' ' + emp.LastName;
                    empOfViewModel.DiscountHours = discountHors;
                    empOfViewModel.ExtraHours = extraHors;
                    empOfViewModel.NumberOfAttandanceDays = atttendanceDay;
                    empOfViewModel.DisccountHoursPrice = (decimal)(discountHourPrice * discountHors);
                    empOfViewModel.ExtraHoursPrice = (decimal)(ExtraHourPrice * extraHors);
                    empOfViewModel.TotalSalary =(decimal)( emp.Salary - (discountHourPrice* discountHors) - (absanceDayPerMonth * SalaryPerDay) +( ExtraHourPrice* extraHors));


                    list.Add(empOfViewModel);
                }
            }
            return (list, alertMessage);

        }
        //public (List<SalaryViewModel> result, string alertMessage) getDataPerYearByEmployee(int Year ,int empId )
        //{
        //    var currentyear = Year;
        //    string alertMessage = null;
        //    List<SalaryViewModel> list = new List<SalaryViewModel>();
        //    var listOfDepartment = db.Departments.Include(w => w.Employees).ToList();
          
        //            var empOfViewModel = new SalaryViewModel();
        //            int numberOfVacations = 0;
        //            int absanceDayPerYear = 0;
        //            int weeklyHolidayPerYear = 0;
        //            int atttendanceDay = 0;
        //            double discountHourPrice = 0;
        //            double ExtraHourPrice = 0;
        //            double discountHoursPercentage = 0;
        //            double ExtraHoursPercentage = 0;
        //            var discountHors = 0;
        //            var extraHors = 0;
        //    var employee = employeeRepository.GetEmployee(empId);
        //            double SalaryPerDay = employee.Salary / 30;

        //            DateTime? hireDate = employee.ContractDate;
        //            if (currentyear < hireDate.Value.Year)
        //            {
        //                alertMessage = "Please Select a Year After Hire Date.";
                
        //                return (list, alertMessage);
        //            }
        //            if (currentyear == DateTime.Now.Year)
        //            {
        //                 alertMessage = "Please Select a Year Before Current Year.";

        //                return (list, alertMessage);
        //            }

        //            var annVacations = vacationRepository.GetVacationById(empId).
        //                  Where(w => w.StartDate.Year == currentyear && w.EndDate.Year == currentyear);
        //            foreach (var vac in annVacations)
        //            {
        //                numberOfVacations += vacationRepository.GetVacationDays(empId, vac.StartDate);

        //            }
        //            var attandance = db.Attendances.Where(w => w.EmployeeId == empId).ToList();
        //            attandance = attandance.Where(w => w.Date.Year == currentyear).ToList();
        //            atttendanceDay = attandance.Where(w => w.IsAbsent == false).ToList().Count;

        //            var officialDay = calcOfficialPerYear(currentyear);
        //            weeklyHolidayPerYear = calcWeeklyHolidayPerYear(currentyear);
        //            DateTime date = new DateTime(currentyear);
        //            absanceDayPerYear = HelperShared.GetDaysInYear(date) - (atttendanceDay + weeklyHolidayPerYear + officialDay);
        //            discountHoursPercentage = generalSettingRepository.DiscountTimePricePerHour();
        //            ExtraHoursPercentage = generalSettingRepository.OverTimePricePerHour();
        //            discountHourPrice = (discountHoursPercentage / 100) * employee.Salary;
        //            ExtraHourPrice = (ExtraHoursPercentage / 100) * employee.Salary;
        //            discountHors = attandance.Sum(w => w.DiscountHours);
        //            extraHors = attandance.Sum(w => w.ExtraHours);
        //            empOfViewModel.empId = empId;
        //            empOfViewModel.DepartmentName = employee.Department.Name;
        //            empOfViewModel.EmployeeName = employee.FirstName + ' ' + employee.LastName;
        //            empOfViewModel.Salary = employee.Salary;
        //            empOfViewModel.DiscountHours = discountHors;
        //            empOfViewModel.ExtraHours = extraHors;
        //            empOfViewModel.NumberOfAttandanceDays = atttendanceDay;
        //            empOfViewModel.NumberOfAbsanceDays = absanceDayPerYear;
        //            empOfViewModel.DisccountHoursPrice = discountHourPrice * discountHors;
        //            empOfViewModel.ExtraHoursPrice = ExtraHourPrice * extraHors;
        //            empOfViewModel.TotalSalary = (decimal)((employee.Salary * 12) - (discountHourPrice * discountHors) - (absanceDayPerYear * SalaryPerDay) + (ExtraHourPrice * extraHors));

        //            list.Add(empOfViewModel);
                
            
        //    return (list, alertMessage);
        //}

        public (List<SalaryViewModel> result, string alertMessage) getDataPerYear(int Year )
        {
            var currentyear = Year;
            string alertMessage = null;
            List<SalaryViewModel> list = new List<SalaryViewModel>();
            var listOfDepartment = db.Departments.Include(w => w.Employees).ToList();
            foreach (var dept in listOfDepartment)
            {
                foreach (var emp in dept.Employees)
                {
                    var empOfViewModel = new SalaryViewModel();
                    int numberOfVacations = 0;
                    int absanceDayPerYear = 0;
                    int weeklyHolidayPerYear = 0;
                    int atttendanceDay = 0;
                    double discountHourPrice = 0;
                    double ExtraHourPrice = 0;
                    double discountHoursPercentage = 0;
                    double ExtraHoursPercentage = 0;
                    var discountHors = 0;
                    var extraHors = 0;
                    double SalaryPerDay = emp.Salary / 30;

                    DateTime? hireDate = emp.ContractDate;
                    if (currentyear < hireDate.Value.Year)
                    {
                       // alertMessage = "Please Select a Year After Hire Date.";
                        continue;
                        //return (list, alertMessage);
                    }
                    if (currentyear == DateTime.Now.Year)
                    {
                       // alertMessage = "Please Select a Year Before Current Year.";
                        continue;

                        //return (list, alertMessage);
                    }

                    var annVacations = vacationRepository.GetVacationById(emp.Id).
                          Where(w => w.StartDate.Year == currentyear && w.EndDate.Year == currentyear);
                    foreach (var vac in annVacations)
                    {
                        numberOfVacations += vacationRepository.GetVacationDays(emp.Id, vac.StartDate);

                    }
                    var attandance = db.Attendances.Where(w => w.EmployeeId == emp.Id).ToList();
                    attandance = attandance.Where(w => w.Date.Year == currentyear).ToList();
                    atttendanceDay = attandance.Where(w => w.IsAbsent == false).ToList().Count;

                    var officialDay = calcOfficialPerYear(currentyear);
                    weeklyHolidayPerYear = calcWeeklyHolidayPerYear(currentyear);
                    DateTime date = new DateTime(currentyear);
                    absanceDayPerYear = HelperShared.GetDaysInYear(date) - (atttendanceDay + weeklyHolidayPerYear + officialDay);
                    discountHoursPercentage = generalSettingRepository.DiscountTimePricePerHour();
                    ExtraHoursPercentage = generalSettingRepository.OverTimePricePerHour();
                    discountHourPrice = (discountHoursPercentage / 100) * emp.Salary;
                    ExtraHourPrice = (ExtraHoursPercentage / 100) * emp.Salary;
                    discountHors = attandance.Sum(w => w.DiscountHours);
                    extraHors = attandance.Sum(w => w.ExtraHours);
                    empOfViewModel.empId = emp.Id;
                    empOfViewModel.DepartmentName = dept.Name;
                    empOfViewModel.EmployeeName = emp.FirstName + ' ' + emp.LastName;
                    empOfViewModel.Salary = emp.Salary;
                    empOfViewModel.DiscountHours = discountHors;
                    empOfViewModel.ExtraHours = extraHors;
                    empOfViewModel.NumberOfAttandanceDays = atttendanceDay;
                    empOfViewModel.NumberOfAbsanceDays = absanceDayPerYear;
                    empOfViewModel.DisccountHoursPrice =(decimal)( discountHourPrice * discountHors);
                    empOfViewModel.ExtraHoursPrice =(decimal)( ExtraHourPrice * extraHors);
                    empOfViewModel.TotalSalary =(decimal)( (emp.Salary * 12) - (discountHourPrice * discountHors) - (absanceDayPerYear * SalaryPerDay) + (ExtraHourPrice* extraHors));

                    list.Add(empOfViewModel);
                }
            }
            return (list, alertMessage);

        }

       
    }
}