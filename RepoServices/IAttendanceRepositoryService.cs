using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IAttendanceRepositoryService
    {

        public List<Attendance> GetAttendances();
        public Attendance GetAttendance(int id, DateTime Date);
        public void InsertAttendance(Attendance attendance);
        public void UpdateAttendance( Attendance attendance);
        public void DeleteAttendance(Attendance attendance);
        public bool AttendanceExists(int id, DateTime date);
    }
}
