using FinalProject.Models;
using FinalProject.ViewModels;
using FinalProject.ViewModels.FinalProject.Models;
using System.Data;

namespace FinalProject.RepoServices
{
    public interface IAttendanceRepositoryService
    {

        public List<Attendance> GetAttendances();
        public List<Attendance> SearchAtendance();
        public Attendance GetAttendance(int id, DateTime Date);
        public void InsertAttendance(Attendance attendance);
        public void UpdateAttendance( Attendance attendance);
        public void DeleteAttendance(Attendance attendance);
        public bool AttendanceExists(int id, DateTime date);
        public string insertBulk(List<Attendance> attendancesList);
        public  Task<List<EmployeeAttendanceVM>> GetEmployeeAttendancesByName(string name);
        public  Task<List<EmployeeAttendanceVM>> GetEmployeeAttendancesByDeptName(string Deptname);
        public DataTable ReadUploadedFile(IFormFile postedFile);
        public DataTable ReadExcel(IFormFile file);
        public List<Attendance> convertDataTableToListAttendance(DataTable dt);
        public List<AttendanceStatus> InsertAttendanceList(List<Attendance> attendancesList);
        public List<AttendanceStatus> InsertBulkAttendanceAndUpdateIFExist(List<Attendance> attendancesList);
        public FileStream InsertDataInfileAndDownloadIt(List<AttendanceStatus> attendanceStatuses);

    }
}
