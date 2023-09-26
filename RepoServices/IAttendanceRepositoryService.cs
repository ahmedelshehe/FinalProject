using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IAttendanceRepositoryService
    {

        public List<Attendance> GetAttendances();
        public Attendance GetAttendance(Attendance attendance);
        public void InsertAttendance(Attendance attendance);
        public void UpdateAttendance( Attendance attendance);
        public void DeleteAttendance(Attendance attendance);
        public bool AttendanceExists(int id, DateTime date);
    }
}
