namespace FinalProject.ViewModels
{
    public class SalaryViewModel
    {
        public int empId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public decimal TotalSalary { get; set; }
        public double Salary { get; set; }
        public long ExtraHours { get; set; }
        public decimal ExtraHoursPrice { get; set; }
        public long DiscountHours { get; set; }
        public decimal DisccountHoursPrice { get; set; }
        public int NumberOfAbsanceDays { get; set; }
        public int NumberOfAttandanceDays { get; set; }

    }
}
